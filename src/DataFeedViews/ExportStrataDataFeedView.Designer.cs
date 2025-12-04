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
            this.ExportStrataPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExportStrataPanel.AutoSize = true;
            this.ExportStrataPanel.Location = new System.Drawing.Point(4, 69);
            this.ExportStrataPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ExportStrataPanel.Name = "ExportStrataPanel";
            this.ExportStrataPanel.Size = new System.Drawing.Size(1121, 500);
            this.ExportStrataPanel.TabIndex = 0;
            // 
            // ExportPathSelectionDialog
            // 
            this.ExportPathSelectionDialog.Filter = "SyncroSim Library (*.ssim)|*.ssim";
            // 
            // ExportPathTextBox
            // 
            this.ExportPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExportPathTextBox.Location = new System.Drawing.Point(4, 36);
            this.ExportPathTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ExportPathTextBox.Name = "ExportPathTextBox";
            this.ExportPathTextBox.ReadOnly = true;
            this.ExportPathTextBox.Size = new System.Drawing.Size(903, 22);
            this.ExportPathTextBox.TabIndex = 1;
            // 
            // BrowseButton
            // 
            this.BrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BrowseButton.Location = new System.Drawing.Point(915, 33);
            this.BrowseButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(100, 28);
            this.BrowseButton.TabIndex = 2;
            this.BrowseButton.Text = "Browse...";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearButton.Location = new System.Drawing.Point(1023, 33);
            this.ClearButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(100, 28);
            this.ClearButton.TabIndex = 3;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // ExportPathLabel
            // 
            this.ExportPathLabel.AutoSize = true;
            this.ExportPathLabel.Location = new System.Drawing.Point(4, 11);
            this.ExportPathLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ExportPathLabel.Name = "ExportPathLabel";
            this.ExportPathLabel.Size = new System.Drawing.Size(108, 16);
            this.ExportPathLabel.TabIndex = 4;
            this.ExportPathLabel.Text = "New Export Path:";
            // 
            // ExportStrataDataFeedView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.ExportPathLabel);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.ExportPathTextBox);
            this.Controls.Add(this.ExportStrataPanel);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ExportStrataDataFeedView";
            this.Size = new System.Drawing.Size(1129, 573);
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
