using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_FileCommander
{
    public partial class Form1 : Form
    {
        private Bitmap bitmap;
        private ImageList imglist;

        public Form1()
        {
            InitializeComponent();

            try
            {
                // Настойка listView для показа файлов
                fileView.View = View.Details;
                fileView.SmallImageList = new ImageList();
                fileView.LargeImageList = new ImageList();

                fileView.LargeImageList.ImageSize = new Size(48, 48);
                fileView.LargeImageList.Images.Add(Bitmap.FromFile("note11.ico"));
                fileView.SmallImageList.Images.Add(Bitmap.FromFile("note11.ico"));

                fileView.Columns.Add("Имя файла", 120, HorizontalAlignment.Left);
                fileView.Columns.Add("Дата создания", 100, HorizontalAlignment.Center);
                fileView.Columns.Add("Размер", 60, HorizontalAlignment.Center);

                // Создание списка изображений 
                imglist = new ImageList();

                // Добавление иконок в список изображений
                imglist.Images.Add(Bitmap.FromFile("CLSDFOLD.ICO"));
                imglist.Images.Add(Bitmap.FromFile("OPENFOLD.ICO"));
                imglist.Images.Add(Bitmap.FromFile("NOTE11.ICO"));
                imglist.Images.Add(Bitmap.FromFile("NOTE12.ICO"));
                imglist.Images.Add(Bitmap.FromFile("Drive01.ico"));

                // Установка списка загруженных картинок для listView
                dirTree.ImageList = imglist;

                // Переменная для стандартного рисунка(черный квадрат), который будет
                // показываться тогда когда файл не является рисунком
                bitmap = (Bitmap)Bitmap.FromFile("nopicture.bmp");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при работе со списком изображений", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            // Настройка дерева папок
            // Метод для получения списка логических дисков
            string[] drives = Directory.GetLogicalDrives();

            // Перебор списка дисков
            foreach (string drive in drives)
            {
                // Создание конкретного узла и назначение иконок
                TreeNode node = new TreeNode(drive, 4, 4);
                // Добавили готовый узел к дереву	
                dirTree.Nodes.Add(node);

                // Заполнение узлов с дисками
                FillByDirectories(node);
            }
        }

        // Метод для заполнения узлов дерева содержимым каталога	
        private void FillByDirectories(TreeNode node)
        {
            try
            {
                // В node.FullPath - находится полный путь к ветке
                DirectoryInfo dirinfo = new DirectoryInfo(node.FullPath);

                // Получение информации о каталогах
                DirectoryInfo[] dirs = dirinfo.GetDirectories();

                // Обработка информации
                foreach (DirectoryInfo dir in dirs)
                {
                    TreeNode tree = new TreeNode(dir.Name, 0, 1);
                    node.Nodes.Add(tree);
                }

            }
            // Исключение будет генерироваться  например для дисковода, если там нет
            // диска	
            catch { }
        }

        /// <summary>
        /// Метод запускается ДО открытия узловой ветки дерева
        /// </summary>
        /// <param name="sender">Ссылка на дерево</param>
        /// <param name="e">Параметры метода</param>
        private void dirTree_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            // Запрет постоянной перерисовки дерева во время добавления элементов
            dirTree.BeginUpdate();

            // Добавление элементов в дерево
            try
            {
                // Перебор всех дочерних узлов для узла, который разворачивается по нажатию "+"
                foreach (TreeNode node in e.Node.Nodes)
                {
                    FillByDirectories(node);
                }
            }
            catch { }

            // возврат режима обычного обновления дерева (сразу вызывает перерисовку дерева)
            dirTree.EndUpdate();
        }

        private void dirTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                FillByFiles(e.Node.FullPath);
            }
            catch (Exception ex)
            { }
        }

        // заполнение listView файлами
        private void FillByFiles(string path)
        {
            fileView.BeginUpdate();

            fileView.Items.Clear();

            DirectoryInfo dirinfo = new DirectoryInfo(path);
            toolStripStatusLabel1.Text = path;

            // Получение информации о файлах
            FileInfo[] files = dirinfo.GetFiles();

            // Обработка информации
            fileView.LargeImageList.Images.Clear();
            fileView.SmallImageList.Images.Clear();
            int iconindex = 0;
            fileView.LargeImageList.Images.Add(Bitmap.FromFile("note11.ico"));
            fileView.SmallImageList.Images.Add(Bitmap.FromFile("note11.ico"));

            // Перебрать все файлы по определённому пути и показать из в listView
            foreach (FileInfo file in files)
            {
                ListViewItem item = new ListViewItem(file.Name);

                // Получить иконку для текущего файла
                Icon icon = Icon.ExtractAssociatedIcon(file.FullName);

                // Добавить эту иконку в список картинок
                fileView.LargeImageList.Images.Add(icon);
                fileView.SmallImageList.Images.Add(icon);
                iconindex++;

                // Указать номер иконки для listView
                item.ImageIndex = iconindex;

                // Добавить пукт в listView
                item.SubItems.Add(file.LastWriteTime.ToString());
                item.SubItems.Add(file.Length.ToString());
                fileView.Items.Add(item);
            }

            fileView.EndUpdate();
        }
    }
}
