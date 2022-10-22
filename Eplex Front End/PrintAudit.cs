using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace Eplex_Front_End
{
    public class PrintAudit
    {
        public string reportPathAndFileName;
        public EplexLockManagement.SiteFormShr SharedSiteData;
        public EplexLockManagement.UserFormShr SharedUserData;
        public EplexLockManagement.DoorFormShr SharedDoorData;
        public EplexLockManagement ParentForm;
        public UserAccessInfo[] Users;
        public List<LockSettings> Lock;

        public int totalCompleted = 55;
        public int totalToDo = 100;
        public Worksheet UserSht;
        public string[,] DoorParms;
        public string[,] ExcelRow = new string[10, 5];
        public Worksheet[] DoorSht;
        const int AuditDoorColumns = 5;
        public string reportPath;
        public int DoorEventsCompleted;
        public int DoorEventsToDo;
        public string catchData;


        public PrintAudit(string dataPathIn, EplexLockManagement.SiteFormShr SharedSiteDataIn, EplexLockManagement.UserFormShr SharedUserDataIn, EplexLockManagement.DoorFormShr SharedDoorDataIn, UserAccessInfo[] UsersIn, List<LockSettings> LockIn, EplexLockManagement ParentFormIn)
        {
            reportPath = dataPathIn;
            SharedSiteData = SharedSiteDataIn;
            SharedUserData = SharedUserDataIn;
            SharedDoorData = SharedDoorDataIn;
            Users = UsersIn;
            Lock = LockIn;
            ParentForm = ParentFormIn;
        }
        public void BuildAuditReport(object sender, DoWorkEventArgs e)
        {
            /***********************************************************************************************************************
            ** Build the audit report excel file
            ***********************************************************************************************************************/
            bool readOK = readEplexAuditFile();

            if (readOK != true) return;

            (ParentForm.DataPath, ParentForm.DataPath2020,  ParentForm.MUnitFolder, ParentForm.EplexAppPath) = ParentForm.GetRegistryInfo();

            string[] dateParts = ParentForm.AuditDoor[0].AuditExtractTimestamp.Split();
            //            string auditExtractYYYY = AuditDoor[0].AuditExtractTimestamp.Substring(AuditDoor[0].AuditExtractTimestamp.Length - 4 - 1);
            string auditExtractYYYY = dateParts[4];
            string auditExtractMMMLit = dateParts[1];
            string auditExtractDD = dateParts[2];
            string auditExtractMM = Convert.ToDateTime(auditExtractMMMLit + " 01, 1900").Month.ToString("00");

            string AuditDataPath = Path.Combine(reportPath + @"Sites\");
            AuditDataPath = Path.Combine(AuditDataPath, SharedSiteData.site);
            AuditDataPath = Path.Combine(AuditDataPath,@"Lock Audit");
            string auditFileName = auditExtractYYYY + "-" + auditExtractMM + "-" + auditExtractDD + " Audit Report.xlsx";
            ParentForm.AuditDataPathAndFile = Path.Combine(AuditDataPath , auditFileName);

            writeAuditFileToExcel(ParentForm.AuditDataPathAndFile);
        }
        private bool readEplexAuditFile()
        {
            /***********************************************************************************************************************
            ** Read the audit file into a List of structure which has a list of the door events
            ***********************************************************************************************************************/
            string auditFileName = "EPLEX5000_DOWNLOAD.txt";
            string MUnitPath = ParentForm.MUnitFolder + auditFileName;
            ParentForm.AuditDoor.Clear();
            bool StatusFlag = true;

            /***********************************************************************************************************************
            ** If the file exists, read it, else popup a arror dialog and quit
            ***********************************************************************************************************************/
            if (File.Exists(MUnitPath))
            {
                try
                {
                    StreamReader AuditFilePathAndFileName = new StreamReader(MUnitPath);
                    int doorNum = -1;

                    while (AuditFilePathAndFileName.Peek() > -1)
                    {
                        var AuditDataRecord = AuditFilePathAndFileName.ReadLine();
                        string[] DataIn = AuditDataRecord.Split("\t".ToCharArray());

                        if (DataIn.Length > 3)
                        {
                            /***********************************************************************************************************************
                            ** This is the door definition record
                            ***********************************************************************************************************************/
                            var tmpAuditDoor = new AuditDoorInfo();
                            int i = 0;
                            tmpAuditDoor.site = DataIn[i];
                            i++; tmpAuditDoor.DoorName = DataIn[i];
                            i++; tmpAuditDoor.DoorID = int.Parse(DataIn[i]);
                            i++; tmpAuditDoor.AuditExtractTimestamp = DataIn[i];
                            i++; tmpAuditDoor.DateTime2 = DataIn[i];
                            i++; tmpAuditDoor.SomeDecimalNum1 = DataIn[i];
                            i++; tmpAuditDoor.SomeDecimalNum2 = DataIn[i];
                            i++; tmpAuditDoor.UserTxnCount = int.Parse(DataIn[i]);
                            i++; tmpAuditDoor.SomeHexNumber1 = DataIn[i];
                            i++; tmpAuditDoor.DoorUserCountMaybe = DataIn[i];
                            i++; tmpAuditDoor.SomeNUmber2 = DataIn[i];
                            tmpAuditDoor.UserTxn = new List<AuditUserInfo>();
                            ParentForm.AuditDoor.Add(tmpAuditDoor);
                            doorNum++;
                        }
                        else
                        {
                            /***********************************************************************************************************************
                            ** This is the user transaction record (Lock events)
                            ***********************************************************************************************************************/
                            var tmpUserDoor = new AuditUserInfo();
                            int i = 0;
                            tmpUserDoor.txnDateTime = ConvertStringToDateTime(DataIn[i]);
                            i++; tmpUserDoor.Txn = DataIn[i];
                            i++; tmpUserDoor.userCode = Regex.Replace(DataIn[i], "[EF]", "0");
                            ParentForm.AuditDoor[doorNum].UserTxn.Add(tmpUserDoor);
                        }
                    }
                    AuditFilePathAndFileName.Close();
                }
                catch (Exception e1)
                {
                    catchData = "PrintAudit.readEplexAuditFile Name: " + MUnitPath + e1.Message;
                    DialogResult OKFlag = MessageBox.Show(catchData, "Unexpected Error", MessageBoxButtons.OK);


                }
            }
            else
            {
                StatusFlag = false;
                DialogResult OKFlag = MessageBox.Show("No audit file data was found. No files can be built. ", "Warning", MessageBoxButtons.OK);
            }

            return StatusFlag;
        }
        private DateTime ConvertStringToDateTime(string hexDateStrIn)
        /***********************************************************************************************************************
        ** Converts the hex date and time to a DateTime type
        ***********************************************************************************************************************/
        {
            int secondsAfterEpoch = Int32.Parse(hexDateStrIn, System.Globalization.NumberStyles.HexNumber);
            DateTime epoch = new DateTime(2000, 1, 1);
            return (epoch.AddSeconds(secondsAfterEpoch));

        }
        private void writeAuditFileToExcel(string dataPath2020)
        /***********************************************************************************************************************
        ** Write the audit information to an excel file
        ***********************************************************************************************************************/
        {
            int totalCompleted = 1;
            int totalToDo = ParentForm.AuditDoor.Count + 1;
            ParentForm.Invoke(new BuildAuditDoorChange(BuildAuditDoorOnChange), "Opening Excelclose", totalCompleted, totalToDo);
            ParentForm.Invoke(new BuildAuditEventsChange(BuildAuditEventsOnChange), "Waiting on Excel...", 0, 100);

            DoorSht = new Worksheet[ParentForm.AuditDoor.Count];
            int sheetNum = 1;
            Excel excel = new Excel(dataPath2020, sheetNum, ParentForm);

            /***********************************************************************************************************************
            ** Create and open the excel file. This is the longest task in the process
            ***********************************************************************************************************************/
            DoorSht[sheetNum - 1] = excel.Open(dataPath2020, sheetNum);
            int i = 0;
            excel.renameSheet(sheetNum, ParentForm.AuditDoor[i].DoorID.ToString("0000"));

            /***********************************************************************************************************************
            ** Process each door in the list
            ***********************************************************************************************************************/
            int doorNum = -1;
            for (i = 0; i < ParentForm.AuditDoor.Count; i++)
            {
                /***********************************************************************************************************************
                ** if the user clicked abort, this is where we leave.
                ***********************************************************************************************************************/
                if (ParentForm.AbortAuditReport)
                {
                    ParentForm.AbortAuditReport = false;
                    excel.Close(SaveChanges: false);
                    excel.Kill();
                    GC.Collect(); // Garbage Collect - Needed to make Excel quit in the background
                    GC.WaitForPendingFinalizers();
                    ParentForm.Invoke(new BuildAuditDoorChange(BuildAuditDoorOnChange), null, 100, 100);
                    ParentForm.Invoke(new BuildAuditEventsChange(BuildAuditEventsOnChange), null, 100, 100);
                    return;
                }
                ParentForm.Invoke(new BuildAuditDoorChange(BuildAuditDoorOnChange), "Processing door " + (i + 1).ToString() + " of " + ParentForm.AuditDoor.Count.ToString(), totalCompleted++, totalToDo);
                int r = 1;
                int c = 1;
                doorNum++;
                AuditExcelRow tmpExcelRow = new AuditExcelRow();
                /***********************************************************************************************************************
                ** The first time through, the worksheet was created by the excel.open above.
                ** Every other time, creat a new sheet for the door information.
                ***********************************************************************************************************************/
                if (i > 0)
                {
                    sheetNum++;
                    DoorSht[sheetNum - 1] = excel.newSheet(ParentForm.AuditDoor[i].DoorID.ToString("0000"), DoorSht[sheetNum - 2]);
                }
                /***********************************************************************************************************************
                ** Write the site and door name
                ** If the Site and door don't come in the audit file, look it up based on the user selection and the lock information list
                ***********************************************************************************************************************/
                if (ParentForm.AuditDoor[doorNum].site.ToUpper().Trim() == "SITE")
                {
                    excel.WriteCell(r, c, SharedSiteData.site);
                }
                else
                {
                    excel.WriteCell(r, c, ParentForm.AuditDoor[doorNum].site);
                }
                r++;
                if (ParentForm.AuditDoor[doorNum].DoorName.ToUpper().Trim() == "DOOR")
                {
                    string DoorByID;
                    int index = Lock.FindIndex(a => a.ID == ParentForm.AuditDoor[doorNum].DoorID.ToString("0000"));
                    if (index > -1)
                    {
                        DoorByID = SharedDoorData.LockListPtr[index].Name;
                    }
                    else
                    {
                        DoorByID = ParentForm.AuditDoor[doorNum].DoorName;
                    }
                    excel.WriteCell(r, c, DoorByID);
                }
                else
                {
                    excel.WriteCell(r, c, ParentForm.AuditDoor[doorNum].DoorName);
                }
                r = r + 2;
                /***********************************************************************************************************************
                ** Write the column headings and color the cells gray
                ***********************************************************************************************************************/
                var hdrStrt = (r: r, c: c);
                excel.WriteCell(r, c, "Date");
                c++; excel.WriteCell(r, c, "Time");
                c++; excel.WriteCell(r, c, "User");
                c++; excel.WriteCell(r, c, "Name");
                c++; excel.WriteCell(r, c, "Action");
                excel.GrayCell(hdrStrt.r, hdrStrt.c, r, c);
                r++;

                /***********************************************************************************************************************
                ** Put all the door event information in an array (will write the whole array to excel...speeeedddd)
                ***********************************************************************************************************************/
                ParentForm.AuditRows.Clear();
                DoorEventsCompleted = 0;
                DoorEventsToDo = ParentForm.AuditDoor[i].UserTxn.Count;
                ExcelRow = new string[ParentForm.AuditDoor[i].UserTxn.Count, AuditDoorColumns];
                int UpdateStatusBarEvery = ParentForm.AuditDoor[i].UserTxn.Count / 20;

                for (int j = 0; j < ParentForm.AuditDoor[i].UserTxn.Count; j++)
                {
                    c = 0;
                    ExcelRow[j, c] = ParentForm.AuditDoor[doorNum].UserTxn[j].txnDateTime.ToString("MM/dd/yyyy");
                    c++; ExcelRow[j, c] = ParentForm.AuditDoor[doorNum].UserTxn[j].txnDateTime.ToString("h:m:ss tt", System.Globalization.CultureInfo.InvariantCulture);
                    c++;
                    /***********************************************************************************************************************
                    ** If the code is zero, there is ne way to identify a user
                    ***********************************************************************************************************************/
                    if (int.Parse(ParentForm.AuditDoor[doorNum].UserTxn[j].userCode) == 0)
                    {
                        ExcelRow[j, c] = "N/A";
                    }
                    else
                    {
                        ExcelRow[j, c] = ParentForm.AuditDoor[doorNum].UserTxn[j].userCode;
                    }
                    c++;
                    /***********************************************************************************************************************
                    ** TryGetValue is at least 10 times faster than a Try/Catch clause
                    ***********************************************************************************************************************/
                    string HoldUsrNm = "";
                    ParentForm.UserDictionary.TryGetValue(int.Parse(ParentForm.AuditDoor[doorNum].UserTxn[j].userCode), out HoldUsrNm);
                    if (HoldUsrNm == null)
                    {
                        ExcelRow[j, c] = "N/A";
                    }
                    else
                    {
                        ExcelRow[j, c] = HoldUsrNm;
                    }
                    c++; ExcelRow[j, c] = ParentForm.AuditDoor[doorNum].UserTxn[j].Txn;
                    /***********************************************************************************************************************
                    ** Update the progress bar every x records - let the user know something good is happening
                    ***********************************************************************************************************************/
                    int UpdateStatusBar = j % UpdateStatusBarEvery;
                    if (UpdateStatusBar == 0)
                    {
                        DoorEventsCompleted = DoorEventsCompleted + UpdateStatusBarEvery;

                        ParentForm.Invoke(new BuildAuditEventsChange(BuildAuditEventsOnChange), "Processing door event " + j.ToString() + " of " + ParentForm.AuditDoor[i].UserTxn.Count.ToString(), DoorEventsCompleted, DoorEventsToDo);
                    }
                }
                /***********************************************************************************************************************
                ** Write the whole array to excel, add borders and adjust the column width
                ***********************************************************************************************************************/
                c = 1;
                excel.WriteArray(r, c, ExcelRow);
                // Add borfers. r-1 includes the header row
                excel.Borders(r - 1, c, r + ExcelRow.GetLength(0) - 1, c + ExcelRow.GetLength(1) - 1);
                // Autofit the columns
                excel.ColumnWidth(FromCol: 1, ToCol: AuditDoorColumns, Width: 0);
                r += ParentForm.AuditDoor[i].UserTxn.Count;
                excel.RowToRepeatAtTop(1, 3);
                excel.FitToPage(1);
                excel.PageNumbers();

            }
            /***********************************************************************************************************************
            ** Save the file, make Excel visible to the user, wrap up the progress dialog.
            ***********************************************************************************************************************/
            excel.Activate(DoorSht[0]);
            excel.SaveAS();
            //excel.Visible(true);
            excel.Close(SaveChanges: false);
            excel.Kill();
            GC.Collect(); // Garbage Collect - Needed to make Excel quit in the background
            GC.WaitForPendingFinalizers();
            ParentForm.Invoke(new BuildAuditEventsChange(BuildAuditEventsOnChange), "Starting Excel on Audit Report File", DoorEventsToDo - 5, DoorEventsToDo);
            Process.Start(dataPath2020);

            System.Threading.Thread.Sleep(4000);
            ParentForm.Invoke(new BuildAuditDoorChange(BuildAuditDoorOnChange), null, 100, 100);
            ParentForm.Invoke(new BuildAuditEventsChange(BuildAuditEventsOnChange), null, 100, 100);


        }
        /***********************************************************************************************************************
        ** this code updates the status while a background thread processes the events
        ***********************************************************************************************************************/
        public delegate void BuildAuditEventsChange(string status, int complete, int total);
        public void BuildAuditEventsOnChange(string status, int complete, int total)
        {
            if (status == null)
            {
                ParentForm.AuditBuildGroupBox.Visible = false;
                ParentForm.AuditUserProgressBar.Visible = false;
                ParentForm.AuditDoorUserStatus.Visible = false;
                ParentForm.AuditDoorUserStatus.Text = status;
                ParentForm.AuditUserProgressBar.Value = 0;
            }
            else
            {
                ParentForm.AuditBuildGroupBox.Visible = true;
                ParentForm.AuditUserProgressBar.Visible = true;
                ParentForm.AuditDoorUserStatus.Visible = true;
                ParentForm.AuditUserProgressBar.Minimum = 0;
                if (complete > total)
                {
                    complete = total - 1;
                }
                ParentForm.AuditUserProgressBar.Maximum = total;
                ParentForm.AuditUserProgressBar.Value = complete;
                ParentForm.AuditDoorUserStatus.Text = status;
            }

        }
        /***********************************************************************************************************************
        ** this code updates the status while a background thread processes the doors/locks
        ***********************************************************************************************************************/
        public delegate void BuildAuditDoorChange(string status, int complete, int total);
        public void BuildAuditDoorOnChange(string status, int complete, int total)
        {
            if (status == null)
            {
                ParentForm.AuditBuildGroupBox.Visible = false;
                ParentForm.AuditDoorProgressBar.Visible = false;
                ParentForm.AuditDoorStatus.Visible = false;
                ParentForm.AuditDoorStatus.Text = status;
                ParentForm.printProgressBar.Value = 0;
            }
            else
            {
                ParentForm.AuditBuildGroupBox.Visible = true;
                ParentForm.AuditDoorProgressBar.Visible = true;
                ParentForm.AuditDoorStatus.Visible = true;
                ParentForm.AuditDoorProgressBar.Minimum = 0;
                if (complete > total)
                {
                    complete = total - 1;
                }
                ParentForm.AuditDoorProgressBar.Maximum = total;
                ParentForm.AuditDoorProgressBar.Value = complete;
                ParentForm.AuditDoorStatus.Text = status;
            }

        }
    }
}
