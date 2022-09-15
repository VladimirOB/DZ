#include <iostream>
#include <fstream>

using namespace std;

void main()
{
	// работа с текстовыми файлами
	fstream file1("test.txt", ios::out);
	file1 << "Hello big beautiful" << endl;
	file1 << "world" << " !!!";
	file1.close();

	char buffer[200];
	file1.open("test.txt", ios::in);

	// если нет ошибок открытия файла
	if (!file1.fail())
	{
		// пока не достигнут конец файла
		while (!file1.eof())
		{
			// чтение файла построчно
			file1.getline(buffer, 200);

			// чтение файла по словам
			// file1 >> buffer;
			
			cout << buffer << endl;
		}

		file1.close();
	}
	else cout << "Error opening file!" << endl;
	

	
	// работа с бинарными файлами
	const size_t SIZE = 10;
	int numbers[] = {19, 8, 7, 6, 5, 4, 3, 2, 1, 0};

	fstream file1("test.dat", ios::out | ios::binary);
	file1.write((char*)numbers, sizeof(int) * SIZE);
	file1.close();

	int numbers2[10] = { 0 };
	file1.open("test.dat", ios::in | ios::binary);

	// если нет ошибок открытия файла
	if (!file1.fail())
	{
		file1.read((char*)numbers2, sizeof(int) * SIZE);

		for (size_t i = 0; i < SIZE; i++)
		{
			cout << numbers2[i] << " ";
		}
		cout << endl;

		file1.close();
	}
	else cout << "Error opening file!" << endl;
	

	fstream file1("c:\\temp\\admin.gif", ios::in | ios::binary);

	// если нет ошибок открытия файла
	if (!file1.fail())
	{
		// переместиться в конец файла
		file1.seekg(0, ios::end);
		
		// получить номер байта в конце (размер файла)
		long size = file1.tellg();

		cout << "file size: " << size << endl;

		// переместиться в начало файла
		file1.seekg(0, ios::beg);

		// выделить память под файл
		char* buffer = new char[size];

		if (buffer == nullptr)
		{
			cout << "There is not enough memory!" << endl;
		}
		else
		{
			// чтение файла в память
			file1.read(buffer, size);

			fstream file2("c:\\temp\\admin2.gif", ios::out | ios::binary);

			// если нет ошибок открытия файла
			if (!file2.fail())
			{
				// запись из буфера в файл
				file2.write(buffer, size);

				// закрыть результирующий файл
				file2.close();

				cout << "File was successfully copied!" << endl;
			} else cout << "Error opening result file!" << endl;
		}

		// закрыть исходный файл
		file1.close();
	}
	else cout << "Error opening file!" << endl;
}