#include <iostream>
#include <io.h>

using namespace std;

void scan_dir(const char* dir_path, const char* mask)
{
	char* new_path = new char[8000];
	char* mask_path = new char[8000];

	strcpy(mask_path, dir_path);
	strcat(mask_path, "\\");
	strcat(mask_path, mask);

	// переменная, хранящая информацию об одном файле
	_finddata_t c_file;

	// адрес списка найденных файлов
	long hFile;

	// найти файлы по маске и вернуть адрес списка найденных файлов и информацию о первом файле
	hFile = _findfirst(mask_path, &c_file);

	if (hFile == -1)
	{
		cout << "Error in finding files!!!" << endl;
	}
	else
	{
		if (strcmp(c_file.name, ".") != 0 && strcmp(c_file.name, "..") != 0)
		{
			// если файл является папкой
			if (c_file.attrib & _A_SUBDIR)
			{
				cout << c_file.name << "   " << "<DIR>" << endl;

				// сформировать путь к подпапке
				strcpy(new_path, dir_path);
				strcat(new_path, "\\");

				// добавить к полному пути имя текущей папки
				strcat(new_path, c_file.name);
				//cout << "Go to -> " << new_path << endl;

				// рекурсивный вызов функции
				scan_dir(new_path, mask);
			}
			else
				cout << dir_path << "\\" << c_file.name << "   " << c_file.size << endl;
		}

		// цикл для получения информации об остальных найденных файлах
		while (_findnext(hFile, &c_file) == 0)
		{
			if (strcmp(c_file.name, ".") != 0 && strcmp(c_file.name, "..") != 0)
			{
				if (c_file.attrib & _A_SUBDIR)
				{
					// сформировать путь к подпапке
					cout << c_file.name << "   " << "<DIR>" << endl;
					strcpy(new_path, dir_path);
					strcat(new_path, "\\");

					// добавить к полному пути имя текущей папки
					strcat(new_path, c_file.name);
					//cout << "Go to -> " << new_path << endl;

					// рекурсивный вызов функции
					scan_dir(new_path, mask);
				}
				else
					cout << dir_path << "\\" << c_file.name << "   " << c_file.size << endl;
			}
		}

		// освободить память от списка найденных файлов
		_findclose(hFile);

		delete[] new_path;
		delete[] mask_path;
	}	
}

void main()
{
	scan_dir("C:\\Students", "*.*");
}