namespace Modemy_Labsony
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
            this.zerwijPolaczenieButton = new System.Windows.Forms.Button();
            this.zadzwonButton = new System.Windows.Forms.Button();
            this.odbierzButton = new System.Windows.Forms.Button();
            this.zerwijPolaczenieZModememButton = new System.Windows.Forms.Button();
            this.polaczSzeregowoButton = new System.Windows.Forms.Button();
            this.konsola = new System.Windows.Forms.TextBox();
            this.wiadomoscInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numerModemu = new System.Windows.Forms.TextBox();
            this.buttonSendFile = new System.Windows.Forms.Button();
            this.checkBoxRecieve = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // zerwijPolaczenieButton
            // 
            this.zerwijPolaczenieButton.Location = new System.Drawing.Point(41, 28);
            this.zerwijPolaczenieButton.Name = "zerwijPolaczenieButton";
            this.zerwijPolaczenieButton.Size = new System.Drawing.Size(296, 98);
            this.zerwijPolaczenieButton.TabIndex = 0;
            this.zerwijPolaczenieButton.Text = "Zerwij polaczenie";
            this.zerwijPolaczenieButton.UseVisualStyleBackColor = true;
            this.zerwijPolaczenieButton.Click += new System.EventHandler(this.zerwijPolaczenieButton_Click);
            // 
            // zadzwonButton
            // 
            this.zadzwonButton.Location = new System.Drawing.Point(41, 132);
            this.zadzwonButton.Name = "zadzwonButton";
            this.zadzwonButton.Size = new System.Drawing.Size(145, 37);
            this.zadzwonButton.TabIndex = 1;
            this.zadzwonButton.Text = "Zadzwon";
            this.zadzwonButton.UseVisualStyleBackColor = true;
            this.zadzwonButton.Click += new System.EventHandler(this.zadzwonButton_Click);
            // 
            // odbierzButton
            // 
            this.odbierzButton.Location = new System.Drawing.Point(192, 132);
            this.odbierzButton.Name = "odbierzButton";
            this.odbierzButton.Size = new System.Drawing.Size(145, 37);
            this.odbierzButton.TabIndex = 2;
            this.odbierzButton.Text = "Odbierz";
            this.odbierzButton.UseVisualStyleBackColor = true;
            this.odbierzButton.Click += new System.EventHandler(this.odbierzButton_Click);
            // 
            // zerwijPolaczenieZModememButton
            // 
            this.zerwijPolaczenieZModememButton.Location = new System.Drawing.Point(378, 95);
            this.zerwijPolaczenieZModememButton.Name = "zerwijPolaczenieZModememButton";
            this.zerwijPolaczenieZModememButton.Size = new System.Drawing.Size(256, 31);
            this.zerwijPolaczenieZModememButton.TabIndex = 3;
            this.zerwijPolaczenieZModememButton.Text = "Zerwij polaczenie z modemem";
            this.zerwijPolaczenieZModememButton.UseVisualStyleBackColor = true;
            this.zerwijPolaczenieZModememButton.Click += new System.EventHandler(this.zerwijPolaczenieZModememButton_Click);
            // 
            // polaczSzeregowoButton
            // 
            this.polaczSzeregowoButton.Location = new System.Drawing.Point(378, 62);
            this.polaczSzeregowoButton.Name = "polaczSzeregowoButton";
            this.polaczSzeregowoButton.Size = new System.Drawing.Size(258, 27);
            this.polaczSzeregowoButton.TabIndex = 6;
            this.polaczSzeregowoButton.Text = "Polacz z modemem szeregowo";
            this.polaczSzeregowoButton.UseVisualStyleBackColor = true;
            this.polaczSzeregowoButton.Click += new System.EventHandler(this.polaczSzeregowoButton_Click);
            // 
            // konsola
            // 
            this.konsola.Location = new System.Drawing.Point(41, 211);
            this.konsola.Multiline = true;
            this.konsola.Name = "konsola";
            this.konsola.Size = new System.Drawing.Size(593, 271);
            this.konsola.TabIndex = 8;
            // 
            // wiadomoscInput
            // 
            this.wiadomoscInput.Location = new System.Drawing.Point(41, 559);
            this.wiadomoscInput.Multiline = true;
            this.wiadomoscInput.Name = "wiadomoscInput";
            this.wiadomoscInput.Size = new System.Drawing.Size(593, 59);
            this.wiadomoscInput.TabIndex = 9;
            this.wiadomoscInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.wiadomoscInput_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 502);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Numer modemu do polaczenia :";
            // 
            // numerModemu
            // 
            this.numerModemu.Location = new System.Drawing.Point(275, 495);
            this.numerModemu.Multiline = true;
            this.numerModemu.Name = "numerModemu";
            this.numerModemu.Size = new System.Drawing.Size(165, 35);
            this.numerModemu.TabIndex = 11;
            // 
            // buttonSendFile
            // 
            this.buttonSendFile.Location = new System.Drawing.Point(378, 28);
            this.buttonSendFile.Name = "buttonSendFile";
            this.buttonSendFile.Size = new System.Drawing.Size(258, 28);
            this.buttonSendFile.TabIndex = 12;
            this.buttonSendFile.Text = "Wyślij Plik";
            this.buttonSendFile.UseVisualStyleBackColor = true;
            this.buttonSendFile.Click += new System.EventHandler(this.buttonSendFile_Click);
            // 
            // checkBoxRecieve
            // 
            this.checkBoxRecieve.AutoSize = true;
            this.checkBoxRecieve.Location = new System.Drawing.Point(378, 139);
            this.checkBoxRecieve.Name = "checkBoxRecieve";
            this.checkBoxRecieve.Size = new System.Drawing.Size(140, 24);
            this.checkBoxRecieve.TabIndex = 13;
            this.checkBoxRecieve.Text = "Zapisz do pliku";
            this.checkBoxRecieve.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 656);
            this.Controls.Add(this.checkBoxRecieve);
            this.Controls.Add(this.buttonSendFile);
            this.Controls.Add(this.numerModemu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.wiadomoscInput);
            this.Controls.Add(this.konsola);
            this.Controls.Add(this.polaczSzeregowoButton);
            this.Controls.Add(this.zerwijPolaczenieZModememButton);
            this.Controls.Add(this.odbierzButton);
            this.Controls.Add(this.zadzwonButton);
            this.Controls.Add(this.zerwijPolaczenieButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button zerwijPolaczenieButton;
        private System.Windows.Forms.Button zadzwonButton;
        private System.Windows.Forms.Button odbierzButton;
        private System.Windows.Forms.Button zerwijPolaczenieZModememButton;
        private System.Windows.Forms.Button polaczSzeregowoButton;
        private System.Windows.Forms.TextBox konsola;
        private System.Windows.Forms.TextBox wiadomoscInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox numerModemu;
        private System.Windows.Forms.Button buttonSendFile;
        private System.Windows.Forms.CheckBox checkBoxRecieve;
    }
}

