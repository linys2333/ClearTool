namespace ClearTool
{
    partial class SettingForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            this.btnCompara = new System.Windows.Forms.Button();
            this.prgCompara = new System.Windows.Forms.ProgressBar();
            this.dbCompara = new LysControl.DBConnect();
            this.dbTarget = new LysControl.DBConnect();
            this.splitMenu1 = new LysControl.SplitMenu();
            this.splitMenu2 = new LysControl.SplitMenu();
            this.cmbSys = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnSync = new System.Windows.Forms.Button();
            this.splitMenu3 = new LysControl.SplitMenu();
            this.SuspendLayout();
            // 
            // btnCompara
            // 
            this.btnCompara.Location = new System.Drawing.Point(135, 461);
            this.btnCompara.Name = "btnCompara";
            this.btnCompara.Size = new System.Drawing.Size(80, 30);
            this.btnCompara.TabIndex = 2;
            this.btnCompara.Text = "比 较";
            this.btnCompara.UseVisualStyleBackColor = true;
            this.btnCompara.Click += new System.EventHandler(this.btnCompara_Click);
            // 
            // prgCompara
            // 
            this.prgCompara.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.prgCompara.Location = new System.Drawing.Point(0, 500);
            this.prgCompara.MarqueeAnimationSpeed = 10;
            this.prgCompara.Maximum = 10;
            this.prgCompara.Name = "prgCompara";
            this.prgCompara.Size = new System.Drawing.Size(361, 10);
            this.prgCompara.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.prgCompara.TabIndex = 5;
            this.prgCompara.Visible = false;
            // 
            // dbCompara
            // 
            this.dbCompara.BackColor = System.Drawing.Color.White;
            this.dbCompara.ConfigFolder = "\\ClearTool\\";
            this.dbCompara.Database = "";
            this.dbCompara.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dbCompara.Location = new System.Drawing.Point(9, 287);
            this.dbCompara.MaximumSize = new System.Drawing.Size(400, 167);
            this.dbCompara.MinimumSize = new System.Drawing.Size(240, 167);
            this.dbCompara.Name = "dbCompara";
            this.dbCompara.Password = "";
            this.dbCompara.Server = "";
            this.dbCompara.Size = new System.Drawing.Size(343, 167);
            this.dbCompara.TabIndex = 1;
            this.dbCompara.UserName = "";
            // 
            // dbTarget
            // 
            this.dbTarget.BackColor = System.Drawing.Color.White;
            this.dbTarget.ConfigFolder = "\\ClearTool\\";
            this.dbTarget.Database = "";
            this.dbTarget.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dbTarget.Location = new System.Drawing.Point(9, 59);
            this.dbTarget.MaximumSize = new System.Drawing.Size(400, 167);
            this.dbTarget.MinimumSize = new System.Drawing.Size(240, 167);
            this.dbTarget.Name = "dbTarget";
            this.dbTarget.Password = "";
            this.dbTarget.Server = "";
            this.dbTarget.Size = new System.Drawing.Size(343, 167);
            this.dbTarget.TabIndex = 0;
            this.dbTarget.UserName = "";
            // 
            // splitMenu1
            // 
            this.splitMenu1.BackColor = System.Drawing.Color.White;
            this.splitMenu1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.splitMenu1.Location = new System.Drawing.Point(17, 246);
            this.splitMenu1.Name = "splitMenu1";
            this.splitMenu1.Size = new System.Drawing.Size(325, 30);
            this.splitMenu1.TabIndex = 9;
            this.splitMenu1.Title = "对比数据库";
            // 
            // splitMenu2
            // 
            this.splitMenu2.BackColor = System.Drawing.Color.White;
            this.splitMenu2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.splitMenu2.Location = new System.Drawing.Point(17, 18);
            this.splitMenu2.Name = "splitMenu2";
            this.splitMenu2.Size = new System.Drawing.Size(325, 30);
            this.splitMenu2.TabIndex = 10;
            this.splitMenu2.Title = "目标数据库";
            // 
            // cmbSys
            // 
            this.cmbSys.BackColor = System.Drawing.Color.White;
            this.cmbSys.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSys.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSys.FormattingEnabled = true;
            this.cmbSys.ItemHeight = 21;
            this.cmbSys.Location = new System.Drawing.Point(223, 17);
            this.cmbSys.Name = "cmbSys";
            this.cmbSys.Size = new System.Drawing.Size(120, 29);
            this.cmbSys.TabIndex = 12;
            // 
            // btnSync
            // 
            this.btnSync.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSync.BackColor = System.Drawing.Color.Transparent;
            this.btnSync.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSync.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnSync.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnSync.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSync.Image = ((System.Drawing.Image)(resources.GetObject("btnSync.Image")));
            this.btnSync.Location = new System.Drawing.Point(312, 243);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(30, 30);
            this.btnSync.TabIndex = 6;
            this.toolTip1.SetToolTip(this.btnSync, "同步");
            this.btnSync.UseVisualStyleBackColor = false;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            this.btnSync.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSync_MouseDown);
            this.btnSync.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnSync_MouseUp);
            // 
            // splitMenu3
            // 
            this.splitMenu3.BackColor = System.Drawing.Color.White;
            this.splitMenu3.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitMenu3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.splitMenu3.Location = new System.Drawing.Point(0, 0);
            this.splitMenu3.Name = "splitMenu3";
            this.splitMenu3.Size = new System.Drawing.Size(361, 1);
            this.splitMenu3.TabIndex = 13;
            this.splitMenu3.Title = "";
            // 
            // SettingForm
            // 
            this.AcceptButton = this.btnCompara;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(361, 510);
            this.Controls.Add(this.splitMenu3);
            this.Controls.Add(this.btnSync);
            this.Controls.Add(this.cmbSys);
            this.Controls.Add(this.splitMenu2);
            this.Controls.Add(this.btnCompara);
            this.Controls.Add(this.dbCompara);
            this.Controls.Add(this.dbTarget);
            this.Controls.Add(this.splitMenu1);
            this.Controls.Add(this.prgCompara);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = true;
            this.Name = "SettingForm";
            this.Opacity = 1D;
            this.Text = "配置";
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.ResumeLayout(false);

        }

        #endregion

        private LysControl.DBConnect dbTarget;
        private LysControl.DBConnect dbCompara;
        private System.Windows.Forms.Button btnCompara;
        private System.Windows.Forms.ProgressBar prgCompara;
        private System.Windows.Forms.Button btnSync;
        private LysControl.SplitMenu splitMenu1;
        private LysControl.SplitMenu splitMenu2;
        private System.Windows.Forms.ComboBox cmbSys;
        private System.Windows.Forms.ToolTip toolTip1;
        private LysControl.SplitMenu splitMenu3;
    }
}

