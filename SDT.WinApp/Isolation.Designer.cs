
namespace SDT.WinApp
{
    partial class Isolation
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ucIndex1 = new SDT.WinApp.Controls.UcIndex();
            this.SuspendLayout();
            // 
            // ucIndex1
            // 
            this.ucIndex1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucIndex1.Location = new System.Drawing.Point(0, 0);
            this.ucIndex1.Margin = new System.Windows.Forms.Padding(4);
            this.ucIndex1.Name = "ucIndex1";
            this.ucIndex1.Size = new System.Drawing.Size(699, 697);
            this.ucIndex1.TabIndex = 1;
            // 
            // Isolation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 697);
            this.Controls.Add(this.ucIndex1);
            this.Name = "Isolation";
            this.Text = "事务隔离级别";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.UcIndex ucIndex1;
    }
}

