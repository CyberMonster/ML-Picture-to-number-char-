/*
 * Created by SharpDevelop.
 * User: Stig
 * Date: 02.01.2017
 * Time: 23:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ML01_Number_Char_
{
	/// <summary>
	/// Description of Node.
	/// </summary>
	public class Node
	{
		public Double Power;
		public System.Drawing.Bitmap Exp_;
		public string PathToExp_;
		public char Mean;
		public Node(char Mean, double Pow_ = 0.0, string XpPath = @"%username%\", System.Drawing.Bitmap Xp = null)
		{
			this.Mean = Mean;
		}
		public static void SaveExp_ (Node Val)
		{
			Val.Exp_.Save(Val.PathToExp_ + Val.Mean + @".bmp");
		}
		public double Check_(System.Drawing.Bitmap Input)
		{
			double retval = 0.0;
			int Height = System.Math.Min(Input.Height, this.Exp_.Height);
			int Width = System.Math.Min(Input.Width, this.Exp_.Width);
			for (var i = 0; i < Height; ++i)
			{
				for (var j = 0; j < Width; ++j)
				{
					if (((Input.GetPixel(i, j).GetBrightness() < 100) && (this.Exp_.GetPixel(i, j).GetBrightness() < 100)) || (Input.GetPixel(i, j).GetBrightness() == 100) && (this.Exp_.GetPixel(i, j).GetBrightness() == 100))
					{
						retval += (this.Exp_.GetPixel(i, j).GetBrightness() / 100);
					}
				}
			}
			return (retval / (System.Math.Min(Input.Height, this.Exp_.Height) * System.Math.Min(Input.Width, this.Exp_.Width)));
		}
	}
}