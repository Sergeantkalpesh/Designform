[Introduction]
The demo program introduces SDK initialization,login, logout, playing back record by time (one day), downloading record by time, and functions such as fast play, slow play, pause, and stop. 
The demo program demonstrates selecting channel and stream type before playing back and downloading record.
For the display control with one day record in the demo program, we don’t provide technical support. 

[Interfaces]
NETClient.Init Initialize SDK and set disconnection callback
NETClient.SetAutoReconnect Set auto reconnection callback
NETClient.LoginWithHighLevelSecurity Login
NETClient.Logout Logout
NETClient.PlayBackControl playback control, play, pause, stop, fast play, slow play, and normal play.
NETClient.QueryRecordFile Query record file 
NETClient.PlayBackByTime Playback record
NETClient.GetPlayBackOsdTime  Get the current time of playing record
NETClient.DownloadByTime Download record by time
NETClient.Cleanup Release SDK resources

[Notice]
When the compiling environment is VS2010, NETSDKCS library can support the version of .NET Framework 4.0 or newer. If you want to use the version older than .NET Framework 4.0, change the method of using NetSDK.cs in IntPtr.Add. We will not support the modification.
The demo program does not support the playback over one day. If you need the playback of multiple days, develop the corresponding display control by yourself.
The demo program supports the playback and downloading record of single channel only.
The demo program does not support multiple devices login.
Copy all file in the libs directory of General_NetSDK_ChnEng_CSharpXX_IS_VX.XXX.XXXXXXXX.X.R.XXXXXX to the build directory of bin directory of the corresponding demo programs.


