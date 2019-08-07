using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 实体类生成工具
{
    public partial class Main : Form
    {
        public bool TxtEntityClassIsNull = true;
        private DBHelper dbHelper;
        private DataBaeUsingInfo databaeUsingInfo;
        public string DBServer;
        private string className;
        public bool IsBuildFun;
        public string StrBuildFun;
        List<string> dataByConAndSql;
        private List<string> nobyteDic = new List<string> {
            "real","int","smallint","bigint","tinyint","money","smallmoney","bit","cursor","sysname","timestamp","uniqueidentifier","text","image","ntext","datetime","smalldatetime"
        };
        public Main()
        {
            InitializeComponent();
        }
        private void Main_Load(object sender, EventArgs e)
        {
            this.dbHelper = new DBHelper();
            this.databaeUsingInfo = new DataBaeUsingInfo();
            this.cboDBServers.SelectedIndex = 0;
        }

        private void btnDBLogin_Click(object sender, EventArgs e)
        {
            this.DBServer = this.cboDBServers.Text.Trim();
            this.cboDBServers.SelectAll();
            string strCon = "Server=" + this.cboDBServers.Text.Trim() + ";Database=master;Uid=" + this.txtUid.Text.Trim() + ";Pwd=" + this.txtPwd.Text.Trim();
            string sql = "select name from sysdatabases";
            string msg = (string)null;
            dataByConAndSql = this.dbHelper.GetDataByConAndSql(strCon, sql, out msg);
            if (msg == null)
                return;
            this.cboDBList.Items.AddRange(dataByConAndSql.ToArray());
            this.databaeUsingInfo.LoginUid = this.txtUid.Text.Trim();
            this.databaeUsingInfo.LoginPwd = this.txtPwd.Text.Trim();
            this.cboDBList.SelectedIndex = 0;
        }

        private void cboDBList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cboDBListChange_SelectTable();
        }

        private void cboDBList_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.cboDBListChange_SelectTable();
        }
        private void cboDBListChange_SelectTable()
        {
            this.cboDBList.SelectAll();
            if (string.IsNullOrEmpty(this.cboDBList.Text))
            {
                int num = (int)MessageBox.Show("请选择数据库！");
            }
            else
            {
                string strCon = "Server=" + this.cboDBServers.Text.Trim() + ";Database=" + this.cboDBList.Text.Trim() + ";Uid=" + this.databaeUsingInfo.LoginUid + ";Pwd=" + this.databaeUsingInfo.LoginPwd;
                string sql = "select table_name from " + this.cboDBList.Text.Trim() + ".information_schema.tables";
                string msg = (string)null;
                dataByConAndSql = this.dbHelper.GetDataByConAndSql(strCon, sql, out msg);
                if (!("登录成功！" == msg))
                    return;
                this.cboTableName.Items.AddRange(dataByConAndSql.ToArray());
                this.databaeUsingInfo.Database = this.cboDBList.Text.Trim();
            }
        }


        public ArrayList GetDB_colname_And_type()
        {
            if (this.cboTableName.SelectedItem == null)
            {
                int num = (int)MessageBox.Show("该数据库无数据表！");
                return (ArrayList)null;
            }
            if (string.IsNullOrEmpty(this.cboTableName.SelectedItem.ToString()))
            {
                int num = (int)MessageBox.Show("请选择数据表！");
                return (ArrayList)null;
            }
            //获取字段名，字段类型，字段说明 SQL语句
            string sql = $@"SELECT t1.column_name,t1.data_type,value=ISNULL(t3.value,'')  FROM information_schema.columns t1
LEFT JOIN sys.columns t2 ON  OBJECT_ID(t1.table_name)=t2.object_id AND t1.COLUMN_NAME=t2.name
LEFT JOIN sys.extended_properties t3 ON t3.minor_id = t2.column_id and t3.major_id =OBJECT_ID(N'{this.cboTableName.SelectedItem.ToString()}') AND t3.class=1 AND t3.name = 'MS_Description' 
 where t1.TABLE_NAME='{this.cboTableName.SelectedItem.ToString()}';";
            //ArrayList fieldByConAndSql = this.dbHelper.GetFieldByConAndSql("Server=" + this.cboDBServers.Text.Trim() + ";Database=" + this.databaeUsingInfo.Database + ";Uid=" + this.databaeUsingInfo.LoginUid + ";Pwd=" + this.databaeUsingInfo.LoginPwd, "select column_name,data_type from " + this.databaeUsingInfo.Database + ".information_schema.columns where table_name='" + this.cboTableName.SelectedItem.ToString() + "'");
            ArrayList fieldByConAndSql = this.dbHelper.GetFieldByConAndSql("Server=" + this.cboDBServers.Text.Trim() + ";Database=" + this.databaeUsingInfo.Database + ";Uid=" + this.databaeUsingInfo.LoginUid + ";Pwd=" + this.databaeUsingInfo.LoginPwd, sql);
            this.databaeUsingInfo.Table = this.cboTableName.SelectedItem.ToString();
            return fieldByConAndSql;
        }

        public List<ScriptModel> GetDB_Script_Type()
        {

            if (this.cboTableName.SelectedItem == null)
            {
                int num = (int)MessageBox.Show("该数据库无数据表！");
                return default(List<ScriptModel>);
            }
            if (string.IsNullOrEmpty(this.cboTableName.SelectedItem.ToString()))
            {
                int num = (int)MessageBox.Show("请选择数据表！");
                return default(List<ScriptModel>);
            }
            #region sql
            var sql = $@"SELECT [field],[type],[byte],[precision],[scale],[isnull],[isidentity],[ispk],[default],CASE WHEN t.ispk=1 THEN t.pkvalue ELSE value END AS [value] FROM( SELECT
                      col.name AS [field],
                      typ.name as [type],
                      col.max_length AS [byte],
                      col.precision AS [precision],
                      col.scale AS [scale],
                      col.is_nullable  AS [isnull],
                      col.is_identity  AS [isidentity],
                      case when exists 
                         ( SELECT 1 
                           FROM 
                             sys.indexes idx 
                               join sys.index_columns idxCol 
                               on (idx.object_id = idxCol.object_id)
                            WHERE
                               idx.object_id = col.object_id
                               AND idxCol.index_column_id = col.column_id 
                               AND idx.is_primary_key = 1
                          ) THEN 1 ELSE 0 END  AS [ispk],
                      ISNULL(STUFF(LEFT(D.definition,LEN(D.definition)-1),1,1,''),'') AS [default],e.value,f.value AS pkvalue
                   FROM
                     sys.columns col 
                     LEFT join sys.types typ on (col.system_type_id = typ.system_type_id AND col.user_type_id = typ.user_type_id)
                     LEFT JOIN sys.default_constraints d ON d.object_id=col.default_object_id  AND d.parent_object_id = col.object_id AND d.parent_column_id = col.column_id   
                     Left JOIN sys.extended_properties e ON e.minor_id = col.column_id and e.major_id =OBJECT_ID(N'{this.cboTableName.SelectedItem.ToString()}') AND e.class=1 AND e.name = 'MS_Description'
                     Left JOIN sys.extended_properties f ON f.minor_id = 0 and e.major_id =f.major_id AND f.class=1 AND f.name = 'MS_Description'
                   WHERE
                     col.object_id =
                   (SELECT object_id FROM sys.tables WHERE name = '{this.cboTableName.SelectedItem.ToString()}') ) t;";

            #endregion
            List<ScriptModel> list = this.dbHelper.GetScriptList("Server=" + this.cboDBServers.Text.Trim() + ";Database=" + this.databaeUsingInfo.Database + ";Uid=" + this.databaeUsingInfo.LoginUid + ";Pwd=" + this.databaeUsingInfo.LoginPwd, sql);
            return list;
        }

        private void btnCreateEntity_Click(object sender, EventArgs e)
        {
            //this.LoadingEntityClass_Text();
            this.LoadingEntityClass_TextV1();
            this.TxtEntityClassIsNull = false;
            this.btnCopy.Enabled = true;
            this.btnCreateCSFile.Enabled = true;
        }
        public void LoadingEntityClass_TextV1()
        {
            ArrayList dbColnameAndType = this.GetDB_colname_And_type();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("\r\npublic class ");
            if (this.cboTableName.SelectedItem == null)
                return;
            this.className = this.cboTableName.SelectedItem.ToString().Trim();
            this.className = this.className.Substring(0, 1).ToUpper() + this.className.Substring(1);
            stringBuilder.AppendLine(this.className);
            stringBuilder.AppendLine("{");
            if (this.IsBuildFun)
                stringBuilder.AppendLine(this.StrBuildFun);
            foreach (string str in dbColnameAndType)
            {
                string[] list = str.Split('|');
                string field = list[0], type = list[1], description = list[2];

                stringBuilder.AppendLine("\t/// <summary>");
                stringBuilder.AppendLine($"\t/// {description}");
                stringBuilder.AppendLine("\t/// </summary>");
                stringBuilder.Append("\tpublic ");
                stringBuilder.Append(type);
                stringBuilder.Append(" ");
                stringBuilder.Append(field);
                stringBuilder.Append(" ");
                stringBuilder.Append("\t{ get; set; }");
                stringBuilder.AppendLine();
            }
            //stringBuilder.Remove(stringBuilder.Length - 3, 2);
            stringBuilder.Append("}");
            this.txtEntityClass.Text = stringBuilder.ToString();
        }

        public void LoadingEntityClass_Text()
        {
            ArrayList dbColnameAndType = this.GetDB_colname_And_type();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("\r\npublic class ");
            if (this.cboTableName.SelectedItem == null)
                return;
            this.className = this.cboTableName.SelectedItem.ToString().Trim();
            this.className = this.className.Substring(0, 1).ToUpper() + this.className.Substring(1);
            stringBuilder.AppendLine(this.className);
            stringBuilder.AppendLine("{");
            if (this.IsBuildFun)
                stringBuilder.AppendLine(this.StrBuildFun);
            foreach (string str in dbColnameAndType)
            {
                stringBuilder.Append("\tprivate ");
                stringBuilder.Append(str.Substring(str.IndexOf('|') + 1));
                stringBuilder.Append(" ");
                stringBuilder.Append(str.Substring(0, str.IndexOf('|')));
                stringBuilder.AppendLine(";");
                stringBuilder.Append("\tpublic ");
                stringBuilder.Append(str.Substring(str.IndexOf('|') + 1));
                stringBuilder.Append(" ");
                stringBuilder.AppendLine(str.Substring(0, 1).ToUpper() + str.Substring(1, str.IndexOf('|') - 1));
                stringBuilder.AppendLine("\t{");
                stringBuilder.Append("\t\tget { return ");
                stringBuilder.Append(str.Substring(0, str.IndexOf('|')));
                stringBuilder.AppendLine("; }");
                stringBuilder.Append("\t\tset { ");
                stringBuilder.Append(str.Substring(0, str.IndexOf('|')));
                stringBuilder.AppendLine(" = value; }");
                stringBuilder.AppendLine("\t}");
                stringBuilder.AppendLine();
            }
            stringBuilder.Remove(stringBuilder.Length - 3, 2);
            stringBuilder.Append("}");
            this.txtEntityClass.Text = stringBuilder.ToString();
        }

        private void btnBuildFun_Click(object sender, EventArgs e)
        {
            //int num = (int)new Form2(this).ShowDialog((IWin32Window)this);
        }

        private void cboTableName_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtEntityClass.Clear();
            this.TxtEntityClassIsNull = true;
            this.databaeUsingInfo.Table = this.cboTableName.SelectedItem.ToString();
            this.IsBuildFun = false;
            this.btnCreateEntity.Enabled = true;
            this.btnBuildFun.Enabled = true;
            this.btnCopy.Enabled = false;
            this.btnCreateCSFile.Enabled = false;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            this.txtEntityClass.Focus();
            Clipboard.SetDataObject((object)this.txtEntityClass.Text.Replace("\n", "\r\n"));
        }

        private void btnCreateCSFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.AddExtension = true;
            saveFileDialog.DefaultExt = "*.cs";
            saveFileDialog.Filter = "C# 文档 (*.cs)|*.cs|文本文档 (*.txt)|*.txt";
            saveFileDialog.FileName = this.className + ".cs";
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;
            FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write, FileShare.None);
            StreamWriter streamWriter = new StreamWriter((Stream)fileStream, Encoding.Default);
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("using System;");
                stringBuilder.AppendLine("using System.Collections.Generic;");
                stringBuilder.AppendLine("using System.Text;");
                stringBuilder.AppendLine();
                stringBuilder.AppendLine("namespace YourNamespace //修改名字空间");
                stringBuilder.Append("{");
                string str = this.txtEntityClass.Text.Replace("\n", "\r\n\t");
                stringBuilder.AppendLine(str);
                stringBuilder.Append("}");
                streamWriter.AutoFlush = true;
                streamWriter.Write(stringBuilder.ToString());
            }
            catch (IOException ex)
            {
                int num = (int)MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message);
            }
            finally
            {
                fileStream.Close();
            }
        }

        private void linkLabel_about_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int num = (int)new AboutBoxAuthor().ShowDialog();
            Process.Start("http://chaogege.info/");
        }

        private void txtEntityClass_TextChanged(object sender, EventArgs e)
        {
            if (this.txtEntityClass.Text == "")
                return;
            this.txtEntityClass.Font = new Font("新宋体", 13f);
            if (this.txtEntityClass.Focused)
                return;
            this.changeColor(new string[26]
            {
        "public",
        "internal",
        "protected",
        "private",
        "void",
        "class",
        "get",
        "set",
        "value",
        "return",
        "this",
        "C#",
        "long",
        "bool",
        "double",
        "byte[]",
        "int",
        "decimal",
        "string",
        "float",
        "DateTime",
        "short",
        "byte",
        "Guid",
        "object",
        "未知类型"
            });
            string str = this.cboTableName.SelectedItem.ToString().Trim();
            this.changeColor(str.Substring(0, 1).ToUpper() + str.Substring(1));
        }

        private void changeColor(string[] keywords)
        {
            for (int start = 0; start < this.txtEntityClass.Text.Length; ++start)
            {
                foreach (string keyword in keywords)
                {
                    int num = this.txtEntityClass.Find(keyword, start, keyword.Length + start, RichTextBoxFinds.WholeWord | RichTextBoxFinds.MatchCase);
                    start = num >= 0 ? start + keyword.Length : start;
                    if (num >= 0)
                        break;
                }
                this.txtEntityClass.SelectionColor = Color.Blue;
            }
        }

        private void changeColor(string className)
        {
            int num = 0;
            int start = 0;
            while (num != -1)
            {
                num = this.txtEntityClass.Find(className, start, RichTextBoxFinds.WholeWord | RichTextBoxFinds.MatchCase);
                start = num == 1 ? start + className.Length : start + 1;
                this.txtEntityClass.SelectionColor = Color.FromArgb((int)byte.MaxValue, 43, 145, 175);
            }
        }

        private void btnCreateScript_Click(object sender, EventArgs e)
        {
            LoadingScript_Text();
        }

        public void LoadingScript_Text()
        {
            List<ScriptModel> list = this.GetDB_Script_Type();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"USE [{this.cboDBList.SelectedItem.ToString()}]\r\nGO");
            if (this.cboTableName.SelectedItem == null)
                return;
            var tableName = this.cboTableName.SelectedItem.ToString().Trim();
            stringBuilder.AppendLine($"IF (OBJECT_ID('{tableName}','U') IS NULL)");
            stringBuilder.AppendLine("BEGIN");
            stringBuilder.AppendLine($"CREATE TABLE [dbo].[{tableName}](");

            var pkID = "";
            foreach (var m in list)
            {
                if (m.ispk)
                {
                    pkID = m.field;
                }
                var identityStr = m.isidentity ? "IDENTITY(1,1)" : "";
                var isnullStr = !m.isnull ? "NOT NULL" : "";
                //nobyteDic中的类型不加对应长度描述
                var byteStr = nobyteDic.Contains(m.type) ? "" : Convert.ToString(m.@byte);
                if (m.precision == 0 && m.scale == 0)
                {
                    byteStr = byteStr == "-1" ? "max" : byteStr;
                    if (byteStr != "")
                        byteStr = $"({byteStr})";
                }
                else
                {
                    if (byteStr != "")
                        byteStr = $"({m.precision},{m.scale})";
                }
                //DF_TChessCardGamesKYRecordR13_3_4_FGameID
                var defaultStr = string.IsNullOrEmpty(m.@default) ? "" : $"CONSTRAINT[DF_{tableName}_{m.field}] DEFAULT({m.@default})";
                stringBuilder.AppendLine($"\t\t[{m.field}]\t[{m.type}]{byteStr}\t{identityStr}\t{isnullStr}\t{defaultStr},");
            }
            if (pkID != "")
            {
                stringBuilder.AppendLine($"\t\tCONSTRAINT[PK_{tableName}] PRIMARY KEY CLUSTERED");
                stringBuilder.AppendLine($"\t\t([{pkID}] ASC) WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]");
                stringBuilder.AppendLine("\t\t)");
            }
            stringBuilder.AppendLine("END");
            stringBuilder.AppendLine("GO");

            foreach (var m in list)
            {
                if (string.IsNullOrEmpty(m.@value)) continue;

                if (m.ispk)
                {
                    //主键 备注
                    stringBuilder.AppendLine($"IF NOT EXISTS(SELECT 1 FROM sys.extended_properties WHERE class = 1 AND major_id = OBJECT_ID(N'{tableName}')");
                    stringBuilder.AppendLine($"AND name = 'MS_Description' AND minor_id = 0)");
                    stringBuilder.AppendLine("BEGIN");
                    stringBuilder.AppendLine($"EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'{m.@value}' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'{tableName}'");
                    stringBuilder.AppendLine("END");
                    stringBuilder.AppendLine("GO\r\n");
                }
                else
                {
                    //列 备注
                    stringBuilder.AppendLine($"IF NOT EXISTS(SELECT 1 FROM sys.extended_properties WHERE class = 1 AND major_id = OBJECT_ID(N'{tableName}')");
                    stringBuilder.AppendLine($"AND name = 'MS_Description' AND minor_id = (SELECT column_id FROM sys.columns WHERE name=N'{m.field}' AND object_id = OBJECT_ID(N'{tableName}') ))");
                    stringBuilder.AppendLine("BEGIN");
                    stringBuilder.AppendLine($"EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'{m.@value}' , @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'{tableName}', @level2type = N'COLUMN', @level2name = N'{m.field}'");
                    stringBuilder.AppendLine("END");
                    stringBuilder.AppendLine("GO\r\n");
                }
            }

            this.txtEntityClass.Text = stringBuilder.ToString();

        }

        private void cboTableName_TextChanged(object sender, EventArgs e)
        {
            this.cboTableName.Items.Clear();
            var filterList = dataByConAndSql.Where(x => x.ToUpper().Contains(this.cboTableName.Text.ToUpper())).ToList();
            this.cboTableName.Items.AddRange(filterList.ToArray());
            this.cboTableName.SelectionStart = this.cboTableName.Text.Length;
            //保持鼠标指针原来状态，有时候鼠标指针会被下拉框覆盖，所以要进行一次设置。
            Cursor = Cursors.Default;
            //自动弹出下拉框
            this.cboTableName.DroppedDown = true;
        }

        private void cboTableName_MouseClick(object sender, MouseEventArgs e)
        {
            //自动弹出下拉框
            this.cboTableName.DroppedDown = true;
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && this.components != null)
        //        this.components.Dispose();
        //    base.Dispose(disposing);
        //}


    }
}
