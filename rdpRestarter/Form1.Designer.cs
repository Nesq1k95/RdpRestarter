namespace rdpRestarter
{
    partial class RdpRestarter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RdpRestarter));
            this.text1 = new System.Windows.Forms.Label();
            this.yesButton = new System.Windows.Forms.Button();
            this.HourButton = new System.Windows.Forms.Button();
            this.dayButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timeLabel = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.testButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // text1
            // 
            resources.ApplyResources(this.text1, "text1");
            this.text1.Name = "text1";
            // 
            // yesButton
            // 
            resources.ApplyResources(this.yesButton, "yesButton");
            this.yesButton.Name = "yesButton";
            this.yesButton.UseVisualStyleBackColor = true;
            this.yesButton.Click += new System.EventHandler(this.yesButton_Click);
            // 
            // HourButton
            // 
            resources.ApplyResources(this.HourButton, "HourButton");
            this.HourButton.Name = "HourButton";
            this.HourButton.UseVisualStyleBackColor = true;
            this.HourButton.Click += new System.EventHandler(this.HourButton_Click);
            // 
            // dayButton
            // 
            resources.ApplyResources(this.dayButton, "dayButton");
            this.dayButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.dayButton.Name = "dayButton";
            this.dayButton.UseVisualStyleBackColor = true;
            this.dayButton.Click += new System.EventHandler(this.dayButton_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timeLabel
            // 
            resources.ApplyResources(this.timeLabel, "timeLabel");
            this.timeLabel.Name = "timeLabel";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // testButton
            // 
            resources.ApplyResources(this.testButton, "testButton");
            this.testButton.Name = "testButton";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // RdpRestarter
            // 
            this.AcceptButton = this.yesButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.dayButton;
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dayButton);
            this.Controls.Add(this.HourButton);
            this.Controls.Add(this.yesButton);
            this.Controls.Add(this.text1);
            this.Name = "RdpRestarter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label text1;
        private System.Windows.Forms.Button yesButton;
        private System.Windows.Forms.Button HourButton;
        private System.Windows.Forms.Button dayButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label timeLabel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button testButton;
    }
}

