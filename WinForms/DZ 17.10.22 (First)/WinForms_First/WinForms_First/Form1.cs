namespace WinForms_First
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			//MessageBox.Show("Button1 click!!!", "Message");

			tbDestination.Text = tbSource.Text;
		}
	}
}