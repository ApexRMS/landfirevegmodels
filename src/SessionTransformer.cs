
using System;
using System.Diagnostics;
using System.Windows.Forms;
using SyncroSim.Core;
using SyncroSim.Core.Forms;

namespace LandFireVegModels
{
    class SessionTransformer : Transformer
    {
        public override void Configure()
        {
            base.Configure();

            WinFormSession wfs = (WinFormSession)this.Session;
            wfs.MainMenuLoaded += this.OnMainMenuLoaded;
        }

        private void OnMainMenuLoaded(object sender, EventArgs e)
        {
            WinFormSession wfs = (WinFormSession)this.Session;
            CommandCollection cmds = wfs.Application.GetMenuCommands();
            Command EditCommand = Command.FindCommand("ssim_edit_menu", cmds);
            Debug.Assert(EditCommand != null);

            if (EditCommand != null)
            {
                EditCommand.Commands.Add(Command.CreateSeparatorCommand());

                Command LFVMExportStrataCmd = new Command(
                    "export-lfvm-strata", 
                    "Export LFVM Strata", 
                    OnExecuteExportStrata, 
                    OnUpdateExportStrata);

                EditCommand.Commands.Add(LFVMExportStrataCmd);
            }
        }

        private void OnUpdateExportStrata(Command cmd)
        {
            cmd.IsEnabled = false;
            WinFormSession wfs = (WinFormSession)this.Session;
            Library lib = wfs.Application.GetSelectedLibrary();

            if (lib != null)
            {
                string ptn = lib.GetPrimaryTransformerName();
                cmd.IsEnabled = (ptn == "landfirevegmodels_landfirevegmodels");
            }
        }

        private void OnExecuteExportStrata(Command cmd)
        {
            ExportStrataForm f = new ExportStrataForm();
            WinFormSession wfs = (WinFormSession)this.Session;
            Library lib = wfs.Application.GetSelectedLibrary();

            if (lib == null)
            {
                Debug.Assert(false);
                return;
            }

            f.Initialize(lib);

            if (f.ShowDialog() == DialogResult.OK)
            {
                
            }
        }
    }
}
