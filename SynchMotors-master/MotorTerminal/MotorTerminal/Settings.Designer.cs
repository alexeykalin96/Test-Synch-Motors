namespace MotorTerminal
{
    partial class Settings
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
            this.Exit = new System.Windows.Forms.Button();
            this.CurrentCheck = new System.Windows.Forms.CheckBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.maxCurrent = new System.Windows.Forms.TextBox();
            this.timeWork = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Read = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SynchSet = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.SynchSet.SuspendLayout();
            this.SuspendLayout();
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(238, 238);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(75, 23);
            this.Exit.TabIndex = 0;
            this.Exit.Text = "Выход";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // CurrentCheck
            // 
            this.CurrentCheck.AutoSize = true;
            this.CurrentCheck.Location = new System.Drawing.Point(22, 23);
            this.CurrentCheck.Name = "CurrentCheck";
            this.CurrentCheck.Size = new System.Drawing.Size(197, 17);
            this.CurrentCheck.TabIndex = 1;
            this.CurrentCheck.Text = "Включить синхронизацию по току";
            this.CurrentCheck.UseVisualStyleBackColor = true;
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 50;
            this.trackBar1.Location = new System.Drawing.Point(8, 46);
            this.trackBar1.Maximum = 1200;
            this.trackBar1.Minimum = 200;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(301, 45);
            this.trackBar1.SmallChange = 50;
            this.trackBar1.TabIndex = 2;
            this.trackBar1.Value = 200;
            this.trackBar1.ValueChanged += new System.EventHandler(this.showMaxCurrent);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Максимальный ток";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Время срабатывания";
            // 
            // trackBar2
            // 
            this.trackBar2.LargeChange = 10;
            this.trackBar2.Location = new System.Drawing.Point(8, 127);
            this.trackBar2.Maximum = 1000;
            this.trackBar2.Minimum = 100;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(301, 45);
            this.trackBar2.SmallChange = 10;
            this.trackBar2.TabIndex = 5;
            this.trackBar2.Value = 100;
            this.trackBar2.ValueChanged += new System.EventHandler(this.showTimeWork);
            // 
            // maxCurrent
            // 
            this.maxCurrent.Location = new System.Drawing.Point(130, 22);
            this.maxCurrent.Name = "maxCurrent";
            this.maxCurrent.ReadOnly = true;
            this.maxCurrent.Size = new System.Drawing.Size(66, 20);
            this.maxCurrent.TabIndex = 6;
            // 
            // timeWork
            // 
            this.timeWork.Location = new System.Drawing.Point(140, 101);
            this.timeWork.Name = "timeWork";
            this.timeWork.ReadOnly = true;
            this.timeWork.Size = new System.Drawing.Size(56, 20);
            this.timeWork.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(208, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "мА";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(213, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "мс";
            // 
            // Read
            // 
            this.Read.Location = new System.Drawing.Point(12, 238);
            this.Read.Name = "Read";
            this.Read.Size = new System.Drawing.Size(75, 23);
            this.Read.TabIndex = 10;
            this.Read.Text = "Считать";
            this.Read.UseVisualStyleBackColor = true;
            this.Read.Click += new System.EventHandler(this.Read_Click);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(125, 238);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 11;
            this.Save.Text = "Сохранить";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // SynchSet
            // 
            this.SynchSet.Controls.Add(this.label1);
            this.SynchSet.Controls.Add(this.trackBar1);
            this.SynchSet.Controls.Add(this.label2);
            this.SynchSet.Controls.Add(this.label4);
            this.SynchSet.Controls.Add(this.trackBar2);
            this.SynchSet.Controls.Add(this.label3);
            this.SynchSet.Controls.Add(this.maxCurrent);
            this.SynchSet.Controls.Add(this.timeWork);
            this.SynchSet.Location = new System.Drawing.Point(12, 49);
            this.SynchSet.Name = "SynchSet";
            this.SynchSet.Size = new System.Drawing.Size(312, 176);
            this.SynchSet.TabIndex = 12;
            this.SynchSet.TabStop = false;
            this.SynchSet.Text = "Параметры синхронизации";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 281);
            this.ControlBox = false;
            this.Controls.Add(this.SynchSet);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Read);
            this.Controls.Add(this.CurrentCheck);
            this.Controls.Add(this.Exit);
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Параметризация";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.SynchSet.ResumeLayout(false);
            this.SynchSet.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.CheckBox CurrentCheck;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.TextBox maxCurrent;
        private System.Windows.Forms.TextBox timeWork;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Read;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox SynchSet;
    }
}