// Decompiled with JetBrains decompiler
// Type: 实体类生成工具.Form2
// Assembly: 实体类生成工具, Version=2.0.0.4, Culture=neutral, PublicKeyToken=null
// MVID: E857BE9B-E6E4-4EB0-873A-168F60AB74E0
// Assembly location: E:\DownLoad\实体类生成工具\实体类生成工具.exe

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace 实体类生成工具
{
  public class Form2 : Form
  {
    private IContainer components;
    private Button btnAddFunction;
    private CheckBox cboAllCheck;
    private CheckBox cboAllNoCheck;
    private GroupBox groupBox2;
    private Panel groupBox1;
    private RadioButton radioButton4;
    private RadioButton radioButton3;
    private RadioButton radioButton2;
    private RadioButton radioButton1;
    private Button button1;
    private CheckBox cboNoNullFiled;
    private Form1 form1;
    private ArrayList al_AboutField;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Form2));
      this.cboAllCheck = new CheckBox();
      this.btnAddFunction = new Button();
      this.cboAllNoCheck = new CheckBox();
      this.groupBox2 = new GroupBox();
      this.radioButton4 = new RadioButton();
      this.radioButton3 = new RadioButton();
      this.radioButton2 = new RadioButton();
      this.radioButton1 = new RadioButton();
      this.groupBox1 = new Panel();
      this.button1 = new Button();
      this.cboNoNullFiled = new CheckBox();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      this.cboAllCheck.AutoSize = true;
      this.cboAllCheck.Location = new Point(12, 14);
      this.cboAllCheck.Name = "cboAllCheck";
      this.cboAllCheck.Size = new Size(48, 16);
      this.cboAllCheck.TabIndex = 0;
      this.cboAllCheck.Text = "全选";
      this.cboAllCheck.UseVisualStyleBackColor = true;
      this.cboAllCheck.Click += new EventHandler(this.cboAllCheck_Click);
      this.btnAddFunction.Location = new Point(285, 160);
      this.btnAddFunction.Name = "btnAddFunction";
      this.btnAddFunction.Size = new Size(101, 23);
      this.btnAddFunction.TabIndex = 2;
      this.btnAddFunction.Text = "添 加";
      this.btnAddFunction.UseVisualStyleBackColor = true;
      this.btnAddFunction.Click += new EventHandler(this.btnAddFunction_Click);
      this.cboAllNoCheck.AutoSize = true;
      this.cboAllNoCheck.Location = new Point(65, 14);
      this.cboAllNoCheck.Name = "cboAllNoCheck";
      this.cboAllNoCheck.Size = new Size(60, 16);
      this.cboAllNoCheck.TabIndex = 3;
      this.cboAllNoCheck.Text = "全不选";
      this.cboAllNoCheck.UseVisualStyleBackColor = true;
      this.cboAllNoCheck.Click += new EventHandler(this.cboAllNoCheck_Click);
      this.groupBox2.Controls.Add((Control) this.radioButton4);
      this.groupBox2.Controls.Add((Control) this.radioButton3);
      this.groupBox2.Controls.Add((Control) this.radioButton2);
      this.groupBox2.Controls.Add((Control) this.radioButton1);
      this.groupBox2.Location = new Point(285, 12);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new Size(101, 140);
      this.groupBox2.TabIndex = 4;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "访问权限";
      this.radioButton4.AutoSize = true;
      this.radioButton4.Location = new Point(14, 111);
      this.radioButton4.Name = "radioButton4";
      this.radioButton4.Size = new Size(71, 16);
      this.radioButton4.TabIndex = 12;
      this.radioButton4.Text = "internal";
      this.radioButton4.UseVisualStyleBackColor = true;
      this.radioButton3.AutoSize = true;
      this.radioButton3.Location = new Point(14, 81);
      this.radioButton3.Name = "radioButton3";
      this.radioButton3.Size = new Size(65, 16);
      this.radioButton3.TabIndex = 13;
      this.radioButton3.Text = "private";
      this.radioButton3.UseVisualStyleBackColor = true;
      this.radioButton2.AutoSize = true;
      this.radioButton2.Location = new Point(14, 51);
      this.radioButton2.Name = "radioButton2";
      this.radioButton2.Size = new Size(77, 16);
      this.radioButton2.TabIndex = 10;
      this.radioButton2.Text = "protected";
      this.radioButton2.UseVisualStyleBackColor = true;
      this.radioButton1.AutoSize = true;
      this.radioButton1.Checked = true;
      this.radioButton1.Location = new Point(14, 21);
      this.radioButton1.Name = "radioButton1";
      this.radioButton1.Size = new Size(59, 16);
      this.radioButton1.TabIndex = 11;
      this.radioButton1.TabStop = true;
      this.radioButton1.Text = "public";
      this.radioButton1.UseVisualStyleBackColor = true;
      this.groupBox1.BackColor = Color.White;
      this.groupBox1.BorderStyle = BorderStyle.Fixed3D;
      this.groupBox1.Location = new Point(12, 38);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(259, 174);
      this.groupBox1.TabIndex = 7;
      this.button1.Location = new Point(285, 189);
      this.button1.Name = "button1";
      this.button1.Size = new Size(101, 23);
      this.button1.TabIndex = 2;
      this.button1.Text = "取 消";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.cboNoNullFiled.AutoSize = true;
      this.cboNoNullFiled.Checked = true;
      this.cboNoNullFiled.CheckState = CheckState.Checked;
      this.cboNoNullFiled.ForeColor = Color.Red;
      this.cboNoNullFiled.Location = new Point(130, 14);
      this.cboNoNullFiled.Name = "cboNoNullFiled";
      this.cboNoNullFiled.Size = new Size(144, 16);
      this.cboNoNullFiled.TabIndex = 8;
      this.cboNoNullFiled.Text = "添加非空字段构造方法";
      this.cboNoNullFiled.UseVisualStyleBackColor = true;
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(397, 223);
      this.Controls.Add((Control) this.cboNoNullFiled);
      this.Controls.Add((Control) this.groupBox1);
      this.Controls.Add((Control) this.groupBox2);
      this.Controls.Add((Control) this.cboAllNoCheck);
      this.Controls.Add((Control) this.cboAllCheck);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.btnAddFunction);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (Form2);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "构造函数窗体";
      this.Load += new EventHandler(this.Form2_Load);
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public Form2(Form1 form1)
    {
      this.InitializeComponent();
      this.form1 = form1;
      this.groupBox1.Padding = new Padding(20, 6, 3, 3);
      this.MaximizeBox = false;
    }

    private void Form2_Load(object sender, EventArgs e)
    {
      this.al_AboutField = new DBHelper().GetFieldAndNullByConAndSql("Server=" + this.form1.DBServer + ";Database=" + this.form1.DatabaeUsingInfo.Database + ";Uid=" + this.form1.DatabaeUsingInfo.LoginUid + ";Pwd=" + this.form1.DatabaeUsingInfo.LoginPwd, "select column_name,is_nullable from " + this.form1.DatabaeUsingInfo.Database + ".information_schema.columns where table_name='" + this.form1.DatabaeUsingInfo.Table + "'");
      int num = 6;
      if (this.al_AboutField.Count > num)
      {
        this.Height += (this.al_AboutField.Count - num) * 24;
        this.groupBox1.Height += (this.al_AboutField.Count - num) * 24;
      }
      this.al_AboutField.Reverse();
      foreach (AboutField aboutField in this.al_AboutField)
      {
        CheckBox checkBox = new CheckBox();
        checkBox.Margin = new Padding(0, 2, 0, 2);
        checkBox.Text = aboutField.col_name.PadRight(20) + aboutField.col_nullable;
        checkBox.Tag = (object) aboutField.col_name;
        checkBox.Dock = DockStyle.Top;
        if ("not null" == aboutField.col_nullable.Trim())
        {
          checkBox.ForeColor = Color.Red;
          checkBox.Checked = true;
        }
        this.groupBox1.Controls.Add((Control) checkBox);
      }
    }

    private void cboAllCheck_Click(object sender, EventArgs e)
    {
      this.cboAllNoCheck.Checked = !this.cboAllCheck.Checked;
      this.setAllCheckBoxCheckState();
    }

    private void cboAllNoCheck_Click(object sender, EventArgs e)
    {
      this.cboAllCheck.Checked = !this.cboAllNoCheck.Checked;
      this.setAllCheckBoxCheckState();
    }

    private void setAllCheckBoxCheckState()
    {
      foreach (Control control in (ArrangedElementCollection) this.groupBox1.Controls)
      {
        if (this.cboAllCheck.Checked)
        {
          if (control is CheckBox)
            ((CheckBox) control).Checked = true;
        }
        else if (control is CheckBox)
          ((CheckBox) control).Checked = false;
      }
    }

    private void btnAddFunction_Click(object sender, EventArgs e)
    {
      StringBuilder stringBuilder1 = new StringBuilder();
      stringBuilder1.AppendLine("\t/// <summary>");
      stringBuilder1.AppendLine("\t/// 无参构造方法");
      stringBuilder1.AppendLine("\t/// </summary>");
      foreach (RadioButton control in (ArrangedElementCollection) this.groupBox2.Controls)
      {
        if (control.Checked)
        {
          stringBuilder1.Append("\t");
          stringBuilder1.Append(control.Text.Trim());
        }
      }
      stringBuilder1.Append(" ");
      string str1 = this.form1.DatabaeUsingInfo.Table.Substring(0, 1).ToUpper() + this.form1.DatabaeUsingInfo.Table.Substring(1);
      stringBuilder1.Append(str1);
      stringBuilder1.AppendLine("(){ }");
      StringBuilder stringBuilder2 = new StringBuilder();
      StringBuilder stringBuilder3 = new StringBuilder();
      StringBuilder stringBuilder4 = new StringBuilder();
      if (this.cboNoNullFiled.Checked)
      {
        stringBuilder2.AppendLine();
        stringBuilder2.AppendLine("\t/// <summary>");
        stringBuilder2.AppendLine("\t/// 数据库非空字段的构造方法");
        stringBuilder2.AppendLine("\t/// </summary>");
        if (this.al_AboutField.Count > 0)
        {
          foreach (RadioButton control in (ArrangedElementCollection) this.groupBox2.Controls)
          {
            if (control.Checked)
            {
              stringBuilder2.Append("\t");
              stringBuilder2.Append(control.Text.Trim());
            }
          }
          stringBuilder2.Append(" ");
          stringBuilder2.Append(str1);
          stringBuilder2.Append("(");
          this.al_AboutField.Reverse();
          foreach (AboutField aboutField in this.al_AboutField)
          {
            if ("not null" == aboutField.col_nullable.Trim())
            {
              foreach (string str2 in this.form1.GetDB_colname_And_type())
              {
                if (aboutField.col_name == str2.Substring(0, str2.IndexOf('|')))
                {
                  string str3 = str2.Substring(str2.IndexOf('|') + 1);
                  if ("" != str3)
                  {
                    stringBuilder2.Append(str3);
                    stringBuilder2.Append(" ");
                    stringBuilder2.Append(aboutField.col_name);
                    stringBuilder2.Append(",");
                  }
                }
              }
            }
          }
          stringBuilder2.Remove(stringBuilder2.Length - 1, 1);
          stringBuilder2.AppendLine(")");
          stringBuilder2.AppendLine("\t{");
          foreach (AboutField aboutField in this.al_AboutField)
          {
            if ("not null" == aboutField.col_nullable.Trim())
            {
              stringBuilder2.Append("\t\tthis.");
              stringBuilder2.Append(aboutField.col_name);
              stringBuilder2.Append(" = ");
              stringBuilder2.Append(aboutField.col_name);
              stringBuilder2.AppendLine(";");
              stringBuilder3.Append(aboutField.col_name.Trim());
            }
          }
          stringBuilder2.AppendLine("\t}");
        }
      }
      if (this.cboNoNullFiled.Checked)
        stringBuilder1.Append(stringBuilder2.ToString());
      bool flag = false;
      StringBuilder stringBuilder5 = new StringBuilder();
      stringBuilder5.AppendLine();
      stringBuilder5.AppendLine("\t/// <summary>");
      stringBuilder5.AppendLine("\t/// 指定字段的构造方法");
      stringBuilder5.AppendLine("\t/// </summary>");
      foreach (RadioButton control in (ArrangedElementCollection) this.groupBox2.Controls)
      {
        if (control.Checked)
        {
          stringBuilder5.Append("\t");
          stringBuilder5.Append(control.Text.Trim());
        }
      }
      stringBuilder5.Append(" ");
      stringBuilder5.Append(str1);
      stringBuilder5.Append("(");
      for (int index = this.groupBox1.Controls.Count - 1; index >= 0; --index)
      {
        CheckBox control = this.groupBox1.Controls[index] as CheckBox;
        if (control != null && control.Checked)
        {
          flag = true;
          string str2 = control.Tag.ToString();
          foreach (string str3 in this.form1.GetDB_colname_And_type())
          {
            if (str2 == str3.Substring(0, str3.IndexOf('|')))
            {
              string str4 = str3.Substring(str3.IndexOf('|') + 1);
              if ("" != str4)
              {
                stringBuilder5.Append(str4);
                stringBuilder5.Append(" ");
                stringBuilder5.Append(str2);
                stringBuilder5.Append(",");
              }
            }
          }
        }
      }
      stringBuilder5.Remove(stringBuilder5.Length - 1, 1);
      stringBuilder5.AppendLine(")");
      stringBuilder5.AppendLine("\t{");
      for (int index = this.groupBox1.Controls.Count - 1; index >= 0; --index)
      {
        CheckBox control = this.groupBox1.Controls[index] as CheckBox;
        if (control != null && control.Checked)
        {
          string str2 = control.Tag.ToString();
          stringBuilder5.Append("\t\tthis.");
          stringBuilder5.Append(str2);
          stringBuilder5.Append(" = ");
          stringBuilder5.Append(str2);
          stringBuilder5.AppendLine(";");
          stringBuilder4.Append(str2.Trim());
        }
      }
      stringBuilder5.AppendLine("\t}");
      if (flag)
      {
        string str2 = stringBuilder3.ToString().Trim();
        string strB = stringBuilder4.ToString().Trim();
        if (this.cboNoNullFiled.Checked)
        {
          if (str2.CompareTo(strB) != 0)
            stringBuilder1.Append(stringBuilder5.ToString());
        }
        else
          stringBuilder1.Append(stringBuilder5.ToString());
      }
      this.form1.IsBuildFun = true;
      this.form1.StrBuildFun = stringBuilder1.ToString();
      if (!this.form1.TxtEntityClassIsNull && MessageBox.Show((IWin32Window) this, "是否重新加载实体类？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
      {
        this.form1.LoadingEntityClass_Text();
        this.form1.btnCopy.Enabled = true;
        this.form1.btnCreateCSFile.Enabled = true;
      }
      this.Close();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.form1.IsBuildFun = false;
      this.Close();
    }
  }
}
