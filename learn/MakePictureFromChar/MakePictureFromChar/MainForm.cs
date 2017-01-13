/*
 * Created by SharpDevelop.
 * User: Stig
 * Date: 04.01.2017
 * Time: 11:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace MakePictureFromChar
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}
		void TextBox1Click(object sender, EventArgs e)
		{
			this.fontDialog1.ShowDialog();
			this.textBox1.Text = this.fontDialog1.Font.Name.ToString();
			this.textBox2.Text = this.fontDialog1.Font.Size.ToString();
			this.OutTest();
		}
		void TextBox4Click(object sender, EventArgs e)
		{
			this.folderBrowserDialog1.ShowDialog();
			this.textBox4.Text = this.folderBrowserDialog1.SelectedPath;
		}
		void OutTest()
		{
			System.Drawing.Bitmap TestPicture = new System.Drawing.Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
			System.Drawing.Graphics Graphic = System.Drawing.Graphics.FromImage(TestPicture);
			if (this.textBox3.Text.Length != 0)
			{
				Graphic.DrawString(this.textBox3.Text.Last() + "", this.fontDialog1.Font, System.Drawing.Brushes.Black, new Rectangle(0, 0, 100, 100));
			}
			this.pictureBox1.Image = TestPicture;
		}
		void TextBox2Click(object sender, EventArgs e)
		{
			this.OutTest();
		}
		void TextBox3TextChanged(object sender, EventArgs e)
		{
			this.OutTest();
		}
		void Button1Click(object sender, EventArgs e)
		{
			if (this.textBox4.Text.Length != 0 && this.textBox1.Text.Length != 0 && this.textBox2.Text.Length != 0)
			{
				for (char Ch = ((string)this.comboBox1.SelectedItem)[0]; Ch <= ((string)this.comboBox1.SelectedItem)[2]; ++Ch)
				{
					this.textBox3.Text = Ch + "";
					this.OutTest();
					this.pictureBox1.Image.Save(this.textBox4.Text + @"\" + Ch + @".bmp");
				}
			}
		}
	}
}
