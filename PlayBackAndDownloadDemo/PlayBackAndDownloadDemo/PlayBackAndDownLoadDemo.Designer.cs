namespace PlayBackAndDownloadDemo
{
    partial class PlayBackAndDownLoadDemo
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
            this.playBackProgressBar = new NetSDKCS.Control.PlayBackProgressBar();
            this.playback_pictureBox = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.normal_button = new System.Windows.Forms.Button();
            this.speed_label = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.slow_button = new System.Windows.Forms.Button();
            this.fast_button = new System.Windows.Forms.Button();
            this.pause_button = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.GroupBox();
            this.login_button = new System.Windows.Forms.Button();
            this.port_textBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.name_textBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pwd_textBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ip_textBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.GroupBox();
            this.download_channel_comboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.download_stream_comboBox = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.downloadstop_button = new System.Windows.Forms.Button();
            this.downloadstart_button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.endtime_dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.starttime_dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.download_progressBar = new System.Windows.Forms.ProgressBar();
            this.panel4 = new System.Windows.Forms.GroupBox();
            this.stop_button = new System.Windows.Forms.Button();
            this.play_button = new System.Windows.Forms.Button();
            this.play_stream_comboBox = new System.Windows.Forms.ComboBox();
            this.channel_comboBox = new System.Windows.Forms.ComboBox();
            this.play_dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.SCtype_comboBox = new System.Windows.Forms.ComboBox();
            this.SC_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.playback_pictureBox)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // playBackProgressBar
            // 
            this.playBackProgressBar.BackColor = System.Drawing.Color.Black;
            this.playBackProgressBar.Location = new System.Drawing.Point(3, 40);
            this.playBackProgressBar.MaximumSize = new System.Drawing.Size(0, 130);
            this.playBackProgressBar.MinimumSize = new System.Drawing.Size(500, 130);
            this.playBackProgressBar.Name = "playBackProgressBar";
            this.playBackProgressBar.Size = new System.Drawing.Size(500, 130);
            this.playBackProgressBar.TabIndex = 0;
            this.playBackProgressBar.ProgressChanged += new NetSDKCS.Control.ProgressEventHandle(this.playBackProgressBar_ProgressChanged);
            // 
            // playback_pictureBox
            // 
            this.playback_pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.playback_pictureBox.Location = new System.Drawing.Point(3, 5);
            this.playback_pictureBox.Name = "playback_pictureBox";
            this.playback_pictureBox.Size = new System.Drawing.Size(519, 335);
            this.playback_pictureBox.TabIndex = 1;
            this.playback_pictureBox.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.normal_button);
            this.panel2.Controls.Add(this.speed_label);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.slow_button);
            this.panel2.Controls.Add(this.fast_button);
            this.panel2.Controls.Add(this.playBackProgressBar);
            this.panel2.Controls.Add(this.pause_button);
            this.panel2.Location = new System.Drawing.Point(3, 346);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(519, 172);
            this.panel2.TabIndex = 3;
            // 
            // normal_button
            // 
            this.normal_button.Location = new System.Drawing.Point(417, 9);
            this.normal_button.Name = "normal_button";
            this.normal_button.Size = new System.Drawing.Size(86, 23);
            this.normal_button.TabIndex = 7;
            this.normal_button.Text = "Normal(正常)";
            this.normal_button.UseVisualStyleBackColor = true;
            this.normal_button.Click += new System.EventHandler(this.normal_button_Click);
            // 
            // speed_label
            // 
            this.speed_label.AutoSize = true;
            this.speed_label.Location = new System.Drawing.Point(86, 14);
            this.speed_label.Name = "speed_label";
            this.speed_label.Size = new System.Drawing.Size(0, 12);
            this.speed_label.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(102, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 12);
            this.label4.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(11, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "Speed(速度):";
            // 
            // slow_button
            // 
            this.slow_button.Location = new System.Drawing.Point(321, 9);
            this.slow_button.Name = "slow_button";
            this.slow_button.Size = new System.Drawing.Size(80, 23);
            this.slow_button.TabIndex = 3;
            this.slow_button.Text = "Slow(慢放)";
            this.slow_button.UseVisualStyleBackColor = true;
            this.slow_button.Click += new System.EventHandler(this.slow_button_Click);
            // 
            // fast_button
            // 
            this.fast_button.Location = new System.Drawing.Point(230, 9);
            this.fast_button.Name = "fast_button";
            this.fast_button.Size = new System.Drawing.Size(80, 23);
            this.fast_button.TabIndex = 2;
            this.fast_button.Text = "Fast(快放)";
            this.fast_button.UseVisualStyleBackColor = true;
            this.fast_button.Click += new System.EventHandler(this.fast_button_Click);
            // 
            // pause_button
            // 
            this.pause_button.Location = new System.Drawing.Point(139, 9);
            this.pause_button.Name = "pause_button";
            this.pause_button.Size = new System.Drawing.Size(80, 23);
            this.pause_button.TabIndex = 1;
            this.pause_button.Text = "Pause(暂停)";
            this.pause_button.UseVisualStyleBackColor = true;
            this.pause_button.Click += new System.EventHandler(this.pause_button_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.login_button);
            this.panel1.Controls.Add(this.port_textBox);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.name_textBox);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.pwd_textBox);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.ip_textBox);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(528, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(244, 168);
            this.panel1.TabIndex = 4;
            this.panel1.TabStop = false;
            this.panel1.Text = "Device Login(设备登录)";
            // 
            // login_button
            // 
            this.login_button.Location = new System.Drawing.Point(59, 136);
            this.login_button.Name = "login_button";
            this.login_button.Size = new System.Drawing.Size(105, 23);
            this.login_button.TabIndex = 8;
            this.login_button.Text = "Login(登录)";
            this.login_button.UseVisualStyleBackColor = true;
            this.login_button.Click += new System.EventHandler(this.login_button_Click);
            // 
            // port_textBox
            // 
            this.port_textBox.Location = new System.Drawing.Point(94, 50);
            this.port_textBox.Name = "port_textBox";
            this.port_textBox.Size = new System.Drawing.Size(140, 23);
            this.port_textBox.TabIndex = 7;
            this.port_textBox.Text = "37777";
            this.port_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.port_textBox_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 12);
            this.label9.TabIndex = 6;
            this.label9.Text = "Port(端口):";
            // 
            // name_textBox
            // 
            this.name_textBox.Location = new System.Drawing.Point(94, 78);
            this.name_textBox.Name = "name_textBox";
            this.name_textBox.Size = new System.Drawing.Size(140, 23);
            this.name_textBox.TabIndex = 5;
            this.name_textBox.Text = "admin";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 12);
            this.label8.TabIndex = 4;
            this.label8.Text = "Name(用户):";
            // 
            // pwd_textBox
            // 
            this.pwd_textBox.Location = new System.Drawing.Point(94, 107);
            this.pwd_textBox.Name = "pwd_textBox";
            this.pwd_textBox.Size = new System.Drawing.Size(140, 23);
            this.pwd_textBox.TabIndex = 3;
            this.pwd_textBox.Text = "hzci202216";
            this.pwd_textBox.UseSystemPasswordChar = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "Pwd(密码):";
            // 
            // ip_textBox
            // 
            this.ip_textBox.Location = new System.Drawing.Point(94, 23);
            this.ip_textBox.Name = "ip_textBox";
            this.ip_textBox.Size = new System.Drawing.Size(140, 23);
            this.ip_textBox.TabIndex = 1;
            this.ip_textBox.Text = "172.13.138.13";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "IP(设备IP):";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.download_channel_comboBox);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.download_stream_comboBox);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.downloadstop_button);
            this.panel3.Controls.Add(this.downloadstart_button);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.endtime_dateTimePicker);
            this.panel3.Controls.Add(this.starttime_dateTimePicker);
            this.panel3.Controls.Add(this.download_progressBar);
            this.panel3.Location = new System.Drawing.Point(528, 318);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(244, 201);
            this.panel3.TabIndex = 5;
            this.panel3.TabStop = false;
            this.panel3.Text = "DownLoad(下载)";
            // 
            // download_channel_comboBox
            // 
            this.download_channel_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.download_channel_comboBox.Location = new System.Drawing.Point(95, 17);
            this.download_channel_comboBox.Name = "download_channel_comboBox";
            this.download_channel_comboBox.Size = new System.Drawing.Size(140, 20);
            this.download_channel_comboBox.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "Channel(通道):";
            // 
            // download_stream_comboBox
            // 
            this.download_stream_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.download_stream_comboBox.FormattingEnabled = true;
            this.download_stream_comboBox.Location = new System.Drawing.Point(94, 46);
            this.download_stream_comboBox.Name = "download_stream_comboBox";
            this.download_stream_comboBox.Size = new System.Drawing.Size(140, 20);
            this.download_stream_comboBox.TabIndex = 10;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 49);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 12);
            this.label12.TabIndex = 9;
            this.label12.Text = "Stream(码流):";
            // 
            // downloadstop_button
            // 
            this.downloadstop_button.Location = new System.Drawing.Point(125, 149);
            this.downloadstop_button.Name = "downloadstop_button";
            this.downloadstop_button.Size = new System.Drawing.Size(105, 23);
            this.downloadstop_button.TabIndex = 8;
            this.downloadstop_button.Text = "Stop(停止)";
            this.downloadstop_button.UseVisualStyleBackColor = true;
            this.downloadstop_button.Click += new System.EventHandler(this.downloadstop_button_Click);
            // 
            // downloadstart_button
            // 
            this.downloadstart_button.Location = new System.Drawing.Point(14, 149);
            this.downloadstart_button.Name = "downloadstart_button";
            this.downloadstart_button.Size = new System.Drawing.Size(105, 23);
            this.downloadstart_button.TabIndex = 7;
            this.downloadstart_button.Text = "Download(下载）";
            this.downloadstart_button.UseVisualStyleBackColor = true;
            this.downloadstart_button.Click += new System.EventHandler(this.downloadstart_button_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "EndTime 结束时间";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "StartTime开始时间";
            // 
            // endtime_dateTimePicker
            // 
            this.endtime_dateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.endtime_dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endtime_dateTimePicker.Location = new System.Drawing.Point(93, 117);
            this.endtime_dateTimePicker.Name = "endtime_dateTimePicker";
            this.endtime_dateTimePicker.ShowUpDown = true;
            this.endtime_dateTimePicker.Size = new System.Drawing.Size(141, 23);
            this.endtime_dateTimePicker.TabIndex = 2;
            // 
            // starttime_dateTimePicker
            // 
            this.starttime_dateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.starttime_dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.starttime_dateTimePicker.Location = new System.Drawing.Point(93, 76);
            this.starttime_dateTimePicker.Name = "starttime_dateTimePicker";
            this.starttime_dateTimePicker.ShowUpDown = true;
            this.starttime_dateTimePicker.Size = new System.Drawing.Size(141, 23);
            this.starttime_dateTimePicker.TabIndex = 1;
            // 
            // download_progressBar
            // 
            this.download_progressBar.Location = new System.Drawing.Point(12, 178);
            this.download_progressBar.Name = "download_progressBar";
            this.download_progressBar.Size = new System.Drawing.Size(220, 14);
            this.download_progressBar.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.stop_button);
            this.panel4.Controls.Add(this.play_button);
            this.panel4.Controls.Add(this.play_stream_comboBox);
            this.panel4.Controls.Add(this.channel_comboBox);
            this.panel4.Controls.Add(this.play_dateTimePicker);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Location = new System.Drawing.Point(528, 176);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(244, 136);
            this.panel4.TabIndex = 6;
            this.panel4.TabStop = false;
            this.panel4.Text = "PlayBack(回放)";
            // 
            // stop_button
            // 
            this.stop_button.Location = new System.Drawing.Point(125, 104);
            this.stop_button.Name = "stop_button";
            this.stop_button.Size = new System.Drawing.Size(105, 23);
            this.stop_button.TabIndex = 10;
            this.stop_button.Text = "Stop(停止)";
            this.stop_button.UseVisualStyleBackColor = true;
            this.stop_button.Click += new System.EventHandler(this.stop_button_Click);
            // 
            // play_button
            // 
            this.play_button.Location = new System.Drawing.Point(14, 104);
            this.play_button.Name = "play_button";
            this.play_button.Size = new System.Drawing.Size(105, 23);
            this.play_button.TabIndex = 9;
            this.play_button.Text = "Play(播放)";
            this.play_button.UseVisualStyleBackColor = true;
            this.play_button.Click += new System.EventHandler(this.play_button_Click);
            // 
            // play_stream_comboBox
            // 
            this.play_stream_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.play_stream_comboBox.FormattingEnabled = true;
            this.play_stream_comboBox.Location = new System.Drawing.Point(94, 46);
            this.play_stream_comboBox.Name = "play_stream_comboBox";
            this.play_stream_comboBox.Size = new System.Drawing.Size(140, 20);
            this.play_stream_comboBox.TabIndex = 6;
            // 
            // channel_comboBox
            // 
            this.channel_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.channel_comboBox.Location = new System.Drawing.Point(94, 18);
            this.channel_comboBox.Name = "channel_comboBox";
            this.channel_comboBox.Size = new System.Drawing.Size(140, 20);
            this.channel_comboBox.TabIndex = 5;
            // 
            // play_dateTimePicker
            // 
            this.play_dateTimePicker.CausesValidation = false;
            this.play_dateTimePicker.CustomFormat = "yyyy-MM-dd";
            this.play_dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.play_dateTimePicker.Location = new System.Drawing.Point(8, 75);
            this.play_dateTimePicker.MinDate = new System.DateTime(1755, 9, 23, 0, 0, 0, 0);
            this.play_dateTimePicker.Name = "play_dateTimePicker";
            this.play_dateTimePicker.Size = new System.Drawing.Size(218, 23);
            this.play_dateTimePicker.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 49);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 12);
            this.label11.TabIndex = 2;
            this.label11.Text = "Stream(码流):";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 12);
            this.label10.TabIndex = 1;
            this.label10.Text = "Channel(通道):";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SC_Button);
            this.groupBox1.Controls.Add(this.SCtype_comboBox);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Location = new System.Drawing.Point(528, 526);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(244, 101);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "StreamConvertor(转码下载)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 13);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(125, 12);
            this.label13.TabIndex = 0;
            this.label13.Text = "StreamType(转码类型)";
            // 
            // SCtype_comboBox
            // 
            this.SCtype_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SCtype_comboBox.FormattingEnabled = true;
            this.SCtype_comboBox.Location = new System.Drawing.Point(14, 29);
            this.SCtype_comboBox.Name = "SCtype_comboBox";
            this.SCtype_comboBox.Size = new System.Drawing.Size(220, 20);
            this.SCtype_comboBox.TabIndex = 1;
            // 
            // SC_Button
            // 
            this.SC_Button.Location = new System.Drawing.Point(14, 55);
            this.SC_Button.Name = "SC_Button";
            this.SC_Button.Size = new System.Drawing.Size(220, 23);
            this.SC_Button.TabIndex = 2;
            this.SC_Button.Text = "TranscodeDownload(转码下载)";
            this.SC_Button.UseVisualStyleBackColor = true;
            this.SC_Button.Click += new System.EventHandler(this.SC_Button_Click);
            // 
            // PlayBackAndDownLoadDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(774, 639);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.playback_pictureBox);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft New Tai Lue", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaximizeBox = false;
            this.Name = "PlayBackAndDownLoadDemo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PlayBackAndDownLoad(回放与下载Demo)";
            ((System.ComponentModel.ISupportInitialize)(this.playback_pictureBox)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private NetSDKCS.Control.PlayBackProgressBar playBackProgressBar;
        private System.Windows.Forms.PictureBox playback_pictureBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button slow_button;
        private System.Windows.Forms.Button fast_button;
        private System.Windows.Forms.Button pause_button;
        private System.Windows.Forms.GroupBox panel1;
        private System.Windows.Forms.GroupBox panel3;
        private System.Windows.Forms.DateTimePicker starttime_dateTimePicker;
        private System.Windows.Forms.ProgressBar download_progressBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker endtime_dateTimePicker;
        private System.Windows.Forms.Label speed_label;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button downloadstop_button;
        private System.Windows.Forms.Button downloadstart_button;
        private System.Windows.Forms.TextBox port_textBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox name_textBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox pwd_textBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ip_textBox;
        private System.Windows.Forms.Button login_button;
        private System.Windows.Forms.GroupBox panel4;
        private System.Windows.Forms.DateTimePicker play_dateTimePicker;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox play_stream_comboBox;
        private System.Windows.Forms.ComboBox channel_comboBox;
        private System.Windows.Forms.ComboBox download_stream_comboBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button play_button;
        private System.Windows.Forms.Button normal_button;
        private System.Windows.Forms.Button stop_button;
        private System.Windows.Forms.ComboBox download_channel_comboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button SC_Button;
        private System.Windows.Forms.ComboBox SCtype_comboBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}

