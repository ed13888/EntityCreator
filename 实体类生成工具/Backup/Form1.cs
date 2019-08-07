// Decompiled with JetBrains decompiler
// Type: 实体类生成工具.Form1
// Assembly: 实体类生成工具, Version=2.0.0.4, Culture=neutral, PublicKeyToken=null
// MVID: E857BE9B-E6E4-4EB0-873A-168F60AB74E0
// Assembly location: E:\DownLoad\实体类生成工具\实体类生成工具.exe

using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace 实体类生成工具
{
  public class Form1 : Form
  {
    public bool TxtEntityClassIsNull = true;
    private DBHelper dbHelper;
    private DataBaeUsingInfo databaeUsingInfo;
    public string DBServer;
    private string className;
    public bool IsBuildFun;
    public string StrBuildFun;
    private IContainer components;
    private SplitContainer splitContainer1;
    private Button btnBuildFun;
    private Button btnCreateEntity;
    private GroupBox groupBox1;
    private Button btnDBLogin;
    private TextBox txtPwd;
    private TextBox txtUid;
    private Label label2;
    private Label label1;
    private ListBox lbxTableName;
    private ComboBox cboDBList;
    private Label label4;
    private Label label3;
    private Label label6;
    private ComboBox cboDBServers;
    public Button btnCopy;
    public Button btnCreateCSFile;
    private LinkLabel linkLabel_about;
    private RichTextBox txtEntityClass;

    public Form1()
    {
      this.InitializeComponent();
      this.dbHelper = new DBHelper();
      this.databaeUsingInfo = new DataBaeUsingInfo();
      this.cboDBServers.SelectedIndex = 0;
    }

    internal DataBaeUsingInfo DatabaeUsingInfo
    {
      get
      {
        return this.databaeUsingInfo;
      }
    }

    private void btnDBLogin_Click(object sender, EventArgs e)
    {
      this.DBServer = this.cboDBServers.Text.Trim();
      this.cboDBServers.SelectAll();
      string strCon = "Server=" + this.cboDBServers.Text.Trim() + ";Database=master;Uid=" + this.txtUid.Text.Trim() + ";Pwd=" + this.txtPwd.Text.Trim();
      string sql = "select name from sysdatabases";
      string msg = (string) null;
      ArrayList dataByConAndSql = this.dbHelper.GetDataByConAndSql(strCon, sql, out msg);
      if (msg == null)
        return;
      int num = (int) new MyMessageBox(msg).ShowDialog((IWin32Window) this);
      if (!("登录成功！" == msg))
        return;
      this.cboDBList.DataSource = (object) dataByConAndSql;
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
        int num = (int) MessageBox.Show("请选择数据库！");
      }
      else
      {
        string strCon = "Server=" + this.cboDBServers.Text.Trim() + ";Database=" + this.cboDBList.Text.Trim() + ";Uid=" + this.databaeUsingInfo.LoginUid + ";Pwd=" + this.databaeUsingInfo.LoginPwd;
        string sql = "select table_name from " + this.cboDBList.Text.Trim() + ".information_schema.tables";
        string msg = (string) null;
        ArrayList dataByConAndSql = this.dbHelper.GetDataByConAndSql(strCon, sql, out msg);
        if (!("登录成功！" == msg))
          return;
        this.lbxTableName.DataSource = (object) dataByConAndSql;
        this.databaeUsingInfo.Database = this.cboDBList.Text.Trim();
      }
    }

    public ArrayList GetDB_colname_And_type()
    {
      if (this.lbxTableName.SelectedItem == null)
      {
        int num = (int) MessageBox.Show("该数据库无数据表！");
        return (ArrayList) null;
      }
      if (string.IsNullOrEmpty(this.lbxTableName.SelectedItem.ToString()))
      {
        int num = (int) MessageBox.Show("请选择数据表！");
        return (ArrayList) null;
      }
      ArrayList fieldByConAndSql = this.dbHelper.GetFieldByConAndSql("Server=" + this.cboDBServers.Text.Trim() + ";Database=" + this.databaeUsingInfo.Database + ";Uid=" + this.databaeUsingInfo.LoginUid + ";Pwd=" + this.databaeUsingInfo.LoginPwd, "select column_name,data_type from " + this.databaeUsingInfo.Database + ".information_schema.columns where table_name='" + this.lbxTableName.SelectedItem.ToString() + "'");
      this.databaeUsingInfo.Table = this.lbxTableName.SelectedItem.ToString();
      return fieldByConAndSql;
    }

    private void btnCreateEntity_Click(object sender, EventArgs e)
    {
      this.LoadingEntityClass_Text();
      this.TxtEntityClassIsNull = false;
      this.btnCopy.Enabled = true;
      this.btnCreateCSFile.Enabled = true;
    }

    public void LoadingEntityClass_Text()
    {
      ArrayList dbColnameAndType = this.GetDB_colname_And_type();
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("\r\npublic class ");
      if (this.lbxTableName.SelectedItem == null)
        return;
      this.className = this.lbxTableName.SelectedItem.ToString().Trim();
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
      int num = (int) new Form2(this).ShowDialog((IWin32Window) this);
    }

    private void lbxTableName_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.txtEntityClass.Clear();
      this.TxtEntityClassIsNull = true;
      this.databaeUsingInfo.Table = this.lbxTableName.SelectedItem.ToString();
      this.IsBuildFun = false;
      this.btnCreateEntity.Enabled = true;
      this.btnBuildFun.Enabled = true;
      this.btnCopy.Enabled = false;
      this.btnCreateCSFile.Enabled = false;
    }

    private void btnCopy_Click(object sender, EventArgs e)
    {
      this.txtEntityClass.Focus();
      Clipboard.SetDataObject((object) this.txtEntityClass.Text.Replace("\n", "\r\n"));
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
      StreamWriter streamWriter = new StreamWriter((Stream) fileStream, Encoding.Default);
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
        int num = (int) MessageBox.Show(ex.Message);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
      }
      finally
      {
        fileStream.Close();
      }
    }

    private void linkLabel_about_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      int num = (int) new AboutBoxAuthor().ShowDialog();
      Process.Start("http://xugang.cnblogs.com/");
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
      string str = this.lbxTableName.SelectedItem.ToString().Trim();
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
        this.txtEntityClass.SelectionColor = Color.FromArgb((int) byte.MaxValue, 43, 145, 175);
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Form1));
      this.splitContainer1 = new SplitContainer();
      this.linkLabel_about = new LinkLabel();
      this.btnCopy = new Button();
      this.btnBuildFun = new Button();
      this.btnCreateCSFile = new Button();
      this.btnCreateEntity = new Button();
      this.groupBox1 = new GroupBox();
      this.cboDBServers = new ComboBox();
      this.label6 = new Label();
      this.btnDBLogin = new Button();
      this.txtPwd = new TextBox();
      this.txtUid = new TextBox();
      this.label2 = new Label();
      this.label1 = new Label();
      this.lbxTableName = new ListBox();
      this.cboDBList = new ComboBox();
      this.label4 = new Label();
      this.label3 = new Label();
      this.txtEntityClass = new RichTextBox();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      this.splitContainer1.Dock = DockStyle.Fill;
      this.splitContainer1.Location = new Point(0, 0);
      this.splitContainer1.Name = "splitContainer1";
      this.splitContainer1.Panel1.Controls.Add((Control) this.linkLabel_about);
      this.splitContainer1.Panel1.Controls.Add((Control) this.btnCopy);
      this.splitContainer1.Panel1.Controls.Add((Control) this.btnBuildFun);
      this.splitContainer1.Panel1.Controls.Add((Control) this.btnCreateCSFile);
      this.splitContainer1.Panel1.Controls.Add((Control) this.btnCreateEntity);
      this.splitContainer1.Panel1.Controls.Add((Control) this.groupBox1);
      this.splitContainer1.Panel1.Controls.Add((Control) this.lbxTableName);
      this.splitContainer1.Panel1.Controls.Add((Control) this.cboDBList);
      this.splitContainer1.Panel1.Controls.Add((Control) this.label4);
      this.splitContainer1.Panel1.Controls.Add((Control) this.label3);
      this.splitContainer1.Panel2.Controls.Add((Control) this.txtEntityClass);
      this.splitContainer1.Size = new Size(595, 465);
      this.splitContainer1.SplitterDistance = 202;
      this.splitContainer1.TabIndex = 11;
      this.linkLabel_about.AutoSize = true;
      this.linkLabel_about.Location = new Point(134, 445);
      this.linkLabel_about.Name = "linkLabel_about";
      this.linkLabel_about.Size = new Size(53, 12);
      this.linkLabel_about.TabIndex = 20;
      this.linkLabel_about.TabStop = true;
      this.linkLabel_about.Text = "关于作者";
      this.linkLabel_about.TextAlign = ContentAlignment.BottomRight;
      this.linkLabel_about.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel_about_LinkClicked);
      this.btnCopy.Enabled = false;
      this.btnCopy.Location = new Point(18, 397);
      this.btnCopy.Name = "btnCopy";
      this.btnCopy.Size = new Size(79, 23);
      this.btnCopy.TabIndex = 17;
      this.btnCopy.Text = "复 制";
      this.btnCopy.UseVisualStyleBackColor = true;
      this.btnCopy.Click += new EventHandler(this.btnCopy_Click);
      this.btnBuildFun.Enabled = false;
      this.btnBuildFun.Location = new Point(18, 363);
      this.btnBuildFun.Name = "btnBuildFun";
      this.btnBuildFun.Size = new Size(79, 23);
      this.btnBuildFun.TabIndex = 17;
      this.btnBuildFun.Text = "构造函数";
      this.btnBuildFun.UseVisualStyleBackColor = true;
      this.btnBuildFun.Click += new EventHandler(this.btnBuildFun_Click);
      this.btnCreateCSFile.Enabled = false;
      this.btnCreateCSFile.Location = new Point(108, 397);
      this.btnCreateCSFile.Name = "btnCreateCSFile";
      this.btnCreateCSFile.Size = new Size(79, 23);
      this.btnCreateCSFile.TabIndex = 18;
      this.btnCreateCSFile.Text = "产生类文件";
      this.btnCreateCSFile.UseVisualStyleBackColor = true;
      this.btnCreateCSFile.Click += new EventHandler(this.btnCreateCSFile_Click);
      this.btnCreateEntity.Enabled = false;
      this.btnCreateEntity.Location = new Point(108, 363);
      this.btnCreateEntity.Name = "btnCreateEntity";
      this.btnCreateEntity.Size = new Size(79, 23);
      this.btnCreateEntity.TabIndex = 18;
      this.btnCreateEntity.Text = "产生实体类";
      this.btnCreateEntity.UseVisualStyleBackColor = true;
      this.btnCreateEntity.Click += new EventHandler(this.btnCreateEntity_Click);
      this.groupBox1.Controls.Add((Control) this.cboDBServers);
      this.groupBox1.Controls.Add((Control) this.label6);
      this.groupBox1.Controls.Add((Control) this.btnDBLogin);
      this.groupBox1.Controls.Add((Control) this.txtPwd);
      this.groupBox1.Controls.Add((Control) this.txtUid);
      this.groupBox1.Controls.Add((Control) this.label2);
      this.groupBox1.Controls.Add((Control) this.label1);
      this.groupBox1.Location = new Point(15, 18);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(172, 157);
      this.groupBox1.TabIndex = 16;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "登录信息";
      this.cboDBServers.FormattingEnabled = true;
      this.cboDBServers.Items.AddRange(new object[2]
      {
        (object) "(local)",
        (object) ".\\SQLEXPRESS"
      });
      this.cboDBServers.Location = new Point(17, 42);
      this.cboDBServers.Name = "cboDBServers";
      this.cboDBServers.Size = new Size(141, 20);
      this.cboDBServers.TabIndex = 9;
      this.label6.AutoSize = true;
      this.label6.Location = new Point(15, 25);
      this.label6.Name = "label6";
      this.label6.Size = new Size(89, 12);
      this.label6.TabIndex = 8;
      this.label6.Text = "数据库服务器：";
      this.btnDBLogin.Location = new Point(103, 124);
      this.btnDBLogin.Name = "btnDBLogin";
      this.btnDBLogin.Size = new Size(55, 23);
      this.btnDBLogin.TabIndex = 7;
      this.btnDBLogin.Text = "登  录";
      this.btnDBLogin.UseVisualStyleBackColor = true;
      this.btnDBLogin.Click += new EventHandler(this.btnDBLogin_Click);
      this.txtPwd.Location = new Point(72, 96);
      this.txtPwd.Name = "txtPwd";
      this.txtPwd.PasswordChar = '*';
      this.txtPwd.Size = new Size(86, 21);
      this.txtPwd.TabIndex = 6;
      this.txtUid.Location = new Point(72, 69);
      this.txtUid.Name = "txtUid";
      this.txtUid.Size = new Size(86, 21);
      this.txtUid.TabIndex = 5;
      this.txtUid.Text = "sa";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(15, 101);
      this.label2.Name = "label2";
      this.label2.Size = new Size(53, 12);
      this.label2.TabIndex = 3;
      this.label2.Text = "密  码：";
      this.label1.AutoSize = true;
      this.label1.Location = new Point(15, 74);
      this.label1.Name = "label1";
      this.label1.Size = new Size(53, 12);
      this.label1.TabIndex = 4;
      this.label1.Text = "用户名：";
      this.lbxTableName.FormattingEnabled = true;
      this.lbxTableName.ItemHeight = 12;
      this.lbxTableName.Location = new Point(15, 259);
      this.lbxTableName.Name = "lbxTableName";
      this.lbxTableName.Size = new Size(172, 88);
      this.lbxTableName.TabIndex = 15;
      this.lbxTableName.SelectedIndexChanged += new EventHandler(this.lbxTableName_SelectedIndexChanged);
      this.cboDBList.FormattingEnabled = true;
      this.cboDBList.Location = new Point(15, 206);
      this.cboDBList.Name = "cboDBList";
      this.cboDBList.Size = new Size(172, 20);
      this.cboDBList.TabIndex = 13;
      this.cboDBList.SelectionChangeCommitted += new EventHandler(this.cboDBList_SelectionChangeCommitted);
      this.cboDBList.SelectedIndexChanged += new EventHandler(this.cboDBList_SelectedIndexChanged);
      this.label4.AutoSize = true;
      this.label4.Location = new Point(18, 244);
      this.label4.Name = "label4";
      this.label4.Size = new Size(77, 12);
      this.label4.TabIndex = 11;
      this.label4.Text = "选择数据表：";
      this.label3.AutoSize = true;
      this.label3.Location = new Point(18, 191);
      this.label3.Name = "label3";
      this.label3.Size = new Size(77, 12);
      this.label3.TabIndex = 12;
      this.label3.Text = "选择数据库：";
      this.txtEntityClass.Dock = DockStyle.Fill;
      this.txtEntityClass.Font = new Font("新宋体", 13f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.txtEntityClass.Location = new Point(0, 0);
      this.txtEntityClass.Name = "txtEntityClass";
      this.txtEntityClass.Size = new Size(389, 465);
      this.txtEntityClass.TabIndex = 0;
      this.txtEntityClass.Text = "";
      this.txtEntityClass.TextChanged += new EventHandler(this.txtEntityClass_TextChanged);
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(595, 465);
      this.Controls.Add((Control) this.splitContainer1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (Form1);
      this.Text = "实体类生成工具";
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel1.PerformLayout();
      this.splitContainer1.Panel2.ResumeLayout(false);
      this.splitContainer1.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
