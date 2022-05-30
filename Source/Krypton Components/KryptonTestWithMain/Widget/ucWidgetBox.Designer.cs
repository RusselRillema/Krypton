
namespace MK_Ultra.Sandwich.SupportTools
{
    partial class ucWidgetBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ucWidgetBox
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Name = "ucWidgetBox";
            this.Size = new System.Drawing.Size(261, 157);
            this.Click += new System.EventHandler(this.ucFeedback2_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ucFeedback2_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ucFeedback2_MouseDown);
            this.MouseLeave += new System.EventHandler(this.ucFeedback2_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ucFeedback2_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ucFeedback2_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
