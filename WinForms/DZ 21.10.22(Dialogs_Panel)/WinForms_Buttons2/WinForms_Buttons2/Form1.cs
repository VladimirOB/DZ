namespace WinForms_Buttons2
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		Button[,] buttons = new Button[5, 3];

		private void button1_Click(object sender, EventArgs e)
		{
			int n = 1;
			for (int i = 0; i < buttons.GetLength(0); i++)
			{
				for (int k = 0; k < buttons.GetLength(1); k++)
				{
					buttons[i, k] = new Button();
					buttons[i, k].Parent = this;
					buttons[i, k].Location = new Point(i * 50 + 100, k * 50 + 100);
					buttons[i, k].Size = new Size(50, 50);
					buttons[i, k].BackColor = Color.FromArgb(200, 200 , 200);
					buttons[i, k].Text = n.ToString();
					n++;

					buttons[i, k].Click += Form1_Click;
					buttons[i, k].MouseEnter += Form1_MouseEnter;
					buttons[i, k].MouseLeave += Form1_MouseLeave;
				}
			}
		}

		private void Form1_MouseLeave(object? sender, EventArgs e)
		{
			if (sender != null && sender is Button)
			{
				Button button = (Button)sender;
				button.BackColor = Color.FromArgb(200, 200, 200);
			}
		}

		private void Form1_MouseEnter(object? sender, EventArgs e)
		{
			if (sender != null && sender is Button)
			{
				Button button = (Button)sender;
				button.BackColor = Color.LightSalmon;
			}
		}

		private void Form1_Click(object? sender, EventArgs e)
		{
			if(sender != null && sender is Button)
			{
				Button button = (Button)sender;
				button.BackColor = Color.Blue;
				button.ForeColor = Color.White;
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < buttons.GetLength(0); i++)
			{
				for (int k = 0; k < buttons.GetLength(1); k++)
				{
					this.Controls.Remove(buttons[i, k]);
				}
			}
		}
	}
}