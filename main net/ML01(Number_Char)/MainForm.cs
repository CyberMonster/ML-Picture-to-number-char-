/*
 * Created by SharpDevelop.
 * User: Stig
 * Date: 03.01.2017
 * Time: 0:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace ML01_Number_Char_
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public List<Node> Nodes;
		public MainForm()
		{
			InitializeComponent();
			this.Nodes = new List<Node>();
		}
		void TextBox1KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == System.Windows.Forms.Keys.Enter && this.textBox1.Text.Length != 0 && !System.IO.File.Exists(this.textBox1.Text))
			{
				if (this.Nodes.Where(z => z.Mean == this.textBox1.Text.Last()).Count() != 0)
				{
					;
				}
				else
				{
					this.Nodes.Add(new Node(this.textBox1.Text.Last()));
				}
			}
		}
		void Button3Click(object sender, EventArgs e)
		{
			this.textBox2.Text = "";
			foreach (Node Node_ in this.Nodes)
			{
				this.textBox2.Text += Node_.Mean + " - " + Node_.Power.ToString() + "; ";
			}
		}
		void TextBox2DragDrop(object sender, DragEventArgs e)
		{
			string Path = "";
			e.Data.GetDataPresent(Path);
		}
		void Button1Click(object sender, EventArgs e)
		{
			if (System.IO.File.Exists(this.textBox1.Text))
			{
				this.pictureBox1.Load(this.textBox1.Text);
			}
		}
	}
	static class MLMP
	{
		static Node CheckAllNodes(List<Node> Nodes, System.Drawing.Bitmap InputPicture)
		{
			Node MostCorrect = null;
			foreach (Node Node_ in Nodes)
			{
				if (MostCorrect != null)
				{
					if (MostCorrect.Check_(InputPicture) < Node_.Check_(InputPicture))
					{
						MostCorrect = Node_;
					}
				}
				else
				{
					Node_.Check_(InputPicture);
				}
			}
			return MostCorrect;
		}
	}
}