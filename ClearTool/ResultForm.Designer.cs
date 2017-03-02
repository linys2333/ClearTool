namespace ClearTool
{
    partial class ResultForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.btnExport = new System.Windows.Forms.Button();
            this.lblSumCount = new System.Windows.Forms.Label();
            this.lblAddCount = new System.Windows.Forms.Label();
            this.lblEditCount = new System.Windows.Forms.Label();
            this.lblDeleteCount = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnRebind = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlTable = new System.Windows.Forms.SplitContainer();
            this.dgvField = new System.Windows.Forms.DataGridView();
            this.FieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FieldIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FieldNameChn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TargetFieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsProjField = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.FieldRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TableNameChn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComparaTableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TargetTableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Flag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsClear = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.IsClearOfBU = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTable)).BeginInit();
            this.pnlTable.Panel1.SuspendLayout();
            this.pnlTable.Panel2.SuspendLayout();
            this.pnlTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvField)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvResult
            // 
            this.dgvResult.AllowUserToAddRows = false;
            this.dgvResult.AllowUserToDeleteRows = false;
            this.dgvResult.AllowUserToOrderColumns = true;
            this.dgvResult.AllowUserToResizeRows = false;
            this.dgvResult.BackgroundColor = System.Drawing.Color.White;
            this.dgvResult.CausesValidation = false;
            this.dgvResult.ColumnHeadersHeight = 30;
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TableName,
            this.Index,
            this.TableNameChn,
            this.ComparaTableName,
            this.TargetTableName,
            this.Flag,
            this.IsClear,
            this.IsClearOfBU,
            this.Remark});
            this.dgvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResult.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvResult.Location = new System.Drawing.Point(0, 0);
            this.dgvResult.MultiSelect = false;
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.RowHeadersVisible = false;
            this.dgvResult.RowTemplate.Height = 23;
            this.dgvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvResult.ShowCellErrors = false;
            this.dgvResult.Size = new System.Drawing.Size(1184, 639);
            this.dgvResult.TabIndex = 5;
            this.dgvResult.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResult_CellClick);
            this.dgvResult.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvResult_DataBindingComplete);
            this.dgvResult.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvResult_EditingControlShowing);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(1006, 18);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(76, 30);
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "导 出";
            this.toolTip1.SetToolTip(this.btnExport, "导出SQL和Excel");
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lblSumCount
            // 
            this.lblSumCount.AutoSize = true;
            this.lblSumCount.Location = new System.Drawing.Point(10, 2);
            this.lblSumCount.Name = "lblSumCount";
            this.lblSumCount.Size = new System.Drawing.Size(47, 21);
            this.lblSumCount.TabIndex = 8;
            this.lblSumCount.Text = "总共 ";
            // 
            // lblAddCount
            // 
            this.lblAddCount.AutoSize = true;
            this.lblAddCount.Location = new System.Drawing.Point(10, 29);
            this.lblAddCount.Name = "lblAddCount";
            this.lblAddCount.Size = new System.Drawing.Size(58, 21);
            this.lblAddCount.TabIndex = 9;
            this.lblAddCount.Text = "新增：";
            // 
            // lblEditCount
            // 
            this.lblEditCount.AutoSize = true;
            this.lblEditCount.Location = new System.Drawing.Point(90, 29);
            this.lblEditCount.Name = "lblEditCount";
            this.lblEditCount.Size = new System.Drawing.Size(58, 21);
            this.lblEditCount.TabIndex = 9;
            this.lblEditCount.Text = "修改：";
            // 
            // lblDeleteCount
            // 
            this.lblDeleteCount.AutoSize = true;
            this.lblDeleteCount.Location = new System.Drawing.Point(170, 29);
            this.lblDeleteCount.Name = "lblDeleteCount";
            this.lblDeleteCount.Size = new System.Drawing.Size(58, 21);
            this.lblDeleteCount.TabIndex = 9;
            this.lblDeleteCount.Text = "删除：";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(80, 2);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(106, 21);
            this.lblInfo.TabIndex = 10;
            this.lblInfo.Text = "张表，其中：";
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnRebind);
            this.pnlBottom.Controls.Add(this.lblInfo);
            this.pnlBottom.Controls.Add(this.btnExport);
            this.pnlBottom.Controls.Add(this.lblSumCount);
            this.pnlBottom.Controls.Add(this.lblDeleteCount);
            this.pnlBottom.Controls.Add(this.lblAddCount);
            this.pnlBottom.Controls.Add(this.lblEditCount);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 701);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1184, 60);
            this.pnlBottom.TabIndex = 11;
            // 
            // btnRebind
            // 
            this.btnRebind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRebind.Location = new System.Drawing.Point(1122, 18);
            this.btnRebind.Name = "btnRebind";
            this.btnRebind.Size = new System.Drawing.Size(50, 30);
            this.btnRebind.TabIndex = 11;
            this.btnRebind.Text = "还原";
            this.toolTip1.SetToolTip(this.btnRebind, "还原数据");
            this.btnRebind.UseVisualStyleBackColor = true;
            this.btnRebind.Click += new System.EventHandler(this.btnRebind_Click);
            // 
            // pnlTable
            // 
            this.pnlTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTable.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.pnlTable.Location = new System.Drawing.Point(0, 0);
            this.pnlTable.Name = "pnlTable";
            this.pnlTable.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // pnlTable.Panel1
            // 
            this.pnlTable.Panel1.Controls.Add(this.dgvResult);
            // 
            // pnlTable.Panel2
            // 
            this.pnlTable.Panel2.Controls.Add(this.dgvField);
            this.pnlTable.Size = new System.Drawing.Size(1184, 701);
            this.pnlTable.SplitterDistance = 639;
            this.pnlTable.TabIndex = 12;
            // 
            // dgvField
            // 
            this.dgvField.AllowUserToAddRows = false;
            this.dgvField.AllowUserToDeleteRows = false;
            this.dgvField.AllowUserToOrderColumns = true;
            this.dgvField.AllowUserToResizeRows = false;
            this.dgvField.BackgroundColor = System.Drawing.Color.White;
            this.dgvField.CausesValidation = false;
            this.dgvField.ColumnHeadersHeight = 30;
            this.dgvField.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvField.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FieldName,
            this.FieldIndex,
            this.FieldNameChn,
            this.TargetFieldName,
            this.IsProjField,
            this.FieldRemark});
            this.dgvField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvField.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvField.Location = new System.Drawing.Point(0, 0);
            this.dgvField.MultiSelect = false;
            this.dgvField.Name = "dgvField";
            this.dgvField.RowHeadersVisible = false;
            this.dgvField.RowTemplate.Height = 23;
            this.dgvField.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvField.ShowCellErrors = false;
            this.dgvField.Size = new System.Drawing.Size(1184, 58);
            this.dgvField.TabIndex = 6;
            this.dgvField.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvResult_DataBindingComplete);
            // 
            // FieldName
            // 
            this.FieldName.DataPropertyName = "FieldName";
            this.FieldName.HeaderText = "ID";
            this.FieldName.Name = "FieldName";
            this.FieldName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.FieldName.Visible = false;
            // 
            // FieldIndex
            // 
            this.FieldIndex.DataPropertyName = "Index";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.FieldIndex.DefaultCellStyle = dataGridViewCellStyle13;
            this.FieldIndex.HeaderText = "序号";
            this.FieldIndex.Name = "FieldIndex";
            this.FieldIndex.ReadOnly = true;
            this.FieldIndex.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.FieldIndex.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FieldIndex.Width = 50;
            // 
            // FieldNameChn
            // 
            this.FieldNameChn.DataPropertyName = "FieldNameChn";
            dataGridViewCellStyle14.NullValue = "--";
            this.FieldNameChn.DefaultCellStyle = dataGridViewCellStyle14;
            this.FieldNameChn.HeaderText = "字段中文名";
            this.FieldNameChn.Name = "FieldNameChn";
            this.FieldNameChn.Width = 200;
            // 
            // TargetFieldName
            // 
            this.TargetFieldName.DataPropertyName = "TargetFieldName";
            this.TargetFieldName.HeaderText = "目标字段名";
            this.TargetFieldName.Name = "TargetFieldName";
            this.TargetFieldName.Width = 200;
            // 
            // IsProjField
            // 
            this.IsProjField.DataPropertyName = "IsProjField";
            this.IsProjField.HeaderText = "项目GUID";
            this.IsProjField.Name = "IsProjField";
            this.IsProjField.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.IsProjField.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsProjField.Width = 151;
            // 
            // FieldRemark
            // 
            this.FieldRemark.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FieldRemark.DataPropertyName = "Remark";
            this.FieldRemark.HeaderText = "备注";
            this.FieldRemark.Name = "FieldRemark";
            // 
            // TableName
            // 
            this.TableName.DataPropertyName = "TableName";
            this.TableName.HeaderText = "ID";
            this.TableName.Name = "TableName";
            this.TableName.Visible = false;
            // 
            // Index
            // 
            this.Index.DataPropertyName = "Index";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Index.DefaultCellStyle = dataGridViewCellStyle8;
            this.Index.HeaderText = "序号";
            this.Index.Name = "Index";
            this.Index.ReadOnly = true;
            this.Index.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Index.Width = 50;
            // 
            // TableNameChn
            // 
            this.TableNameChn.DataPropertyName = "TableNameChn";
            dataGridViewCellStyle9.NullValue = "--";
            this.TableNameChn.DefaultCellStyle = dataGridViewCellStyle9;
            this.TableNameChn.HeaderText = "表中文名";
            this.TableNameChn.Name = "TableNameChn";
            this.TableNameChn.Width = 200;
            // 
            // ComparaTableName
            // 
            this.ComparaTableName.DataPropertyName = "ComparaTableName";
            this.ComparaTableName.HeaderText = "对比表名";
            this.ComparaTableName.Name = "ComparaTableName";
            this.ComparaTableName.Width = 200;
            // 
            // TargetTableName
            // 
            this.TargetTableName.DataPropertyName = "TargetTableName";
            this.TargetTableName.HeaderText = "目标表名";
            this.TargetTableName.Name = "TargetTableName";
            this.TargetTableName.Width = 200;
            // 
            // Flag
            // 
            this.Flag.DataPropertyName = "Flag";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Flag.DefaultCellStyle = dataGridViewCellStyle10;
            this.Flag.HeaderText = "标志";
            this.Flag.Name = "Flag";
            this.Flag.ReadOnly = true;
            this.Flag.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Flag.Width = 60;
            // 
            // IsClear
            // 
            this.IsClear.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.IsClear.DataPropertyName = "IsClear";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.NullValue = null;
            this.IsClear.DefaultCellStyle = dataGridViewCellStyle11;
            this.IsClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IsClear.HeaderText = "是否清空(集团级)";
            this.IsClear.Items.AddRange(new object[] {
            "是",
            "否"});
            this.IsClear.MaxDropDownItems = 2;
            this.IsClear.Name = "IsClear";
            this.IsClear.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.IsClear.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsClear.Width = 157;
            // 
            // IsClearOfBU
            // 
            this.IsClearOfBU.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.IsClearOfBU.DataPropertyName = "IsClearOfBU";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.IsClearOfBU.DefaultCellStyle = dataGridViewCellStyle12;
            this.IsClearOfBU.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IsClearOfBU.HeaderText = "是否清空(公司级)";
            this.IsClearOfBU.Items.AddRange(new object[] {
            "是",
            "否"});
            this.IsClearOfBU.MaxDropDownItems = 2;
            this.IsClearOfBU.Name = "IsClearOfBU";
            this.IsClearOfBU.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.IsClearOfBU.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsClearOfBU.Width = 157;
            // 
            // Remark
            // 
            this.Remark.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Remark.DataPropertyName = "Remark";
            this.Remark.HeaderText = "备注";
            this.Remark.Name = "Remark";
            this.Remark.ReadOnly = true;
            // 
            // ResultForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.pnlTable);
            this.Controls.Add(this.pnlBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "ResultForm";
            this.Opacity = 1D;
            this.ShowInTaskbar = false;
            this.Text = "结果";
            this.TransparencyKey = System.Drawing.Color.Empty;
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.pnlTable.Panel1.ResumeLayout(false);
            this.pnlTable.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlTable)).EndInit();
            this.pnlTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvField)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label lblSumCount;
        private System.Windows.Forms.Label lblAddCount;
        private System.Windows.Forms.Label lblEditCount;
        private System.Windows.Forms.Label lblDeleteCount;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnRebind;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.SplitContainer pnlTable;
        private System.Windows.Forms.DataGridView dgvField;
        private System.Windows.Forms.DataGridViewTextBoxColumn FieldName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FieldIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn FieldNameChn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TargetFieldName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsProjField;
        private System.Windows.Forms.DataGridViewTextBoxColumn FieldRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn TableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Index;
        private System.Windows.Forms.DataGridViewTextBoxColumn TableNameChn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComparaTableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TargetTableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Flag;
        private System.Windows.Forms.DataGridViewComboBoxColumn IsClear;
        private System.Windows.Forms.DataGridViewComboBoxColumn IsClearOfBU;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
    }
}