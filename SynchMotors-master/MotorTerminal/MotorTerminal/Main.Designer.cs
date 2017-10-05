namespace MotorTerminal
{
    partial class Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.Diagnostics = new System.Windows.Forms.Button();
            this.Settings = new System.Windows.Forms.Button();
            this.About = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PortState = new System.Windows.Forms.TextBox();
            this.Disconnect = new System.Windows.Forms.Button();
            this.Connect = new System.Windows.Forms.Button();
            this.Refresh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.PortName = new System.Windows.Forms.ComboBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Diagnostics
            // 
            this.Diagnostics.Image = ((System.Drawing.Image)(resources.GetObject("Diagnostics.Image")));
            this.Diagnostics.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Diagnostics.Location = new System.Drawing.Point(16, 24);
            this.Diagnostics.Name = "Diagnostics";
            this.Diagnostics.Size = new System.Drawing.Size(146, 44);
            this.Diagnostics.TabIndex = 0;
            this.Diagnostics.Text = "         Диагностика";
            this.Diagnostics.UseVisualStyleBackColor = true;
            this.Diagnostics.Click += new System.EventHandler(this.Diagnostics_Click);
            // 
            // Settings
            // 
            this.Settings.Image = ((System.Drawing.Image)(resources.GetObject("Settings.Image")));
            this.Settings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Settings.Location = new System.Drawing.Point(206, 24);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(146, 44);
            this.Settings.TabIndex = 1;
            this.Settings.Text = "         Параметризация";
            this.Settings.UseVisualStyleBackColor = true;
            this.Settings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // About
            // 
            this.About.Location = new System.Drawing.Point(16, 85);
            this.About.Name = "About";
            this.About.Size = new System.Drawing.Size(146, 44);
            this.About.TabIndex = 2;
            this.About.Text = "О программе";
            this.About.UseVisualStyleBackColor = true;
            // 
            // Exit
            // 
            this.Exit.Image = ((System.Drawing.Image)(resources.GetObject("Exit.Image")));
            this.Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Exit.Location = new System.Drawing.Point(206, 85);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(146, 44);
            this.Exit.TabIndex = 3;
            this.Exit.Text = "   Выход";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Diagnostics);
            this.groupBox1.Controls.Add(this.Exit);
            this.groupBox1.Controls.Add(this.Settings);
            this.groupBox1.Controls.Add(this.About);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 147);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.PortState);
            this.groupBox2.Controls.Add(this.Disconnect);
            this.groupBox2.Controls.Add(this.Connect);
            this.groupBox2.Controls.Add(this.Refresh);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.PortName);
            this.groupBox2.Location = new System.Drawing.Point(12, 188);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(368, 93);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Параметры соединения";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Состояние порта";
            // 
            // PortState
            // 
            this.PortState.Location = new System.Drawing.Point(112, 64);
            this.PortState.Name = "PortState";
            this.PortState.ReadOnly = true;
            this.PortState.Size = new System.Drawing.Size(162, 20);
            this.PortState.TabIndex = 5;
            // 
            // Disconnect
            // 
            this.Disconnect.Enabled = false;
            this.Disconnect.Image = ((System.Drawing.Image)(resources.GetObject("Disconnect.Image")));
            this.Disconnect.Location = new System.Drawing.Point(280, 18);
            this.Disconnect.Name = "Disconnect";
            this.Disconnect.Size = new System.Drawing.Size(40, 36);
            this.Disconnect.TabIndex = 4;
            this.Disconnect.UseVisualStyleBackColor = true;
            this.Disconnect.Click += new System.EventHandler(this.Disconnect_Click);
            // 
            // Connect
            // 
            this.Connect.Image = ((System.Drawing.Image)(resources.GetObject("Connect.Image")));
            this.Connect.Location = new System.Drawing.Point(234, 18);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(40, 36);
            this.Connect.TabIndex = 3;
            this.Connect.UseVisualStyleBackColor = true;
            this.Connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // Refresh
            // 
            this.Refresh.Image = ((System.Drawing.Image)(resources.GetObject("Refresh.Image")));
            this.Refresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Refresh.Location = new System.Drawing.Point(188, 18);
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(40, 36);
            this.Refresh.TabIndex = 2;
            this.Refresh.UseVisualStyleBackColor = true;
            this.Refresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Имя порта";
            // 
            // PortName
            // 
            this.PortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PortName.FormattingEnabled = true;
            this.PortName.Location = new System.Drawing.Point(80, 27);
            this.PortName.Name = "PortName";
            this.PortName.Size = new System.Drawing.Size(90, 21);
            this.PortName.TabIndex = 0;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 293);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Терминал";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Diagnostics;
        private System.Windows.Forms.Button Settings;
        private System.Windows.Forms.Button About;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox PortName;
        private System.Windows.Forms.Button Refresh;
        private System.Windows.Forms.Button Disconnect;
        private System.Windows.Forms.Button Connect;
        private System.Windows.Forms.TextBox PortState;
        private System.Windows.Forms.Label label2;
        public System.IO.Ports.SerialPort serialPort1;
    }
}

