using System;
using System.Diagnostics;
using System.IO;

namespace VideoToImage
{
	public static class VideoToImageService
	{
		private static string RootPath = System.AppDomain.CurrentDomain.BaseDirectory;
		public static void Cut(string videoPath, string savePath, int width, int height, int cutTimeFrame)
		{
			var cmd = String.Format("-i \"{0}\" -y -f image2 -ss {4}s  -t 0.001 -s {2}*{3} \"{1}\"", videoPath, savePath, width, height, cutTimeFrame);

			var exeFilePath = Path.Combine(RootPath, "ffmpeg.exe");

			ProcessStartInfo startInfo = new ProcessStartInfo();
			startInfo.WindowStyle = ProcessWindowStyle.Hidden;

			startInfo.Arguments = cmd;
			startInfo.UseShellExecute = false;
			startInfo.CreateNoWindow = true;
			startInfo.FileName = exeFilePath;
			startInfo.WindowStyle = ProcessWindowStyle.Hidden;

			using (Process proc = new Process())
			{
				proc.StartInfo = startInfo;
				proc.Start();
				proc.WaitForExit();//不等待完成就不调用此方法
				proc.Close();
			}
		}
	}
}