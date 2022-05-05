using ComponentFactory.Krypton.Docking;
using ComponentFactory.Krypton.Navigator;
using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tester
{
    public partial class Form1 : KryptonForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            KryptonDockingWorkspace w = dockingManager.ManageWorkspace("Workspace", kryptonDockableWorkspace1);
            dockingManager.ManageControl("Control", kryptonPanel1, w);
            dockingManager.ManageFloating("Floating", this);
            dockingManager.AddToWorkspace("Workspace", new KryptonPage[] { NewPage("Portfolio Dashboard"), NewPage("Balances"), NewPage("Positions"), NewPage("Orders"), NewPage("DMA") });
            dockingManager.AddAutoHiddenGroup("Control", DockingEdge.Left, new KryptonPage[] { NewPage("Loaded Accounts") });
            dockingManager.AddDockspace("Control", DockingEdge.Bottom, new KryptonPage[] { NewPage("Feedback") });

            var navigator = dockingManager.FindDockingNavigator("Loaded Accounts");
        }

        private KryptonPage NewPage(string Text, Control control = null)
        {
            // Create and uniquely name the page
            KryptonPage page = new KryptonPage();
            page.Text = Text;
            page.TextTitle = page.Text;
            page.UniqueName = page.Text;
            if (control == null)
            {
                // Add rich text box as content of the page
                KryptonPanel pannel = new KryptonPanel();
                pannel.Dock = DockStyle.Fill;
                pannel.Text = "Page Content";
                page.Controls.Add(pannel);
            }
            else
            {
                control.Dock = DockStyle.Fill;
                page.Controls.Add(control);
            }

            return page;
        }
    }
}
