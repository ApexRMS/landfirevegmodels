
using System;
using System.IO;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Globalization;
using SyncroSim.Core;

namespace LandFireVegModels
{
    public partial class ExportStrataForm : Form
    {
        private Library m_Library;
        private Project m_Project;
        private DataTable m_Strata;
        private DataView m_StrataView;
        private string m_FileName;
        private Color m_HighlightColor = Color.FromArgb(51, 153, 255);
        private const string LOCATION_KEY = "landfirevegmodels_LastLocation";

        public ExportStrataForm()
        {
            InitializeComponent();

            this.DataGridViewMain.MultiSelect = false;
            this.DataGridViewMain.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DataGridViewMain.BackgroundColor = Color.FromArgb(243, 242, 240);
            this.DataGridViewMain.DefaultCellStyle.SelectionBackColor = Color.White;
            this.DataGridViewMain.RowsDefaultCellStyle.SelectionBackColor = Color.White;
            this.DataGridViewMain.DefaultCellStyle.SelectionForeColor = Color.Black;
            this.DataGridViewMain.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
            this.DataGridViewMain.ApplyFocusColors = false;
            this.DataGridViewMain.PaintGridBorders = false;
            this.DataGridViewMain.StandardTab = true;

            this.PanelMain.BorderColor = Color.DarkGray;
            this.ActiveControl = this.DataGridViewMain;
            this.BackColor = SystemColors.Control;
            this.PanelBottom.BackColor = Color.FromArgb(214, 219, 233);
        }

        public string FileName
        {
            get
            {
                return this.m_FileName;
            }
        }

        public List<int> GetSelectedStratumIds()
        {
            List<int> Ids = new List<int>();

            foreach (DataRow dr in this.m_Strata.Rows)
            {
                if (Convert.ToBoolean(dr["Selected"]))
                {
                    Ids.Add(Convert.ToInt32(dr["Id"]));
                }
            }

            Debug.Assert(Ids.Count > 0);
            return Ids;
        }

        public void Initialize(Library library)
        {
            this.m_Library = library;
            this.m_Project = this.GetFirstProject();

            this.LabelLibrary.Text = this.m_Library.Connection.ConnectionString;
            this.LabelProject.Text = this.m_Project.Name;

            this.FillStrataGrid();
            this.EnableControls();
            this.RestoreLocation();

            this.ActiveControl = this.TextBoxSearch;
        }

        private void EnableControls()
        {
            this.ButtonOK.Enabled = (this.m_Project != null && this.AnyStratumSelected());
            this.ButtonBrowse.Enabled = (this.m_Project != null && this.DataGridViewMain.Rows.Count > 0);
        }

        private void SaveLocation()
        {
            string loc = this.TextBoxLocation.Text.Trim();
            this.m_Library.SetSettingValue(LOCATION_KEY, loc);
        }

        private void RestoreLocation()
        {
            string loc = this.m_Library.GetSettingValue(LOCATION_KEY);

            if (!string.IsNullOrWhiteSpace(loc))
            {
                if (Directory.Exists(loc))
                {
                    this.TextBoxLocation.Text = loc;
                }
            }
        }

        private void FillStrataGrid()
        {
            if (this.m_Project == null)
            {
                return;
            }

            DataSheet ds = this.m_Project.GetDataSheet("stsim_Stratum");

            if (ds == null)
            {
                Debug.Assert(false);
                return;
            }

            this.m_Strata = new DataTable();
            this.m_Strata.Columns.Add(new DataColumn("Selected", typeof(bool)));
            this.m_Strata.Columns.Add(new DataColumn("Id", typeof(int)));
            this.m_Strata.Columns.Add(new DataColumn("Name", typeof(string)));
            this.m_Strata.Columns.Add(new DataColumn("Description", typeof(string)));

            foreach (DataRow dr in ds.GetData().Rows)
            {
                if (dr.RowState == DataRowState.Deleted)
                {
                    continue;
                }

                this.m_Strata.Rows.Add(new[] 
                {
                    false,
                    dr["StratumID"],
                    dr["Name"],
                    dr["Description"]
                });
            }

            this.m_StrataView = new DataView(this.m_Strata, null, "Name", DataViewRowState.CurrentRows);
            this.DataGridViewMain.DataSource = this.m_StrataView;
        }

        private Project GetFirstProject()
        {
            int c = 0;
            Project Proj = null;

            foreach (Project p in this.m_Library.Projects)
            {
                if (!p.IsDeleted)
                {
                    if (Proj == null)
                    {
                        Proj = p;
                    }

                    c++;
                }
            }

            if (c == 0)
            {
                Shared.ShowMessageBox(
                    "No projects found in specified library.", 
                    MessageBoxButtons.OK);
            }
            else if (c > 1)
            {
                Shared.ShowMessageBox(
                    "Multiple projects found in specified library.  Using the first project found.", 
                    MessageBoxButtons.OK);
            }

            return Proj;
        }

        private bool AnyStratumSelected()
        {
            foreach (DataRow dr in this.m_Strata.Rows)
            {
                if (Convert.ToBoolean(dr["Selected"]))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool ValidateFileName(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                Shared.ShowMessageBox("You must provide a file name.", MessageBoxButtons.OK);
                return false;
            }

            return true;
        }

        private bool ValidateFileLocation(string location)
        {
            if (string.IsNullOrWhiteSpace(location))
            {
                Shared.ShowMessageBox("You must provide a folder name.", MessageBoxButtons.OK);
                return false;
            }

            try
            {
                if (!Directory.Exists(location))
                {
                    Directory.CreateDirectory(location);
                }

                return true;
            }
            catch (Exception ex)
            {
                string msg =
                    "Cannot create a Library in the specified folder.  More information:" +
                    Environment.NewLine + 
                    Environment.NewLine + 
                    ex.Message;

                Shared.ShowMessageBox(msg, MessageBoxButtons.OK);
            }

            return false;
        }

        private static bool ConfirmOverwriteFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                string msg = "The file already exists.  Overwrite?";

                if (Shared.ShowMessageBox(msg, MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    return false;
                }
            }

            return true;
        }

        private void ButtonBrowse_Click(object sender, System.EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.SelectedPath = this.TextBoxLocation.Text;

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                this.TextBoxLocation.Text = dlg.SelectedPath;
            }
        }

        private void ButtonOK_Click(object sender, System.EventArgs e)
        {
            //File name
            string ProposedFileName = this.TextBoxName.Text.Trim();

            if (!ValidateFileName(ProposedFileName))
            {
                this.ActiveControl = this.TextBoxName;
                return;
            }

            if (!ProposedFileName.EndsWith(".ssim", StringComparison.OrdinalIgnoreCase))
            {
                ProposedFileName = ProposedFileName + ".ssim";
            }

            //Location
            string ProposedLocation = this.TextBoxLocation.Text.Trim();

            if (!this.ValidateFileLocation(ProposedLocation))
            {
                this.ActiveControl = this.TextBoxLocation;
                return;
            }

            //Confirm overwrite
            string ProposedFullPath = Path.Combine(ProposedLocation, ProposedFileName);

            if (!ConfirmOverwriteFile(ProposedFullPath))
            {
                return;
            }

            this.m_FileName = ProposedFullPath;
            this.SaveLocation();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ButtonCancel_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void DataGridViewMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
            {
                return;
            }

            if (e.ColumnIndex == this.ColumnSelected.Index)
            {
                this.DataGridViewMain.EndEdit(DataGridViewDataErrorContexts.Commit);
                this.DataGridViewMain.Invalidate();

                this.EnableControls();
            }
        }

        private void ButtonCheckVisible_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgr in this.DataGridViewMain.Rows)
            {
                DataRowView drv = (DataRowView)dgr.DataBoundItem;
                drv.Row["Selected"] = true;
            }

            this.EnableControls();
        }

        private void ButtonUncheckAll_Click(object sender, EventArgs e)
        {
            foreach(DataRow dr in this.m_Strata.Rows)
            {
                dr["Selected"] = false;
            }

            this.EnableControls();
        }

        private void TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string t = this.TextBoxSearch.Text;
            bool IsEmpty = string.IsNullOrEmpty(t);

            if (IsEmpty)
            {
                this.m_StrataView.RowFilter = null;
            }
            else
            {
                this.m_StrataView.RowFilter = string.Format(CultureInfo.InvariantCulture,
                    "Name LIKE '%{0}%' OR Description LIKE '%{1}%'", t, t);
            }
        }
    }
}
