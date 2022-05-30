using ComponentFactory.Krypton.Docking;
using ComponentFactory.Krypton.Navigator;
using ComponentFactory.Krypton.Toolkit;
using ComponentFactory.Krypton.Workspace;
using Microsoft.Web.WebView2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static KryptonTestWithMain.PageCreator;

namespace KryptonTestWithMain.Forms
{
    public partial class DMA2 : UserControl
    {
        private string _config = "DMA_Config.json";

        private WebView2 _wv2PriceChart;
        public DMA2()
        {
            InitializeComponent();
        }

        private void DMA2_Load(object sender, EventArgs e)
        {
            kryptonDockableWorkspace1.CellCountChanged += KryptonDockableWorkspace1_CellCountChanged;

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

            _wv2PriceChart = new WebView2();


            var positions = CreateLocalPage("Positions", kryptonDataGridPositions);
            var orders = CreateLocalPage("Orders", kryptonDataGridOrders);
            var priceChart = CreateLocalPage("Price Chart", _wv2PriceChart);
            var trading = CreateLocalPage("Trading", kryptonDataGridOrders);
            var recentOrders = CreateLocalPage("Recent orders", kryptonDataGridOrders);
            var orderbook = CreateLocalPage("Orderbook", kryptonDataGridOrders);
            var recentTrades = CreateLocalPage("Recent Trades", kryptonDataGridOrders);


            dockingManager.AddToWorkspace("Workspace", new KryptonPage[] { positions, orders, priceChart, trading, recentOrders, orderbook, recentTrades });

            //foreach (var item in kryptonDockableWorkspace1.AllPages())
            //{
            //    //if (item?.ButtonSpecs[0] != null)
            //    //    item.ButtonSpecs[0].Visible = false;
            //    var x = item.KryptonParentContainer as KryptonWorkspaceCell;
            //    x.Button.ButtonSpecs[0].Visible = false;
            //    foreach (var page in x.Pages)
            //    {
            //        page.ButtonSpecs[page.ButtonSpecs.Count - 1].Visible = false;
            //        var c = page.KryptonParentContainer as KryptonWorkspaceCell;
            //        c.Button.ButtonSpecs[0].Visible = false;
            //    }
            //}
            //SetupPriceChart();
        }

        private void KryptonDockableWorkspace1_CellCountChanged(object sender, EventArgs e)
        {
            KryptonDockableWorkspace dockableWorkspace = (sender as KryptonDockableWorkspace);
            var cell = dockableWorkspace.FirstVisibleCell();
            if (cell?.Button.ButtonSpecs.SingleOrDefault(x => x.Type == PaletteButtonSpecStyle.Close) != null)
                cell.Button.ButtonSpecs.Single(x => x.Type == PaletteButtonSpecStyle.Close).Visible = false;
            //var x = dockableWorkspace.AllPages();
            //foreach (var item in x)
            //{
            //    item.
            //    item.AreFlagsSet(KryptonPageFlags.DockingAllowClose);
            //    item.AreFlagsSet(KryptonPageFlags.All);
            //    item.ButtonSpecs[0].Visible = false;
            //}
        }

        private void SetupPriceChart()
        {
            string html = "";
            using (Stream stream = this.GetType().Assembly.GetManifestResourceStream(this.GetType().Namespace + ".TradingViewChart.html"))
            {
                using (var streamReader = new StreamReader(stream))
                {
                    html = streamReader.ReadToEnd();
                }
            }
            html = html.Replace("{symbol}", "BYBIT:BTCUSD");
            html = html.Replace("{interval}", "30");

            if (_wv2PriceChart == null)
                return;

            if (_wv2PriceChart.IsDisposed)
                return;

            MethodInvoker mi = async delegate ()
            {
                await _wv2PriceChart.EnsureCoreWebView2Async();
                _wv2PriceChart.NavigateToString(html);
            };

            if (_wv2PriceChart.InvokeRequired) _wv2PriceChart.BeginInvoke(mi); else mi();
        }

        private KryptonPage CreateLocalPage(string text, Control control)
        {
            var page = NewPage(text, control);
            page.ClearFlags(KryptonPageFlags.All);
            page.SetFlags(KryptonPageFlags.AllowConfigSave);
            page.SetFlags(KryptonPageFlags.DockingAllowWorkspace);
            page.SetFlags(KryptonPageFlags.AllowPageReorder);
            page.SetFlags(KryptonPageFlags.AllowPageDrag);
            return page;
        }

        internal void LoadConfig()
        {
            dockingManager.LoadConfigFromFile(_config);
        }

        internal void SaveConfig()
        {
            dockingManager.SaveConfigToFile(_config);
        }
    }
}
