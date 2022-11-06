using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinForms_TreeView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // загрузка картинок в дерево
            Bitmap img1 = new Bitmap("Image1.bmp");
            Bitmap img2 = new Bitmap("Image2.bmp");
            treeView1.ImageList = new ImageList();
            treeView1.ImageList.Images.Add(img1);
            treeView1.ImageList.Images.Add(img2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                treeView1.Nodes.Add("Легковые автомобили");
                int cnt = treeView1.Nodes.Count-1;
                // Конструктор TreeNode принимает Название, номер картинки для невыделенного состояния и для выделенного
                treeView1.Nodes[cnt].Nodes.Add(new TreeNode("Honda", 0, 1));
                treeView1.Nodes[1].Nodes[0].Nodes.Add(new TreeNode("Accord", 0, 1));
                treeView1.Nodes[1].Nodes[0].Nodes.Add(new TreeNode("Civic", 0, 1));
                treeView1.Nodes[1].Nodes[0].Nodes.Add(new TreeNode("Acura", 0, 1));
                treeView1.Nodes[1].Nodes.Add(new TreeNode("Opel", 0, 1));
                treeView1.Nodes[1].Nodes[1].Nodes.Add(new TreeNode("Cadet", 0, 1));
                treeView1.Nodes[1].Nodes[1].Nodes.Add(new TreeNode("Omega", 0, 1));
                treeView1.Nodes[1].Nodes[1].Nodes.Add(new TreeNode("Corsa", 0, 1));
                treeView1.Nodes[1].Nodes.Add(new TreeNode("BMW", 0, 1));
                treeView1.Nodes[1].Nodes[2].Nodes.Add(new TreeNode("Z8", 0, 1));
                treeView1.Nodes[1].Nodes[2].Nodes.Add(new TreeNode("M5", 0, 1));
                treeView1.Nodes[1].Nodes[2].Nodes.Add(new TreeNode("X5", 0, 1));

                treeView1.Nodes.Add("Грузовые автомобили");
                treeView1.Nodes[2].Nodes.Add(new TreeNode("КамАЗ", 0, 1));
                treeView1.Nodes[2].Nodes.Add(new TreeNode("ЗИЛ", 0, 1));
                treeView1.Nodes[2].Nodes.Add(new TreeNode("БелАЗ", 0, 1));
                treeView1.Nodes[2].Nodes.Add(new TreeNode("Mercedes", 0, 1));
            }
            catch
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Если выделен какой-либо узел
            if (treeView1.SelectedNode != null)
            {
                // Создать новый узел
                TreeNode node = new TreeNode(textBox1.Text, 0, 1);
                node.ToolTipText = "Новый узел";

                // Добавить дочерний узел к выделенному элементу
                treeView1.SelectedNode.Nodes.Add(node);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Если есть выделенный элемент и у него есть родительский элемент
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Parent != null)
            {
                // Создать новый узел
                TreeNode node = new TreeNode(textBox1.Text);

                // Получить индекс выделенного элемента
                int index = treeView1.SelectedNode.Index;

                // Вставить новый узел перед выделенным элементом
                treeView1.SelectedNode.Parent.Nodes.Insert(index, node);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Если есть выделенный элемент
            if (treeView1.SelectedNode != null)
            {
                treeView1.SelectedNode.Remove();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // развернуть все ветки дерева
            treeView1.ExpandAll();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // свернуть все ветки дерева
            treeView1.CollapseAll();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // подключение компаратора
            treeView1.TreeViewNodeSorter = new Sorter();

            // произвести сортировку дерева
            treeView1.Sort();
        }

        /// <summary>
        /// Вызывается после выделения узла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Обновить разделитель в строке полного пути к узлу
            treeView1.PathSeparator = textBox2.Text;

            // Отобразить полный путь к выделенному узлу
            label1.Text = treeView1.SelectedNode.FullPath;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // удалить все узлы дерева
            treeView1.Nodes.Clear();
            label1.Text = "";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            treeView1.CheckBoxes = checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            treeView1.LabelEdit = checkBox2.Checked;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            treeView1.ShowLines = checkBox3.Checked;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            treeView1.ShowPlusMinus = checkBox4.Checked;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            treeView1.ShowNodeToolTips = checkBox5.Checked;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Запускается ДО разворачивания узла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            //MessageBox.Show("Before expand");
        }

        private void treeView1_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            //e.CancelEdit = true;
        }
    }

    /// <summary>
    /// Сортирующий узлы дерева класс
    /// </summary>
    public class Sorter : IComparer
    {
        public int Compare(object obj1, object obj2)
        {
            string str = ((TreeNode)obj1).Text;
            string str2 = ((TreeNode)obj2).Text;
            return str.Length - str2.Length;
        }
    }
}