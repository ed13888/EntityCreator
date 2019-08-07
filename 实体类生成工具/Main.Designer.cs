namespace 实体类生成工具
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDBLogin = new System.Windows.Forms.Button();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboDBServers = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboDBList = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboTableName = new System.Windows.Forms.ComboBox();
            this.btnBuildFun = new System.Windows.Forms.Button();
            this.btnCreateEntity = new System.Windows.Forms.Button();
            this.btnCreateCSFile = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnCreateScript = new System.Windows.Forms.Button();
            this.txtEntityClass = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDBLogin);
            this.groupBox1.Controls.Add(this.txtPwd);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtUid);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboDBServers);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(190, 152);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "登录信息";
            // 
            // btnDBLogin
            // 
            this.btnDBLogin.Location = new System.Drawing.Point(8, 106);
            this.btnDBLogin.Name = "btnDBLogin";
            this.btnDBLogin.Size = new System.Drawing.Size(170, 37);
            this.btnDBLogin.TabIndex = 6;
            this.btnDBLogin.Text = "登录";
            this.btnDBLogin.UseVisualStyleBackColor = true;
            this.btnDBLogin.Click += new System.EventHandler(this.btnDBLogin_Click);
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(57, 79);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(121, 21);
            this.txtPwd.TabIndex = 5;
            this.txtPwd.Text = "12345678";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "密码:";
            // 
            // txtUid
            // 
            this.txtUid.Location = new System.Drawing.Point(57, 55);
            this.txtUid.Name = "txtUid";
            this.txtUid.Size = new System.Drawing.Size(121, 21);
            this.txtUid.TabIndex = 3;
            this.txtUid.Text = "develop";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "用户名:";
            // 
            // cboDBServers
            // 
            this.cboDBServers.FormattingEnabled = true;
            this.cboDBServers.Items.AddRange(new object[] {
            "192.168.10.139",
            ".\\\\SQLEXPRESS"});
            this.cboDBServers.Location = new System.Drawing.Point(6, 32);
            this.cboDBServers.Name = "cboDBServers";
            this.cboDBServers.Size = new System.Drawing.Size(172, 20);
            this.cboDBServers.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "数据库服务器:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "选择数据库:";
            // 
            // cboDBList
            // 
            this.cboDBList.FormattingEnabled = true;
            this.cboDBList.Location = new System.Drawing.Point(12, 182);
            this.cboDBList.Name = "cboDBList";
            this.cboDBList.Size = new System.Drawing.Size(190, 20);
            this.cboDBList.TabIndex = 2;
            this.cboDBList.SelectedIndexChanged += new System.EventHandler(this.cboDBList_SelectedIndexChanged);
            this.cboDBList.SelectionChangeCommitted += new System.EventHandler(this.cboDBList_SelectionChangeCommitted);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 225);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "选择数据表:";
            // 
            // cboTableName
            // 
            this.cboTableName.FormattingEnabled = true;
            this.cboTableName.Location = new System.Drawing.Point(12, 240);
            this.cboTableName.Name = "cboTableName";
            this.cboTableName.Size = new System.Drawing.Size(190, 20);
            this.cboTableName.TabIndex = 4;
            this.cboTableName.TextUpdate += new System.EventHandler(this.cboTableName_TextChanged);
            this.cboTableName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cboTableName_MouseClick);
            // 
            // btnBuildFun
            // 
            this.btnBuildFun.Location = new System.Drawing.Point(14, 279);
            this.btnBuildFun.Name = "btnBuildFun";
            this.btnBuildFun.Size = new System.Drawing.Size(75, 23);
            this.btnBuildFun.TabIndex = 5;
            this.btnBuildFun.Text = "构造函数";
            this.btnBuildFun.UseVisualStyleBackColor = true;
            this.btnBuildFun.Click += new System.EventHandler(this.btnBuildFun_Click);
            // 
            // btnCreateEntity
            // 
            this.btnCreateEntity.Location = new System.Drawing.Point(127, 279);
            this.btnCreateEntity.Name = "btnCreateEntity";
            this.btnCreateEntity.Size = new System.Drawing.Size(75, 23);
            this.btnCreateEntity.TabIndex = 6;
            this.btnCreateEntity.Text = "产生实体类";
            this.btnCreateEntity.UseVisualStyleBackColor = true;
            this.btnCreateEntity.Click += new System.EventHandler(this.btnCreateEntity_Click);
            // 
            // btnCreateCSFile
            // 
            this.btnCreateCSFile.Location = new System.Drawing.Point(127, 308);
            this.btnCreateCSFile.Name = "btnCreateCSFile";
            this.btnCreateCSFile.Size = new System.Drawing.Size(75, 23);
            this.btnCreateCSFile.TabIndex = 8;
            this.btnCreateCSFile.Text = "产生类文件";
            this.btnCreateCSFile.UseVisualStyleBackColor = true;
            this.btnCreateCSFile.Click += new System.EventHandler(this.btnCreateCSFile_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(14, 308);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 23);
            this.btnCopy.TabIndex = 7;
            this.btnCopy.Text = "复制";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnCreateScript
            // 
            this.btnCreateScript.Location = new System.Drawing.Point(14, 337);
            this.btnCreateScript.Name = "btnCreateScript";
            this.btnCreateScript.Size = new System.Drawing.Size(75, 23);
            this.btnCreateScript.TabIndex = 9;
            this.btnCreateScript.Text = "产生脚本";
            this.btnCreateScript.UseVisualStyleBackColor = true;
            this.btnCreateScript.Click += new System.EventHandler(this.btnCreateScript_Click);
            // 
            // txtEntityClass
            // 
            this.txtEntityClass.Location = new System.Drawing.Point(208, 1);
            this.txtEntityClass.Name = "txtEntityClass";
            this.txtEntityClass.Size = new System.Drawing.Size(590, 447);
            this.txtEntityClass.TabIndex = 10;
            this.txtEntityClass.Text = "";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtEntityClass);
            this.Controls.Add(this.btnCreateScript);
            this.Controls.Add(this.btnCreateCSFile);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnCreateEntity);
            this.Controls.Add(this.btnBuildFun);
            this.Controls.Add(this.cboTableName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboDBList);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Name = "Main";
            this.Text = "实体类生成工具V1.3";
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDBLogin;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboDBServers;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboDBList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboTableName;
        private System.Windows.Forms.Button btnBuildFun;
        private System.Windows.Forms.Button btnCreateEntity;
        private System.Windows.Forms.Button btnCreateCSFile;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnCreateScript;
        private System.Windows.Forms.RichTextBox txtEntityClass;
    }
}