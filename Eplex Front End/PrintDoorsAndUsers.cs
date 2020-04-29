using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.Office.Interop.Excel;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace Eplex_Front_End
{
    public class PrintDoorsAndUsers
    {
        public string reportPath;
        public string reportPathAndFileName;
        public EplexLockManagement.SiteFormShr SharedSiteData;
        public EplexLockManagement.UserFormShr SharedUserData;
        public EplexLockManagement.DoorFormShr SharedDoorData;
        public EplexLockManagement.RegistrySettingsFormShr SharedRegistryFormData;
        public EplexLockManagement ParentForm;
        public UserAccessInfo[] Users;
        public List<LockSettings> Lock;

        public int totalCompleted = 55;
        public int totalToDo = 100;
        public Worksheet UserSht;
        public string[,] DoorParms;
        public Excel excel;
        public bool AbortInProcess = false;


        public PrintDoorsAndUsers(string dataPathIn, EplexLockManagement.SiteFormShr SharedSiteDataIn, EplexLockManagement.UserFormShr SharedUserDataIn, EplexLockManagement.DoorFormShr SharedDoorDataIn, UserAccessInfo[] UsersIn, List<LockSettings> LockIn, EplexLockManagement.RegistrySettingsFormShr SharedRegistryFormDataIn, EplexLockManagement ParentFormIn)
            {
            reportPath = dataPathIn;
            SharedSiteData = SharedSiteDataIn;
            SharedUserData = SharedUserDataIn;
            SharedDoorData = SharedDoorDataIn;
            SharedRegistryFormData = SharedRegistryFormDataIn;
            Users = UsersIn;
            Lock = LockIn;
            ParentForm = ParentFormIn;
        }

        public void WriteTheReport(object sender, DoWorkEventArgs e)
        {
            /***********************************************************************************************************************
            ** Write the data to Excel
            ***********************************************************************************************************************/
            reportPathAndFileName = reportPath + DateTime.Now.ToString("yyyy-MM-dd") + @" Eplex Report.xlsx";
            int SheetNum = 1;
            ParentForm.DoorUserAbort = false;

            ////System.Windows.Forms.Application.UseWaitCursor = true;
            ////System.Windows.Forms.Application.DoEvents();

            //if (InvokeRequired)
            //{
            int totalCompleted = 50;
            int totalToDo = 100;

            ParentForm.Invoke(new WriteReportChange(WriteReportOnChange), "Opening Excel", totalCompleted, totalToDo);
            //}
            excel = new Excel(reportPathAndFileName, SheetNum, ParentForm);
            UserSht = excel.Open(reportPathAndFileName, SheetNum);
            excel.renameSheet(1, "Users");
            if (WasAbortRequested()) return;

            WriteUsersToExcel(excel);
            if (WasAbortRequested()) return;
            WriteDoorsToExcel(excel);
            if (WasAbortRequested()) return;

            excel.Activate(UserSht);
            excel.SaveAS();
            //excel.Visible(true);
            excel.Close(SaveChanges: false);
            excel.Kill();
//            excel = null; // Needed to make Excel quit in the background
            GC.Collect(); // Garbage Collect - Needed to make Excel quit in the background
            GC.WaitForPendingFinalizers();

            totalCompleted = totalToDo - 5;
            ParentForm.Invoke(new WriteReportChange(WriteReportOnChange), "Copying dated backup to common report file", totalCompleted, totalToDo);
            totalCompleted = totalToDo - 1;
            string outFile = PutACopyInUsersRegistryLocation(reportPathAndFileName);
            ParentForm.Invoke(new WriteReportChange(WriteReportOnChange), "Starting Excel on Print File", totalCompleted, totalToDo);

            Process.Start(outFile);

            System.Threading.Thread.Sleep(4000);
            ParentForm.Invoke(new WriteReportChange(WriteReportOnChange), null, totalCompleted, totalToDo); // Tells the process box to close
            //System.Windows.Forms.Application.UseWaitCursor = false;
        }

        public delegate void WriteReportChange(string status, int complete, int total);
        /***********************************************************************************************************************
        ** This code updates the progress dialog while a background thread writes teh Door and User information to Excel
        ***********************************************************************************************************************/
        public void WriteReportOnChange(string status, int complete, int total)
        {
            if (status == null)
            {
                ParentForm.printProgressGroupBox.Visible = false;
                ParentForm.printProgressBar.Visible = false;
                ParentForm.printProgessStatus.Visible = false;
                ParentForm.printProgessStatus.Text = status;
                ParentForm.printProgressBar.Value = 0;
            }
            else
            {
                ParentForm.printProgressGroupBox.Visible = true;
                ParentForm.printProgressBar.Visible = true;
                ParentForm.printProgessStatus.Visible = true;
                ParentForm.printProgressBar.Minimum = 0;
                if (complete > total)
                {
                    complete = total - 1;
                }
                ParentForm.printProgressBar.Maximum = total;
                ParentForm.printProgressBar.Value = complete;
                ParentForm.printProgessStatus.Text = status;
            }

        }
        private void WriteUsersToExcel(Excel excel)
        /***********************************************************************************************************************
        ** This writes the user and dor data to excel
        ***********************************************************************************************************************/
        {
            Dictionary<string, int> DoorColDict = new Dictionary<string, int>();

            /***********************************************************************************************************************
            ** Write the site name
            ***********************************************************************************************************************/
            ParentForm.Invoke(new WriteReportChange(WriteReportOnChange), "Writing Site Name", totalCompleted, totalToDo);
            int r = 1; int c = 1;
            excel.WriteCell(r, c, SharedSiteData.site);
            excel.Merge(r, c, r, c + 3);
            excel.GrayCell(r, c);
            excel.ColumnWidth(r, c, 13);
            excel.Alignment("Center", r, c, r, c);
            if (WasAbortRequested()) return;

            /***********************************************************************************************************************
            ** Write the column headers
            ***********************************************************************************************************************/
            c = 1;
            totalCompleted = totalCompleted + 5;
            ParentForm.Invoke(new WriteReportChange(WriteReportOnChange), "Writing Headers", totalCompleted, totalToDo);
            r++;
            r++;
            int SaveStartRow = r;
            int SaveStartCol = c;

            excel.WriteCell(r, c, "Usr\nNum");
            excel.GrayCell(r, c);
            excel.ColumnWidth(r, c, 0);
            c++;
            excel.WriteCell(r, c, "Access\nCode");
            excel.GrayCell(r, c);
            excel.ColumnWidth(r, c, 0);
            c++;
            int SaveUserNameStartRow = r;
            int SaveUserNameCol = c;
            excel.WriteCell(r, c, "User Name");
            excel.GrayCell(r, c);
            excel.ColumnWidth(r, c, 24);
            c++;
            excel.WriteCell(r, c, "User Type");
            excel.GrayCell(r, c);
            excel.ColumnWidth(r, c, 0);
            if (WasAbortRequested()) return;

            /***********************************************************************************************************************
            ** Write the Door Headers
            ***********************************************************************************************************************/
            totalCompleted = totalCompleted + 5;
            ParentForm.Invoke(new WriteReportChange(WriteReportOnChange), "Writing Door Headers", totalCompleted, totalToDo);
            foreach (LockSettings Door in Lock)
            {
                string[] DataIn = Door.Name.Split();
                string Hdr = "";
                //* Split the door lock name headers into multiple lines
                for (int i = 0; i < DataIn.Length; i++)
                {
                    Hdr = Hdr + DataIn[i] + "\n";
                }

                Hdr = Hdr.Substring(0, Hdr.Length - 1);

                c++;
                excel.WriteCell(r, c, Hdr);
                excel.GrayCell(r, c);
                DoorColDict[Door.Name] = c;
                excel.ColumnWidth(r, c, 0);
            }
            if (WasAbortRequested()) return;
            int MaxCol = c;
            /***********************************************************************************************************************
            ** Write the Data
            ***********************************************************************************************************************/
            totalCompleted = totalCompleted + 5;
            ParentForm.Invoke(new WriteReportChange(WriteReportOnChange), "Writing Users", totalCompleted, totalToDo);
            c = 0;

            /***********************************************************************************************************************
            ** Use Linq to sort by user name and eliminate the blank entries
            ***********************************************************************************************************************/
            var RealUsers = Users
                .Where(x => x.Name.Trim() != "")
                .OrderBy(x => x.Name);

            /***********************************************************************************************************************
            ** Write out the user information
            ***********************************************************************************************************************/
            int FurthestCol = 1;
            int UsersProcessed = 0;
            bool unknownDoor = false;
            foreach (UserAccessInfo User in RealUsers)
            {
                if (WasAbortRequested()) return;
                UsersProcessed++;
                r++;
                c = 1; excel.WriteCell(r, c, User.Num.ToString("000"));
                c++; excel.WriteCell(r, c, User.Code.ToString());
                c++; excel.WriteCell(r, c, User.Name);
                c++; excel.WriteCell(r, c, User.Type);
                int DoorErrCol = MaxCol;
                FurthestCol = MaxCol;
                foreach (string Door in User.ThisUserDoorListPtr)
                {
                    try
                    {
                        c = DoorColDict[Door];
                        excel.WriteCell(r, c, "X");
                    }
                    catch
                    {
                        DoorErrCol++;
                        c = DoorErrCol;
                        excel.WriteCell(r, c, Door);
                        if (DoorErrCol > FurthestCol)
                        {
                            FurthestCol = DoorErrCol;
                        }
                        if (unknownDoor == false)
                        {
                            unknownDoor = true;
                            excel.WriteCell(3, c, @"Doors Here are invalid. Fix these Users");
                        }
                    }
                }
                if (UsersProcessed == RealUsers.Count())
                {
                    for (int i = 2; i < FurthestCol; i++)
                    {
                        if (i == 3)
                        {
                            // Skip it
                        }
                        else
                        {
                            excel.ColumnWidth(1, i, 0);
                        }

                    }
                }
            }
            if (WasAbortRequested()) return;
            /***********************************************************************************************************************
            ** Format the borders and center the data
            ***********************************************************************************************************************/
            totalCompleted = totalCompleted + 5;
            ParentForm.Invoke(new WriteReportChange(WriteReportOnChange), "Formatting Excel Worksheet", totalCompleted, totalToDo);
            excel.Alignment("Center", SaveStartRow, SaveStartCol, r, FurthestCol);
            excel.Alignment("Left", SaveUserNameStartRow, SaveUserNameCol, r, SaveUserNameCol);
            excel.Borders(SaveStartRow, SaveStartCol, r, FurthestCol);

            /***********************************************************************************************************************
            ** Write the Generated date and time.
            ***********************************************************************************************************************/
            ParentForm.Invoke(new WriteReportChange(WriteReportOnChange), "Writing date and time stamp", totalCompleted, totalToDo);
            r = 1; c = 6;
            string GenMsg = "File Generated: " + DateTime.Now.ToString("MM-dd-yyyy") + " "
                                                + DateTime.Now.ToString("h:m:ss tt", System.Globalization.CultureInfo.InvariantCulture);

            excel.WriteCell(r, c, GenMsg);
            excel.Alignment("Left", r, c, r, c);

            /***********************************************************************************************************************
            ** Set to one page wide by any number tall
            ***********************************************************************************************************************/
            ParentForm.Invoke(new WriteReportChange(WriteReportOnChange), "Setting Page Attributes", totalCompleted, totalToDo);
            if (WasAbortRequested()) return;

            excel.FitToPage(1,1);
            excel.PageNumbers();
        }
        private void WriteDoorsToExcel(Excel excel)
        {
            Dictionary<string, int> DoorColDict = new Dictionary<string, int>();
            if (WasAbortRequested()) return;

            /***********************************************************************************************************************
            ** Create a new sheet
            ***********************************************************************************************************************/
            excel.newSheet("Doors", UserSht);
            if (WasAbortRequested()) return;

            /***********************************************************************************************************************
            ** Write the site name
            ***********************************************************************************************************************/
            totalCompleted++;
            ParentForm.Invoke(new WriteReportChange(WriteReportOnChange), "Writing Door Information", totalCompleted, totalToDo);

            LoadDoorAttributeLits();

            /***********************************************************************************************************************
            ** Write the Door atttribute labels column
            ***********************************************************************************************************************/
            int r = 3;
            int c = 1;
            int SaveStartRow = r;
            int SaveStartCol = c;
            excel.WriteArray(r, c, DoorParms);
            if (WasAbortRequested()) return;

            /***********************************************************************************************************************
            ** Write the Door Headers
            ***********************************************************************************************************************/
            totalCompleted = totalCompleted + 2;
            ParentForm.Invoke(new WriteReportChange(WriteReportOnChange), "Writing Door Attributes", totalCompleted, totalToDo);
            foreach (LockSettings Door in Lock)
            {
                c++;
                r = SaveStartRow;
                excel.WriteCell(r, c, Door.ID);
                r++;
                excel.WriteCell(r, c, Door.Name);
                r++;
                excel.WriteCell(r, c, SharedSiteData.site);
                r++;
                excel.WriteCell(r, c, Door.Function);
                r++;
                excel.WriteCell(r, c, Door.UnlockTime.ToString());
                r++;
                excel.WriteCell(r, c, Door.BuzzerVolume.ToString());
                r++;
                excel.WriteCell(r, c, Door.TamperCount.ToString());
                r++;
                excel.WriteCell(r, c, Door.TamperShutdownTime.ToString());
                r++;
                string PassMode = "Deactivated";
                if (Door.PassageMode == true) PassMode = "Activated";
                excel.WriteCell(r, c, PassMode);
                r++;
                excel.WriteCell(r, c, Door.PassageModeOpenTimeLimit.ToString());
                r++;
                string LockoutMode = "Disabled";
                if (Door.LockOutMode == true) LockoutMode = "Enabled";
                excel.WriteCell(r, c, LockoutMode);
                r++;
                excel.WriteCell(r, c, Door.AccessCodeLength.ToString());
                r++;
                string RmtUnl = "Disabled";
                if (Door.RemoteUnlock == true) RmtUnl = "Enabled";
                excel.WriteCell(r, c, RmtUnl);
                r++;
                string LtchH = "Disabled";
                if (Door.LatchHoldback == true) LtchH = "Enabled";
                excel.WriteCell(r, c, LtchH);
            }
            if (WasAbortRequested()) return;


            int FurthestRow = r;
            int FurthestCol = c;
            excel.ColumnWidth(1, FurthestCol, 0);
            /***********************************************************************************************************************
            ** Format the borders and center the data
            ***********************************************************************************************************************/
            totalCompleted = totalCompleted + 5;
            ParentForm.Invoke(new WriteReportChange(WriteReportOnChange), "Formatting Excel Worksheet", totalCompleted, totalToDo);
            excel.Alignment("Center", SaveStartRow, 1, FurthestRow, FurthestCol);
            excel.Alignment("Left", SaveStartRow, 1, FurthestRow, 1);
            excel.Borders(SaveStartRow, SaveStartCol, FurthestRow, FurthestCol);
            if (WasAbortRequested()) return;

            /***********************************************************************************************************************
            ** Write the Generated date and time.
            ***********************************************************************************************************************/
            ParentForm.Invoke(new WriteReportChange(WriteReportOnChange), "Writing date and time stamp", totalCompleted, totalToDo);
            r = 1; c = 6;
            string GenMsg = "File Generated: " + DateTime.Now.ToString("MM-dd-yyyy") + " "
                                                + DateTime.Now.ToString("h:m:ss tt", System.Globalization.CultureInfo.InvariantCulture);
            if (WasAbortRequested()) return;

            excel.WriteCell(r, c, GenMsg);
            excel.Alignment("Left", r, c, r, c);

            /***********************************************************************************************************************
            ** Set to one page wide by any number tall
            ***********************************************************************************************************************/
            ParentForm.Invoke(new WriteReportChange(WriteReportOnChange), "Setting Page Attributes", totalCompleted, totalToDo);

            excel.FitToPage(1,1);
            excel.PageNumbers();
            if (WasAbortRequested()) return;
        }
        private void LoadDoorAttributeLits()
        {
            DoorParms = new string[14,2]
            {
                {"Lock ID",""},
                {"Lock Name",""},
                {"Site Name",""},
                {"Lock Function",""},
                {"Unlock Time",""},
                {"Buzzer Volume",""},
                {"Tamper Count",""},
                {"Tamper Shutdown Time",""},
                {"Passage Mode",""},
                {"Passage Mode Open Time",""},
                {"Lockout Mode",""},
                {"Access Code Length",""},
                {"Remote Unlock",""},
                {"Latch Holdback",""}
            };

        }
        private bool WasAbortRequested()
        {
            if (ParentForm.DoorUserAbort && AbortInProcess == false)
            {
                AbortInProcess = true;
                excel.Close(SaveChanges: false);
                excel.Kill();
                GC.Collect(); // Garbage Collect - Needed to make Excel quit in the background
                GC.WaitForPendingFinalizers();
                ParentForm.Invoke(new WriteReportChange(WriteReportOnChange), null, 100, 100);
            }
            return ParentForm.DoorUserAbort;
        }
        private string PutACopyInUsersRegistryLocation(string reportPathAndFileName)
        {
            string outFile = Path.Combine(SharedRegistryFormData.LatestReportPath, SharedRegistryFormData.LatestReportFile);
            DirectoryInfo di = Directory.CreateDirectory(SharedRegistryFormData.LatestReportPath);
            bool overWrite = true;
            File.Copy(reportPathAndFileName, Path.Combine(SharedRegistryFormData.LatestReportPath, SharedRegistryFormData.LatestReportFile), overWrite);
            return outFile;

        }
    }
}
