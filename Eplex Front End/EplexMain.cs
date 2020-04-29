using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;

public struct LockSettings
{
    public string Name;
    public string ID;
    public string Function;
    public int UnlockTime;
    public int BuzzerVolume;
    public int TamperCount;
    public int TamperShutdownTime;
    public bool PassageMode;
    public int PassageModeOpenTimeLimit;
    public bool LockOutMode;
    public int AccessCodeLength;
    public bool RemoteUnlock;
    public bool LatchHoldback;
    public bool[] AuditFlags;
    public string SourceFile;
    public Dictionary<string, int> AuditFlagDictionary;
}

public struct UserAccessInfo
{
    public int Num;
    public int Code;
    public string Name;
    public string Type;
    public bool UpdateInProgress;
    public int GroupCount;
    public List<string> ThisUserGroupListPtr;  // Future Use
    public List<string> ThisUserDoorListPtr;
}

public struct AuditDoorInfo
{
    public string site;
    public string DoorName;
    public int DoorID;
    public string AuditExtractTimestamp;
    public string DateTime2;
    public string SomeDecimalNum1;
    public string SomeDecimalNum2;
    public int UserTxnCount;
    public string SomeHexNumber1;
    public string DoorUserCountMaybe;
    public string SomeNUmber2;
    public List<AuditUserInfo> UserTxn;
}
public struct AuditUserInfo
{
    public DateTime txnDateTime;
    public string Txn;
    public string userCode;
}

public struct AuditExcelRow
{
    public string txnDate;
    public string txnTime;
    public string userCode;
    public string userName;
    public string Txn;
}

namespace Eplex_Front_End
{
    public partial class EplexLockManagement : Form
    {
        /***********************************************************************************************************************
        ** This class holds the data to share with the User update form
        ***********************************************************************************************************************/
        public class UserFormShr
        {
            public int num { get; set; }
            public string name { get; set; }
            public int code { get; set; }
            public string type { get; set; }
            public bool Cancel { get; set; }
            public bool NextRequested { get; set; }
            public bool NextButtonEnabled { get; set; }
            public bool PrevRequested { get; set; }
            public bool PrevButtonEnabled { get; set; }
            public List<string> ThisUserGroupListPtr;
            public List<string> ThisUserDoorListPtr;
            public Dictionary<int, string> UserDictionaryPtr;
        }
        /***********************************************************************************************************************
        ** This class holds the data to share with the Door Lock update form
        ***********************************************************************************************************************/
        public class DoorFormShr
        {
            public string site { get; set; }
            public bool Cancel { get; set; }
            public bool AddInProgress { get; set; }
            public string LockDataPathAndFile { get; set; }

            public int DoorRowSelected { get; set; }
            public LockSettings LockSelectedPtr;
            public List<LockSettings> LockListPtr;
            public List<string> LockFunctionsPtr;
        }
        /***********************************************************************************************************************
        ** This class holds the data to share with the Door Lock update form
        ***********************************************************************************************************************/
        public class SiteFormShr
        {
            public string DialogFunction { get; set; }
            public string site { get; set; }
            public bool Cancel { get; set; }
            public string SiteDataPath { get; set; }
            public string SiteDataPath2020 { get; set; }

        }

        /***********************************************************************************************************************
        ** This class holds the data to share with the generate the PCMUnit file form
        ***********************************************************************************************************************/
        public class PCMUnitFormShr
        {
            public bool Cancel { get; set; }
            public string PCMUnitDataPath { get; set; }
        }

        private ListViewColumnSorter UserListViewColumnSorter;
        private ListViewColumnSorter DoorListViewColumnSorter;
        private ListViewColumnSorter SiteListViewColumnSorter;

        /***********************************************************************************************************************
        ** This class holds the data to share with the Users by Door form
        ***********************************************************************************************************************/
        public class DoorUserFormShr
        {
            public string site { get; set; }
            public string UserDataPathAndFile { get; set; }
            public bool Cancel { get; set; }
            public int DoorRowSelected { get; set; }
            public LockSettings LockSelectedPtr;
            public List<LockSettings> LockListPtr;
            public List<string> LockFunctionsPtr;
            public UserAccessInfo[] Users;
        }

        /***********************************************************************************************************************
        ** This class holds the registry data
        ***********************************************************************************************************************/
        public class RegistrySettingsFormShr
        {
            public string AppPath { get; set; }
            public string DataPath { get; set; }
            public string DataPath2020 { get; set; }
            public string MUnitPath { get; set; }
            public string AppPathLit { get; set; }
            public string DataPathLit { get; set; }
            public string DataPath2020Lit { get; set; }
            public string MUnitPathLit { get; set; }
            public string EplexDataEncryptionLit { get; set; }
            public bool EplexDataEncryption { get; set; }
            public string LatestReportPath { get; set; }
            public string LatestReportPathLit { get; set; }
            public string LatestReportFile { get; set; }
            public string LatestReportFileLit { get; set; }
            public string EplexRegistryKeyPart1 { get; set; }
            public bool Cancel { get; set; }
            public bool Test { get; set; }
        }

        /***********************************************************************************************************************
        ** Door/Lock Variables - terms Door and Lock are interchangable
        ***********************************************************************************************************************/
        List<LockSettings> Lock = new List<LockSettings>();
        public LockSettings DoorLock = new LockSettings();
        string LockDataFileName = "LockConfigurations.txt";
        string LockDataPathAndFile;
        public DoorFormShr SharedDoorData = new DoorFormShr();
        public DoorUserFormShr SharedDoorUserData = new DoorUserFormShr();
        const string DoorActionEdit = "Edit";
        const string DoorActionDelete = "Delete";
        public Dictionary<string, int> AuditDictionary = new Dictionary<string, int>();

        /***********************************************************************************************************************
        **Audit related Variables
        ***********************************************************************************************************************/
        public string AuditDataPathAndFile;
        public List<AuditDoorInfo> AuditDoor = new List<AuditDoorInfo>();
        //        List<AuditUserInfo> AuditUser = new List<AuditUserInfo>();
        public List<AuditExcelRow> AuditRows = new List<AuditExcelRow>();
        public bool AbortAuditReport = false;
        public bool DoorUserAbort = false;

        /***********************************************************************************************************************
        ** Site related Variables
        ***********************************************************************************************************************/
        public string DataPath;
        public string DataPath2020;
        public string SiteDataPath;
        public string SiteDataPath2020;
        public string MUnitFolder;
        public string EplexAppPath;
        string LockFunctionListPathAndFile;
        public List<string> Sites = new List<string>();
        public List<string> LockFunctions = new List<string>();
        public SiteFormShr SharedSiteData = new SiteFormShr();
        public PCMUnitFormShr SharedPCMUnitData = new PCMUnitFormShr();
        public RegistrySettingsFormShr SharedRegistryFormData = new RegistrySettingsFormShr();
        const string PCMUnitCtrlFileName = "PCMUnitControlRecs.txt";
        public string PCMUnitCtlFullFilePath;

        /***********************************************************************************************************************
        ** User related Variables
        ***********************************************************************************************************************/
        public UserAccessInfo[] Users = new UserAccessInfo[300]; // Going to use 1 to 299
        string UserDataFileName = "Users.txt";
        public string UserDataPathAndFile;
        public UserFormShr SharedUserData = new UserFormShr();
        public Dictionary<int, string> UserDictionary = new Dictionary<int, string>();
        const int MaxUsers = 299;
        bool UserAddFlag;
        public List<string>[] ThisUserDoorList = new List<string>[300];
        public List<string>[] ThisUserGroupList = new List<string>[300];

        /***********************************************************************************************************************
        ** Encryption related Variables
        ***********************************************************************************************************************/
        Encryption encrypt = new Encryption();
        public string storedData;


        /***********************************************************************************************************************
        ** Misc Variables
        ***********************************************************************************************************************/
        string LatestReportFileName = @"LockData.xlsx";
        string FuntionList = @"LockFunctions.txt";
        string SaveState = @"SaveState.txt";
        string SaveStateDataPathAndFile;
        string SaveStateDataPathAndFile2020;
        const string FldDelim = "%%!!%%";
        const string ReportFPath = @"Eplex Reports\";
        public string MyDocumentsPath;
        public Excel excel;
        public PrintDoorsAndUsers printDoorsAndUsers;
        public PrintAudit printAudit;
        public string reportPath;
        public string reportPathAndFileName;
        public bool DemoPgm = false;
        public string[] args;
        public string catchData;


        public EplexLockManagement()
        {
            InitializeComponent();
            // Create an instance of a ListView column sorter and assign it 
            // to the ListView control.
            UserListViewColumnSorter = new ListViewColumnSorter();
            this.UserListView.ListViewItemSorter = UserListViewColumnSorter;
            DoorListViewColumnSorter = new ListViewColumnSorter();
            this.DoorListView.ListViewItemSorter = DoorListViewColumnSorter;
            SiteListViewColumnSorter = new ListViewColumnSorter();
            this.SiteListView.ListViewItemSorter = SiteListViewColumnSorter;
            args = Environment.GetCommandLineArgs();

        }

        private void EplexLockManagement_Load(object sender, EventArgs e)
        /***********************************************************************************************************************
        ** This runs prior to displaying the dialog.
        ***********************************************************************************************************************/
        {
            (DataPath, DataPath2020, MUnitFolder, EplexAppPath) = GetRegistryInfo();
            SiteDataPath = DataPath + @"Sites";
            SiteDataPath2020 = DataPath2020 + @"Sites";
            SharedSiteData.SiteDataPath = SiteDataPath;
            SharedSiteData.SiteDataPath2020 = SiteDataPath2020;
            SaveStateDataPathAndFile = SiteDataPath2020 + @"\" + SaveState;
            LockFunctionListPathAndFile = SiteDataPath2020 + @"\" + FuntionList;

            ReadEplexAppStateData(SaveStateDataPathAndFile);
            ReadEplexLockFuntionList(LockFunctionListPathAndFile);

            ReadEplexSiteData(SiteDataPath2020);
            SiteListView.Visible = true;
            LoadSiteListbox();
            //            RefreshLockAndUser(); This gets called when LoadSiteListBox triggers a SelectionChange event
            //            var SiteListView = SelectedIndexChanged.isTrusted;

            PCMUnitCtlFullFilePath = DataPath2020 + @"Sites\" + PCMUnitCtrlFileName;
            printProgressGroupBox.Visible = false;
            printProgressBar.Visible = false;
            printProgessStatus.Visible = false;

        }
        private void RefreshLockAndUser()
        {
            EstablishPaths();
            UserListView.Visible = true;
            DoorListView.Visible = true;

            //LoadTestData();
            ReadEplexLockData(LockDataPathAndFile);
            ReadEplexUserData(UserDataPathAndFile);

            // WriteEplexLockData(LockDataPathAndFile);

            LoadDoorListbox();
            LoadUserListbox();


        }
        private void EstablishPaths()
        {
            string LockDataPath = DataPath2020 + @"Sites\" + SharedDoorData.site + @"\Lock Configuration";
            SharedSiteData.site = SharedDoorData.site;
            LockDataPathAndFile = LockDataPath + @"\" + LockDataFileName;
            SharedDoorData.LockDataPathAndFile = LockDataPathAndFile;
            UserDataPathAndFile = LockDataPath + @"\" + UserDataFileName;
            SharedDoorUserData.UserDataPathAndFile = UserDataPathAndFile;
        }
        private void LoadTestData()
        /***********************************************************************************************************************
        ** This loads some test data
        ***********************************************************************************************************************/
        {

            for (int j = 0; j < 2; j++)
            {
                var TempLock = new LockSettings();
                TempLock.AuditFlags = new bool[34];
                TempLock.Name = "Test Lock " + j + 1.ToString();
                TempLock.ID = (j + 1).ToString();
                TempLock.Function = "Latch Holdback";
                TempLock.UnlockTime = 5;
                TempLock.BuzzerVolume = 2;
                TempLock.TamperCount = 5;
                TempLock.TamperShutdownTime = 60;
                TempLock.PassageMode = false;
                TempLock.PassageModeOpenTimeLimit = 9;
                TempLock.LockOutMode = false;
                TempLock.AccessCodeLength = 5;
                TempLock.RemoteUnlock = false;
                TempLock.LatchHoldback = true;
                for (int i = 0; i < 34; i++)
                {
                    TempLock.AuditFlags[i] = true;
                }
                Lock.Add(TempLock);
            }

            for (int j = 1; j < 6; j++)
            {
                Users[j].Num = j;
                Users[j].Code = 12340 + j;
                Users[j].Name = "Name " + j.ToString();
                Users[j].Type = "Access User";
            }

            for (int j = 6; j < MaxUsers; j++)
            {
                Users[j].Num = j;
            }
        }
        private void ReadEplexLockData(string DataPath2020)
        /***********************************************************************************************************************
        ** This reads the lock configuration data and loads it into a list
        ***********************************************************************************************************************/
        {
            bool DataEncrypted=false;
            string[] DataRecordsIn;
            string LockDataRecord;

            Lock.Clear();
            try
            {
                StreamReader LockPathAndFileName = new StreamReader(DataPath2020);
                storedData = LockPathAndFileName.ReadToEnd();
                LockDataRecord = encrypt.AesDecryptor(storedData, FldDelim, ref DataEncrypted, this);

                if (DataEncrypted)
                {
                    string[] stringSeparators = new string[] { Environment.NewLine };
                    DataRecordsIn = LockDataRecord.Split(stringSeparators, StringSplitOptions.None);
                    LockPathAndFileName.Close();
                }
                else
                {
                    LockPathAndFileName.Close();
                    DataRecordsIn = File.ReadAllLines(DataPath2020);
                }

                foreach (string DataRec in DataRecordsIn)
                {
                    if (DataRec.Length > 0)
                    {
                        string[] stringSeparators = new string[] { FldDelim };
                        string[] DataIn = DataRec.Split(stringSeparators, StringSplitOptions.None);

                        var TempLock = new LockSettings();
                        TempLock.AuditFlags = new bool[34];

                        LoadLockWithData(TempLock, DataIn, Lock, DataPath2020);
                        Lock.Sort((x, y) => x.Name.CompareTo(y.Name));
                    }
                }
                //                    LockPathAndFileName.Close();
            }
            catch (Exception e2)
            {
                DialogResult OKFlag = MessageBox.Show(e2.Message , "Error in ReadEplexLockData", MessageBoxButtons.OK);
                return;
            }
        }
        private void LoadLockWithData(LockSettings TempLock, string[] DataIn, List<LockSettings> Lock, string DataPath2020)
        {
            string TmpID = "";
            int i = 0;
            TempLock.Name = DataIn[i];
            i++; TmpID = "0000" + DataIn[i];
            TempLock.ID = TmpID.Substring(TmpID.Length - 4);
            i++; TempLock.Function = DataIn[i];
            i++; TempLock.UnlockTime = int.Parse(DataIn[i]);
            i++; TempLock.BuzzerVolume = int.Parse(DataIn[i]);
            i++; TempLock.TamperCount = int.Parse(DataIn[i]);
            i++; TempLock.TamperShutdownTime = int.Parse(DataIn[i]);
            i++; TempLock.PassageMode = bool.Parse(DataIn[i]);
            i++; TempLock.PassageModeOpenTimeLimit = int.Parse(DataIn[i]);
            i++; TempLock.LockOutMode = bool.Parse(DataIn[i]);
            i++; TempLock.AccessCodeLength = int.Parse(DataIn[i]);
            i++; TempLock.RemoteUnlock = bool.Parse(DataIn[i]);
            i++; TempLock.LatchHoldback = bool.Parse(DataIn[i]);
            for (int j = 0; j < 34; j++)
            {
                i++;
                TempLock.AuditFlags[j] = bool.Parse(DataIn[i]);
            } // for j
            TempLock.SourceFile = DataPath2020;

            Lock.Add(TempLock);
            LoadAuditDictionary();

        }
        private void ReadEplexUserData(string DataPath2020)
        /***********************************************************************************************************************
        ** This reads the user data and loads it into an array
        ***********************************************************************************************************************/
        {
            bool DataEncrypted=false;
            string[] DataRecordsIn;
            Array.Clear(Users, 0, 299);
            int Unum;

            for (int i = 0; i <= MaxUsers; i++)
            {
                ThisUserDoorList[i] = new List<string>();
                ThisUserGroupList[i] = new List<string>();
                InitializeUsers(ref Users[i], ref ThisUserDoorList[i], ref ThisUserGroupList[i], ref i);
            }

            try
            {
                StreamReader UserPathAndFileName = new StreamReader(DataPath2020);

                storedData = UserPathAndFileName.ReadToEnd();
                string UserDataRecord = encrypt.AesDecryptor(storedData, FldDelim, ref DataEncrypted, this);
                if (DataEncrypted)
                {
                    string[] stringSeparators = new string[] { Environment.NewLine };
                    DataRecordsIn = UserDataRecord.Split(stringSeparators, StringSplitOptions.None);
                    UserPathAndFileName.Close();
                }
                else
                {
                    UserPathAndFileName.Close();
                    DataRecordsIn = File.ReadAllLines(DataPath2020);
                }
                foreach (string DataRec in DataRecordsIn)
                {
                    if (DataRec.Length > 0)
                    {
                        string[] stringSeparators = new string[] { FldDelim };
                        string[] DataIn = DataRec.Split(stringSeparators, StringSplitOptions.None);

                        int i = 0;
                        Unum = int.Parse(DataIn[i]);
                        Users[Unum].Num = Unum;
                        Users[Unum].UpdateInProgress = false;
                        i++; Users[Unum].Name = DataIn[i];
                        i++; Users[Unum].Type = DataIn[i];
                        i++; Users[Unum].Code = int.Parse(DataIn[i]);
                        i++; Users[Unum].GroupCount = int.Parse(DataIn[i]);
                        i++;

                        ThisUserGroupList[Unum].Clear();

                        for (int j = i; j < i + Users[Unum].GroupCount - 1; j++)
                        {
                            ThisUserGroupList[Unum].Add(DataIn[j]);
                            i = j;
                        }
                        ThisUserDoorList[Unum].Clear();
                        for (int j = i; j < DataIn.Length; j++)
                        {
                            ThisUserDoorList[Unum].Add(DataIn[j]);
                        }
                        UserDictionary[Users[Unum].Code] = Users[Unum].Name;
                    }
                }
                UserPathAndFileName.Close();
            }
            catch (Exception e)
            {
                DialogResult OKFlag = MessageBox.Show(e.Message , "Error in ReadEplexUserData", MessageBoxButtons.OK);
                return;
            }
        }
        private void InitializeUsers(ref UserAccessInfo UserIn, ref List<string> ThisUserDoorList, ref List<string> ThisUserGroupList, ref int i)
        {
            UserIn.Num = i;
            UserIn.Name = "";
            UserIn.Type = "";
            UserIn.Code = 0;
            UserIn.GroupCount = 0;
            UserIn.UpdateInProgress = false;

            ThisUserGroupList.Add("");
            UserIn.ThisUserGroupListPtr = ThisUserGroupList;
            ThisUserDoorList.Add("");
            UserIn.ThisUserDoorListPtr = ThisUserDoorList;
        }
        private void ReadEplexAppStateData(string DataPath2020)
        /***********************************************************************************************************************
        ** This reads information saved from the last session
        ***********************************************************************************************************************/
        {
            string AppStateDataRecord = "";
            bool DataEncrypted=false;
            string[] DataRecordsIn;

            try
            {
                StreamReader AppStatePathAndFileName = new StreamReader(DataPath2020);

                storedData = AppStatePathAndFileName.ReadToEnd();
                string DataRecord = encrypt.AesDecryptor(storedData, FldDelim, ref DataEncrypted, this);
                if (DataEncrypted)
                {
                    string[] stringSeparators = new string[] { Environment.NewLine };
                    DataRecordsIn = DataRecord.Split(stringSeparators, StringSplitOptions.None);
                    AppStatePathAndFileName.Close();
                }
                else
                {
                    AppStatePathAndFileName.Close();
                    DataRecordsIn = File.ReadAllLines(DataPath2020);
                }
                foreach (string DataRec in DataRecordsIn)
                {
                    if (DataRec.Length > 0)
                    {
                        string[] stringSeparators = new string[] { FldDelim };
                        string[] DataIn = DataRec.Split(stringSeparators, StringSplitOptions.None);

                        int i = 0;
                        SharedDoorData.site = DataIn[i];
                        SharedSiteData.site = DataIn[i];
                    }
                }
                AppStatePathAndFileName.Close();
            }
            catch (Exception e2)
            {
                SharedDoorData.site = "";
                DialogResult OKFlag = MessageBox.Show(e2.Message , "Error in ReadEplexAppStateData", MessageBoxButtons.OK);
                return;
            }
        }
        private void ReadEplexLockFuntionList(string DataPath2020)
        /***********************************************************************************************************************
        ** This reads all available lock function types
        ***********************************************************************************************************************/
        {
            string LockFunctoinListDataRecord = "";
            bool DataEncrypted=false;

            try
            {
                StreamReader LockFunctoinListPathAndFileName = new StreamReader(DataPath2020);

                while (LockFunctoinListPathAndFileName.Peek() > -1)
                {
                    storedData = LockFunctoinListPathAndFileName.ReadLine();
                    LockFunctoinListDataRecord = encrypt.AesDecryptor(storedData, FldDelim, ref DataEncrypted, this);

                    string[] stringSeparators = new string[] { FldDelim };
                    string[] DataIn = LockFunctoinListDataRecord.Split(stringSeparators, StringSplitOptions.None);

                    LockFunctions.AddRange(DataIn);
                }
                LockFunctoinListPathAndFileName.Close();
            }
            catch
            {
                LockFunctions.Add("Latch Holdback");
                LockFunctions.Add("Entry Lock with Passage (Cylindrical, Mortise without deadbolt)");
            }
            LockFunctions.Sort();
        }
        private void ReadEplexSiteData(string DataPath2020)
        /***********************************************************************************************************************
        ** This quieres the directories to determine the sites
        ***********************************************************************************************************************/
        {
            if (Directory.Exists(DataPath2020))
            {
                Sites.Clear();
                Sites.AddRange(System.IO.Directory.GetDirectories(DataPath2020).Select(x => new DirectoryInfo(x).Name).ToList());
                Sites.Sort();
            }
            else
            {
                Sites.Clear();
                try
                {
                    DirectoryInfo di = Directory.CreateDirectory(DataPath2020);
                }
                catch (Exception e1)
                {
                    catchData = "ReadEplexSiteData - Path: " + DataPath2020 + " " + e1.Message;
                }

            }

        }
        public void WriteEplexLockData(string DataPath2020)
        /***********************************************************************************************************************
        ** This writes the lock configuration data
        ***********************************************************************************************************************/
        {
            System.Windows.Forms.Application.UseWaitCursor = true;
            System.Windows.Forms.Application.DoEvents();
            String PathOnly = Path.GetDirectoryName(DataPath2020);      // .GetFileName(strPath);
            try
            {
                DirectoryInfo di = Directory.CreateDirectory(PathOnly);
            }
            catch (Exception e1)
            {
                catchData = "WriteEplexLockData - Path: " + DataPath2020 + " " + e1.Message;
            }

            string userFileBuffer = "";
            StreamWriter LockPathAndFileName;
            File.Delete(DataPath2020);
            string LockDataRecord = "";
            string FileBuffer = "";
            string DataRecord = "";

            for (int i = 0; i < Lock.Count; i++)
            {
                LockDataRecord = Lock[i].Name + FldDelim + Lock[i].ID +
                                FldDelim + Lock[i].Function +
                                FldDelim + Lock[i].UnlockTime +
                                FldDelim + Lock[i].BuzzerVolume +
                                FldDelim + Lock[i].TamperCount +
                                FldDelim + Lock[i].TamperShutdownTime +
                                FldDelim + Lock[i].PassageMode +
                                FldDelim + Lock[i].PassageModeOpenTimeLimit +
                                FldDelim + Lock[i].LockOutMode +
                                FldDelim + Lock[i].AccessCodeLength +
                                FldDelim + Lock[i].RemoteUnlock +
                                FldDelim + Lock[i].LatchHoldback;
                for (int j = 0; j < 34; j++)
                {
                    LockDataRecord = LockDataRecord + FldDelim + Lock[i].AuditFlags[j];
                } // for j

                FileBuffer = FileBuffer + LockDataRecord + Environment.NewLine;


            }  // for i
            LockPathAndFileName = File.AppendText(DataPath2020);
            string encryptedData = encrypt.AesEncryptor(FileBuffer, this, EncryptIt:SharedRegistryFormData.EplexDataEncryption);
            LockPathAndFileName.Write(encryptedData);
            LockPathAndFileName.Close();

            System.Windows.Forms.Application.UseWaitCursor = false;
            System.Windows.Forms.Application.DoEvents();
        }

        public void WriteEplexUserData(string DataPath2020)
        /***********************************************************************************************************************
        ** This writes the User configuration data
        ***********************************************************************************************************************/
        {
            System.Windows.Forms.Application.UseWaitCursor = true;
            System.Windows.Forms.Application.DoEvents();

            int DoorIndex;
            String PathOnly = Path.GetDirectoryName(DataPath2020);      // .GetFileName(strPath);
            try
            {
                DirectoryInfo di = Directory.CreateDirectory(PathOnly);
            }
            catch (Exception e1)
            {
                catchData = "WriteEplexUserData - Path: " + DataPath2020 + " " + e1.Message;
            }

            string UserDataRecord = "";
            File.Delete(DataPath2020);
            StreamWriter UserPathAndFileName;
            string userFileBuffer = "";

            using (UserPathAndFileName = File.AppendText(DataPath2020))
            {
                for (int i = 0; i < MaxUsers; i++)
                {
                    double minUserCode = Math.Pow(10, SharedDoorData.LockSelectedPtr.AccessCodeLength - 2);
                    if (Users[i].Code > minUserCode)
                    {
                        UserDataRecord = Users[i].Num + FldDelim + Users[i].Name +
                                        FldDelim + Users[i].Type +
                                        FldDelim + Users[i].Code +
                                        FldDelim + Users[i].ThisUserGroupListPtr.Count;

                        for (int j = 0; j < Users[i].ThisUserGroupListPtr.Count; j++)
                        {
                            UserDataRecord = UserDataRecord + FldDelim + Users[i].ThisUserGroupListPtr[j];
                        }
                        for (int j = 0; j < Users[i].ThisUserDoorListPtr.Count; j++)
                        {
                            DoorIndex = FindDoorListEntry(Users[i].ThisUserDoorListPtr[j]);
                            if (DoorIndex > -1)
                                UserDataRecord = UserDataRecord + FldDelim + Users[i].ThisUserDoorListPtr[j];
                            else
                                Users[i].ThisUserDoorListPtr.RemoveAt(j);
                        }

                        userFileBuffer = userFileBuffer + UserDataRecord + Environment.NewLine;    // @"\r\n";

                    }
                }  // for i
                string encryptedData = encrypt.AesEncryptor(userFileBuffer, this, EncryptIt:SharedRegistryFormData.EplexDataEncryption);
                UserPathAndFileName.Write(encryptedData);
                UserPathAndFileName.Close();
                //*************************************************************************************************
                //* Test code to make sure the read brings in the same data as write put out
                //*************************************************************************************************
                //StreamReader UserPathAndFileNameIn;
                //UserPathAndFileNameIn = new StreamReader(File.Open(DataPath2020, FileMode.Open));
                //long fLen = new System.IO.FileInfo(DataPath2020).Length;
                //string Datafile = UserPathAndFileNameIn.ReadToEnd();
                //UserPathAndFileNameIn.Close();
                //*************************************************************************************************
                //* End Test Code
                //*************************************************************************************************

                System.Windows.Forms.Application.UseWaitCursor = false;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        private void WriteEplexAppStateData(string DataPath2020)
        /***********************************************************************************************************************
        ** This writes the application state for use at next startup
        ***********************************************************************************************************************/
        {
            StreamWriter AppStatePathAndFileName = new StreamWriter(DataPath2020);
            string AppStateDataRecord = "";

            using (AppStatePathAndFileName)
            {
                AppStateDataRecord = SharedDoorData.site + FldDelim;
                string encryptedData = encrypt.AesEncryptor(AppStateDataRecord, this, EncryptIt:SharedRegistryFormData.EplexDataEncryption);
                AppStatePathAndFileName.Write(encryptedData);
            }
            AppStatePathAndFileName.Close();
        }

        public (string DataPath, string DataPath2020, string MUnitFolder, string EplexAppPath) GetRegistryInfo()
        /***********************************************************************************************************************
        ** This builds the path where the data will be stored.
        ***********************************************************************************************************************/
        {
            string catchInfo = "";
            DataPath = "";
            DataPath2020 = "";
            MUnitFolder = "";
            EplexAppPath = "";
            string RegistryEntry = "";
            SharedRegistryFormData.AppPathLit = "AppPath";
            SharedRegistryFormData.DataPathLit = "DataPath";
            SharedRegistryFormData.DataPath2020Lit = "DataPath2020";
            SharedRegistryFormData.MUnitPathLit = "MUnitFolder";
            SharedRegistryFormData.EplexDataEncryptionLit = "DataProtection";
            SharedRegistryFormData.LatestReportPathLit = "ReportPath";
            SharedRegistryFormData.LatestReportFileLit = "ReportFile";

            try
            {
                var ThisUSerSID = SID;   //(Environ("UserName"))

                string ElpexPathKeyLit = @"Software\Kaba\Eplex 5000";

                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(ElpexPathKeyLit,true))
                {
                    SharedRegistryFormData.EplexRegistryKeyPart1 = key.Name;
                    if (key != null)
                    {
                        catchInfo = SharedRegistryFormData.DataPathLit;
                        Object o = key.GetValue(SharedRegistryFormData.DataPathLit);
                        if (o != null)
                        {
                            DataPath = o.ToString();
                            SharedRegistryFormData.DataPath = DataPath;
                        }
                        catchInfo = SharedRegistryFormData.DataPath2020Lit;
                        o = key.GetValue(SharedRegistryFormData.DataPath2020Lit);
                        if (o != null)
                        {
                            DataPath2020 = o.ToString();
                            SharedRegistryFormData.DataPath2020 = DataPath2020;
                        }
                        else
                        {
                            DataPath2020 = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                            SharedRegistryFormData.DataPath2020 = DataPath2020;
                        }
                        catchInfo = SharedRegistryFormData.MUnitPathLit;
                        o = key.GetValue(SharedRegistryFormData.MUnitPathLit);
                        if (o != null)
                        {
                            MUnitFolder = o.ToString();
                            SharedRegistryFormData.MUnitPath = MUnitFolder;
                        }
                        catchInfo = SharedRegistryFormData.AppPathLit;
                        o = key.GetValue(SharedRegistryFormData.AppPathLit);
                        if (o != null)
                        {
                            EplexAppPath = o.ToString();
                            SharedRegistryFormData.AppPath = EplexAppPath;
                        }
                        catchInfo = "Get " + SharedRegistryFormData.EplexDataEncryptionLit;
                        o = key.GetValue(SharedRegistryFormData.EplexDataEncryptionLit);
                        if (o != null)
                        {
                            string EplexDataEncryptionRegistry = o.ToString();
                            if (EplexDataEncryptionRegistry.ToUpper().Trim() == "FALSE")
                                SharedRegistryFormData.EplexDataEncryption = false;
                            else
                                SharedRegistryFormData.EplexDataEncryption = true;
                        }
                        else
                        {
                            catchInfo = "Set " + SharedRegistryFormData.EplexDataEncryptionLit;
                            key.SetValue(SharedRegistryFormData.EplexDataEncryptionLit, "True");
                            SharedRegistryFormData.EplexDataEncryption = true;
                        }
                        catchInfo = SharedRegistryFormData.LatestReportFileLit;
                        o = key.GetValue(SharedRegistryFormData.LatestReportFileLit);
                        if (o != null)
                        {
                            RegistryEntry = o.ToString();
                            SharedRegistryFormData.LatestReportFile = RegistryEntry;
                        }
                        else
                        {
                            SharedRegistryFormData.LatestReportFile = LatestReportFileName;
                        }
                        catchInfo = SharedRegistryFormData.LatestReportPathLit;
                        o = key.GetValue(SharedRegistryFormData.LatestReportPathLit);
                        if (o != null)
                        {
                            RegistryEntry = o.ToString();
                            SharedRegistryFormData.LatestReportPath = RegistryEntry;
                        }
                        else
                        {
                            MyDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                            SharedRegistryFormData.LatestReportPath = MyDocumentsPath + @"\" + @"Eplex Reports\";
                        }
                    }
                }
            }
            catch (Exception e1)  
            {
                catchData = "GetRegistryInfo - Key: " + catchInfo + " " + e1.Message;
            }

            string CmdLineParm = "";
            if (args.Length > 1)
            {
                CmdLineParm = args[1];
            }
            SharedRegistryFormData.Test = false;
            if (DemoPgm || CmdLineParm.ToUpper().Trim() == "TEST")
            {
                SharedRegistryFormData.Test = true;
                MyDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

                DataPath = MyDocumentsPath + @"\" + @"EplexDemo\";
                DataPath2020 = MyDocumentsPath + @"\" + @"EplexDemo\";
                SharedRegistryFormData.DataPath = DataPath;
                SharedRegistryFormData.DataPath2020 = DataPath2020;
                if (DemoPgm)
                {
                    EplexAppPath = DataPath2020;
                    SharedRegistryFormData.AppPath = DataPath2020;
                }
                MUnitFolder = DataPath2020 + @"Munit\";
                SharedRegistryFormData.MUnitPath = MUnitFolder;
                SharedRegistryFormData.LatestReportFile = LatestReportFileName;
                SharedRegistryFormData.LatestReportPath = MyDocumentsPath + @"\" + @"Eplex Reports\";

                return (DataPath: DataPath, DataPath2020: DataPath2020, MUnitFolder: MUnitFolder, EplexAppPath: EplexAppPath);
            }

            MyDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return (DataPath: DataPath, DataPath2020: DataPath2020, MUnitFolder: MUnitFolder, EplexAppPath: EplexAppPath);
        }
        public static SecurityIdentifier SID
        /***********************************************************************************************************************
        ** This gets the users SID
        ***********************************************************************************************************************/
        {
            get
            {
                WindowsIdentity identity = null;

                if (HttpContext.Current == null)
                {
                    identity = WindowsIdentity.GetCurrent();
                }
                else
                {
                    identity = HttpContext.Current.User.Identity as WindowsIdentity;
                }

                return identity.User;
            }
        }
        public void LoadDoorListbox()
        /***********************************************************************************************************************
        ** Loads the Door array to the listview control
        ***********************************************************************************************************************/
        {
            DoorListView.Items.Clear();
            DoorListView.GridLines = true;
            DoorListView.View = View.Details;
            DoorListView.Columns.Add("Name", 125);
            DoorListView.Columns.Add("ID", 45);
            DoorListView.Columns.Add("Function", 150);
            DoorListView.Columns[0].TextAlign = HorizontalAlignment.Center;
            DoorListView.Columns[1].TextAlign = HorizontalAlignment.Center;
            DoorListView.Columns[2].TextAlign = HorizontalAlignment.Left;

            //          Skip the 0 erntry
            for (int i = 0; i < Lock.Count; i++)
            {
                ListViewItem item1 = new ListViewItem(Lock[i].Name);

                //                ListViewItem item1 = new ListViewItem(Lock[i].Name);
                //                item1.SubItems.Add(Lock[i].Name);
                item1.SubItems.Add(Lock[i].ID);
                item1.SubItems.Add(Lock[i].Function);

                DoorListView.Items.AddRange(new ListViewItem[] { item1 });
                if (this.DoorListView.SelectedItems.Count == 0)
                {
                    if (SharedDoorData.LockSelectedPtr.Name == null)
                    {
                        SharedDoorData.LockSelectedPtr.Name = DoorListView.Items[0].Text;
                        DoorListView.Items[0].Selected = true;
                    }
                }
            }
        }
        public void LoadUserListbox()
        /***********************************************************************************************************************
        ** Loads the User array to the listview control
        ***********************************************************************************************************************/
        {
            UserListView.Clear();
            UserListView.GridLines = true;
            UserListView.View = View.Details;
            UserListView.Columns.Add("Num", 60);
            UserListView.Columns.Add("Code", 65);
            UserListView.Columns.Add("User Name", 175);
            UserListView.Columns.Add("User Type", 100);
            UserListView.Columns[0].TextAlign = HorizontalAlignment.Center;
            UserListView.Columns[1].TextAlign = HorizontalAlignment.Center;
            UserListView.Columns[2].TextAlign = HorizontalAlignment.Left;
            UserListView.Columns[3].TextAlign = HorizontalAlignment.Center;

            //          Skip the 0 erntry
            for (int i = 1; i <= MaxUsers; i++)
            {
                ListViewItem item1 = new ListViewItem(Users[i].Num.ToString("000"), 0);
                if (Users[i].Code == 0)
                {
                    // Skip it   item1.SubItems.Add("");
                }
                else
                {
                    item1.SubItems.Add(Users[i].Code.ToString());
                    item1.SubItems.Add(Users[i].Name);
                    item1.SubItems.Add(Users[i].Type);
                    UserListView.Items.AddRange(new ListViewItem[] { item1 });
                }
            }
        }
        public void LoadSiteListbox()
        /***********************************************************************************************************************
        ** Loads the Site list to the listview control
        ***********************************************************************************************************************/
        {
            SiteListView.Clear();
            SiteListView.GridLines = true;
            SiteListView.View = View.Details;
            SiteListView.Columns.Add("Sites", 150);
            SiteListView.Columns[0].TextAlign = HorizontalAlignment.Left;

            for (int i = 0; i < Sites.Count; i++)
            {
                ListViewItem item1 = new ListViewItem(Sites[i]);
                SiteListView.Items.AddRange(new ListViewItem[] { item1 });
                if (item1.Text == SharedDoorData.site)
                {
                    SiteListView.Items[i].Selected = true;
                    SiteListView.Select();
                }
            }

        }
        private void ToolBarUsers_Click(object sender, EventArgs e)
        /***********************************************************************************************************************
        ** Show and hides the user listview control
        ***********************************************************************************************************************/
        {
            if (UserListView.Visible)
            {
                UserListView.Visible = false;
            }
            else
            {
                UserListView.Visible = true;
            }
        }
        private void UserListView_DoubleClick(object sender, EventArgs e)
        /***********************************************************************************************************************
        ** Invokes the user maintenance dialog and keeps all data in sync
        ***********************************************************************************************************************/
        {
            if (Lock.Count == 0)
            {
                SystemSounds.Beep.Play();
                DialogResult OKFlag = MessageBox.Show("Please add door/lock information before users. ", "Warning", MessageBoxButtons.OK);
                return;
            }

            if (this.UserListView.SelectedItems.Count > 0)
            {
                int UsrNum = Int32.Parse(this.UserListView.SelectedItems[0].SubItems[0].Text);
                SharedUserData.num = Users[UsrNum].Num;
                SharedUserData.name = Users[UsrNum].Name;
                SharedUserData.code = Users[UsrNum].Code;
                SharedUserData.type = Users[UsrNum].Type;

                SharedUserData.NextRequested = false;
                SharedUserData.PrevRequested = false;
                if (this.UserListView.SelectedItems[0].Index == 0)
                {
                    SharedUserData.PrevButtonEnabled = false;
                }
                else
                {
                    SharedUserData.PrevButtonEnabled = true;
                }
                if (this.UserListView.SelectedItems[0].Index == UserListView.Items.Count - 1)
                {
                    SharedUserData.NextButtonEnabled = false;
                }
                else
                {
                    SharedUserData.NextButtonEnabled = true;
                }


                AddEditUsers();

                if (SharedUserData.Cancel == false)
                {
                    //******************************************************************************************************************
                    //* Update the Listview on the dialog 
                    //******************************************************************************************************************
                    ListViewItem selectedItem = UserListView.SelectedItems[0];
                    selectedItem.SubItems[0].Text = SharedUserData.num.ToString("000");
                    selectedItem.SubItems[1].Text = SharedUserData.code.ToString();
                    selectedItem.SubItems[2].Text = SharedUserData.name;
                    selectedItem.SubItems[3].Text = SharedUserData.type;
                    WriteEplexUserData(UserDataPathAndFile);
                }
            }
            else
            {
                DialogResult OKFlag = MessageBox.Show("Select a User to edit.", "Warning", MessageBoxButtons.OK);
            }


        }
        private void AddEditUsers()
        {
            SharedUserData.UserDictionaryPtr = UserDictionary;
            SharedUserData.ThisUserDoorListPtr = Users[SharedUserData.num].ThisUserDoorListPtr;
            SharedDoorData.LockListPtr = Lock;
            SharedDoorData.LockSelectedPtr = Lock[0];

            UserUpdateForm UserForm = new UserUpdateForm(SharedUserData, SharedDoorData, this);
            if (UserAddFlag)
            {
                UserForm.PrevUser.Enabled = false;
                UserForm.NextUser.Enabled = false;
            }
            this.Visible = false;
            UserForm.ShowDialog(this);
            this.Visible = true;

            if (SharedUserData.Cancel != true)
            {
                //******************************************************************************************************************
                //* Update the Users array 
                //******************************************************************************************************************
                //string TmpStr = SharedUserData.num.ToString("000");
                Users[SharedUserData.num].Num = SharedUserData.num;
                Users[SharedUserData.num].Name = SharedUserData.name;
                Users[SharedUserData.num].Code = SharedUserData.code;
                Users[SharedUserData.num].Type = SharedUserData.type;
                UserDictionary[SharedUserData.code] = SharedUserData.name;
            }


        }
        private void UserListView_KeyUp(object sender, KeyEventArgs e)
        /***********************************************************************************************************************
        ** Handles deleting a user
        ***********************************************************************************************************************/
        {
            if (e.KeyCode == Keys.Delete)
            {
                UserDeleteButton_Click(sender, e);
            }
        }
        private void ToolBarSites_Click(object sender, EventArgs e)
        /***********************************************************************************************************************
        ** Show and hides the Sites listview control
        ***********************************************************************************************************************/
        {
            if (SiteListView.Visible)
            {
                SiteListView.Visible = false;
            }
            else
            {
                SiteListView.Visible = true;
            }
        }

        private void ToolBarDoors_Click(object sender, EventArgs e)
        /***********************************************************************************************************************
        ** Show and hides the Sites listview control
        ***********************************************************************************************************************/
        {
            {
                if (DoorListView.Visible)
                {
                    DoorListView.Visible = false;
                }
                else
                {
                    DoorListView.Visible = true;
                }
            }
        }
        private void UserEditButton_Click(object sender, EventArgs e)
        /***********************************************************************************************************************
        ** Edit the selected User.
        ***********************************************************************************************************************/
        {
            UserListView_DoubleClick(sender, e);
        }

        private void UserListView_MouseClick(object sender, MouseEventArgs e)
        /***********************************************************************************************************************
        ** Activate the user buttons.
        ***********************************************************************************************************************/
        {
            UserAddButton.Enabled = true;
            UserEditButton.Enabled = true;
            UserDeleteButton.Enabled = true;
        }

        private void UserDeleteButton_Click(object sender, EventArgs e)
        /***********************************************************************************************************************
        ** Delete the selected user
        ***********************************************************************************************************************/
        {
            if (this.UserListView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = UserListView.SelectedItems[0];
                DialogResult YNFlag = MessageBox.Show("Do you want to delete " + selectedItem.SubItems[1].Text + " for " + selectedItem.SubItems[2].Text, "Confirm Delete", MessageBoxButtons.YesNo);
                if (YNFlag == DialogResult.Yes)
                {
                    int UsrNum = Int32.Parse(this.UserListView.SelectedItems[0].SubItems[0].Text);
                    UserDictionary.Remove(Users[UsrNum].Code);
                    Users[UsrNum].Name = "";
                    Users[UsrNum].Code = 0;
                    Users[UsrNum].Type = "";
                    UserListView.SelectedItems[0].Remove();

                    WriteEplexUserData(UserDataPathAndFile);
                    //******************************************************************************************************************
                    //* Update the Listview on the dialog 
                    //******************************************************************************************************************
                    selectedItem.SubItems[1].Text = "0";
                    selectedItem.SubItems[2].Text = "";
                    selectedItem.SubItems[3].Text = "";
                }
            }
            else
            {
                DialogResult OKFlag = MessageBox.Show("Select a User to delete ", "Warning", MessageBoxButtons.OK);
            }
        }
        private void UserAddButton_Click(object sender, EventArgs e)
        /***********************************************************************************************************************
        ** Add a user
        ***********************************************************************************************************************/
        {
            if (Lock.Count == 0)
            {
                SystemSounds.Beep.Play();
                DialogResult OKFlag = MessageBox.Show("Please add door/lock information before users. ", "Warning", MessageBoxButtons.OK);
                return;
            }
            if (DemoPgm)
            {
                /***********************************************************************************************************************
                ** Have to know the number of users for this door. This will build an array of users who have access to this door
                ***********************************************************************************************************************/
                var RealUsers = Users
                    .Where(x => (x.Name.Trim() != "") )
                    .OrderBy(x => x.Name);
                if (RealUsers.Count() > 4)
                {
                    SystemSounds.Beep.Play();
                    DialogResult OKFlag = MessageBox.Show("Only 5 users allowed in demo mode. ", "Warning", MessageBoxButtons.OK);
                    return;
                }
            }

            UserAddFlag = true;
            for (int i = 1; i <= MaxUsers; i++)
            {
                if (Users[i].Code == 0)
                {
                    SharedUserData.num = i;
                    break;
                }
            }
            SharedUserData.name = "";
            SharedUserData.code = 0;
            SharedUserData.type = "";
            AddEditUsers();

            if (SharedUserData.Cancel == false)
            {
                //******************************************************************************************************************
                //* Add an entry in the ListView dialog 
                //******************************************************************************************************************
                ListViewItem item1 = new ListViewItem(SharedUserData.num.ToString("000"), 0);
                item1.SubItems.Add(SharedUserData.code.ToString());
                item1.SubItems.Add(SharedUserData.name);
                item1.SubItems.Add(SharedUserData.type);
                UserListView.Items.AddRange(new ListViewItem[] { item1 });

                WriteEplexUserData(UserDataPathAndFile);
                UserAddFlag = false;
            }

        }
        private void ExitButton_Click(object sender, EventArgs e)
        /***********************************************************************************************************************
        ** Leave, stop the program
        ***********************************************************************************************************************/
        {
            WriteEplexAppStateData(SaveStateDataPathAndFile);
            Form tmp = this.FindForm();
            tmp.Close();
            tmp.Dispose();
        }
        private void DoorAddButton_Click(object sender, EventArgs e)
        {
            if (Sites.Count == 0)
            {
                SystemSounds.Beep.Play();
                DialogResult OKFlag = MessageBox.Show("Please add site information before doors. ", "Warning", MessageBoxButtons.OK);
                return;
            }


            SharedDoorData.Cancel = false;
            DoorLock.Name = "%%!!%%ADD";  // Indicates to the DoorLorkForm that this is an add
            DoorLock.ID = "";
            DoorLock.Function = "";
            DoorLock.AuditFlags = new bool[34];
            SharedDoorData.LockSelectedPtr = DoorLock;
            SharedDoorData.LockListPtr = Lock;
            SharedDoorData.LockFunctionsPtr = LockFunctions;
            SharedDoorData.LockSelectedPtr.AuditFlagDictionary = AuditDictionary;
            SharedDoorData.AddInProgress = true;
            LoadAuditDictionary();

            DoorLockForm DoorForm = new DoorLockForm(SharedDoorData);
            this.Visible = false;
            DoorForm.ShowDialog(this);
            this.Visible = true;

            if (SharedDoorData.Cancel == false)
            {
                //******************************************************************************************************************
                //* Update the Doors array 
                //******************************************************************************************************************
                Lock.Add(SharedDoorData.LockSelectedPtr);

                //******************************************************************************************************************
                //* Update the Listview on the dialog 
                //******************************************************************************************************************
                ListViewItem item1 = new ListViewItem(SharedDoorData.LockSelectedPtr.Name);
                item1.SubItems.Add(SharedDoorData.LockSelectedPtr.ID);
                item1.SubItems.Add(SharedDoorData.LockSelectedPtr.Function);
                DoorListView.Items.AddRange(new ListViewItem[] { item1 });
                EstablishPaths();

                WriteEplexLockData(LockDataPathAndFile);
            }

        }

        private void DoorEditButton_Click(object sender, EventArgs e)
        {
            MouseEventArgs e1 = new MouseEventArgs(MouseButtons.Left, 1, 1, 1, 1);
            DoorListView_MouseDoubleClick(sender, e1);
        }
        private void EditDoorDataSetup(ref int DoorIndex)
        {
            string name = this.DoorListView.SelectedItems[0].Text;
            DoorIndex = FindDoorListEntry(name);
            SharedDoorData.DoorRowSelected = DoorIndex;
            DoorLock = Lock[DoorIndex];
            SharedDoorData.LockSelectedPtr = DoorLock;
            SharedDoorUserData.LockSelectedPtr = DoorLock;
            SharedDoorData.LockListPtr = Lock;
            SharedDoorData.LockFunctionsPtr = LockFunctions;
            SharedDoorData.LockSelectedPtr.AuditFlagDictionary = AuditDictionary;

        }
        private void EditDoorData(ref int DoorIndex)
        {
            string saveDoorName = SharedDoorData.LockSelectedPtr.Name;
            DoorLockForm DoorForm = new DoorLockForm(SharedDoorData);
            this.Visible = false;
            DoorForm.ShowDialog(this);
            this.Visible = true;
            if (SharedDoorData.Cancel == false)
            {
                //******************************************************************************************************************
                //* Update the Doors array 
                //******************************************************************************************************************
                Lock[DoorIndex] = SharedDoorData.LockSelectedPtr;

                //******************************************************************************************************************
                //* Update the Listview on the dialog 
                //******************************************************************************************************************
                ListViewItem selectedItem = DoorListView.SelectedItems[0];
                selectedItem.SubItems[0].Text = SharedDoorData.LockSelectedPtr.Name;
                selectedItem.SubItems[1].Text = SharedDoorData.LockSelectedPtr.ID;
                selectedItem.SubItems[2].Text = SharedDoorData.LockSelectedPtr.Function;
                WriteEplexLockData(LockDataPathAndFile);
                DoorChgUpdateUsers(saveDoorName, DoorActionEdit);
            }
        }
        private void DoorChgUpdateUsers(string saveDoorName, string DoorAction)
        {
            if ((saveDoorName != SharedDoorData.LockSelectedPtr.Name && DoorAction == DoorActionEdit) || DoorAction == DoorActionDelete)
            {
                foreach (UserAccessInfo user in Users)
                {
                    int userDoorIndex = user.ThisUserDoorListPtr.FindIndex(a => a == saveDoorName);

                    if (userDoorIndex > -1)
                    {
                        user.ThisUserDoorListPtr.RemoveAt(userDoorIndex);
                        if (DoorAction == DoorActionEdit)
                            user.ThisUserDoorListPtr.Add(SharedDoorData.LockSelectedPtr.Name);
                    }
                }
                WriteEplexUserData(UserDataPathAndFile);
            }
        }

        private void DoorListView_MouseDoubleClick(object sender, MouseEventArgs e)
        /***********************************************************************************************************************
        ** Invokes the Doorlock maintenance dialog and keeps all data in sync
        ***********************************************************************************************************************/
        {
            int DoorIndex = 0;
            if (this.DoorListView.SelectedItems.Count > 0)
            {
                SharedDoorData.AddInProgress = false;
                EditDoorDataSetup(ref DoorIndex);
                EditDoorData(ref DoorIndex);
            }
            else
            {
                DialogResult OKFlag = MessageBox.Show("Select a Door to edit ", "Warning", MessageBoxButtons.OK);
            }
        }
        public int FindDoorListEntry(string name)
        {
            int index = Lock.FindIndex(a => a.Name == name);

            return index;
        }

        private void SiteListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SiteListView.SelectedItems.Count == 0)
                return;

            ListViewItem item = this.SiteListView.SelectedItems[0];
            SharedDoorData.site = item.Text;
            RefreshLockAndUser();


        }

        private void UserListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {

            DetermineSortOrder(UserListViewColumnSorter, e);
            this.UserListView.Sort();
        }

        private void DoorListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            DetermineSortOrder(DoorListViewColumnSorter, e);
            this.DoorListView.Sort();
        }
        private void SiteListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            DetermineSortOrder(SiteListViewColumnSorter, e);
            this.SiteListView.Sort();

        }
        private void DetermineSortOrder(ListViewColumnSorter ColSorterInstance, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == ColSorterInstance.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (ColSorterInstance.Order == SortOrder.Ascending)
                {
                    ColSorterInstance.Order = SortOrder.Descending;
                }
                else
                {
                    ColSorterInstance.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                ColSorterInstance.SortColumn = e.Column;
                ColSorterInstance.Order = SortOrder.Ascending;
            }
        }

        private void DoorCopyButton_Click(object sender, EventArgs e)
        {
            int DoorIndex = 0;
            if (this.DoorListView.SelectedItems.Count > 0)
            {
                EditDoorDataSetup(ref DoorIndex);
                DoorCopyForm DoorCopyForm = new DoorCopyForm(SharedDoorData);
                this.Visible = false;
                DoorCopyForm.ShowDialog(this);
                this.Visible = true;
                if (SharedDoorData.Cancel == false)
                {
                    //******************************************************************************************************************
                    //* Add the new door to the Doors array 
                    //******************************************************************************************************************
                    LockSettings NewLock = new LockSettings();
                    NewLock = Lock[DoorIndex];
                    NewLock.Name = SharedDoorData.LockSelectedPtr.Name;
                    NewLock.ID = SharedDoorData.LockSelectedPtr.ID;
                    Lock.Add(NewLock);

                    //******************************************************************************************************************
                    //* Update the Listview on the dialog 
                    //******************************************************************************************************************

                    ListViewItem item1 = new ListViewItem(Lock[Lock.Count - 1].Name);
                    item1.SubItems.Add(Lock[Lock.Count - 1].ID);
                    item1.SubItems.Add(Lock[Lock.Count - 1].Function);

                    DoorListView.Items.AddRange(new ListViewItem[] { item1 });
                    WriteEplexLockData(LockDataPathAndFile);

                }
            }
            else
            {
                DialogResult OKFlag = MessageBox.Show("Select a Door to copy ", "Warning", MessageBoxButtons.OK);
            }
        }

        private void DoorDeleteButton_Click(object sender, EventArgs e)
        {
            /***********************************************************************************************************************
            ** Delete the selected door
            ***********************************************************************************************************************/
            {
                string saveDoorName = SharedDoorData.LockSelectedPtr.Name;
                if (this.DoorListView.SelectedItems.Count > 0)
                {
                    ListViewItem selectedItem = DoorListView.SelectedItems[0];
                    DialogResult YNFlag = MessageBox.Show("Do you want to delete " + selectedItem.SubItems[0].Text + " with ID " + selectedItem.SubItems[1].Text, "Confirm Delete", MessageBoxButtons.YesNo);
                    if (YNFlag == DialogResult.Yes)
                    {
                        saveDoorName = this.DoorListView.SelectedItems[0].Text;
                        int DoorIndex = FindDoorListEntry(saveDoorName);

                        Lock.RemoveAt(DoorIndex);

                        //******************************************************************************************************************
                        //* Update the Listview on the dialog 
                        //******************************************************************************************************************
                        DoorListView.SelectedItems[0].Remove();
                        WriteEplexLockData(LockDataPathAndFile);
                        DoorChgUpdateUsers(saveDoorName, DoorActionDelete);
                    }
                }
                else
                {
                    DialogResult OKFlag = MessageBox.Show("Select a User to delete ", "Warning", MessageBoxButtons.OK);
                }
            }

        }

        private void DoorListView_KeyUp_1(object sender, KeyEventArgs e)
        {
            /***********************************************************************************************************************
            ** Handles deleting a user
            ***********************************************************************************************************************/
            if (e.KeyCode == Keys.Delete)
            {
                DoorDeleteButton_Click(sender, e);
            }

        }

        private void SiteRenameButton_Click(object sender, EventArgs e)
        {
            /***********************************************************************************************************************
            ** Handles renaming a site
            ***********************************************************************************************************************/
            if (Sites.Count == 0)
            {
                SystemSounds.Beep.Play();
                DialogResult OKFlag = MessageBox.Show("Please add site information. ", "Warning", MessageBoxButtons.OK);
                return;
            }

            SharedSiteData.site = SiteListView.SelectedItems[0].Text;
            SharedSiteData.DialogFunction = "Rename";

            SiteName SiteNameForm = new SiteName(SharedSiteData);
            this.Visible = false;
            SiteNameForm.ShowDialog(this);
            this.Visible = true;
            if (SharedSiteData.Cancel == false)
            {
//                SiteDataPath = SharedSiteData.SiteDataPath;
                SiteDataPath2020 = SharedSiteData.SiteDataPath2020;
                SharedDoorData.site = SharedSiteData.site;
                ReadEplexSiteData(SiteDataPath2020);
                LoadSiteListbox();
            }

        }
        private void SiteAddButton_Click(object sender, EventArgs e)
        {
            /***********************************************************************************************************************
            ** Handles Adding a site
            ***********************************************************************************************************************/
            SharedSiteData.site = "";
            SharedSiteData.DialogFunction = "New";
            SiteName SiteNameForm = new SiteName(SharedSiteData);
            this.Visible = false;
            SiteNameForm.ShowDialog(this);
            this.Visible = true;
            if (SharedSiteData.Cancel == false)
            {
//                SiteDataPath = SharedSiteData.SiteDataPath;
                SiteDataPath2020 = SharedSiteData.SiteDataPath2020;
                SharedDoorData.site = SharedSiteData.site;
                ReadEplexSiteData(SiteDataPath2020);
                LoadSiteListbox();
            }
        }

        private void SiteDeleteButton_Click(object sender, EventArgs e)
        {
            if (Sites.Count == 0)
            {
                SystemSounds.Beep.Play();
                DialogResult OKFlag = MessageBox.Show("Please add site information. ", "Warning", MessageBoxButtons.OK);
                return;
            }
                if (this.SiteListView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = SiteListView.SelectedItems[0];
                DialogResult YNFlag = MessageBox.Show("Are you sure you want to delete this site: " + selectedItem.SubItems[0].Text + " This will delete all doors and users in the site.", "Confirm Delete", MessageBoxButtons.YesNo);
                if (YNFlag == DialogResult.Yes)
                {
                    SiteDataPath2020 = SharedSiteData.SiteDataPath2020;
                    String PathOnly = SiteDataPath2020 + @"\" + selectedItem.SubItems[0].Text;
                    try
                    {
                        Directory.Delete(PathOnly, true);
                        ReadEplexSiteData(SiteDataPath2020);
                        SiteListView.Visible = true;
                        LoadSiteListbox();
                    }
                    catch (Exception e1)
                    {
                        DialogResult OKFlag = MessageBox.Show(e1.Message, "Warning", MessageBoxButtons.OK);

                    }
                }

            }
        }

        private void SiteGenerateButton_Click(object sender, EventArgs e)
        {
            if (Sites.Count == 0)
            {
                SystemSounds.Beep.Play();
                DialogResult OKFlag = MessageBox.Show("Please add site information. ", "Warning", MessageBoxButtons.OK);
                return;
            }
                ListViewItem selectedItem = SiteListView.SelectedItems[0];
            string SiteName = selectedItem.SubItems[0].Text;

            string CtrlRec = "";
            string UserRec = "";
            string UsrTyp = "";

            string MUnitDataPath = MUnitFolder + @"EPLEX5000_UPLOAD.txt";
            string MunitPathOnly = Path.GetDirectoryName(MUnitDataPath);

            if (Directory.Exists(MunitPathOnly))
            {
                // OK, great
            }
            else
            {
                try
                {
                    DirectoryInfo di = Directory.CreateDirectory(MunitPathOnly);
                }
                catch (Exception e1)
                {
                    DialogResult OKFlag = MessageBox.Show(e1.Message, "Unexpected Error", MessageBoxButtons.OK);
                }
            }

            StreamWriter MUnitPathAndFileName = new StreamWriter(MUnitDataPath);
            using (MUnitPathAndFileName)

                foreach (LockSettings Door in Lock)
                {
                    /***********************************************************************************************************************
                    ** Have to know the number of users for this door. This will build an array of users who have access to this door
                    ***********************************************************************************************************************/
                    var RealUsers = Users
                        .Where(x => (x.Name.Trim() != "") && (x.ThisUserDoorListPtr.FindIndex(a => a == Door.Name) > -1))
                        .OrderBy(x => x.Name);
                    // Lock.FindIndex(a => a.Name == name)

                    MUnitPathAndFileName.WriteLine(Door.SourceFile);
                    if (Door.Function.Trim() == "Latch Holdback")
                    {
                        CtrlRec = $"09\tD\tD\t{Door.AccessCodeLength}\t{Door.UnlockTime.ToString("00")}\t{Door.TamperShutdownTime.ToString("00")}\t{Door.TamperCount}\t{Door.BuzzerVolume}\t{Door.ID}\t-49\tD\t54\t{SiteName}\t{Door.Name}\t{RealUsers.Count().ToString("00")}\tE\t9";
                    }
                    if (Door.Function.Trim() == "Entry Lock with Passage (Cylindrical, Mortise without deadbolt)")
                    {
                        CtrlRec = $"09\tD\tD\t{Door.AccessCodeLength}\t{Door.UnlockTime.ToString("00")}\t{Door.TamperShutdownTime.ToString("00")}\t{Door.TamperCount}\t{Door.BuzzerVolume}\t{Door.ID}\t-64\tD\t04\t{SiteName}\t{Door.Name}\t{RealUsers.Count().ToString("00")}\tF\t11";
                    }
                    MUnitPathAndFileName.WriteLine(CtrlRec);

                    foreach (UserAccessInfo User in RealUsers)  //Was originally going through all Users
                    {
                        var item = User.ThisUserDoorListPtr.Find(x => x == Door.Name);  // Look for this door in the this users list of doors
                        if (item != null)
                        {
                            if (User.Code != 0)
                            {
                                if (User.Type.ToUpper() == "MANAGER")
                                {
                                    UsrTyp = "1";
                                }
                                else
                                {
                                    UsrTyp = "0";
                                }
                                UserRec = $"{User.Num.ToString("000")}\t{User.Code.ToString("00000000")}\t{UsrTyp}\t001\tFF";
                                MUnitPathAndFileName.WriteLine(UserRec);
                            }
                        }
                    }
                }
            MUnitPathAndFileName.Close();

            SharedPCMUnitData.PCMUnitDataPath = MUnitDataPath;
            SharedPCMUnitData.Cancel = false;
            PCMUnitConfirmForm PCMUnitForm = new PCMUnitConfirmForm(SharedPCMUnitData);
            this.Visible = false;
            PCMUnitForm.ShowDialog(this);
            this.Visible = true;

        }

        private void DoorUsersButton_Click(object sender, EventArgs e)
        {
            /***********************************************************************************************************************
            ** Handles listing all users for the selected door
            ***********************************************************************************************************************/
            if (Sites.Count == 0)
            {
                SystemSounds.Beep.Play();
                DialogResult OKFlag = MessageBox.Show("Please add site information. ", "Warning", MessageBoxButtons.OK);
                return;
            }

            SharedDoorUserData.Cancel = false;

            if (this.DoorListView.SelectedItems.Count == 0)
            {
                this.DoorListView.Items[0].Selected = true;
            }
            if (this.DoorListView.SelectedItems.Count > 0)
            {
                ListViewItem item = this.DoorListView.SelectedItems[0];
                SharedDoorUserData.LockListPtr = Lock;
                SharedDoorUserData.LockSelectedPtr = Lock[FindDoorListEntry(DoorListView.SelectedItems[0].SubItems[0].Text)];
                SharedDoorUserData.site = SharedDoorData.site;
                SharedDoorUserData.Users = Users;
                SharedDoorUserData.DoorRowSelected = DoorListView.SelectedItems[0].Index;

                DoorUsersForm DoorUsersNameForm = new DoorUsersForm(SharedDoorUserData, this);
                this.Visible = false;
                DoorUsersNameForm.ShowDialog(this);
                this.Visible = true;
                if (SharedDoorUserData.Cancel == false)
                {
                    WriteEplexUserData(UserDataPathAndFile);
                }
            }
            else
            {
                DialogResult OKFlag = MessageBox.Show("Select a Door to work with the users for a door.", "Warning", MessageBoxButtons.OK);
            }

        }

        private void fileLocationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /***********************************************************************************************************************
            ** Open the files dialog
            ***********************************************************************************************************************/
            RegistrySettingsForm PCMUnitForm = new RegistrySettingsForm(SharedRegistryFormData, DemoPgm);
            this.Visible = false;
            PCMUnitForm.ShowDialog(this);
            this.Visible = true;

        }

        private void fileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            /***********************************************************************************************************************
            ** Open file explorer to the data paths
            ***********************************************************************************************************************/
            Process.Start(SiteDataPath2020);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /***********************************************************************************************************************
            ** Set up a destination for the report file
            ***********************************************************************************************************************/
            //reportPath = MyDocumentsPath + @"\" + ReportFPath;
            reportPath = DataPath2020 + ReportFPath;
            if (Directory.Exists(reportPath))
            {
                // OK, great
            }
            else
            {
                try
                {
                    DirectoryInfo di = Directory.CreateDirectory(reportPath);
                }
                catch (Exception e1)
                {
                    DialogResult OKFlag = MessageBox.Show(e1.Message, "Unexpected Error", MessageBoxButtons.OK);
                }
            }

            printDoorsAndUsers = new PrintDoorsAndUsers(reportPath, SharedSiteData, SharedUserData, SharedDoorData, Users, Lock, SharedRegistryFormData, this);
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(printDoorsAndUsers.WriteTheReport);
            worker.RunWorkerAsync(this);


        }

        public void reportFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /***********************************************************************************************************************
            ** Open file explorer to the data paths
            ***********************************************************************************************************************/
            reportPath = DataPath2020 + ReportFPath;
            if (Directory.Exists(reportPath))
            {
                // OK great!
            }
            else
            {
                reportPath = DataPath2020;
            }
            Process.Start(reportPath);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitButton_Click(sender, e);
        }
        private void LoadAuditDictionary()
        {
            /***********************************************************************************************************************
            ** Load the Audit flag literals into a dictionary along with their position in the Lock definition structure
            ***********************************************************************************************************************/
            int i = -1;

            List<string> AuditFlagList = new List<string>()
            {
                "ACCESS",
                "ADD ACCESS USER",
                "ENABLE ACCESS USER",
                "DISABLE ACCESS USER",
                "DELETE ACCESS USER",
                "MANAGER",
                "ADD MANAGER USER",
                "ENABLE MANAGER USER",
                "DISABLE MANAGER USER",
                "DELETE MANAGER USER",
                "SERVICE",
                "ADD SERVICE USER",
                "ENABLE SERVICE USER",
                "DISABLE SERVICE USER",
                "DELETE SERVICE USER",
                "ALL USERS",
                "ENABLE ALL USERS",
                "DISABLE ALL USERS",
                "DELETE ALL USERS",
                "M-UNIT USER",
                "M-UNIT USER'S COMBINATION MODIFIED",
                "ACTIVATE M-UNIT USER",
                "DEACTIVATE M-UNIT USER",
                "PASSAGE & LOCKOUT MODE",
                "ENABLE PASSAGE MODE",
                "DISABLE PASSAGE MODE",
                "ENABLE LOCKOUT MODE",
                "DISABLE LOCKOUT MODE",
                "DEADBOLT MODE",
                "DEADBOLT ENGAGED MODE",
                "DEADBOLT RETRACTED MODE",
                "LATCH HOLDBACK",
                "DOOR LOCK",
                "DOOR UNLOCK"
            };
            i = -1;
            foreach (string AF in AuditFlagList)
            {
                i++;
                AuditDictionary[AF] = i;
            }
            int x1 = 1;
        }
        private void buildAuditFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /***********************************************************************************************************************
            ** Drive te audit report build and the progress bar.
            ***********************************************************************************************************************/
            SharedDoorData.LockListPtr = Lock;
            reportPath = DataPath2020;


            printAudit = new PrintAudit(reportPath, SharedSiteData, SharedUserData, SharedDoorData, Users, Lock, this);

            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(printAudit.BuildAuditReport);
            worker.RunWorkerAsync(this);

        }

        private void generatePCMUnitFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SiteGenerateButton_Click(sender, e);
        }

        private void AbortButton_Click(object sender, EventArgs e)
        {
            AbortAuditReport = true;
            Invoke(new PrintAudit.BuildAuditDoorChange(printAudit.BuildAuditDoorOnChange), "Abort Scheduled", 90, 100);
            Invoke(new PrintAudit.BuildAuditEventsChange(printAudit.BuildAuditEventsOnChange), "Abort Scheduled", 90, 100);
        }

        private void DoorUserAbortButton_Click(object sender, EventArgs e)
        {
            DoorUserAbort = true;
            Invoke(new PrintDoorsAndUsers.WriteReportChange(printDoorsAndUsers.WriteReportOnChange), "Abort Scheduled", 90, 100);

        }

        private void RenameButton_Click(object sender, EventArgs e)
        {
            if (this.DoorListView.SelectedItems.Count > 0)
            {
                int DoorIndex=0;
                SharedDoorUserData.Users = Users;
                SharedDoorData.LockListPtr = Lock;
                EditDoorDataSetup(ref DoorIndex);
                RenameDoorForm DoorRenameForm = new RenameDoorForm(SharedDoorData, SharedDoorUserData,this);
                this.Visible = false;
                DoorRenameForm.ShowDialog(this);
                this.DoorListView.SelectedItems[0].Text = DoorRenameForm.NewDoorName.Text;
                this.Visible = true;

                SharedDoorData.LockSelectedPtr.Name = DoorRenameForm.NewDoorName.Text;
                int index1 = Lock.FindIndex(a => a.Name == DoorRenameForm.DoorName.Text);
                if (index1 > -1)
                {
                    Lock.RemoveAt(index1);
                    Lock.Add(SharedDoorData.LockSelectedPtr);
                    WriteEplexLockData(SharedDoorData.LockDataPathAndFile);
                    foreach (UserAccessInfo User in SharedDoorUserData.Users)
                    {
                        if (User.Code > 0)
                        {
                            int index = User.ThisUserDoorListPtr.FindIndex(a => a == DoorRenameForm.DoorName.Text);
                            if (index > -1)
                            {
                                User.ThisUserDoorListPtr.RemoveAt(index);
                                User.ThisUserDoorListPtr.Add(DoorRenameForm.NewDoorName.Text);
                            }
                        }
                    }
                    WriteEplexUserData(SharedDoorUserData.UserDataPathAndFile);
                }
            }
            else
            {
                DialogResult OKFlag = MessageBox.Show("Select a Door to rename.", "Warning", MessageBoxButtons.OK);
            }

        }
    }
}
