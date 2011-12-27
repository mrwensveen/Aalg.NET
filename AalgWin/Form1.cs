using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aalg.NET;
using System.IO;

namespace AalgWin
{
	public partial class Form1 : Form
	{
		private readonly Generator generator;
		public Form1()
		{
			string[] args = Environment.GetCommandLineArgs();

			string filename = args.Length > 1 ? args[1] : "regels.dat";
			Stream regels = new FileInfo(filename).OpenRead();

			generator = new Generator(regels, "\r\n");


			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			this.Font = new Font(this.Font.FontFamily, 12f);
			button1.Text = RenderLyrics();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			textBox1.Clear();
			button1.Text = RenderLyrics();
		}

		private string RenderLyrics()
		{
			// Select and output a title
			string title = generator.GetRandomPhrasePart(1).ToUpper();
			WriteLine(textBox1, title + "\r\n");

			// Generate 2 strophes
			for (int i = 0; i < 2; i++)
			{
				WriteLine(textBox1, generator.GenerateStrophe());
			}

			// Exclamation!
			WriteLine(textBox1, String.Format("{0} !!\r\n", generator.GetRandomPhrasePart(1)));

			// A final strophe
			WriteLine(textBox1, generator.GenerateStrophe());

			// More exclamations!
			WriteLine(textBox1, String.Format("{0} !!", generator.GetRandomPhrasePart(1)));
			WriteLine(textBox1, String.Format("{0} !!!!\r\n", generator.GetRandomPhrasePart(1)));

			return title;
		}

		private void WriteLine(TextBox textBox, string line)
		{
			textBox.AppendText(line);
			textBox.AppendText("\r\n");
		}
	}
}
