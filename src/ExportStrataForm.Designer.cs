namespace LandFireVegModels
{
    partial class ExportStrataForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ButtonBrowse = new System.Windows.Forms.Button();
            this.ButtonOK = new System.Windows.Forms.Button();
            this.TextBoxName = new System.Windows.Forms.TextBox();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.TextBoxLocation = new System.Windows.Forms.TextBox();
            this.PanelMain = new SyncroSim.Core.Forms.BasePanel();
            this.DataGridViewMain = new SyncroSim.Core.Forms.BaseDataGridView();
            this.ColumnSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.PanelTop = new System.Windows.Forms.Panel();
            this.LabelProject = new System.Windows.Forms.Label();
            this.LabelLibrary = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PanelBottom = new System.Windows.Forms.Panel();
            this.ButtonUncheckAll = new System.Windows.Forms.Button();
            this.TextBoxSearch = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ButtonCheckSelected = new System.Windows.Forms.Button();
            this.PanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewMain)).BeginInit();
            this.PanelTop.SuspendLayout();
            this.PanelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonBrowse
            // 
            this.ButtonBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonBrowse.Location = new System.Drawing.Point(859, 48);
            this.ButtonBrowse.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonBrowse.Name = "ButtonBrowse";
            this.ButtonBrowse.Size = new System.Drawing.Size(100, 28);
            this.ButtonBrowse.TabIndex = 4;
            this.ButtonBrowse.Text = "Browse...";
            this.ButtonBrowse.UseVisualStyleBackColor = true;
            this.ButtonBrowse.Click += new System.EventHandler(this.ButtonBrowse_Click);
            // 
            // ButtonOK
            // 
            this.ButtonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonOK.Location = new System.Drawing.Point(745, 94);
            this.ButtonOK.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size(100, 28);
            this.ButtonOK.TabIndex = 5;
            this.ButtonOK.Text = "OK";
            this.ButtonOK.UseVisualStyleBackColor = true;
            this.ButtonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // TextBoxName
            // 
            this.TextBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxName.Location = new System.Drawing.Point(93, 14);
            this.TextBoxName.Margin = new System.Windows.Forms.Padding(4);
            this.TextBoxName.Name = "TextBoxName";
            this.TextBoxName.Size = new System.Drawing.Size(751, 22);
            this.TextBoxName.TabIndex = 1;
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(859, 94);
            this.ButtonCancel.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(100, 28);
            this.ButtonCancel.TabIndex = 6;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // Label3
            // 
            this.Label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(11, 18);
            this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(73, 17);
            this.Label3.TabIndex = 0;
            this.Label3.Text = "File name:";
            // 
            // Label2
            // 
            this.Label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(10, 54);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(52, 17);
            this.Label2.TabIndex = 2;
            this.Label2.Text = "Folder:";
            // 
            // TextBoxLocation
            // 
            this.TextBoxLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxLocation.Location = new System.Drawing.Point(93, 50);
            this.TextBoxLocation.Margin = new System.Windows.Forms.Padding(4);
            this.TextBoxLocation.Name = "TextBoxLocation";
            this.TextBoxLocation.ReadOnly = true;
            this.TextBoxLocation.Size = new System.Drawing.Size(751, 22);
            this.TextBoxLocation.TabIndex = 3;
            // 
            // PanelMain
            // 
            this.PanelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelMain.BackColor = System.Drawing.SystemColors.Control;
            this.PanelMain.BorderColor = System.Drawing.Color.Gray;
            this.PanelMain.Controls.Add(this.DataGridViewMain);
            this.PanelMain.Location = new System.Drawing.Point(93, 83);
            this.PanelMain.Margin = new System.Windows.Forms.Padding(4);
            this.PanelMain.Name = "PanelMain";
            this.PanelMain.Padding = new System.Windows.Forms.Padding(1);
            this.PanelMain.PaintBottomBorder = true;
            this.PanelMain.PaintLeftBorder = true;
            this.PanelMain.PaintRightBorder = true;
            this.PanelMain.PaintTopBorder = true;
            this.PanelMain.ShowBorder = true;
            this.PanelMain.Size = new System.Drawing.Size(753, 342);
            this.PanelMain.TabIndex = 19;
            // 
            // DataGridViewMain
            // 
            this.DataGridViewMain.AllowUserToAddRows = false;
            this.DataGridViewMain.AllowUserToDeleteRows = false;
            this.DataGridViewMain.AllowUserToResizeRows = false;
            this.DataGridViewMain.ApplyFocusColors = true;
            this.DataGridViewMain.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(232)))));
            this.DataGridViewMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridViewMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridViewMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnSelected,
            this.ColumnID,
            this.ColumnName,
            this.ColumnDescription});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridViewMain.DefaultCellStyle = dataGridViewCellStyle6;
            this.DataGridViewMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridViewMain.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.DataGridViewMain.EnableMouseClicks = true;
            this.DataGridViewMain.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.DataGridViewMain.IsReadOnly = false;
            this.DataGridViewMain.Location = new System.Drawing.Point(1, 1);
            this.DataGridViewMain.Margin = new System.Windows.Forms.Padding(4);
            this.DataGridViewMain.MultiSelect = false;
            this.DataGridViewMain.Name = "DataGridViewMain";
            this.DataGridViewMain.PaintGridBorders = true;
            this.DataGridViewMain.RowHeadersVisible = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            this.DataGridViewMain.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.DataGridViewMain.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.DataGridViewMain.SelectedForeColor = System.Drawing.Color.White;
            this.DataGridViewMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridViewMain.Size = new System.Drawing.Size(751, 340);
            this.DataGridViewMain.TabIndex = 0;
            this.DataGridViewMain.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewMain_CellContentClick);
            // 
            // ColumnSelected
            // 
            this.ColumnSelected.DataPropertyName = "Selected";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.NullValue = false;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.ColumnSelected.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnSelected.HeaderText = "";
            this.ColumnSelected.MinimumWidth = 30;
            this.ColumnSelected.Name = "ColumnSelected";
            this.ColumnSelected.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnSelected.Width = 30;
            // 
            // ColumnID
            // 
            this.ColumnID.DataPropertyName = "Id";
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.ColumnID.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnID.HeaderText = "ID";
            this.ColumnID.Name = "ColumnID";
            this.ColumnID.ReadOnly = true;
            this.ColumnID.Visible = false;
            // 
            // ColumnName
            // 
            this.ColumnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnName.DataPropertyName = "Name";
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.ColumnName.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColumnName.FillWeight = 30F;
            this.ColumnName.HeaderText = "Name";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            this.ColumnName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ColumnDescription
            // 
            this.ColumnDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnDescription.DataPropertyName = "Description";
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.ColumnDescription.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColumnDescription.FillWeight = 70F;
            this.ColumnDescription.HeaderText = "Description";
            this.ColumnDescription.Name = "ColumnDescription";
            this.ColumnDescription.ReadOnly = true;
            this.ColumnDescription.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Strata:";
            // 
            // PanelTop
            // 
            this.PanelTop.BackColor = System.Drawing.Color.White;
            this.PanelTop.Controls.Add(this.LabelProject);
            this.PanelTop.Controls.Add(this.LabelLibrary);
            this.PanelTop.Controls.Add(this.label5);
            this.PanelTop.Controls.Add(this.label4);
            this.PanelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelTop.Location = new System.Drawing.Point(0, 0);
            this.PanelTop.Name = "PanelTop";
            this.PanelTop.Size = new System.Drawing.Size(972, 65);
            this.PanelTop.TabIndex = 0;
            // 
            // LabelProject
            // 
            this.LabelProject.AutoSize = true;
            this.LabelProject.Location = new System.Drawing.Point(89, 35);
            this.LabelProject.Name = "LabelProject";
            this.LabelProject.Size = new System.Drawing.Size(51, 17);
            this.LabelProject.TabIndex = 3;
            this.LabelProject.Text = "project";
            // 
            // LabelLibrary
            // 
            this.LabelLibrary.AutoSize = true;
            this.LabelLibrary.Location = new System.Drawing.Point(89, 9);
            this.LabelLibrary.Name = "LabelLibrary";
            this.LabelLibrary.Size = new System.Drawing.Size(47, 17);
            this.LabelLibrary.TabIndex = 1;
            this.LabelLibrary.Text = "library";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Project:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Library:";
            // 
            // PanelBottom
            // 
            this.PanelBottom.BackColor = System.Drawing.Color.White;
            this.PanelBottom.Controls.Add(this.ButtonBrowse);
            this.PanelBottom.Controls.Add(this.TextBoxLocation);
            this.PanelBottom.Controls.Add(this.Label2);
            this.PanelBottom.Controls.Add(this.Label3);
            this.PanelBottom.Controls.Add(this.ButtonCancel);
            this.PanelBottom.Controls.Add(this.ButtonOK);
            this.PanelBottom.Controls.Add(this.TextBoxName);
            this.PanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelBottom.Location = new System.Drawing.Point(0, 495);
            this.PanelBottom.Name = "PanelBottom";
            this.PanelBottom.Size = new System.Drawing.Size(972, 133);
            this.PanelBottom.TabIndex = 6;
            // 
            // ButtonUncheckAll
            // 
            this.ButtonUncheckAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonUncheckAll.Location = new System.Drawing.Point(729, 446);
            this.ButtonUncheckAll.Name = "ButtonUncheckAll";
            this.ButtonUncheckAll.Size = new System.Drawing.Size(117, 28);
            this.ButtonUncheckAll.TabIndex = 5;
            this.ButtonUncheckAll.Text = "Uncheck All";
            this.ButtonUncheckAll.UseVisualStyleBackColor = true;
            this.ButtonUncheckAll.Click += new System.EventHandler(this.ButtonUncheckAll_Click);
            // 
            // TextBoxSearch
            // 
            this.TextBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TextBoxSearch.Location = new System.Drawing.Point(153, 450);
            this.TextBoxSearch.Name = "TextBoxSearch";
            this.TextBoxSearch.Size = new System.Drawing.Size(187, 22);
            this.TextBoxSearch.TabIndex = 3;
            this.TextBoxSearch.TextChanged += new System.EventHandler(this.TextBoxSearch_TextChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(91, 452);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Search:";
            // 
            // ButtonCheckSelected
            // 
            this.ButtonCheckSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonCheckSelected.Location = new System.Drawing.Point(606, 446);
            this.ButtonCheckSelected.Name = "ButtonCheckSelected";
            this.ButtonCheckSelected.Size = new System.Drawing.Size(117, 28);
            this.ButtonCheckSelected.TabIndex = 4;
            this.ButtonCheckSelected.Text = "Check Visible";
            this.ButtonCheckSelected.UseVisualStyleBackColor = true;
            this.ButtonCheckSelected.Click += new System.EventHandler(this.ButtonCheckVisible_Click);
            // 
            // ExportStrataForm
            // 
            this.AcceptButton = this.ButtonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ButtonCancel;
            this.ClientSize = new System.Drawing.Size(972, 628);
            this.Controls.Add(this.TextBoxSearch);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.PanelBottom);
            this.Controls.Add(this.PanelTop);
            this.Controls.Add(this.ButtonCheckSelected);
            this.Controls.Add(this.ButtonUncheckAll);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PanelMain);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExportStrataForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Export LFVM Strata";
            this.PanelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewMain)).EndInit();
            this.PanelTop.ResumeLayout(false);
            this.PanelTop.PerformLayout();
            this.PanelBottom.ResumeLayout(false);
            this.PanelBottom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button ButtonBrowse;
        internal System.Windows.Forms.Button ButtonOK;
        internal System.Windows.Forms.TextBox TextBoxName;
        internal System.Windows.Forms.Button ButtonCancel;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox TextBoxLocation;
        internal SyncroSim.Core.Forms.BasePanel PanelMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel PanelTop;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LabelProject;
        private System.Windows.Forms.Label LabelLibrary;
        private System.Windows.Forms.Panel PanelBottom;
        internal SyncroSim.Core.Forms.BaseDataGridView DataGridViewMain;
        private System.Windows.Forms.Button ButtonUncheckAll;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDescription;
        private System.Windows.Forms.TextBox TextBoxSearch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button ButtonCheckSelected;
    }
}