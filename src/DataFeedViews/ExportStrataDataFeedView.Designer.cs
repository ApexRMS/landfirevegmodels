namespace LandFireVegModels
{
    partial class ExportStrataDataFeedView : SyncroSim.Core.Forms.DataFeedView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ExportStrataPanel = new System.Windows.Forms.Panel();
            this.ExportPathSelectionDialog = new System.Windows.Forms.SaveFileDialog();
            this.ExportPathTextBox = new System.Windows.Forms.TextBox();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.ExportPathLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ExportStrataPanel
            // 
            this.ExportStrataPanel.AutoSize = true;
            this.ExportStrataPanel.Location = new System.Drawing.Point(3, 69);
            this.ExportStrataPanel.Name = "ExportStrataPanel";
            this.ExportStrataPanel.Size = new System.Drawing.Size(919, 393);
            this.ExportStrataPanel.TabIndex = 0;
            // 
            // ExportPathSelectionDialog
            // 
            this.ExportPathSelectionDialog.Filter = "SyncroSim Library (*.ssim)|*.ssim";
            // 
            // ExportPathTextBox
            // 
            this.ExportPathTextBox.Location = new System.Drawing.Point(3, 29);
            this.ExportPathTextBox.Name = "ExportPathTextBox";
            this.ExportPathTextBox.ReadOnly = true;
            this.ExportPathTextBox.Size = new System.Drawing.Size(737, 20);
            this.ExportPathTextBox.TabIndex = 1;
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(757, 27);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(75, 23);
            this.BrowseButton.TabIndex = 2;
            this.BrowseButton.Text = "Browse...";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(847, 27);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(75, 23);
            this.ClearButton.TabIndex = 3;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // ExportPathLabel
            // 
            this.ExportPathLabel.AutoSize = true;
            this.ExportPathLabel.Location = new System.Drawing.Point(3, 9);
            this.ExportPathLabel.Name = "ExportPathLabel";
            this.ExportPathLabel.Size = new System.Drawing.Size(90, 13);
            this.ExportPathLabel.TabIndex = 4;
            this.ExportPathLabel.Text = "New Export Path:";
            // 
            // ExportStrataDataFeedView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.ExportPathLabel);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.ExportPathTextBox);
            this.Controls.Add(this.ExportStrataPanel);
            this.Name = "ExportStrataDataFeedView";
            this.Size = new System.Drawing.Size(925, 465);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel ExportStrataPanel;
        private System.Windows.Forms.SaveFileDialog ExportPathSelectionDialog;
        private System.Windows.Forms.TextBox ExportPathTextBox;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Label ExportPathLabel;
    }
}
