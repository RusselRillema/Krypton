namespace DockingFlags
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.kryptonPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonDockableWorkspace = new ComponentFactory.Krypton.Docking.KryptonDockableWorkspace();
            this.kryptonPalette = new ComponentFactory.Krypton.Toolkit.KryptonPalette(this.components);
            this.kryptonDockingManager = new ComponentFactory.Krypton.Docking.KryptonDockingManager();
            this.imageListSmall = new System.Windows.Forms.ImageList(this.components);
            this.kryptonManager = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.buttonSpecAny1 = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).BeginInit();
            this.kryptonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDockableWorkspace)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel
            // 
            this.kryptonPanel.Controls.Add(this.kryptonDockableWorkspace);
            this.kryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel.Name = "kryptonPanel";
            this.kryptonPanel.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.kryptonPanel.Size = new System.Drawing.Size(641, 466);
            this.kryptonPanel.TabIndex = 0;
            // 
            // kryptonDockableWorkspace
            // 
            this.kryptonDockableWorkspace.AutoHiddenHost = false;
            this.kryptonDockableWorkspace.CompactFlags = ((ComponentFactory.Krypton.Workspace.CompactFlags)(((ComponentFactory.Krypton.Workspace.CompactFlags.RemoveEmptyCells | ComponentFactory.Krypton.Workspace.CompactFlags.RemoveEmptySequences) 
            | ComponentFactory.Krypton.Workspace.CompactFlags.PromoteLeafs)));
            this.kryptonDockableWorkspace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonDockableWorkspace.Location = new System.Drawing.Point(3, 3);
            this.kryptonDockableWorkspace.Name = "kryptonDockableWorkspace";
            // 
            // 
            // 
            this.kryptonDockableWorkspace.Root.UniqueName = "D3A631E8871B4E59D3A631E8871B4E59";
            this.kryptonDockableWorkspace.Root.WorkspaceControl = this.kryptonDockableWorkspace;
            this.kryptonDockableWorkspace.ShowMaximizeButton = false;
            this.kryptonDockableWorkspace.Size = new System.Drawing.Size(635, 460);
            this.kryptonDockableWorkspace.TabIndex = 0;
            this.kryptonDockableWorkspace.TabStop = true;
            // 
            // kryptonPalette
            // 
            this.kryptonPalette.BasePaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Black;
            this.kryptonPalette.Common.StateCommon.Back.Color1 = System.Drawing.Color.Silver;
            this.kryptonPalette.Common.StateCommon.Back.Color2 = System.Drawing.Color.Silver;
            this.kryptonPalette.ContextMenu.StateCommon.ControlInner.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.kryptonPalette.ContextMenu.StateCommon.ControlInner.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.kryptonPalette.ContextMenu.StateCommon.ControlOuter.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.kryptonPalette.ContextMenu.StateCommon.ControlOuter.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.kryptonPalette.ContextMenu.StateNormal.ItemHighlight.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.kryptonPalette.ContextMenu.StateNormal.ItemHighlight.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.kryptonPalette.FormStyles.FormCommon.StateActive.Back.Color1 = System.Drawing.Color.Gray;
            this.kryptonPalette.FormStyles.FormCommon.StateActive.Back.Color2 = System.Drawing.Color.Silver;
            this.kryptonPalette.FormStyles.FormCommon.StateActive.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette.FormStyles.FormCommon.StateCommon.Back.Color1 = System.Drawing.Color.Gray;
            this.kryptonPalette.FormStyles.FormCommon.StateCommon.Back.Color2 = System.Drawing.Color.Silver;
            this.kryptonPalette.FormStyles.FormCustom1.StateActive.Back.Color1 = System.Drawing.Color.Gray;
            this.kryptonPalette.FormStyles.FormCustom1.StateActive.Back.Color2 = System.Drawing.Color.Silver;
            this.kryptonPalette.FormStyles.FormCustom1.StateCommon.Back.Color1 = System.Drawing.Color.Gray;
            this.kryptonPalette.FormStyles.FormCustom1.StateCommon.Back.Color2 = System.Drawing.Color.Silver;
            this.kryptonPalette.FormStyles.FormMain.StateActive.Back.Color1 = System.Drawing.Color.Gray;
            this.kryptonPalette.FormStyles.FormMain.StateActive.Back.Color2 = System.Drawing.Color.Silver;
            this.kryptonPalette.FormStyles.FormMain.StateCommon.Back.Color1 = System.Drawing.Color.Gray;
            this.kryptonPalette.FormStyles.FormMain.StateCommon.Back.Color2 = System.Drawing.Color.Silver;
            this.kryptonPalette.FormStyles.FormMain.StateInactive.Back.Color1 = System.Drawing.Color.Gray;
            this.kryptonPalette.FormStyles.FormMain.StateInactive.Back.Color2 = System.Drawing.Color.Silver;
            this.kryptonPalette.PanelStyles.PanelCommon.StateCommon.Color1 = System.Drawing.Color.Gray;
            this.kryptonPalette.PanelStyles.PanelCommon.StateCommon.Color2 = System.Drawing.Color.Blue;
            this.kryptonPalette.Ribbon.RibbonAppButton.StateCommon.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.kryptonPalette.Ribbon.RibbonAppButton.StateCommon.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.kryptonPalette.Ribbon.RibbonAppButton.StateCommon.BackColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.kryptonPalette.Ribbon.RibbonAppButton.StateCommon.BackColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.kryptonPalette.Ribbon.RibbonAppButton.StateCommon.BackColor5 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.kryptonPalette.Ribbon.RibbonAppButton.StateNormal.BackColor1 = System.Drawing.Color.Blue;
            this.kryptonPalette.Ribbon.RibbonAppButton.StateNormal.BackColor2 = System.Drawing.Color.Blue;
            this.kryptonPalette.Ribbon.RibbonAppButton.StateNormal.BackColor3 = System.Drawing.Color.Blue;
            this.kryptonPalette.Ribbon.RibbonAppButton.StateNormal.BackColor4 = System.Drawing.Color.Blue;
            this.kryptonPalette.Ribbon.RibbonAppButton.StateNormal.BackColor5 = System.Drawing.Color.Blue;
            this.kryptonPalette.Ribbon.RibbonAppMenuInner.BackColor1 = System.Drawing.Color.Fuchsia;
            this.kryptonPalette.Ribbon.RibbonAppMenuInner.BackColor2 = System.Drawing.Color.Fuchsia;
            this.kryptonPalette.Ribbon.RibbonAppMenuInner.BackColor3 = System.Drawing.Color.Fuchsia;
            this.kryptonPalette.Ribbon.RibbonAppMenuInner.BackColor4 = System.Drawing.Color.Fuchsia;
            this.kryptonPalette.Ribbon.RibbonAppMenuInner.BackColor5 = System.Drawing.Color.Fuchsia;
            this.kryptonPalette.Ribbon.RibbonGalleryBack.BackColor1 = System.Drawing.Color.Fuchsia;
            this.kryptonPalette.Ribbon.RibbonGalleryBack.BackColor2 = System.Drawing.Color.Fuchsia;
            this.kryptonPalette.Ribbon.RibbonGalleryBack.BackColor3 = System.Drawing.Color.Fuchsia;
            this.kryptonPalette.Ribbon.RibbonGalleryBack.BackColor4 = System.Drawing.Color.Fuchsia;
            this.kryptonPalette.Ribbon.RibbonGalleryBack.BackColor5 = System.Drawing.Color.Fuchsia;
            this.kryptonPalette.Ribbon.RibbonGalleryBorder.BackColor1 = System.Drawing.Color.Fuchsia;
            this.kryptonPalette.Ribbon.RibbonGalleryBorder.BackColor2 = System.Drawing.Color.Fuchsia;
            this.kryptonPalette.Ribbon.RibbonGalleryBorder.BackColor3 = System.Drawing.Color.Fuchsia;
            this.kryptonPalette.Ribbon.RibbonGalleryBorder.BackColor4 = System.Drawing.Color.Fuchsia;
            this.kryptonPalette.Ribbon.RibbonGalleryBorder.BackColor5 = System.Drawing.Color.Fuchsia;
            this.kryptonPalette.Ribbon.RibbonGroupArea.StateCommon.BackColor1 = System.Drawing.Color.DarkMagenta;
            this.kryptonPalette.Ribbon.RibbonGroupArea.StateCommon.BackColor2 = System.Drawing.Color.Purple;
            this.kryptonPalette.Ribbon.RibbonGroupArea.StateCommon.BackColor3 = System.Drawing.Color.Magenta;
            this.kryptonPalette.Ribbon.RibbonGroupArea.StateCommon.BackColor4 = System.Drawing.Color.Fuchsia;
            this.kryptonPalette.Ribbon.RibbonGroupArea.StateCommon.BackColor5 = System.Drawing.Color.Orchid;
            this.kryptonPalette.Ribbon.RibbonGroupArea.StateContextCheckedNormal.BackColor1 = System.Drawing.Color.Cyan;
            this.kryptonPalette.Ribbon.RibbonGroupArea.StateContextCheckedNormal.BackColor2 = System.Drawing.Color.Cyan;
            this.kryptonPalette.Ribbon.RibbonGroupArea.StateContextCheckedNormal.BackColor3 = System.Drawing.Color.Cyan;
            this.kryptonPalette.Ribbon.RibbonTab.StateCommon.BackColor1 = System.Drawing.Color.Lime;
            this.kryptonPalette.Ribbon.RibbonTab.StateCommon.BackColor2 = System.Drawing.Color.Lime;
            this.kryptonPalette.Ribbon.RibbonTab.StateCommon.BackColor3 = System.Drawing.Color.Lime;
            this.kryptonPalette.Ribbon.RibbonTab.StateCommon.BackColor4 = System.Drawing.Color.Lime;
            this.kryptonPalette.Ribbon.RibbonTab.StateCommon.BackColor5 = System.Drawing.Color.Lime;
            this.kryptonPalette.Ribbon.RibbonTab.StateCommon.TextColor = System.Drawing.Color.DarkOliveGreen;
            this.kryptonPalette.TabStyles.TabCommon.StateNormal.Back.Color1 = System.Drawing.Color.Red;
            this.kryptonPalette.TabStyles.TabCommon.StateNormal.Back.Color2 = System.Drawing.Color.Yellow;
            this.kryptonPalette.TabStyles.TabCommon.StateNormal.Border.Color1 = System.Drawing.Color.Lime;
            this.kryptonPalette.TabStyles.TabCommon.StateNormal.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.kryptonPalette.TabStyles.TabCommon.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette.TabStyles.TabCommon.StateSelected.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.kryptonPalette.TabStyles.TabCommon.StateSelected.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.kryptonPalette.TabStyles.TabCommon.StateSelected.Border.Color1 = System.Drawing.Color.Lime;
            this.kryptonPalette.TabStyles.TabCommon.StateSelected.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.kryptonPalette.TabStyles.TabCommon.StateSelected.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette.ToolMenuStatus.Button.ButtonCheckedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.kryptonPalette.ToolMenuStatus.Button.ButtonCheckedGradientEnd = System.Drawing.Color.Maroon;
            this.kryptonPalette.ToolMenuStatus.Button.ButtonPressedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.kryptonPalette.ToolMenuStatus.Button.ButtonPressedGradientEnd = System.Drawing.Color.Maroon;
            this.kryptonPalette.ToolMenuStatus.Button.ButtonSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.kryptonPalette.ToolMenuStatus.Button.ButtonSelectedGradientEnd = System.Drawing.Color.Maroon;
            this.kryptonPalette.ToolMenuStatus.Button.ButtonSelectedHighlight = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.kryptonPalette.ToolMenuStatus.Button.OverflowButtonGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.kryptonPalette.ToolMenuStatus.Button.OverflowButtonGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.kryptonPalette.ToolMenuStatus.Grip.GripDark = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.kryptonPalette.ToolMenuStatus.Menu.MenuBorder = System.Drawing.Color.Red;
            this.kryptonPalette.ToolMenuStatus.Menu.MenuItemBorder = System.Drawing.Color.White;
            this.kryptonPalette.ToolMenuStatus.Menu.MenuItemPressedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.kryptonPalette.ToolMenuStatus.Menu.MenuItemPressedGradientEnd = System.Drawing.Color.Maroon;
            this.kryptonPalette.ToolMenuStatus.Menu.MenuItemSelected = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.kryptonPalette.ToolMenuStatus.Menu.MenuItemSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.kryptonPalette.ToolMenuStatus.Menu.MenuItemSelectedGradientEnd = System.Drawing.Color.Green;
            this.kryptonPalette.ToolMenuStatus.MenuStrip.MenuStripFont = new System.Drawing.Font("Sitka Banner", 8.25F, System.Drawing.FontStyle.Bold);
            this.kryptonPalette.ToolMenuStatus.MenuStrip.MenuStripGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.kryptonPalette.ToolMenuStatus.MenuStrip.MenuStripGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.kryptonPalette.ToolMenuStatus.Rafting.RaftingContainerGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.kryptonPalette.ToolMenuStatus.Rafting.RaftingContainerGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.kryptonPalette.ToolMenuStatus.Separator.SeparatorDark = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.kryptonPalette.ToolMenuStatus.Separator.SeparatorLight = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.kryptonPalette.ToolMenuStatus.StatusStrip.StatusStripGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.kryptonPalette.ToolMenuStatus.StatusStrip.StatusStripGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.kryptonPalette.ToolMenuStatus.ToolStrip.ToolStripDropDownBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.kryptonPalette.ToolMenuStatus.ToolStrip.ToolStripGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.kryptonPalette.ToolMenuStatus.ToolStrip.ToolStripGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.kryptonPalette.ToolMenuStatus.ToolStrip.ToolStripPanelGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.kryptonPalette.ToolMenuStatus.ToolStrip.ToolStripPanelGradientEnd = System.Drawing.Color.Maroon;
            this.kryptonPalette.ToolMenuStatus.UseRoundedEdges = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            // 
            // imageListSmall
            // 
            this.imageListSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListSmall.ImageStream")));
            this.imageListSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListSmall.Images.SetKeyName(0, "document_plain.png");
            this.imageListSmall.Images.SetKeyName(1, "preferences.png");
            this.imageListSmall.Images.SetKeyName(2, "information2.png");
            // 
            // kryptonManager
            // 
            this.kryptonManager.GlobalPalette = this.kryptonPalette;
            this.kryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Custom;
            // 
            // buttonSpecAny1
            // 
            this.buttonSpecAny1.Text = "MenuOption1";
            this.buttonSpecAny1.UniqueName = "42066A424DAA4CF6B78FC7241CA7C378";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.buttonSpecAny1});
            this.ClientSize = new System.Drawing.Size(641, 466);
            this.Controls.Add(this.kryptonPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Docking Flags";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).EndInit();
            this.kryptonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDockableWorkspace)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel;
        private ComponentFactory.Krypton.Docking.KryptonDockingManager kryptonDockingManager;
        private System.Windows.Forms.ImageList imageListSmall;
        private ComponentFactory.Krypton.Docking.KryptonDockableWorkspace kryptonDockableWorkspace;
        private ComponentFactory.Krypton.Toolkit.KryptonPalette kryptonPalette;
        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny buttonSpecAny1;
    }
}

