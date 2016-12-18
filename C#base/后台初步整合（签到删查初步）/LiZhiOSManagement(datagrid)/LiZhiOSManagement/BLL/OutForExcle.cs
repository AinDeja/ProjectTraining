using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.BLL
{
    public class OutForExcle
    {
//outputPath：保存路径

//dataSet：数据集

//deleteOldFile：是否删除已有的老文件
//保存exce

 public void DataSetToLocalExcel(DataSet dataSet, string outputPath, bool deleteOldFile)
        {
            if (deleteOldFile)
            {
                if (System.IO.File.Exists(outputPath)) { System.IO.File.Delete(outputPath); }
            }
            // Create the Excel Application object
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

            // Create a new Excel Workbook
            Microsoft.Office.Interop.Excel.Workbook excelWorkbook = excelApp.Workbooks.Add(Type.Missing);

            int sheetIndex = 0;

            // Copy each DataTable
            foreach (System.Data.DataTable dt in dataSet.Tables)
            {

                // Copy the DataTable to an object array
                object[,] rawData = new object[dt.Rows.Count + 1, dt.Columns.Count];

                // Copy the column names to the first row of the object array
                for (int col = 0; col < dt.Columns.Count; col++)
                {
                    rawData[0, col] = dt.Columns[col].ColumnName;
                }

                // Copy the values to the object array
                for (int col = 0; col < dt.Columns.Count; col++)
                {
                    for (int row = 0; row < dt.Rows.Count; row++)
                    {
                        rawData[row + 1, col] = dt.Rows[row].ItemArray[col];
                    }
                }

                // Calculate the final column letter
                string finalColLetter = string.Empty;
                string colCharset = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                int colCharsetLen = colCharset.Length;

                if (dt.Columns.Count > colCharsetLen)
                {
                    finalColLetter = colCharset.Substring(
                        (dt.Columns.Count - 1) / colCharsetLen - 1, 1);
                }

                finalColLetter += colCharset.Substring(
                        (dt.Columns.Count - 1) % colCharsetLen, 1);

                // Create a new Sheet
                Microsoft.Office.Interop.Excel.Worksheet excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelWorkbook.Sheets.Add(
                    excelWorkbook.Sheets.get_Item(++sheetIndex),
                    Type.Missing, 1, Microsoft.Office.Interop.Excel.XlSheetType.xlWorksheet);

                excelSheet.Name = dt.TableName;
                Microsoft.Office.Interop.Excel.Range ra = excelSheet.get_Range((object)excelApp.Cells[3, 1], (object)excelApp.Cells[3, 1]);
                ra.ColumnWidth = 20;
                // Fast data export to Excel
                string excelRange = string.Format("A1:{0}{1}",
                    finalColLetter, dt.Rows.Count + 1);

                excelSheet.get_Range(excelRange, Type.Missing).Value2 = rawData;

                // Mark the first row as BOLD
                ((Microsoft.Office.Interop.Excel.Range)excelSheet.Rows[1, Type.Missing]).Font.Bold = true;
            }
            //excelApp.Application.AlertBeforeOverwriting = false;
            excelApp.Application.DisplayAlerts = false;
            // Save and Close the Workbook
            excelWorkbook.SaveAs(outputPath, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            excelWorkbook.Close(true, Type.Missing, Type.Missing);

            
            excelWorkbook = null;

            // Release the Application object
            excelApp.Quit();
            excelApp = null;

            // Collect the unreferenced objects
            GC.Collect();
            GC.WaitForPendingFinalizers();
            this.DownLoadExcel1(outputPath);
        }

//下载

        private void DownLoadExcel1(string fullFileName)
        {
            HttpResponse response = HttpContext.Current.Response;
            response.Clear();
            response.WriteFile(fullFileName);
            string httpHeader = "attachment;filename=" + fullFileName;
            response.AppendHeader("Content-Disposition", httpHeader);
            response.Charset = "utf-8";
            response.ContentEncoding = System.Text.Encoding.Default;
            response.ContentType = "application/vnd.ms-excel";
            System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);

            response.BufferOutput = true;
            response.AppendToLog(DateTime.Now.ToString() + "导出Excel文件");
            response.Flush();

            System.IO.File.Delete(fullFileName);//删除临时文件
             //response.End();
            
           HttpContext.Current.ApplicationInstance.CompleteRequest();

        }
    }
}