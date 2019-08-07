// Decompiled with JetBrains decompiler
// Type: 实体类生成工具.DBHelper
// Assembly: 实体类生成工具, Version=2.0.0.4, Culture=neutral, PublicKeyToken=null
// MVID: E857BE9B-E6E4-4EB0-873A-168F60AB74E0
// Assembly location: E:\DownLoad\实体类生成工具\实体类生成工具.exe

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace 实体类生成工具
{
    public class DBHelper
    {
        public List<string> GetDataByConAndSql(string strCon, string sql, out string msg)
        {
            List<string> arrayList = new List<string>();
            using (SqlConnection connection = new SqlConnection(strCon))
            {
                SqlCommand sqlCommand = new SqlCommand(sql, connection);
                SqlDataReader sqlDataReader = (SqlDataReader)null;
                try
                {
                    connection.Open();
                    sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                        arrayList.Add(sqlDataReader[0].ToString());
                    msg = "登录成功！";
                }
                catch (SqlException ex)
                {
                    msg = ex.Message;
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                }
                finally
                {
                    if (sqlDataReader != null)
                        sqlDataReader.Close();
                    connection.Close();
                }
                return arrayList;
            }
        }

        public ArrayList GetFieldByConAndSql(string strCon, string sql)
        {
            ArrayList arrayList = new ArrayList();
            using (SqlConnection connection = new SqlConnection(strCon))
            {
                SqlCommand sqlCommand = new SqlCommand(sql, connection);
                SqlDataReader sqlDataReader = (SqlDataReader)null;
                try
                {
                    connection.Open();
                    sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        //string str1 = sqlDataReader[0].ToString().Substring(0, 1).ToLower() + sqlDataReader[0].ToString().Substring(1);
                        string str1 = sqlDataReader[0].ToString().Substring(0, 1).ToUpper() + sqlDataReader[0].ToString().Substring(1);
                        string str2 = this.DBTpyeConvertCSType(sqlDataReader[1].ToString());
                        string str3 = sqlDataReader[2].ToString();
                        arrayList.Add((object)(str1 + "|" + str2 + "|" + str3));
                    }
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (sqlDataReader != null)
                        sqlDataReader.Close();
                    connection.Close();
                }
                return arrayList;
            }
        }

        private string DBTpyeConvertCSType(string dbtype)
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add((object)"SQL", (object)"C#");
            hashtable.Add((object)"bigint", (object)"long");
            hashtable.Add((object)"binary", (object)"object");
            hashtable.Add((object)"bit", (object)"bool");
            hashtable.Add((object)"char", (object)"string");
            hashtable.Add((object)"datetime", (object)"DateTime");
            hashtable.Add((object)"decimal", (object)"decimal");
            hashtable.Add((object)"float", (object)"double");
            hashtable.Add((object)"image", (object)"byte[]");
            hashtable.Add((object)"int", (object)"int");
            hashtable.Add((object)"money", (object)"decimal");
            hashtable.Add((object)"nchar", (object)"string");
            hashtable.Add((object)"ntext", (object)"string");
            hashtable.Add((object)"numeric", (object)"decimal");
            hashtable.Add((object)"nvarchar", (object)"string");
            hashtable.Add((object)"real", (object)"float");
            hashtable.Add((object)"smalldatetime", (object)"DateTime");
            hashtable.Add((object)"smallint", (object)"short");
            hashtable.Add((object)"smallmoney", (object)"decimal");
            hashtable.Add((object)"text", (object)"string");
            hashtable.Add((object)"timestamp", (object)"byte[]");
            hashtable.Add((object)"tinyint", (object)"byte");
            hashtable.Add((object)"uniqueidentifier", (object)"Guid");
            hashtable.Add((object)"varbinary", (object)"byte[]");
            hashtable.Add((object)"varchar", (object)"string");
            hashtable.Add((object)"xml", (object)"string");
            hashtable.Add((object)"sql_variant", (object)"object");
            string str = "未知类型";
            if (!string.IsNullOrEmpty(dbtype))
            {
                try
                {
                    str = hashtable[(object)dbtype].ToString();
                    if (string.IsNullOrEmpty(str))
                        str = "未知类型";
                }
                catch
                {
                    str = "未知类型";
                }
            }
            return str;
        }

        public ArrayList GetFieldAndNullByConAndSql(string strCon, string sql)
        {
            ArrayList arrayList = new ArrayList();
            using (SqlConnection connection = new SqlConnection(strCon))
            {
                SqlCommand sqlCommand = new SqlCommand(sql, connection);
                SqlDataReader sqlDataReader = (SqlDataReader)null;
                try
                {
                    connection.Open();
                    sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        string str1 = sqlDataReader[0].ToString().Substring(0, 1).ToLower() + sqlDataReader[0].ToString().Substring(1);
                        string str2 = !("NO" == sqlDataReader[1].ToString().ToUpper()) ? "null" : "not null";
                        arrayList.Add((object)new AboutField()
                        {
                            col_name = str1,
                            col_nullable = str2
                        });
                    }
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (sqlDataReader != null)
                        sqlDataReader.Close();
                    connection.Close();
                }
                return arrayList;
            }
        }

        public List<ScriptModel> GetScriptList(string strCon, string sql)
        {
            List<ScriptModel> list = new List<ScriptModel>();
            using (SqlConnection connection = new SqlConnection(strCon))
            {
                SqlCommand sqlCommand = new SqlCommand(sql, connection);
                SqlDataReader sqlDataReader = (SqlDataReader)null;
                try
                {
                    connection.Open();
                    sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        var model = new ScriptModel
                        {
                            field = sqlDataReader[0].ToString(),
                            type = sqlDataReader[1].ToString(),
                            @byte = Convert.ToInt32(sqlDataReader[2]),
                            precision = Convert.ToInt32(sqlDataReader[3]),
                            scale = Convert.ToInt32(sqlDataReader[4]),
                            isnull = Convert.ToBoolean(sqlDataReader[5]),
                            isidentity = Convert.ToBoolean(sqlDataReader[6]),
                            ispk = Convert.ToBoolean(sqlDataReader[7]),
                            @default = sqlDataReader[8].ToString(),
                            value = sqlDataReader[9].ToString(),

                        };
                        list.Add(model);



                    }
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (sqlDataReader != null)
                        sqlDataReader.Close();
                    connection.Close();
                }
                return list;
            }
        }
    }
}
