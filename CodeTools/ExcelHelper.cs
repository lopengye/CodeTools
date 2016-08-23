using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.OleDb;
using System.Data;
using System.Collections;

namespace CodeTools
{
    /// <summary>
    /// LPY 2016-8-5 添加
    /// Excel文件操作帮助类
    /// </summary>
    public class ExcelHelper
    {
        public static string xlsConnStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"";
        public static string xlsxConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"";

        public static DataTable GetExcelSchemaTable(string fileName)
        {
            try
            {
                OleDbConnection conn = new OleDbConnection(GetConnStrByFileName(fileName));
                conn.Open();
                DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });//获取数据源的表定义元数据
                conn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.Message);
                throw new Exception(ex.Message) ;
            }            
        }


        public static DataTable GetExcelSheetHeaderBySheetName(string fileName, string sheetName)
        {
            try
            {
                OleDbConnection conn = new OleDbConnection(GetConnStrByFileName(fileName));
                conn.Open();
                DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new object[] { null, null, sheetName, null });
                return dt;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public static ArrayList GetColumnsNameBySheetName(string fileName, string sheetName)
        {
            try
            {
                OleDbConnection conn = new OleDbConnection(GetConnStrByFileName(fileName));
                conn.Open();
                DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new object[] { null, null, sheetName, null });
                ArrayList alTemplet=new ArrayList();
                foreach (DataRow col in dt.Rows)
                {
                    alTemplet.Add(col["Column_Name"].ToString());
                }
                return alTemplet;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public static DataSet GetDataSetBySheetName(string fileName, string sheetName)
        {
            try
            {
                OleDbConnection conn = new OleDbConnection(GetConnStrByFileName(fileName));
                conn.Open();
                OleDbDataAdapter da = new OleDbDataAdapter();
                da.SelectCommand = new OleDbCommand(string.Format("Select * FROM [{0}]", sheetName), conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.Message);
                throw;
            }
        }


        private static string GetConnStrByFileName(string fileName)
        {
            string fileExtension = System.IO.Path.GetExtension(fileName).ToLower();
            if (fileExtension == ".xls")
                return string.Format(xlsConnStr, fileName);
            else
                return string.Format(xlsxConnStr, fileName);
        }
    }
}
/*
             对于EXCEL中的表即sheet([sheet1$])如果不是固定的可以使用下面的方法得到  
string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" +"Data Source="+ Path +";"+"Extended Properties=Excel 8.0;"; 
OleDbConnection conn = new OleDbConnection(strConn); 
DataTable schemaTable = objConn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables,null); 
string tableName=schemaTable.Rows[0][2].ToString().Trim();   
             */