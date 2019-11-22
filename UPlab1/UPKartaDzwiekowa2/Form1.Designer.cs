namespace UPKartaDzwiekowa2
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
            this.buttonPlay = new System.Windows.Forms.Button();
            this.buttonPlayDirectX = new System.Windows.Forms.Button();
            this.buttonWaveOutWrite = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonWMP = new System.Windows.Forms.Button();
            this.buttonRecord = new System.Windows.Forms.Button();
            this.buttonStopRec = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.progressBar3 = new System.Windows.Forms.ProgressBar();
            this.progressBar4 = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(12, 12);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(75, 37);
            this.buttonPlay.TabIndex = 0;
            this.buttonPlay.Text = "Play";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // buttonPlayDirectX
            // 
            this.buttonPlayDirectX.Location = new System.Drawing.Point(118, 12);
            this.buttonPlayDirectX.Name = "buttonPlayDirectX";
            this.buttonPlayDirectX.Size = new System.Drawing.Size(75, 37);
            this.buttonPlayDirectX.TabIndex = 1;
            this.buttonPlayDirectX.Text = "DirectX";
            this.buttonPlayDirectX.UseVisualStyleBackColor = true;
            this.buttonPlayDirectX.Click += new System.EventHandler(this.buttonPlayDirectX_Click);
            // 
            // buttonWaveOutWrite
            // 
            this.buttonWaveOutWrite.Location = new System.Drawing.Point(223, 12);
            this.buttonWaveOutWrite.Name = "buttonWaveOutWrite";
            this.buttonWaveOutWrite.Size = new System.Drawing.Size(131, 37);
            this.buttonWaveOutWrite.TabIndex = 2;
            this.buttonWaveOutWrite.Text = "WaveOutWrite";
            this.buttonWaveOutWrite.UseVisualStyleBackColor = true;
            this.buttonWaveOutWrite.Click += new System.EventHandler(this.buttonWaveOutWrite_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(12, 100);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 34);
            this.buttonStop.TabIndex = 3;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonWMP
            // 
            this.buttonWMP.Location = new System.Drawing.Point(396, 12);
            this.buttonWMP.Name = "buttonWMP";
            this.buttonWMP.Size = new System.Drawing.Size(75, 36);
            this.buttonWMP.TabIndex = 4;
            this.buttonWMP.Text = "WMP";
            this.buttonWMP.UseVisualStyleBackColor = true;
            this.buttonWMP.Click += new System.EventHandler(this.buttonWMP_Click);
            // 
            // buttonRecord
            // 
            this.buttonRecord.Location = new System.Drawing.Point(503, 12);
            this.buttonRecord.Name = "buttonRecord";
            this.buttonRecord.Size = new System.Drawing.Size(75, 42);
            this.buttonRecord.TabIndex = 5;
            this.buttonRecord.Text = "Record";
            this.buttonRecord.UseVisualStyleBackColor = true;
            this.buttonRecord.Click += new System.EventHandler(this.buttonRecord_Click);
            // 
            // buttonStopRec
            // 
            this.buttonStopRec.Location = new System.Drawing.Point(503, 100);
            this.buttonStopRec.Name = "buttonStopRec";
            this.buttonStopRec.Size = new System.Drawing.Size(83, 29);
            this.buttonStopRec.TabIndex = 6;
            this.buttonStopRec.Text = "StopRec";
            this.buttonStopRec.UseVisualStyleBackColor = true;
            this.buttonStopRec.Click += new System.EventHandler(this.buttonStopRec_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 211);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(337, 23);
            this.progressBar1.TabIndex = 7;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(12, 240);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(337, 23);
            this.progressBar2.TabIndex = 7;
            // 
            // progressBar3
            // 
            this.progressBar3.Location = new System.Drawing.Point(12, 268);
            this.progressBar3.Name = "progressBar3";
            this.progressBar3.Size = new System.Drawing.Size(337, 23);
            this.progressBar3.TabIndex = 7;
            // 
            // progressBar4
            // 
            this.progressBar4.Location = new System.Drawing.Point(12, 297);
            this.progressBar4.Name = "progressBar4";
            this.progressBar4.Size = new System.Drawing.Size(337, 23);
            this.progressBar4.TabIndex = 7;
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(456, 211);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 28);
            this.comboBox1.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.progressBar4);
            this.Controls.Add(this.progressBar3);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.buttonStopRec);
            this.Controls.Add(this.buttonRecord);
            this.Controls.Add(this.buttonWMP);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonWaveOutWrite);
            this.Controls.Add(this.buttonPlayDirectX);
            this.Controls.Add(this.buttonPlay);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonPlayDirectX;
        private System.Windows.Forms.Button buttonWaveOutWrite;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonWMP;
        private System.Windows.Forms.Button buttonRecord;
        private System.Windows.Forms.Button buttonStopRec;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.ProgressBar progressBar3;
        private System.Windows.Forms.ProgressBar progressBar4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

