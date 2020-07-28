
using System;
using System.IO;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SyncroSim.Core;
using System.Diagnostics;

namespace LandFireVegModels
{
    public partial class ExportStrataForm : Form
    {
        private Library m_Library;
        private Project m_Project;
        private DataTable m_Strata;
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
                string f = this.TextBoxName.Text.Trim();
                string p = this.TextBoxLocation.Text.Trim();

                return Path.Combine(p, f);
            }
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
            this.m_Strata.Columns.Add(new DataColumn("ContainsSearch", typeof(bool)));

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
                    dr["Description"], 
                    false
                });
            }

            DataView dv = new DataView(this.m_Strata, null, "Name", DataViewRowState.CurrentRows);
            this.DataGridViewMain.DataSource = dv;
        }

        private Project GetFirstProject()
        {
            int c = 0;
            Project Proj = null;

            foreach (Project p in this.m_Library.Projects)
            {
                if (!p.IsDeleted && Proj == null)
                {
                    Proj = p;
                    c++;
                }
            }

            if (c == 0)
            {
                MessageBox.Show("No projects found in specified library.");
            }
            else if (c > 1)
            {
                MessageBox.Show("Multiple projects found in specified library.  Using the first project found.");
            }

            return Proj;
        }

        private bool AnyStratumSelected()
        {
            foreach (DataRow dr in this.m_Strata.Rows)
            {
                object v = dr["Selected"];

                if (v != DBNull.Value && (bool)v == true)
                {
                    return true;
                }
            }

            return false;
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
            if (string.IsNullOrWhiteSpace(this.TextBoxName.Text))
            {
                MessageBox.Show("You must provide a file name");
                return;
            }

            if (string.IsNullOrWhiteSpace(this.TextBoxLocation.Text))
            {
                MessageBox.Show("You must provide a folder name");
                return;
            }

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

        private void ButtonUncheckAll_Click(object sender, EventArgs e)
        {
            foreach(DataRow dr in this.m_Strata.Rows)
            {
                dr["Selected"] = false;
            }
        }

        private void TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string t = this.TextBoxSearch.Text;
            bool IsEmpty = string.IsNullOrEmpty(t);
            bool AtLeastOne = false;

            foreach (DataRow dr in this.m_Strata.Rows)
            {
                dr["ContainsSearch"] = false;

                if (!IsEmpty)
                {
                    string n = Convert.ToString(dr["Name"]);
                    string d = Convert.ToString(dr["Description"]);

                    if (n.IndexOf(t, 0, StringComparison.CurrentCultureIgnoreCase) != -1 ||
                        d.IndexOf(t, 0, StringComparison.CurrentCultureIgnoreCase) != -1)
                    {
                        dr["ContainsSearch"] = true;
                        AtLeastOne = true;
                    }
                }
            }

            if (AtLeastOne)
            {
                foreach (DataGridViewRow dgr in this.DataGridViewMain.Rows)
                {
                    DataRow dr = ((DataRowView)dgr.DataBoundItem).Row;

                    if (Convert.ToBoolean(dr["ContainsSearch"]))
                    {
                        this.DataGridViewMain.CurrentCell = dgr.Cells[this.ColumnName.Index];
                        break;
                    }
                }
            }

            this.DataGridViewMain.Invalidate();
        }

        private void DataGridViewMain_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (e.ColumnIndex != this.ColumnName.Index && 
                e.ColumnIndex != this.ColumnDescription.Index)
            {
                return;
            }

            DataGridViewRow dgr = this.DataGridViewMain.Rows[e.RowIndex];
            DataRow dr = ((DataRowView)dgr.DataBoundItem).Row;
            bool ContainsSearch = Convert.ToBoolean(dr["ContainsSearch"]);

            if (ContainsSearch)
            {
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.SelectionForeColor = Color.White;
                e.CellStyle.BackColor = this.m_HighlightColor;
                e.CellStyle.SelectionBackColor = this.m_HighlightColor;
            }
            else
            {
                e.CellStyle.ForeColor = Color.Black;
                e.CellStyle.SelectionForeColor = Color.Black;
                e.CellStyle.BackColor = Color.White;
                e.CellStyle.SelectionBackColor = Color.White;
            }

            e.Paint(e.ClipBounds, DataGridViewPaintParts.All ^ DataGridViewPaintParts.Focus);
        }
    }
}
