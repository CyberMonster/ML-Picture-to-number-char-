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
            this.textBox4.Text = System.Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + System.IO.Path.DirectorySeparatorChar + @"ML_DataSet" + System.IO.Path.DirectorySeparatorChar + @"CharFromPicture";
            if (System.IO.Directory.Exists(this.textBox4.Text))
            {
                List<string> ExistedDefaultNamedFolders = new List<string>();
                bool IsDefNameEqual;
                foreach (string Path in System.IO.Directory.GetDirectories(this.textBox4.Text).Select(z => System.IO.Path.GetFileName(z)).ToArray())
                {
                    IsDefNameEqual = true;
                    if (Path.Length < MainForm.DefaultsFolderName.Length)
                    {
                        IsDefNameEqual = false;
                    }
                    else
                    {
                        int Counter;
                        for (Counter = 0; Counter < MainForm.DefaultsFolderName.Length; ++Counter)
                        {
                            if (Path[Counter] != MainForm.DefaultsFolderName[Counter])
                            {
                                IsDefNameEqual = false;
                                break;
                            }
                        }
                        if (!IsDefNameEqual)
                        {
                            continue;
                        }
                        ExistedDefaultNamedFolders.Add(Path.Substring(Counter));
                    }
                }
                int ParseResult;
                this.textBox4.Text += System.IO.Path.DirectorySeparatorChar + MainForm.DefaultsFolderName + ((ExistedDefaultNamedFolders.Count != 0) ? (ExistedDefaultNamedFolders.Select(z => int.TryParse(z, out ParseResult) ? ParseResult : -1).Max() + 1).ToString() : "0");
            }
            else
            {
                this.textBox4.Text += System.IO.Path.DirectorySeparatorChar + MainForm.DefaultsFolderName + "0";
            }

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
            if (this.comboBox1.SelectedItem == null && this.comboBox1.Text.Count() == 3)
            {
                AddToComboBoxFromThatText(ref this.comboBox1);
            }
            if (this.textBox4.Text.Length != 0 && this.textBox1.Text.Length != 0 && this.textBox2.Text.Length != 0 && (this.comboBox1.SelectedItem != null))
			{
				for (char Ch = ((string)this.comboBox1.SelectedItem)[0]; Ch <= ((string)this.comboBox1.SelectedItem)[2]; ++Ch)
				{
					this.textBox3.Text = Ch + "";
					this.OutTest();
                    if (!System.IO.File.Exists(this.textBox4.Text))
                    {
                        System.IO.Directory.CreateDirectory(this.textBox4.Text);
                    }
					this.pictureBox1.Image.Save(this.textBox4.Text + System.IO.Path.DirectorySeparatorChar + char.ConvertToUtf32(Ch + "", 0).ToString() + " " + this.fontDialog1.Font.Name + " " + this.fontDialog1.Font.Size.ToString() + @".bmp");
				}
			}
		}

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddToComboBoxFromThatText(ref this.comboBox1);
            }
        }
        private void AddToComboBoxFromThatText(ref System.Windows.Forms.ComboBox ComboBox_)
        {
            ComboBox_.Items.Add(ComboBox_.Text);
            ComboBox_.SelectedItem = (object)ComboBox_.Items[ComboBox_.Items.Count - 1];
        }

        private const string DefaultsFolderName = @"DataSet_";
    }
}
