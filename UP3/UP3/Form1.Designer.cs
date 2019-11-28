namespace UP3
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.labelIP = new System.Windows.Forms.Label();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.timerRead = new System.Windows.Forms.Timer(this.components);
            this.labelValueText = new System.Windows.Forms.Label();
            this.progressBarValue = new System.Windows.Forms.ProgressBar();
            this.labelValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(12, 40);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(100, 20);
            this.textBoxIP.TabIndex = 0;
            // 
            // labelIP
            // 
            this.labelIP.AutoSize = true;
            this.labelIP.Location = new System.Drawing.Point(12, 14);
            this.labelIP.Name = "labelIP";
            this.labelIP.Size = new System.Drawing.Size(47, 13);
            this.labelIP.TabIndex = 1;
            this.labelIP.Text = "Adres IP";
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(142, 9);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(75, 23);
            this.buttonConnect.TabIndex = 2;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.Location = new System.Drawing.Point(142, 38);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(75, 23);
            this.buttonDisconnect.TabIndex = 3;
            this.buttonDisconnect.Text = "Disconnect";
            this.buttonDisconnect.UseVisualStyleBackColor = true;
            this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);
            // 
            // timerRead
            // 
            this.timerRead.Interval = 250;
            this.timerRead.Tick += new System.EventHandler(this.timerRead_Tick);
            // 
            // labelValueText
            // 
            this.labelValueText.AutoSize = true;
            this.labelValueText.Location = new System.Drawing.Point(50, 86);
            this.labelValueText.Name = "labelValueText";
            this.labelValueText.Size = new System.Drawing.Size(50, 13);
            this.labelValueText.TabIndex = 4;
            this.labelValueText.Text = "Wartość:";
            // 
            // progressBarValue
            // 
            this.progressBarValue.Location = new System.Drawing.Point(15, 102);
            this.progressBarValue.Name = "progressBarValue";
            this.progressBarValue.Size = new System.Drawing.Size(202, 23);
            this.progressBarValue.TabIndex = 5;
            // 
            // labelValue
            // 
            this.labelValue.AutoSize = true;
            this.labelValue.Location = new System.Drawing.Point(139, 86);
            this.labelValue.Name = "labelValue";
            this.labelValue.Size = new System.Drawing.Size(13, 13);
            this.labelValue.TabIndex = 6;
            this.labelValue.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 140);
            this.Controls.Add(this.labelValue);
            this.Controls.Add(this.progressBarValue);
            this.Controls.Add(this.labelValueText);
            this.Controls.Add(this.buttonDisconnect);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.labelIP);
            this.Controls.Add(this.textBoxIP);
            this.Name = "Form1";
            this.Text = "Disconnected";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.Label labelIP;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonDisconnect;
        private System.Windows.Forms.Timer timerRead;
        private System.Windows.Forms.Label labelValueText;
        private System.Windows.Forms.ProgressBar progressBarValue;
        private System.Windows.Forms.Label labelValue;
    }
}

