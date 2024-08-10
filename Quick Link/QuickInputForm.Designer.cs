namespace QuickLink
{
    partial class QuickInputForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuickInputForm));
            this.ButtonGo = new System.Windows.Forms.Button();
            this.TextBox = new System.Windows.Forms.TextBox();
            this.TicketIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.TicketIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonGo
            // 
            this.ButtonGo.Location = new System.Drawing.Point(162, 9);
            this.ButtonGo.Name = "ButtonGo";
            this.ButtonGo.Size = new System.Drawing.Size(75, 23);
            this.ButtonGo.TabIndex = 0;
            this.ButtonGo.Text = "Go!";
            this.ButtonGo.UseVisualStyleBackColor = true;
            this.ButtonGo.Click += new System.EventHandler(this.ButtonGo_Click);
            // 
            // TextBox
            // 
            this.TextBox.Location = new System.Drawing.Point(34, 10);
            this.TextBox.Name = "TextBox";
            this.TextBox.Size = new System.Drawing.Size(122, 20);
            this.TextBox.TabIndex = 1;
            this.TextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // TicketIcon
            // 
            this.TicketIcon.InitialImage = global::QuickLink.Properties.Resources.app_icon_SpiraPlan_192x192;
            this.TicketIcon.Location = new System.Drawing.Point(12, 12);
            this.TicketIcon.Name = "TicketIcon";
            this.TicketIcon.Size = new System.Drawing.Size(16, 16);
            this.TicketIcon.TabIndex = 2;
            this.TicketIcon.TabStop = false;
            // 
            // QuickInputForm
            // 
            this.AcceptButton = this.ButtonGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 40);
            this.Controls.Add(this.TicketIcon);
            this.Controls.Add(this.TextBox);
            this.Controls.Add(this.ButtonGo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuickInputForm";
            this.ShowInTaskbar = false;
            this.Text = "Quick Link";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.TicketIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonGo;
        private System.Windows.Forms.TextBox TextBox;
        private System.Windows.Forms.PictureBox TicketIcon;
    }
}

