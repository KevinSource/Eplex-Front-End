using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;



namespace Eplex_Front_End
{
    using Microsoft.Office.Interop.Excel;
    using _Excel = Microsoft.Office.Interop.Excel;
    using System.IO;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using System.Diagnostics;

    public class Excel
    {
        /***********************************************************************************************************************
        ** Set up to use Excel for printing
        ***********************************************************************************************************************/
        string path = "";
        int sheet = 1;
        _Application excel = new _Excel.Application();
        Workbook wb;
        Worksheet ws;
        public EplexLockManagement ParentForm;
        public string catchData="";
        public Int32 ExcelHwnd;


        public Excel(string path, int sheet, EplexLockManagement _ParentForm)
        {
            this.path = path;
            this.sheet = sheet;
            ParentForm = _ParentForm;
            ExcelHwnd = excel.Hwnd;
        }
        public Worksheet Open(string path, int sheet)
        {
            String PathOnly = Path.GetDirectoryName(path);
            string FileNameOnly = Path.GetFileName(path);
            try
            {
                DirectoryInfo di = Directory.CreateDirectory(PathOnly);
            }
            catch
            {
                catchData = "excel.Worksheet directory create error: " + path;
            }

            wb = excel.Workbooks.Add();
            ws = wb.Worksheets[sheet];
            return ws;
        }
        public void Visible(bool V_Flag)
        {
            excel.Visible = V_Flag;
        }
        public Worksheet newSheet(string SheetName, Worksheet After)
        {
            Worksheet newworksheet;
            if (After == null)
            {
                newworksheet = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets.Add();
            }
            else
            {
                newworksheet = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets.Add(After:After);
            }
            int tryTimes = 1;
            while (tryTimes < 31)
            {
                try
                {
                    newworksheet.Name = SheetName;
                    break;
                }
                catch (Exception e1)
                {
                    catchData = "excel.newSheet Name: " + SheetName + e1.Message;
                    SheetName = SheetName + tryTimes.ToString();
                    tryTimes++;
                }
            }
 
            ws = newworksheet;
            return ws;

        }
        public void renameSheet(int sheetNum, string sheetName)
        {
            wb.Worksheets[sheetNum].name = sheetName;

        }
        public string ReadCell(int i, int j)
        {
            if (ws.Cells[i, j].Value2 != null)
            {
                return ws.Cells[i, j].Value2;
            }
            else
            {
                return "";
            }
        }
        public void WriteCell(int i, int j, string valueIn)
        {
            ws.Cells[i, j].Value = valueIn;
        }
        public void WriteList(int startRow, int startColumn, List<AuditExcelRow> txnList)
        {
            ws.Cells[startRow, startColumn].InsertTable(txnList);
        }
        public void WriteArray<T>(int startRow, int startColumn, T[,] array)
        {
            var row = array.GetLength(0);
            var col = array.GetLength(1);
            Range c1 = (Range)ws.Cells[startRow, startColumn];
            Range c2 = (Range)ws.Cells[startRow + row - 1, startColumn + col - 1];
            Range range = ws.Range[c1, c2];
            range.Value = array;
        }    
        public void GrayCell(int FromRow, int FromCol, int ToRow=0,int ToCol=0)
        {
            if (ToRow == 0)
            {
                ToRow = FromRow;
                ToCol = FromCol;
            }

            Range GrayRng = ws.Range[ws.Cells[FromRow, FromCol], ws.Cells[ToRow, ToCol]];
            GrayRng.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
            GrayRng.Interior.Pattern = Microsoft.Office.Interop.Excel.Constants.xlSolid;
            GrayRng.Interior.Pattern = _Excel.Constants.xlSolid;
            GrayRng.Interior.PatternColorIndex = _Excel.Constants.xlAutomatic;

        }
        public void ColumnWidth(int FromCol, int ToCol, int Width)
        {
            /***********************************************************************************************************************
            ** Pass 0 to autofit
            ***********************************************************************************************************************/
            if (Width == 0)
            {
                // ws.Cells[FromCol, ToCol].EntireColumn.autofit();
                ws.Range[ws.Cells[1, FromCol], ws.Cells[1, ToCol]].EntireColumn.autofit();
            }
            else
            {
                ws.Range[ws.Cells[1, FromCol], ws.Cells[1, ToCol]].columnWidth = Width;
            }

        }
        public void Save()
        {
            wb.Save();
        }
        public void Alignment(string align, int from_r, int from_c, int to_r=0, int to_c=0)
        {
            //*************************************************************************************************
            //* to_r and to_c are optional. The caller can just pass a single cell, no problem
            //*************************************************************************************************
            int alignIt = 0;
            if (to_r == 0)
            {
                to_r = from_r;
                to_c = from_c;
            }

            switch (align.ToUpper())
            {
                case "LEFT":
                    alignIt = (int)_Excel.XlHAlign.xlHAlignLeft;
                    break;
                case "CENTER":
                    alignIt = (int)_Excel.XlHAlign.xlHAlignCenter;
                    break;
                case "RIGHT":
                    alignIt = (int)_Excel.XlHAlign.xlHAlignRight;
                    break;
                case "CENTERACROSSSELECTION":
                    alignIt = (int)_Excel.XlHAlign.xlHAlignCenterAcrossSelection;
                    break;
                default:
                    alignIt = (int) _Excel.XlHAlign.xlHAlignLeft;
                    break;
            }

            _Excel.Range WorkingRng = ws.Range[ws.Cells[from_r, from_c], ws.Cells[to_r, to_c]];
            WorkingRng.HorizontalAlignment = alignIt;

        }
        public void Borders(int from_r, int from_c, int to_r=0, int to_c=0)
        {
            //*************************************************************************************************
            //* to_r and to_c are optional. The caller can just pass a single cell, no problem
            //*************************************************************************************************
            if (to_r == 0)
            {
                to_r = from_r;
                to_c = from_c;
            }

            _Excel.Range WorkingRng = ws.Range[ws.Cells[from_r, from_c], ws.Cells[to_r, to_c]];
            WorkingRng.Borders[_Excel.XlBordersIndex.xlEdgeLeft].LineStyle = _Excel.XlLineStyle.xlContinuous;
            WorkingRng.Borders[_Excel.XlBordersIndex.xlEdgeTop].LineStyle = _Excel.XlLineStyle.xlContinuous;
            WorkingRng.Borders[_Excel.XlBordersIndex.xlEdgeBottom].LineStyle = _Excel.XlLineStyle.xlContinuous;
            WorkingRng.Borders[_Excel.XlBordersIndex.xlEdgeRight].LineStyle = _Excel.XlLineStyle.xlContinuous;
            WorkingRng.Borders[_Excel.XlBordersIndex.xlInsideVertical].LineStyle = _Excel.XlLineStyle.xlContinuous;
            WorkingRng.Borders[_Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = _Excel.XlLineStyle.xlContinuous;

        }
        public void Merge(int from_r, int from_c, int to_r, int to_c)
        {
            ws.Range[ws.Cells[from_r, from_c], ws.Cells[to_r, to_c]].Merge();
        }
        public void Activate(Worksheet sht)
        {
            sht.Activate();
        }
        public void PageNumbers()
        {
            ws.PageSetup.CenterFooter = @"Page &P";
        }
        public void RowToRepeatAtTop(int StartRow, int EndRow=0)
        {
            if (EndRow == 0) EndRow = StartRow;
            string RowRange = $"${StartRow.ToString()}:${EndRow.ToString()}";
            
            ws.PageSetup.PrintTitleRows = RowRange;
        }
        public void FitToPage(int Wide, int Tall=0)
        {
            excel.Application.PrintCommunication = false;
            ws.PageSetup.FitToPagesWide = 1;
            if (Tall == 0)
                ws.PageSetup.FitToPagesTall = false;
            else
                ws.PageSetup.FitToPagesTall = Tall;
            excel.Application.PrintCommunication = true;
        }
        public void SaveAS()
        {
            /// Test code path = @"C:\Users\Public\Documents\Bat\2020-04-13 Audit Report.xlsx";
            if (File.Exists(path))
            {
                
                try
                {
                    File.Delete(path);
                }
                catch (IOException e1)
                {
                    catchData = "Getting unique file name - excel.SaveAS Name: " + path + e1.Message;
                    int fNum = 0;
                    String PathOnly = Path.GetDirectoryName(path);
                    string FileNameOnly = Path.GetFileName(path);
                    PathOnly = Path.GetDirectoryName(path);
                    FileNameOnly = Path.GetFileName(path);
                    while (File.Exists(path))
                    {
                        fNum++;
                        string newFName = FileNameOnly.Substring(0, FileNameOnly.Length - 5) + fNum.ToString().Trim() + ".xlsx";
                        path = Path.Combine(PathOnly , newFName);
                    }
                    ParentForm.reportPathAndFileName = path;
                }
            }
            try
            {
                
                excel.DisplayAlerts = false;
                //wb.SaveAs(Filename:path, FileFormat:_Excel.XlFileFormat.xlWorkbookDefault, AddToMru: true);
                wb.SaveCopyAs(Filename: path);
            }
            catch (Exception e1)
            {
                catchData = "SaveCopyAs 1 failed - excel.SaveAS Name: " + path + e1.Message;
                try
                {
                    excel.DisplayAlerts = false;
                    wb.SaveCopyAs(Filename: path);
                }
                catch (Exception e2)
                {
                    catchData = "SaveCopyAs 2 failed - excel.SaveAS Name: " + path + e1.Message;
                    try
                    {
                        excel.DisplayAlerts = false;
                        wb.Save();
                    }
                    catch (Exception e3)
                    {
                        catchData = "Save failed - excel.SaveAS Name: " + path + e1.Message;
                    }
                }
            }
            }
        public void Close(bool SaveChanges=true)
        {
//            IntPtr ExcelHwnd = (IntPtr)excel.Hwnd;
            excel.DisplayAlerts = false;
            if (wb != null)
            {
                wb.Close(SaveChanges);
            }
            ws = null;
            wb = null;

        }
        public void Quit()
        {
            excel.Quit();
        }
        public void Kill()
        {
            Process[] localExcel = Process.GetProcessesByName("EXCEL");
            foreach (Process Pgm in localExcel)
            {
                /****************************************************************************************************************************
                * The commented out code will find the instance of excel that this app started. It worked fine.
                * The problem was, on some computers, ghost excel instances started. The code now kills all excel instances without a
                * a window (MainWindowHandle = 0)
                ****************************************************************************************************************************/
                //// xlMinimized keeps the screen from flashing when the user interface is made visible to set the MainWindowHandle
                //try
                //{
                //    excel.WindowState = XlWindowState.xlMinimized;
                //}
                //catch (Exception e1)
                //{
                //    // Skip it
                //    catchData = "No window to minimize - excel.Kill: " + path + e1.Message;
                //}
                //// Excel won't have an Hwnd (window Handle) until it's visible.
                //try
                //{
                //    excel.Visible = true;
                //}
                //catch (Exception e1)
                //{
                //    // Skip it
                //    catchData = "No window to make visible - excel.Kill: " + path + e1.Message;
                //}
                //if ((Pgm.ProcessName == "EXCEL") && (ExcelHwnd == Pgm.MainWindowHandle.ToInt32()))
                if ((Pgm.ProcessName == "EXCEL") && (Pgm.MainWindowHandle == (IntPtr)0 ))
                {
                    Pgm.Kill();
                    System.Windows.Forms.Application.DoEvents();
                }
            }
        }
    }
}
