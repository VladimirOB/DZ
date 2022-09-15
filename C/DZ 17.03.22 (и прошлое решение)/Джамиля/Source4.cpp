#include <iostream>

using namespace std;

void main()
{
	// Программа спрашивает у пользователя имя файла и пользователь мог указывать количество частей, на сколько разбит файл файлю 
	//При этом размер последней части может быть меньше, чем у других равных частей. Собираем части в один файл


	char rezult_filename[80];

	cout << "Enter rezult file name: ";
	cin >> rezult_filename;
	FILE* img = fopen(rezult_filename, "wb");

	int part = 0;
	cout << "Enter part:";
	cin >> part;
	int j = 0;
	for (size_t i = 0; i < part; i++)
	{

		char dest_filename1[80];
		cout << "Enter the name of the part of the file: ";
		cin >> dest_filename1;
		FILE* img1 = fopen(dest_filename1, "rb");

		if (img1 != NULL)
		{
			long file_size = 0;

			fseek(img1, 0, SEEK_END);
			file_size = ftell(img1);


			char* buffer = new char[file_size];

			if (buffer != NULL)
			{
				// переместиться в начало открытого файла
				fseek(img1, 0, SEEK_SET);

				// чтение всего файла в память
				fread(buffer, sizeof(char), file_size, img1);


				if (img != NULL)
				{

					fwrite(buffer, sizeof(char), file_size, img);

					fclose(img1);
					delete[] buffer;
				}
				else
					cout << "Could not open rezult file!" << endl;
			}
			else
				cout << "The source file is too big!!!" << endl;

		}
		else
			cout << "Could not open destination file!!!" << endl;
	}



	fclose(img);



}
