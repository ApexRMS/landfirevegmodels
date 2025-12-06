using SyncroSim.Core;
using SyncroSim.Core.Forms;
using System;
using System.Windows.Forms;

namespace LandFireVegModels
{
    public partial class ExportStrataDataFeedView
    {
        public ExportStrataDataFeedView()
        {
            InitializeComponent();
        }

        protected override void InitializeView()
        {
            base.InitializeView();

            DataFeedView v = this.Session.CreateMultiRowDataFeedView(this.Scenario, this.ControllingScenario);
            this.ExportStrataPanel.Controls.Add(v);
        }

        public override void LoadDataFeed(DataFeed dataFeed)
        {
            base.LoadDataFeed(dataFeed);

            this.SetTextBoxBinding(this.ExportPathTextBox, "landfirevegmodels_ExportLibraryPath", "Path");

            if (this.ExportStrataPanel.Controls.Count > 0)
            {
                DataFeedView v = (DataFeedView)this.ExportStrataPanel.Controls[0];
                v.LoadDataFeed(dataFeed, "landfirevegmodels_ExportStrata");
            }

            this.RefreshBoundControls();
        }

        public override void EnableView(bool enable)
        {
            if (this.ExportStrataPanel.Controls.Count > 0)
            {
                DataFeedView v = (DataFeedView)this.ExportStrataPanel.Controls[0];
                v.EnableView(enable);
            }
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            if (this.ExportPathSelectionDialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            this.ExportPathTextBox.Text = this.ExportPathSelectionDialog.FileName;
            DataSheet ds = this.DataFeed.GetDataSheet("landfirevegmodels_ExportLibraryPath");
            ds.SetSingleRowData("Path", this.ExportPathSelectionDialog.FileName);
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            this.ResetBoundControls();
            this.DataFeed.DataSheets["landfirevegmodels_ExportLibraryPath"].ClearData();
        }
    }
}
