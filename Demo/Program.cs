using System;
using VideoToImage;

namespace Demo
{
	class Program
	{
		static void Main(string[] args)
		{
			VideoToImageService.Cut("D:\\1.wmv", "D:\\2.jpg", 480, 260, 35);
		}
	}
}
