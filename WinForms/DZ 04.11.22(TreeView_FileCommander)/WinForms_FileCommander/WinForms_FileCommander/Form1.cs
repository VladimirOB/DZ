using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
			FillByFiles(e.Node.FullPath);
		}

        // заполнение listView файлами
        private void FillByFiles(string path)
        {
            fileView.BeginUpdate();

            fileView.Items.Clear();

            DirectoryInfo dirinfo = new DirectoryInfo(path);
            toolStripStatusLabel1.Text = path;

            try
            {
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
			}
            catch(Exception ex)
            {

            }
            finally
            {
				fileView.EndUpdate();
			}
        }

        private void dirTree_MouseClick(object sender, MouseEventArgs e)
        {
            TreeNode node = dirTree.GetNodeAt(e.X, e.Y);
            if(node != null)
            {
                this.Text = node.Text;
            } 
        }

        private void dirTree_DragEnter(object sender, DragEventArgs e)
        {
			if ((e.AllowedEffect & DragDropEffects.Copy) != 0 && e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.Copy;
			}
		}

        private void dirTree_DragDrop(object sender, DragEventArgs e)
        {
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				// конвертирование экранных координат в координаты dirTree
				Point p = dirTree.PointToClient(new Point(e.X, e.Y));

                // получить узел, в который происходит вставка Drag-N-Drop
				TreeNode node = dirTree.GetNodeAt(p.X, p.Y);
				if (node != null)
				{
					// Если перетаскивается список файлов
					if (e.Data.GetDataPresent(DataFormats.FileDrop))
					{
						// Получить и напечатать список файлов
						string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop);

						foreach (var sourceFilePath in fileList)
						{
							File.Copy(sourceFilePath, $"{node.FullPath}\\{Path.GetFileName(sourceFilePath)}");
						}
					}

					FillByFiles(dirTree.SelectedNode.FullPath);
				}
			}
		}

        private void fileView_DragEnter(object sender, DragEventArgs e)
        {
			// Если пользователь копирует объект перетаскиванием и это список файлов и это не перетаскивание из listBox в него же
			if (e.Data.GetDataPresent(DataFormats.FileDrop) && (e.AllowedEffect & DragDropEffects.Copy) != 0 && !e.Data.GetDataPresent("Myappformat"))
			{
				// Разрешить копирование
				e.Effect = DragDropEffects.Copy;
			}
		}

        private void fileView_DragDrop(object sender, DragEventArgs e)
        {
			// Если перетаскивается список файлов
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				// Получить и напечатать список файлов
				string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop);
				
                if(dirTree.SelectedNode != null)
                {
                    foreach (var sourceFilePath in fileList)
                    {
                        File.Copy(sourceFilePath, $"{dirTree.SelectedNode.FullPath}\\{Path.GetFileName(sourceFilePath)}");
                    }
                }
			}

			FillByFiles(dirTree.SelectedNode.FullPath);
		}

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
			FillByFiles(dirTree.SelectedNode.FullPath);
		}

        private void fileView_MouseDown(object sender, MouseEventArgs e)
        {
			// Если есть выделенные строки
			if (fileView.SelectedItems.Count > 0 && dirTree.SelectedNode != null)
			{
				// Создать контейнер для хранения данных
				DataObject data1 = new DataObject();

				// Положить содержимое выделенной в списке строки
				StringCollection col = new StringCollection();

                foreach (ListViewItem item in fileView.SelectedItems)
                {
					col.Add($"{dirTree.SelectedNode.FullPath}\\{item.Text}");
				}
				
                data1.SetFileDropList(col);

				// Добавить признак пользовательского формата в контейнер
				data1.SetData("Myappformat", 0);

				// НАЧАТЬ перетаскивание программно
				DragDropEffects dde = DoDragDrop(data1, DragDropEffects.Copy);
			}
		}

        private void dirTree_DragOver(object sender, DragEventArgs e)
        {
			// конвертирование экранных координат в координаты dirTree
			Point p = dirTree.PointToClient(new Point(e.X, e.Y));

			// получить узел, в который происходит вставка Drag-N-Drop
			TreeNode node = dirTree.GetNodeAt(p.X, p.Y);

            if(node != null)
            {
                dirTree.SelectedNode = node;
            }
		}
    }
}
