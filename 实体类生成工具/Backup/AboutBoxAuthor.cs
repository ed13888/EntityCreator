// Decompiled with JetBrains decompiler
// Type: 实体类生成工具.AboutBoxAuthor
// Assembly: 实体类生成工具, Version=2.0.0.4, Culture=neutral, PublicKeyToken=null
// MVID: E857BE9B-E6E4-4EB0-873A-168F60AB74E0
// Assembly location: E:\DownLoad\实体类生成工具\实体类生成工具.exe

using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace 实体类生成工具
{
  internal class AboutBoxAuthor : Form
  {
    private IContainer components;
    private TableLayoutPanel tableLayoutPanel;
    private PictureBox logoPictureBox;
    private Label labelProductName;
    private Label labelVersion;
    private Label labelCopyright;
    private Label labelCompanyName;
    private Label textBoxDescription;
    private Button okButton;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (AboutBoxAuthor));
      this.tableLayoutPanel = new TableLayoutPanel();
      this.logoPictureBox = new PictureBox();
      this.labelProductName = new Label();
      this.labelVersion = new Label();
      this.labelCopyright = new Label();
      this.labelCompanyName = new Label();
      this.textBoxDescription = new Label();
      this.okButton = new Button();
      this.tableLayoutPanel.SuspendLayout();
      ((ISupportInitialize) this.logoPictureBox).BeginInit();
      this.SuspendLayout();
      this.tableLayoutPanel.ColumnCount = 2;
      this.tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333f));
      this.tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 66.66666f));
      this.tableLayoutPanel.Controls.Add((Control) this.logoPictureBox, 0, 0);
      this.tableLayoutPanel.Controls.Add((Control) this.labelProductName, 1, 0);
      this.tableLayoutPanel.Controls.Add((Control) this.labelVersion, 1, 1);
      this.tableLayoutPanel.Controls.Add((Control) this.labelCopyright, 1, 2);
      this.tableLayoutPanel.Controls.Add((Control) this.labelCompanyName, 1, 3);
      this.tableLayoutPanel.Controls.Add((Control) this.textBoxDescription, 1, 4);
      this.tableLayoutPanel.Controls.Add((Control) this.okButton, 1, 5);
      this.tableLayoutPanel.Dock = DockStyle.Fill;
      this.tableLayoutPanel.Location = new Point(9, 8);
      this.tableLayoutPanel.Name = "tableLayoutPanel";
      this.tableLayoutPanel.RowCount = 6;
      this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
      this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 15f));
      this.tableLayoutPanel.Size = new Size(267, 138);
      this.tableLayoutPanel.TabIndex = 0;
      this.logoPictureBox.Image = (Image) componentResourceManager.GetObject("logoPictureBox.Image");
      this.logoPictureBox.Location = new Point(3, 3);
      this.logoPictureBox.Name = "logoPictureBox";
      this.tableLayoutPanel.SetRowSpan((Control) this.logoPictureBox, 6);
      this.logoPictureBox.Size = new Size(82, 132);
      this.logoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
      this.logoPictureBox.TabIndex = 12;
      this.logoPictureBox.TabStop = false;
      this.labelProductName.Dock = DockStyle.Fill;
      this.labelProductName.Location = new Point(95, 0);
      this.labelProductName.Margin = new Padding(6, 0, 3, 0);
      this.labelProductName.MaximumSize = new Size(0, 16);
      this.labelProductName.Name = "labelProductName";
      this.labelProductName.Size = new Size(169, 16);
      this.labelProductName.TabIndex = 19;
      this.labelProductName.Text = "产品名称";
      this.labelProductName.TextAlign = ContentAlignment.MiddleLeft;
      this.labelVersion.Dock = DockStyle.Fill;
      this.labelVersion.Location = new Point(95, 20);
      this.labelVersion.Margin = new Padding(6, 0, 3, 0);
      this.labelVersion.MaximumSize = new Size(0, 16);
      this.labelVersion.Name = "labelVersion";
      this.labelVersion.Size = new Size(169, 16);
      this.labelVersion.TabIndex = 0;
      this.labelVersion.Text = "版本";
      this.labelVersion.TextAlign = ContentAlignment.MiddleLeft;
      this.labelCopyright.Dock = DockStyle.Fill;
      this.labelCopyright.Location = new Point(95, 40);
      this.labelCopyright.Margin = new Padding(6, 0, 3, 0);
      this.labelCopyright.MaximumSize = new Size(0, 16);
      this.labelCopyright.Name = "labelCopyright";
      this.labelCopyright.Size = new Size(169, 16);
      this.labelCopyright.TabIndex = 21;
      this.labelCopyright.Text = "日期";
      this.labelCopyright.TextAlign = ContentAlignment.MiddleLeft;
      this.labelCompanyName.Dock = DockStyle.Fill;
      this.labelCompanyName.Location = new Point(95, 60);
      this.labelCompanyName.Margin = new Padding(6, 0, 3, 0);
      this.labelCompanyName.MaximumSize = new Size(0, 16);
      this.labelCompanyName.Name = "labelCompanyName";
      this.labelCompanyName.Size = new Size(169, 16);
      this.labelCompanyName.TabIndex = 22;
      this.labelCompanyName.Text = "公司";
      this.labelCompanyName.TextAlign = ContentAlignment.MiddleLeft;
      this.textBoxDescription.Dock = DockStyle.Fill;
      this.textBoxDescription.Font = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.textBoxDescription.Location = new Point(95, 83);
      this.textBoxDescription.Margin = new Padding(6, 3, 3, 3);
      this.textBoxDescription.Name = "textBoxDescription";
      this.textBoxDescription.Size = new Size(169, 22);
      this.textBoxDescription.TabIndex = 23;
      this.textBoxDescription.Text = "说明";
      this.okButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.okButton.DialogResult = DialogResult.Cancel;
      this.okButton.Location = new Point(189, 113);
      this.okButton.Name = "okButton";
      this.okButton.Size = new Size(75, 22);
      this.okButton.TabIndex = 24;
      this.okButton.Text = "确定(&O)";
      this.AcceptButton = (IButtonControl) this.okButton;
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(285, 154);
      this.Controls.Add((Control) this.tableLayoutPanel);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (AboutBoxAuthor);
      this.Padding = new Padding(9, 8, 9, 8);
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "关于";
      this.tableLayoutPanel.ResumeLayout(false);
      ((ISupportInitialize) this.logoPictureBox).EndInit();
      this.ResumeLayout(false);
    }

    public AboutBoxAuthor()
    {
      this.InitializeComponent();
      this.labelProductName.Text = this.AssemblyProduct;
      this.labelVersion.Text = string.Format("版本 {0}", (object) this.AssemblyVersion);
      this.labelCopyright.Text = this.AssemblyCopyright;
      this.labelCompanyName.Text += this.AssemblyCompany;
      this.textBoxDescription.Text = this.AssemblyDescription;
    }

    public string AssemblyTitle
    {
      get
      {
        object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyTitleAttribute), false);
        if (customAttributes.Length > 0)
        {
          AssemblyTitleAttribute assemblyTitleAttribute = (AssemblyTitleAttribute) customAttributes[0];
          if (assemblyTitleAttribute.Title != "")
            return assemblyTitleAttribute.Title;
        }
        return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
      }
    }

    public string AssemblyVersion
    {
      get
      {
        return Assembly.GetExecutingAssembly().GetName().Version.ToString();
      }
    }

    public string AssemblyDescription
    {
      get
      {
        object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyDescriptionAttribute), false);
        if (customAttributes.Length == 0)
          return "";
        return ((AssemblyDescriptionAttribute) customAttributes[0]).Description;
      }
    }

    public string AssemblyProduct
    {
      get
      {
        object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyProductAttribute), false);
        if (customAttributes.Length == 0)
          return "";
        return ((AssemblyProductAttribute) customAttributes[0]).Product;
      }
    }

    public string AssemblyCopyright
    {
      get
      {
        object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyCopyrightAttribute), false);
        if (customAttributes.Length == 0)
          return "";
        return ((AssemblyCopyrightAttribute) customAttributes[0]).Copyright;
      }
    }

    public string AssemblyCompany
    {
      get
      {
        object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyCompanyAttribute), false);
        if (customAttributes.Length == 0)
          return "";
        return ((AssemblyCompanyAttribute) customAttributes[0]).Company;
      }
    }
  }
}
