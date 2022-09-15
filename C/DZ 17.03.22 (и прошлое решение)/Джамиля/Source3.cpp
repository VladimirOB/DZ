#include <iostream>

using namespace std;

void main()
{
	// Программа спрашивает у пользователя имя файла и пользователь мог указывать количество частей, на сколько разделить файлю 
	//При этом размер последней части может быть меньше, чем у других равных частей. Разбираем на части.


	FILE* img = NULL;
	char source_filename[80];
	cout << "Enter source file name: ";
	cin >> source_filename;

	int part = 0;
	cout << "Enter part:";
	cin >> part;

	img = fopen(source_filename, "rb");
	int cnt = 1;//счетчик частей
	if (img != NULL)
	{

		long file_size = 0;
		// переместиться в конец открытого файла
		fseek(img, 0, SEEK_END);
		// получить номер байта, где находится файловый указатель (размер файла)
		file_size = ftell(img);

		int file_size_part = 0;//размер одиннаковых по размеру файлов
		int file_size_part_end = 0;//размер последнего файла

		file_size_part = file_size / part;
		if (file_size % part != 0)
		{
			file_size_part = file_size_part + 1;
			file_size_part_end = file_size - (file_size_part * (part - 1));
		}
		else
			file_size_part_end = file_size_part;
		int size = 0;//текущий размер буффера
		cout << "file_size= " << file_size << endl;
		cout << "file_size_part= " << file_size_part << endl;
		cout << "file_size_part_end= " << file_size_part_end << endl;

		char* buffer = new char[file_size];
		if (buffer != NULL)
		{
			fseek(img, 0, SEEK_SET);
			fread(buffer, sizeof(char), file_size, img);



			while (cnt < part)

			{

				FILE* img1 = NULL;
				char dest_filename1[80];
				cout << "Enter the name of the part of the file: ";
				cin >> dest_filename1;
				img1 = fopen(dest_filename1, "wb");


				if (img1 != NULL)
				{
					fseek(img, size, SEEK_SET);
					fread(buffer, sizeof(char), file_size, img);
					fwrite(buffer, sizeof(char), file_size_part, img1);

					fclose(img1);
					size = file_size_part + size;



				}
				else
					cout << "Could not open destination file!!!" << endl;
				cnt++;
			}

			FILE* img1 = NULL;
			char dest_filename1[80];
			cout << "Enter the name of the part of the file: ";
			cin >> dest_filename1;
			img1 = fopen(dest_filename1, "wb");
			if (img1 != NULL)
			{

				fseek(img, size, SEEK_SET);
				fread(buffer, sizeof(char), file_size, img);
				// запись в файл из буфера
				fwrite(buffer, sizeof(char), file_size_part_end, img1);

				fclose(img1);
			}
			else
				cout << "Could not open destination file!!!" << endl;
			delete[] buffer;


		}
		else
			cout << "The source file is too big!!!" << endl;
		fclose(img);
	}
	else
		cout << "Can`t open source file!" << endl;


}



