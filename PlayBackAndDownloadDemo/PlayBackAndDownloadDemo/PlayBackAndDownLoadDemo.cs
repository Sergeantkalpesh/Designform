using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using NetSDKCS;
using NetSDKCS.Control;
using System.Runtime.InteropServices;
using System.IO;

namespace PlayBackAndDownloadDemo
{
    public partial class PlayBackAndDownLoadDemo : Form
    {
        #region Field 字段
        private const int m_WaitTime = 5000;
        private const double MAXSPEED = 16;
        private const double MINSPEED = 0.0625; // 1/16
        private const int DOWNLOAD_END = -1;
        private const int DOWNLOAD_FAILED = -2;
        private const double OSD_TIMER_INTERVAL = 62.5; // 1000ms/16(maxspeed)
        private static fDisConnectCallBack m_DisConnectCallBack;
        private static fHaveReConnectCallBack m_ReConnectCallBack;
        private static fTimeDownLoadPosCallBack m_DownloadPosCallBack;
        private static fDataCallBack m_DataCallBack;

        private IntPtr m_LoginID = IntPtr.Zero;
        private NET_DEVICEINFO_Ex m_DeviceInfo;
        private DateTime m_EndTime;
        private IntPtr m_PlayBackID = IntPtr.Zero;
        private bool m_IsPause = false;
        private System.Timers.Timer m_Timer = new System.Timers.Timer();
        private NET_TIME m_OsdTime = new NET_TIME();
        private NET_TIME m_OsdStartTime = new NET_TIME();
        private NET_TIME m_OsdEndTime = new NET_TIME();
        private double m_CurrentSpeed;
        private IntPtr m_DownloadID = IntPtr.Zero;
        private DateTime m_DateTimeNow;
        private string m_FilePath;
        private int m_StreamType;
        #endregion

        public PlayBackAndDownLoadDemo()
        {
            InitializeComponent();
            m_Timer.Interval = OSD_TIMER_INTERVAL;
            m_Timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            this.Load += new EventHandler(PlayBackAndDownLoadDemo_Load);
        }

        private void PlayBackAndDownLoadDemo_Load(object sender, EventArgs e)
        {
            m_DateTimeNow = DateTime.Now;
            starttime_dateTimePicker.Value = m_DateTimeNow.AddHours(-1);
            m_DisConnectCallBack = new fDisConnectCallBack(DisConnectCallBack);
            m_ReConnectCallBack = new fHaveReConnectCallBack(ReConnectCallBack);
            m_DownloadPosCallBack = new fTimeDownLoadPosCallBack(DownLoadPosCallBack);
            m_DataCallBack = new fDataCallBack(DataCallBack);
            try
            {
                NETClient.Init(m_DisConnectCallBack, IntPtr.Zero, null);
                NET_LOG_SET_PRINT_INFO logInfo = new NET_LOG_SET_PRINT_INFO()
                {
                    dwSize = (uint)Marshal.SizeOf(typeof(NET_LOG_SET_PRINT_INFO))
                };
                NETClient.LogOpen(logInfo);
                NETClient.SetAutoReconnect(m_ReConnectCallBack, IntPtr.Zero);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Process.GetCurrentProcess().Kill();
            }
            InitOrLogoutUI();
        }

        #region UpdateUI 更新UI
        private void InitOrLogoutUI()
        {
            login_button.Text = "Login(登录)";
            play_button.Enabled = false;
            stop_button.Enabled = false;
            downloadstart_button.Enabled = false;
            downloadstop_button.Enabled = false;
            play_button.Enabled = false;
            stop_button.Enabled = false;
            normal_button.Enabled = false;
            pause_button.Enabled = false;
            fast_button.Enabled = false;
            slow_button.Enabled = false;
            channel_comboBox.Enabled = false;
            channel_comboBox.Items.Clear();
            play_stream_comboBox.Enabled = false;
            play_stream_comboBox.Items.Clear();
            download_channel_comboBox.Enabled = false;
            download_channel_comboBox.Items.Clear();
            download_stream_comboBox.Enabled = false;
            download_stream_comboBox.Items.Clear();
            play_dateTimePicker.Enabled = false;
            starttime_dateTimePicker.Enabled = false;
            endtime_dateTimePicker.Enabled = false;
            playBackProgressBar.Enabled = false;
            speed_label.Text = "";
            playback_pictureBox.Refresh();
            playBackProgressBar.Clear();
            SCtype_comboBox.Enabled = false;
            SCtype_comboBox.Items.Clear();
            SC_Button.Enabled = false;
        }
        private void LoginUI()
        {
            login_button.Text = "Logout(登出)";
            play_button.Enabled = true;
            downloadstart_button.Enabled = true;
            channel_comboBox.Enabled = true;
            play_stream_comboBox.Enabled = true;
            download_channel_comboBox.Enabled = true;
            download_stream_comboBox.Enabled = true;
            play_dateTimePicker.Enabled = true;
            starttime_dateTimePicker.Enabled = true;
            endtime_dateTimePicker.Enabled = true;
            for (int i = 0; i < m_DeviceInfo.nChanNum; i++)
            {
                download_channel_comboBox.Items.Add(i + 1);
                channel_comboBox.Items.Add(i + 1);  
            }
            download_channel_comboBox.SelectedIndex = 0;
            channel_comboBox.SelectedIndex = 0;
            play_stream_comboBox.Items.Add("MainStream(主码流)");
            play_stream_comboBox.Items.Add("ExtraStream(辅码流)");
            play_stream_comboBox.SelectedIndex = 0;
            download_stream_comboBox.Items.Add("MainStream(主码流)");
            download_stream_comboBox.Items.Add("ExtraStream(辅码流)");
            download_stream_comboBox.SelectedIndex = 0;
            SCtype_comboBox.Enabled = true;
            SCtype_comboBox.Items.Add("Private(私有码流)");
            SCtype_comboBox.Items.Add("GBPS(国标PS码流)");
            SCtype_comboBox.Items.Add("TS(TS码流)");
            SCtype_comboBox.Items.Add("MP4(MP4文件)");
            SCtype_comboBox.Items.Add("H264(裸视频流)");
            SCtype_comboBox.Items.Add("FLV(流式FLV)");
            SCtype_comboBox.Items.Add("PS(PS码流)");
            SCtype_comboBox.SelectedIndex = 0;
            SC_Button.Enabled = true;
            m_StreamType = 0;
        }
        private void PlayUI()
        {
            play_dateTimePicker.Enabled = false;
            channel_comboBox.Enabled = false;
            play_stream_comboBox.Enabled = false;
            play_button.Enabled = false;
            stop_button.Enabled = true;
            normal_button.Enabled = true;
            pause_button.Enabled = true;
            fast_button.Enabled = true;
            slow_button.Enabled = true;
            playBackProgressBar.Enabled = true;
            m_CurrentSpeed = 1;
            speed_label.Text = "1X";
            pause_button.Text = "Pause(暂停)";

        }
        private void StopPlayUI()
        {
            play_dateTimePicker.Enabled = true;
            channel_comboBox.Enabled = true;
            play_stream_comboBox.Enabled = true;
            play_button.Enabled = true;
            stop_button.Enabled = false;
            normal_button.Enabled = false;
            pause_button.Enabled = false;
            fast_button.Enabled = false;
            slow_button.Enabled = false;
            playBackProgressBar.Enabled = false;
            playback_pictureBox.Refresh();
            playBackProgressBar.Clear();
            m_CurrentSpeed = 0;
            speed_label.Text = "";
        }
        private void PauseOrPlayUI(bool isPlay)
        {
            if (isPlay)
            {
                if (m_CurrentSpeed == MAXSPEED)
                {
                    fast_button.Enabled = false;
                }
                else
                {
                    fast_button.Enabled = true;
                }
                if (m_CurrentSpeed == MINSPEED)
                {
                    slow_button.Enabled = false;
                }
                else
                {
                    slow_button.Enabled = true;
                }
                normal_button.Enabled = true;
                ShowSpeed(PlayBackType.Play);
                m_IsPause = false;
                pause_button.Text = "Pause(暂停)";
            }
            else
            {
                slow_button.Enabled = false;
                fast_button.Enabled = false;
                normal_button.Enabled = false;
                ShowSpeed(PlayBackType.Pause);
                m_IsPause = true;
                pause_button.Text = "Play(播放)";
            }
        }
        private void FastUI()
        {
            ShowSpeed(PlayBackType.Fast);
            if (m_CurrentSpeed == MAXSPEED)
            {
                fast_button.Enabled = false;
            }
            else
            {
                slow_button.Enabled = true;
            }
        }
        private void SlowUI()
        {
            ShowSpeed(PlayBackType.Slow);
            if (m_CurrentSpeed == MINSPEED)
            {
                slow_button.Enabled = false;
            }
            else
            {
                fast_button.Enabled = true;
            }
        }
        private void NormalUI()
        {
            fast_button.Enabled = true;
            slow_button.Enabled = true;
            ShowSpeed(PlayBackType.Normal);
        }
        private void ShowSpeed(PlayBackType mode)
        {
            switch (mode)
            {
                case PlayBackType.Slow:
                    m_CurrentSpeed /= 2;
                    break;
                case PlayBackType.Stop:
                    m_CurrentSpeed = 0;
                    break;
                case PlayBackType.Normal:
                    m_CurrentSpeed = 1;
                    break;
                case PlayBackType.Fast:
                    m_CurrentSpeed *= 2;
                    break;
                default:
                    break;
            }
            if (mode == PlayBackType.Pause || m_CurrentSpeed == 0)
            {
                speed_label.Text = "";
                return;
            }
            if (m_CurrentSpeed < 1 && m_CurrentSpeed > 0)
            {
                int i = (int)(1 / m_CurrentSpeed);
                speed_label.Text = string.Format("1/{0}X", i);
            }
            else
            {
                speed_label.Text = m_CurrentSpeed.ToString() + "X";
            }
        }
        private void DisConnectUI()
        {
            MessageBox.Show("Device is OffLine(设备离线!)");
            if (IntPtr.Zero != m_PlayBackID)
            {
                NETClient.PlayBackControl(m_PlayBackID, PlayBackType.Stop);
                m_PlayBackID = IntPtr.Zero;
            }
            if (IntPtr.Zero != m_LoginID)
            {
                NETClient.Logout(m_LoginID);
                m_LoginID = IntPtr.Zero;
            }
            m_Timer.Stop();
            InitOrLogoutUI();
        }
        private void ReConnectUI()
        {
            NETClient.Logout(m_LoginID);
            m_LoginID = IntPtr.Zero;
            m_PlayBackID = IntPtr.Zero;
            m_DownloadID = IntPtr.Zero;
            login_button.Text = "Login(登录)";
            MessageBox.Show(this, "Device is OnLine(设备在线)!");
        }

        #endregion

        #region CallBack 回调
        private void DisConnectCallBack(IntPtr lLoginID, IntPtr pchDVRIP, int nDVRPort, IntPtr dwUser)
        {
            this.BeginInvoke((Action)DisConnectUI);
        }

        private void ReConnectCallBack(IntPtr lLoginID, IntPtr pchDVRIP, int nDVRPort, IntPtr dwUser)
        {
            this.BeginInvoke((Action)ReConnectUI);
        }

        private void DownLoadPosCallBack(IntPtr lPlayHandle, uint dwTotalSize, uint dwDownLoadSize, int index, NET_RECORDFILE_INFO recordfileinfo, IntPtr dwUser)
        {
            if (lPlayHandle == m_DownloadID)
            {
                int value = 0;
                if (DOWNLOAD_END == (int)dwDownLoadSize)
                {
                    value = DOWNLOAD_END;
                }
                else if (DOWNLOAD_FAILED == (int)dwDownLoadSize)
                {
                    value = DOWNLOAD_FAILED;
                }
                else
                {
                    if (dwDownLoadSize >= dwTotalSize)
                    {
                        value = 100;
                    }
                    else
                    {
                        value = (int)(dwDownLoadSize * 100 / dwTotalSize);
                    }
                }
                this.BeginInvoke((Action<int>)UpdateProgressBarUI, value);
            }
        }

        private int DataCallBack(IntPtr lRealHandle, uint dwDataType, IntPtr pBuffer, uint dwBufSize, IntPtr dwUser)
        {
            if (0 == dwDataType && 0 == m_StreamType)
            {
                using (FileStream stream = new FileStream(m_FilePath, FileMode.Append))
                {
                    byte[] data = new byte[dwBufSize];
                    Marshal.Copy(pBuffer, data, 0, (int)dwBufSize);
                    stream.Write(data, 0, (int)dwBufSize);
                    stream.Flush();
                    stream.Dispose();
                }
            }
            else if (1000 + m_StreamType == dwDataType)
            {
                using (FileStream stream = new FileStream(m_FilePath, FileMode.Append))
                {
                    byte[] data = new byte[dwBufSize];
                    Marshal.Copy(pBuffer, data, 0, (int)dwBufSize);
                    stream.Write(data, 0, (int)dwBufSize);
                    stream.Flush();
                    stream.Dispose();
                }
            }
            return 0;
        }

        private void UpdateProgressBarUI(int value)
        {
            if (m_DownloadID != IntPtr.Zero)
            {
                if (DOWNLOAD_END == value)
                {
                    download_progressBar.Value = 100;
                    NETClient.StopDownload(m_DownloadID);
                    MessageBox.Show(this, "Download End(下载结束)!");
                    download_progressBar.Value = 0;
                    downloadstart_button.Enabled = true;
                    downloadstop_button.Enabled = false;
                    download_channel_comboBox.Enabled = true;
                    download_stream_comboBox.Enabled = true;
                    starttime_dateTimePicker.Enabled = true;
                    endtime_dateTimePicker.Enabled = true;
                    m_DownloadID = IntPtr.Zero;
                    SCtype_comboBox.Enabled = true;
                    SC_Button.Enabled = true;
                    SC_Button.Text = "TranscodeDownload(转码下载)";
                    return;
                }
                if (DOWNLOAD_FAILED == value)
                {
                    MessageBox.Show(this, "Download Failed(下载失败)!");
                    download_channel_comboBox.Enabled = true;
                    download_stream_comboBox.Enabled = true;
                    starttime_dateTimePicker.Enabled = true;
                    endtime_dateTimePicker.Enabled = true;
                    SCtype_comboBox.Enabled = true;
                    return;
                }
                download_progressBar.Value = value;
            }
        }
        #endregion

        private void login_button_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == m_LoginID)
            {
                ushort port = 0;
                try
                {
                    port = Convert.ToUInt16(port_textBox.Text.Trim());
                }
                catch
                {
                    MessageBox.Show("Input port error(输入端口错误)!");
                    return;
                }
                m_DeviceInfo = new NET_DEVICEINFO_Ex();
                m_LoginID = NETClient.LoginWithHighLevelSecurity(ip_textBox.Text.Trim(), port, name_textBox.Text.Trim(), pwd_textBox.Text.Trim(), EM_LOGIN_SPAC_CAP_TYPE.TCP, IntPtr.Zero, ref m_DeviceInfo);
                if (IntPtr.Zero == m_LoginID)
                {
                    MessageBox.Show(this, NETClient.GetLastError());
                    return;
                }
                LoginUI();
            }
            else
            {
                bool result = NETClient.Logout(m_LoginID);
                if (!result)
                {
                    MessageBox.Show(this, NETClient.GetLastError());
                    return;
                }
                m_LoginID = IntPtr.Zero;
                InitOrLogoutUI();
                m_Timer.Stop();
            }
        }

        private void play_button_Click(object sender, EventArgs e)
        {
            m_PlayBackID = IntPtr.Zero;
            DateTime startTime = new DateTime(play_dateTimePicker.Value.Year, play_dateTimePicker.Value.Month, play_dateTimePicker.Value.Day, 0, 0, 0);
            m_EndTime = startTime.AddDays(1).AddSeconds(-1);

            int fileCount = 0;
            NET_RECORDFILE_INFO[] recordFileArray = new NET_RECORDFILE_INFO[5000];
            bool ret = QueryFile(startTime, m_EndTime, ref recordFileArray, ref fileCount);
            if (false == ret)
            {
                MessageBox.Show(this, NETClient.GetLastError());
                return;
            }
            if (0 == fileCount)
            {
                MessageBox.Show(this, "None Record file(没有录像文件)!");
                return;
            }

            VideoTime[] videoTimeArray = new VideoTime[fileCount];
            for (int i = 0; i < fileCount; i++)
            {
                videoTimeArray[i] = new VideoTime();
                videoTimeArray[i].StartTime = recordFileArray[i].starttime.ToDateTime();
                videoTimeArray[i].EndTime = recordFileArray[i].endtime.ToDateTime();
            }
            playBackProgressBar.Init(startTime, videoTimeArray);
            if(m_EndTime > recordFileArray[fileCount - 1].endtime.ToDateTime())
            {
                m_EndTime = recordFileArray[fileCount - 1].endtime.ToDateTime();
            }
            if(!PlayBack(startTime, m_EndTime))
            {
                MessageBox.Show(this, NETClient.GetLastError());
                return;
            }
            PlayUI();
            m_Timer.Start();
        }

        private void stop_button_Click(object sender, EventArgs e)
        {
            m_Timer.Stop();
            NETClient.PlayBackControl(m_PlayBackID, PlayBackType.Stop);
            m_PlayBackID = IntPtr.Zero;
            StopPlayUI();
        }

        private void pause_button_Click(object sender, EventArgs e)
        {
            if (m_IsPause)
            {
                NETClient.PlayBackControl(m_PlayBackID, PlayBackType.Play);
                PauseOrPlayUI(true);
            }
            else
            {
                NETClient.PlayBackControl(m_PlayBackID, PlayBackType.Pause);
                PauseOrPlayUI(false);
            }
        }

        private void fast_button_Click(object sender, EventArgs e)
        {
            NETClient.PlayBackControl(m_PlayBackID, PlayBackType.Fast);
            FastUI();
        }

        private void slow_button_Click(object sender, EventArgs e)
        {
            NETClient.PlayBackControl(m_PlayBackID, PlayBackType.Slow);
            SlowUI();
        }

        private void normal_button_Click(object sender, EventArgs e)
        {
            NETClient.PlayBackControl(m_PlayBackID, PlayBackType.Normal);
            NormalUI();
        }

        private void downloadstart_button_Click(object sender, EventArgs e)
        {
            DateTime startTime = new DateTime(starttime_dateTimePicker.Value.Year, starttime_dateTimePicker.Value.Month, starttime_dateTimePicker.Value.Day, starttime_dateTimePicker.Value.Hour, starttime_dateTimePicker.Value.Minute, starttime_dateTimePicker.Value.Second);
            DateTime endTime = new DateTime(endtime_dateTimePicker.Value.Year, endtime_dateTimePicker.Value.Month, endtime_dateTimePicker.Value.Day, endtime_dateTimePicker.Value.Hour, endtime_dateTimePicker.Value.Minute, endtime_dateTimePicker.Value.Second);
            if (startTime == endTime)
            {
                MessageBox.Show(this,"The start time is the same ad the end time(开始时间与结束时间相同)!");
                return;
            }
            if (startTime > endTime)
            {
                MessageBox.Show(this,"The start time is greater than the end time(开始时间大于结束时间)!");
                return;
            }
            //set stream type 设置码流类型
            EM_STREAM_TYPE streamType = (EM_STREAM_TYPE)play_stream_comboBox.SelectedIndex + 1;
            IntPtr pStream = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(int)));
            Marshal.StructureToPtr((int)streamType, pStream, true);
            NETClient.SetDeviceMode(m_LoginID, EM_USEDEV_MODE.RECORD_STREAM_TYPE, pStream);
            
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "data";
            saveFileDialog.Filter = "|*.dav";
            string path = AppDomain.CurrentDomain.BaseDirectory + "savedata";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            saveFileDialog.InitialDirectory = path;
            var res = saveFileDialog.ShowDialog();
            if (res == System.Windows.Forms.DialogResult.OK)
            {
                
                m_DownloadID = NETClient.DownloadByTime(m_LoginID, download_channel_comboBox.SelectedIndex, EM_QUERY_RECORD_TYPE.ALL, startTime, endTime, saveFileDialog.FileName, m_DownloadPosCallBack, IntPtr.Zero, null, IntPtr.Zero, IntPtr.Zero);
                if (IntPtr.Zero == m_DownloadID)
                {
                    saveFileDialog.Dispose();
                    MessageBox.Show(this, NETClient.GetLastError());
                    return;
                }
                downloadstart_button.Enabled = false;
                downloadstop_button.Enabled = true;
                download_progressBar.Value = 0;
                download_channel_comboBox.Enabled = false;
                download_stream_comboBox.Enabled = false;
                starttime_dateTimePicker.Enabled = false;
                endtime_dateTimePicker.Enabled = false;
                SCtype_comboBox.Enabled = false;
                SC_Button.Enabled = false;
            }
            saveFileDialog.Dispose();
        }

        private void downloadstop_button_Click(object sender, EventArgs e)
        {
            bool ret = NETClient.StopDownload(m_DownloadID);
            if (!ret)
            {
                MessageBox.Show(this, NETClient.GetLastError());
                return;
            }
            m_DownloadID = IntPtr.Zero;
            download_progressBar.Value = 0;
            downloadstart_button.Enabled = true;
            downloadstop_button.Enabled = false;
            download_channel_comboBox.Enabled = true;
            download_stream_comboBox.Enabled = true;
            starttime_dateTimePicker.Enabled = true;
            endtime_dateTimePicker.Enabled = true;
            SCtype_comboBox.Enabled = true;
            SC_Button.Enabled = true;
        }

        private bool QueryFile(DateTime startTime, DateTime endTime, ref NET_RECORDFILE_INFO[] infos ,ref int fileCount)
        {
            //set stream type 设置码流类型
            EM_STREAM_TYPE streamType = (EM_STREAM_TYPE)play_stream_comboBox.SelectedIndex + 1;
            IntPtr pStream = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(int)));
            Marshal.StructureToPtr((int)streamType, pStream, true);
            NETClient.SetDeviceMode(m_LoginID, EM_USEDEV_MODE.RECORD_STREAM_TYPE, pStream);
            //query record file 查询录像文件
            bool ret = NETClient.QueryRecordFile(m_LoginID, channel_comboBox.SelectedIndex, EM_QUERY_RECORD_TYPE.ALL, startTime, m_EndTime, null, ref infos, ref fileCount, m_WaitTime, false);
            if (false == ret)
            {
                return false;
            }
            return true;
        }

        private bool PlayBack(DateTime startTime, DateTime endTime)
        {
            if (IntPtr.Zero != m_PlayBackID)
            {
                NETClient.PlayBackControl(m_PlayBackID, PlayBackType.Stop);
                this.BeginInvoke((Action)PictureBoxRefresh);
            }
            NET_IN_PLAY_BACK_BY_TIME_INFO stuInfo = new NET_IN_PLAY_BACK_BY_TIME_INFO();
            NET_OUT_PLAY_BACK_BY_TIME_INFO stuOut = new NET_OUT_PLAY_BACK_BY_TIME_INFO();
            stuInfo.stStartTime = NET_TIME.FromDateTime(startTime);
            stuInfo.stStopTime = NET_TIME.FromDateTime(endTime);
            stuInfo.hWnd = playback_pictureBox.Handle;
            stuInfo.cbDownLoadPos = null;
            stuInfo.dwPosUser = IntPtr.Zero;
            stuInfo.fDownLoadDataCallBack = null;
            stuInfo.dwDataUser = IntPtr.Zero;
            stuInfo.nPlayDirection = 0;
            stuInfo.nWaittime = m_WaitTime;

            m_PlayBackID = NETClient.PlayBackByTime(m_LoginID, channel_comboBox.SelectedIndex, stuInfo, ref stuOut);
            if (IntPtr.Zero == m_PlayBackID)
            {
                return false;
            }
            return true;
        }

        private void PictureBoxRefresh()
        {
            playback_pictureBox.Refresh();
        }

        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            NETClient.GetPlayBackOsdTime(m_PlayBackID, ref m_OsdTime, ref m_OsdStartTime, ref m_OsdEndTime);
            playBackProgressBar.SeekByTime((DateTime)m_OsdTime.ToDateTime());
        }

        private void playBackProgressBar_ProgressChanged(object sender, NetSDKCS.Control.ProgressEventargs args)
        {
            m_Timer.Stop();
            if (!PlayBack(args.Time, m_EndTime))
            {
                this.BeginInvoke((Action<string>)UpdateUI, NETClient.GetLastError());
                return;
            }
            PauseOrPlayUI(true);
            NormalUI();
            m_Timer.Start();
        }

        private void UpdateUI(string message)
        {
            MessageBox.Show(this, message);
        }

        private void port_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            NETClient.Cleanup();
        }

        private void SC_Button_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == m_DownloadID)
            {
                DateTime startTime = new DateTime(starttime_dateTimePicker.Value.Year, starttime_dateTimePicker.Value.Month, starttime_dateTimePicker.Value.Day, starttime_dateTimePicker.Value.Hour, starttime_dateTimePicker.Value.Minute, starttime_dateTimePicker.Value.Second);
                DateTime endTime = new DateTime(endtime_dateTimePicker.Value.Year, endtime_dateTimePicker.Value.Month, endtime_dateTimePicker.Value.Day, endtime_dateTimePicker.Value.Hour, endtime_dateTimePicker.Value.Minute, endtime_dateTimePicker.Value.Second);
                if (startTime == endTime)
                {
                    MessageBox.Show(this, "The start time is the same ad the end time(开始时间与结束时间相同)!");
                    return;
                }
                if (startTime > endTime)
                {
                    MessageBox.Show(this, "The start time is greater than the end time(开始时间大于结束时间)!");
                    return;
                }
                //set stream type 设置码流类型
                EM_STREAM_TYPE streamType = (EM_STREAM_TYPE)play_stream_comboBox.SelectedIndex + 1;
                IntPtr pStream = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(int)));
                Marshal.StructureToPtr((int)streamType, pStream, true);
                NETClient.SetDeviceMode(m_LoginID, EM_USEDEV_MODE.RECORD_STREAM_TYPE, pStream);

                m_StreamType = SCtype_comboBox.SelectedIndex;
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = "data";
                saveFileDialog.Filter = "|*.dav";

                switch (m_StreamType)
                {
                    case 0:
                        saveFileDialog.Filter = "|*.dav";
                        break;
                    case 1:
                        saveFileDialog.Filter = "|*.ps";
                        break;
                    case 2:
                        saveFileDialog.Filter = "|*.ts";
                        break;
                    case 3:
                        saveFileDialog.Filter = "|*.mp4";
                        break;
                    case 4:
                        saveFileDialog.Filter = "|*.dav";
                        break;
                    case 5:
                        saveFileDialog.Filter = "|*.flv";
                        break;
                    case 6:
                        saveFileDialog.Filter = "|*.ps";
                        break;
                    default:
                        saveFileDialog.Filter = "|*.dav";
                        break;
                }

                string path = AppDomain.CurrentDomain.BaseDirectory + "savedata";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                saveFileDialog.InitialDirectory = path;
                var res = saveFileDialog.ShowDialog();
                if (res == System.Windows.Forms.DialogResult.OK)
                {

                    //m_DownloadID = NETClient.DownloadByTime(m_LoginID, download_channel_comboBox.SelectedIndex, EM_QUERY_RECORD_TYPE.ALL, startTime, endTime, saveFileDialog.FileName, m_DownloadPosCallBack, IntPtr.Zero, null, IntPtr.Zero, IntPtr.Zero);
                    NET_IN_DOWNLOAD_BY_DATA_TYPE stuIn = new NET_IN_DOWNLOAD_BY_DATA_TYPE();
                    stuIn.dwSize = (uint)Marshal.SizeOf(typeof(NET_IN_DOWNLOAD_BY_DATA_TYPE));
                    stuIn.emDataType = (EM_REAL_DATA_TYPE)SCtype_comboBox.SelectedIndex;
                    stuIn.nChannelID = download_channel_comboBox.SelectedIndex;
                    stuIn.stStartTime = NET_TIME.FromDateTime(startTime);
                    stuIn.stStopTime = NET_TIME.FromDateTime(endTime);
                    stuIn.cbDownLoadPos = m_DownloadPosCallBack;
                    //stuIn.fDownLoadDataCallBack = m_DataCallBack;
                    stuIn.szSavedFileName = Marshal.StringToHGlobalAnsi(saveFileDialog.FileName);
                    m_FilePath = saveFileDialog.FileName;
                    NET_OUT_DOWNLOAD_BY_DATA_TYPE stuOut = new NET_OUT_DOWNLOAD_BY_DATA_TYPE()
                    {
                        dwSize = (uint)Marshal.SizeOf(typeof(NET_OUT_DOWNLOAD_BY_DATA_TYPE))
                    };

                    m_DownloadID = NETClient.DownloadByDataType(m_LoginID, stuIn, ref stuOut, 5000);
                    if (IntPtr.Zero == m_DownloadID)
                    {
                        saveFileDialog.Dispose();
                        MessageBox.Show(this, NETClient.GetLastError());
                        return;
                    }
                    downloadstart_button.Enabled = false;
                    downloadstop_button.Enabled = false;
                    download_progressBar.Value = 0;
                    download_channel_comboBox.Enabled = false;
                    download_stream_comboBox.Enabled = false;
                    starttime_dateTimePicker.Enabled = false;
                    endtime_dateTimePicker.Enabled = false;
                    SCtype_comboBox.Enabled = false;
                    SC_Button.Text = "StopDownload(停止转码下载)";
                }
                saveFileDialog.Dispose();
            }
            else
            {
                bool ret = NETClient.StopDownload(m_DownloadID);
                if (!ret)
                {
                    MessageBox.Show(this, NETClient.GetLastError());
                    return;
                }
                m_DownloadID = IntPtr.Zero;
                download_progressBar.Value = 0;
                downloadstart_button.Enabled = true;
                downloadstop_button.Enabled = false;
                download_channel_comboBox.Enabled = true;
                download_stream_comboBox.Enabled = true;
                starttime_dateTimePicker.Enabled = true;
                endtime_dateTimePicker.Enabled = true;
                SCtype_comboBox.Enabled = true;
                SC_Button.Text = "TranscodeDownload(转码下载)";
            }
        }
    }
}
