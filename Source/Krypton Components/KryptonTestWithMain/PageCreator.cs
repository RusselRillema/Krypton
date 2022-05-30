using ComponentFactory.Krypton.Navigator;
using ComponentFactory.Krypton.Toolkit;
using System.Windows.Forms;

namespace KryptonTestWithMain
{
    public static class PageCreator 
    {
        public static KryptonPage NewPage(string Text, Control control = null)
        {
            // Create and uniquely name the page
            KryptonPage page = new KryptonPage();
            //page.ClearFlags(KryptonPageFlags.DockingAllowDropDown);
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


            //page.ClearFlags(KryptonPageFlags.All);
            //page.SetFlags(KryptonPageFlags.AllowConfigSave);
            //page.SetFlags(KryptonPageFlags.DockingAllowFloating);
            //page.SetFlags(KryptonPageFlags.DockingAllowWorkspace);
            //page.SetFlags(KryptonPageFlags.AllowPageReorder);
            //page.SetFlags(KryptonPageFlags.AllowPageDrag);

            return page;
        }
    }
}
