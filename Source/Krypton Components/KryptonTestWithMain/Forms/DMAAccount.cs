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
using static KryptonTestWithMain.PageCreator;

namespace KryptonTestWithMain.Forms
{
    public partial class DMAAccount : UserControl
    {
        public DMAAccount()
        {
            InitializeComponent();
        }

        private void DMAAccount_Load(object sender, EventArgs e)
        {
            KryptonDockingWorkspace w = dockingManager.ManageWorkspace("Workspace", kryptonDockableWorkspace1);
            dockingManager.ManageControl("Control", kryptonPanel1, w);
            dockingManager.ManageFloating("Floating", ParentForm);

            KryptonDataGridView kryptonDataGridPositions = new KryptonDataGridView();
            kryptonDataGridPositions.Columns.Add("Side", "Side");
            kryptonDataGridPositions.Columns.Add("Qty", "Qty");
            kryptonDataGridPositions.Columns.Add("EntryPrice", "Entry Price");
            kryptonDataGridPositions.Columns.Add("MarkPrice", "Mark Price");
            kryptonDataGridPositions.Columns.Add("LiqPrice", "Liq Price");
            kryptonDataGridPositions.Columns.Add("UPnL", "UPnL");

            

            KryptonDataGridView kryptonDataGridOrders = new KryptonDataGridView();
            kryptonDataGridOrders.Columns.Add("Side", "Side");
            kryptonDataGridOrders.Columns.Add("Qty", "Qty");
            kryptonDataGridOrders.Columns.Add("Price", "Price");
            kryptonDataGridOrders.Columns.Add("Filled", "Filled");
            kryptonDataGridOrders.Columns.Add("PO", "PO");
            kryptonDataGridOrders.Columns.Add("Cancel", "");

            var positions = NewPage("Positions", kryptonDataGridPositions);
            positions.ClearFlags(KryptonPageFlags.All);
            positions.SetFlags(KryptonPageFlags.AllowConfigSave);
            positions.SetFlags(KryptonPageFlags.DockingAllowDropDown);
            positions.SetFlags(KryptonPageFlags.DockingAllowAutoHidden);
            //positions.SetFlags(KryptonPageFlags.DockingAllowDocked);
            positions.SetFlags(KryptonPageFlags.DockingAllowFloating);
            positions.SetFlags(KryptonPageFlags.DockingAllowWorkspace);
            positions.SetFlags(KryptonPageFlags.AllowPageReorder);
            positions.SetFlags(KryptonPageFlags.AllowPageDrag);

            var orders = NewPage("Orders", kryptonDataGridOrders);
            orders.ClearFlags(KryptonPageFlags.All);
            orders.SetFlags(KryptonPageFlags.AllowConfigSave);
            orders.SetFlags(KryptonPageFlags.DockingAllowDropDown);
            orders.SetFlags(KryptonPageFlags.DockingAllowAutoHidden);
            //orders.SetFlags(KryptonPageFlags.DockingAllowDocked);
            orders.SetFlags(KryptonPageFlags.DockingAllowFloating);
            orders.SetFlags(KryptonPageFlags.DockingAllowWorkspace);
            orders.SetFlags(KryptonPageFlags.AllowPageReorder);
            orders.SetFlags(KryptonPageFlags.AllowPageDrag);

            dockingManager.AddToWorkspace("Workspace", new KryptonPage[] { positions, orders });
        }
    }
}
