// Decompiled with JetBrains decompiler
// Type: 实体类生成工具.MyMessageBox
// Assembly: 实体类生成工具, Version=2.0.0.4, Culture=neutral, PublicKeyToken=null
// MVID: E857BE9B-E6E4-4EB0-873A-168F60AB74E0
// Assembly location: E:\DownLoad\实体类生成工具\实体类生成工具.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace 实体类生成工具
{
  public class MyMessageBox : Form
  {
    private IContainer components;
    private Label label1;
    private Button button1;

    public MyMessageBox()
    {
      this.InitializeComponent();
      this.StartPosition = FormStartPosition.CenterParent;
    }

    public MyMessageBox(string msg)
    {
      this.InitializeComponent();
      this.StartPosition = FormStartPosition.CenterParent;
      this.label1.Text = msg;
      if (msg.Length <= 10)
        return;
      this.Width += (msg.Length - 10) * 9;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.Close();
      this.Dispose();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (MyMessageBox));
      this.label1 = new Label();
      this.button1 = new Button();
      this.SuspendLayout();
      this.label1.AutoSize = true;
      this.label1.Location = new Point(15, 20);
      this.label1.Name = "label1";
      this.label1.Size = new Size(11, 12);
      this.label1.TabIndex = 0;
      this.label1.Text = "a";
      this.button1.Anchor = AnchorStyles.None;
      this.button1.Location = new Point(40, 49);
      this.button1.Name = "button1";
      this.button1.Size = new Size(55, 22);
      this.button1.TabIndex = 1;
      this.button1.Text = "确 定";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(134, 78);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.label1);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (MyMessageBox);
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.Text = "提示框";
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
