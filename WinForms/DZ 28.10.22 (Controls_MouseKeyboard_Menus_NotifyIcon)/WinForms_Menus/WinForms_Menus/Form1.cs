using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinForms_Menus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void test1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("test");
        }

        private void test3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Создание строки меню
            MenuStrip menu1 = new MenuStrip();

            // Создание пункта меню
            menu1.Items.Add("File");

            // Создание подпункта меню "Exit"
            ((ToolStripMenuItem)menu1.Items[0]).DropDownItems.Add("Exit", null, new EventHandler(test3ToolStripMenuItem_Click));

            // Закрепить строку меню сверху
            menu1.Dock = DockStyle.Top;

            // Добавление строки меню в окно
            menu1.Parent = this;

            // указать добавленную строку меню как главное меню окна
            this.MainMenuStrip = menu1;

            // MessageBox.Show($"Children count: {this.Controls.Count}");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Добавление стандартного пункта меню
            Image img = Bitmap.FromFile("14.ico");
            ToolStripMenuItem item = new ToolStripMenuItem(textBox1.Text, img);
            item.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            this.MainMenuStrip.Items.Add(item);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Image img = Bitmap.FromFile("14.ico");
            ToolStripMenuItem item = new ToolStripMenuItem(textBox2.Text, img);
            item.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            this.MainMenuStrip.Items.Insert(Convert.ToInt32(textBox3.Text), item);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.MainMenuStrip.Items.RemoveAt(Convert.ToInt32(textBox4.Text));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ToolStripTextBox tb = new ToolStripTextBox();
            tb.Text = "hello";
            tb.BorderStyle = BorderStyle.FixedSingle;
            this.MainMenuStrip.Items.Add(tb);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Пункт меню выпадающий список
            ToolStripComboBox combo = new ToolStripComboBox();
            combo.Items.Add("Item1");
            combo.Items.Add("Item2");
            combo.Items.Add("Item3");
            combo.SelectedIndex = 0;

            // Обработчик выбора пункта меню
            combo.SelectedIndexChanged += Combo_SelectedIndexChanged;
            this.MainMenuStrip.Items.Add(combo);
        }

        // Обработчик выбора пункта меню
        private void Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show(((ToolStripComboBox)sender).SelectedItem.ToString());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ToolStripButton b1 = new ToolStripButton("Кнопка");
            b1.ToolTipText = "My button";
            this.MainMenuStrip.ShowItemToolTips = true;
            b1.Click += B1_Click;
            this.MainMenuStrip.Items.Add(b1);

        }

        private void B1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Кнопка нажата!!!");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ToolStripLabel l1 = new ToolStripLabel();
            l1.Text = "My label";
            this.MainMenuStrip.Items.Add(l1);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // Создание подпункта меню
            ToolStripMenuItem item = new ToolStripMenuItem(textBox6.Text);

            // Установить птичку программно
            item.Checked = true;

            // Разрешить пользователю менять птичку
            item.CheckOnClick = true;

            // Добавление подпункта в меню File
            ((ToolStripMenuItem)this.MainMenuStrip.Items[Convert.ToInt32(textBox5.Text)]).DropDownItems.Add(item);

            // Добавление подподпункта в меню File
            item.DropDownItems.Add(new ToolStripMenuItem("test"));
        }

        private void button10_Click(object sender, EventArgs e)
        {
            // Удаление всех пунктов меню, сама строка меню не удаляется
            this.MainMenuStrip.Items.Clear();
        }

        private void testingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("OK!!!!!!!!");
        }

        private void okToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("OK!!!!!!!!");
        }

        private void item2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Item2");
        }

        private void myMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("My menu!!!");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            // получить список строк меню
            List<MenuStrip> menus = new List<MenuStrip>();
            foreach (var item in this.Controls)
            {
                if (item is MenuStrip)
                    menus.Add((MenuStrip)item);
            }

            // удалить все строки меню
            while(menus.Count>0)
            {
                this.Controls.Remove(menus[0]);
                menus.RemoveAt(0);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.ContextMenuStrip = contextMenuStrip2;
        }

        private void oneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(((ToolStripMenuItem)sender).Text);
        }
    }
}
