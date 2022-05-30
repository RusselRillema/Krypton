using ComponentFactory.Krypton.Docking;
using ComponentFactory.Krypton.Navigator;
using ComponentFactory.Krypton.Toolkit;
using ComponentFactory.Krypton.Workspace;
using KryptonTestWithMain.Forms;
using System;
using System.Linq;
using System.Windows.Controls;
using static KryptonTestWithMain.PageCreator;

namespace KryptonTestWithMain
{
    public partial class Form1 : KryptonForm
    {
        private int _floatingWindowCount;
        private string configFileName = "test.json";
        DMA2 dma2;

        public Form1()
        {
            InitializeComponent();
        }




        private void Form1_Load(object sender, EventArgs e)
        {
            dockingManager.FloatingWindowAdding += DockingManager_FloatingWindowAdding;
            dockingManager.FloatingWindowRemoved += DockingManager_FloatingWindowRemoved;
            dockingManager.PageFloatingRequest += DockingManager_PageFloatingRequest;

            KryptonDockingWorkspace w = dockingManager.ManageWorkspace("Workspace", kryptonDockableWorkspace1);
            //kryptonDockableWorkspace1.PageDrop += KryptonDockableWorkspace1_PageDrop;
            dockingManager.ManageControl("Control", kryptonPanel1, w);
            dockingManager.ManageFloating("Floating", this);
            var balances = NewPage("Balances");

            dma2 = new DMA2();
            dockingManager.AddToWorkspace("Workspace", new KryptonPage[] { CreateDashboardPage(), balances, NewPage("Positions"), NewPage("DMAPage", dma2), NewPage("Orders"), CreateDMAPage() });
            
            var accountsPage = NewPage("LoadedAccounts");
            accountsPage.ClearFlags(KryptonPageFlags.All);
            accountsPage.SetFlags(KryptonPageFlags.AllowConfigSave);
            accountsPage.SetFlags(KryptonPageFlags.DockingAllowDocked);
            accountsPage.SetFlags(KryptonPageFlags.DockingAllowAutoHidden);
            dockingManager.AddAutoHiddenGroup("Control", DockingEdge.Left, new KryptonPage[] { accountsPage });
            
            dockingManager.AddDockspace("Control", DockingEdge.Bottom, new KryptonPage[] { NewPage("Feedback") });

            try
            {
                dockingManager.LoadConfigFromFile(configFileName);
                dma2.LoadConfig();
            }
            catch (Exception) { };
        }

        private void DockingManager_PageFloatingRequest(object sender, CancelUniqueNameEventArgs e)
        {
        }

        private void KryptonDockableWorkspace1_PageDrop(object sender, PageDropEventArgs e)
        {
            KryptonDockableWorkspace dockableWorkspace = (sender as KryptonDockableWorkspace);
            var x = dockableWorkspace.AllPages();
            if (x?.Count() == 1)
            {
                var t = x[0].KryptonParentContainer as KryptonWorkspaceCell;
                if (t == null)
                    return;

                if (t.Pages.Count == 1)
                {
                    //t.Button.ButtonSpecs[t.Button.ButtonSpecs.Count - 1].Visible = false;
                    t.NavigatorMode = NavigatorMode.HeaderGroup;
                }
                else
                {
                    //t.Button.ButtonSpecs[t.Button.ButtonSpecs.Count - 1].Visible = true;
                    t.NavigatorMode = NavigatorMode.BarTabGroup;
                }
            }
            else
            {
                foreach (var item in x)
                {
                    var t = item.KryptonParentContainer as KryptonWorkspaceCell;
                    if (t == null)
                        return;

                    if (t.Pages.Count == 1)
                    {
                        //t.Button.ButtonSpecs[t.Button.ButtonSpecs.Count - 1].Visible = false;
                        t.NavigatorMode = NavigatorMode.HeaderGroup;
                    }
                    else
                    {
                        //t.Button.ButtonSpecs[t.Button.ButtonSpecs.Count - 1].Visible = true;
                        t.NavigatorMode = NavigatorMode.BarTabGroup;
                    }
                }
            }
        }

        private KryptonPage CreateDashboardPage()
        {
            return NewPage("Portfolio Dashboard", new DashControl());
        }

        private KryptonPage CreateBalancesPage()
        {
            return NewPage("Balances", new DashControl());
        }

        private KryptonPage CreatePositionsPage()
        {
            return NewPage("Positions", new DashControl());
        }

        private KryptonPage CreateOrdersPage()
        {
            return NewPage("Orders", new DashControl());
        }

        private KryptonPage CreateDMAPage()
        {
            return NewPage("DMA", new DMAAccount());
        }

        private void DockingManager_FloatingWindowAdding(object sender, FloatingWindowEventArgs e)
        {
            var width = 520;
            var window = e.FloatingWindow;
            window.MinimizeBox = true;
            window.ButtonSpecs.AddRange(this.ButtonSpecs.ToArray());
            window.TextExtra = "Extra Text";
            window.ShowInTaskbar = true;
            window.Width = width;
            window.HeaderStyle = HeaderStyle.Custom1;

            var cell = e.FloatingWindow.FloatspaceControl.FirstVisibleCell();
            e.FloatingWindow.FloatspaceControl.CellCountChanged += FloatspaceControl_CellCountChanged;
            e.FloatingWindow.FloatspaceControl.CellVisibleCountChanged += FloatspaceControl_CellVisibleCountChanged;
            e.FloatingWindow.FloatspaceControl.PageDrop += FloatspaceControl_PageDrop;
            e.FloatingWindow.FloatspaceControl.BeforePageDrag += FloatspaceControl_BeforePageDrag;

            ++_floatingWindowCount;
            ExitMainAppIfNoMoreFloatingWindows();
        }

        private void DockingManager_FloatingWindowRemoved(object sender, FloatingWindowEventArgs e)
        {
            e.FloatingWindow.FloatspaceControl.CellCountChanged -= FloatspaceControl_CellCountChanged;
            e.FloatingWindow.FloatspaceControl.CellVisibleCountChanged -= FloatspaceControl_CellVisibleCountChanged;
            e.FloatingWindow.FloatspaceControl.PageDrop -= FloatspaceControl_PageDrop;
            e.FloatingWindow.FloatspaceControl.BeforePageDrag -= FloatspaceControl_BeforePageDrag;
        }

        private void FloatspaceControl_CellVisibleCountChanged(object sender, EventArgs e)
        {
            KryptonFloatspace floatSpace = (sender as KryptonFloatspace);
            UpdateCellSettings(floatSpace);
        }

        private void FloatspaceControl_CellCountChanged(object sender, EventArgs e)
        {
            KryptonFloatspace floatSpace = (sender as KryptonFloatspace);
            //UpdateCellSettings(floatSpace);
        }

        private void FloatspaceControl_PageDrop(object sender, PageDropEventArgs e)
        {
            KryptonFloatspace floatSpace = (sender as KryptonFloatspace);

            var floatingWindow = floatSpace.Parent as KryptonFloatingWindow;
            floatingWindow.TextExtra = "";
            //UpdateCellSettings(floatSpace);
        }

        private void FloatspaceControl_BeforePageDrag(object sender, PageDragCancelEventArgs e)
        {
            KryptonFloatspace floatSpace = (sender as KryptonFloatspace);
            var floatingWindow = floatSpace.Parent as KryptonFloatingWindow;
            floatingWindow.TextExtra = floatSpace.FirstVisibleCell().Pages.FirstOrDefault().Text;
        }

        private static void UpdateCellSettings(KryptonFloatspace floatSpace)
        {
            KryptonWorkspaceCell cell = floatSpace.FirstVisibleCell();
            if (cell != null)
            {
                if (floatSpace.CellVisibleCount <= 1)
                {
                    cell.NavigatorMode = NavigatorMode.HeaderGroup;
                    cell.Button.ButtonSpecs.SingleOrDefault(x => x.Type == PaletteButtonSpecStyle.Close).Visible = false;

                    var floatingWindow = floatSpace.Parent as KryptonFloatingWindow;
                    if (floatingWindow == null)
                        return;

                    if (cell.Pages.Count == 1)
                    {
                        floatingWindow.TextExtra = cell?.Pages.FirstOrDefault()?.Text;

                        cell.Header.HeaderVisibleBar = false;
                        cell.Header.HeaderVisiblePrimary = false;
                        cell.Header.HeaderVisibleSecondary = false;
                    }
                    else
                    { 
                        floatingWindow.TextExtra = "";

                        cell.Header.HeaderVisibleBar = true;
                        cell.Header.HeaderVisiblePrimary = true;
                        cell.Header.HeaderVisibleSecondary = true;
                    }
                }
                else
                {
                    var floatingWindow = floatSpace.Parent as KryptonFloatingWindow;
                    if (floatingWindow != null)
                        floatingWindow.TextExtra = "";
                    do
                    {
                        cell.NavigatorMode = NavigatorMode.HeaderGroup;
                        cell.Button.ButtonSpecs.SingleOrDefault(x => x.Type == PaletteButtonSpecStyle.Close).Visible = true;
                        cell.Header.HeaderVisibleBar = true;
                        cell.Header.HeaderVisiblePrimary = true;
                        cell.Header.HeaderVisibleSecondary = true;

                        cell = floatSpace.NextVisibleCell(cell);
                    }
                    while (cell != null);
                }
            }
        }

        private void ExitMainAppIfNoMoreFloatingWindows()
        {
            if (_floatingWindowCount == 0)
                this.Close();
        }

        


        private void KryptonContextMenuItemShowPortfolioDashboard_Click(object sender, System.EventArgs e)
        {
            dockingManager.AddFloatingWindow("Floating", new KryptonPage[] { CreateDashboardPage() });
        }

        private void KryptonContextMenuItemShowAccounts_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void KryptonContextMenuItemShowBalances_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void KryptonContextMenuItemShowPositions_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void KryptonContextMenuItemShowOrders_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void KryptonContextMenuItemShowDMA_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void KryptonContextMenuItemShowFeedback_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void KryptonContextMenuItemShowLog_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void KryptonContextMenuItemShowWebSocketSummary_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void kryptonContextMenuItem6_Click(object sender, EventArgs e)
        {
            dockingManager.SaveConfigToFile(configFileName);
            dma2.SaveConfig();
        }
    }
}
