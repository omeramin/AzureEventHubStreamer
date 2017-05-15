namespace EventHubStreamer
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_connectEventHub = new System.Windows.Forms.Button();
            this.updateTextBoxbackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.btn_closeEventHub = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 37);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(1043, 616);
            this.textBox1.TabIndex = 0;
            this.textBox1.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Status";
            // 
            // btn_connectEventHub
            // 
            this.btn_connectEventHub.Location = new System.Drawing.Point(899, 8);
            this.btn_connectEventHub.Name = "btn_connectEventHub";
            this.btn_connectEventHub.Size = new System.Drawing.Size(75, 23);
            this.btn_connectEventHub.TabIndex = 2;
            this.btn_connectEventHub.Text = "Connect";
            this.btn_connectEventHub.UseVisualStyleBackColor = true;
            this.btn_connectEventHub.Click += new System.EventHandler(this.btn_connectEventHub_Click);
            // 
            // updateTextBoxbackgroundWorker
            // 
            this.updateTextBoxbackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.updateTextBoxbackgroundWorker_DoWork);
            this.updateTextBoxbackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.updateTextBoxbackgroundWorker_ProgressChanged);
            // 
            // btn_closeEventHub
            // 
            this.btn_closeEventHub.Enabled = false;
            this.btn_closeEventHub.Location = new System.Drawing.Point(980, 8);
            this.btn_closeEventHub.Name = "btn_closeEventHub";
            this.btn_closeEventHub.Size = new System.Drawing.Size(75, 23);
            this.btn_closeEventHub.TabIndex = 3;
            this.btn_closeEventHub.Text = "Close";
            this.btn_closeEventHub.UseVisualStyleBackColor = true;
            this.btn_closeEventHub.Click += new System.EventHandler(this.btn_closeEventHub_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 665);
            this.Controls.Add(this.btn_closeEventHub);
            this.Controls.Add(this.btn_connectEventHub);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_connectEventHub;
        private System.ComponentModel.BackgroundWorker updateTextBoxbackgroundWorker;
        private System.Windows.Forms.Button btn_closeEventHub;
    }
}

