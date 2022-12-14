#include <iostream>

using namespace std;

void main()
{
    // запись в текстовый файл
	/*FILE* f = NULL;

	//fopen_s(&f, "c:\\temp\\test.txt", "w");
	f = fopen("c:\\temp\\test.txt", "w");
	
	if (f != NULL)
	{
		fputs("Hello\n", f);
		fputs("world", f);
		fclose(f);
	}

	// Пользователь вводит имя файла и строки, пока не введёт слово exit
	// Программа всё записывает в файл, кроме слова exit
    char b[100];
    FILE* p = NULL;
    cout << "input name of file ";
    char filename[100];
    cin >> filename;
    fopen_s(&p, filename, "w");
    if (p != NULL)
    {
        while (1) {
            cin >> b;
            if (strcmp(b, "exit") == 0) {
                fclose(p);
                break;
            }
            fputs(b, p);
            fputs("\n", p);
        }
    }*/

	// чтение из текстового файла

	/*char filename[40];
	cout << "Enter file name for reading: ";
	cin >> filename;

	FILE* f = NULL;

	//fopen_s(&f, filename, "r");
	f = fopen(filename, "r");

	// если файл удалось открыть
	if (f != NULL)
	{
		char str[100] = "";

		// пока не достигнут конец файла
		while (!feof(f))
		{
			// очистка старого содержимого строки
			strcpy(str, "");

			// чтение новой строки из файла
			fgets(str, 99, f);

			// удаление перехода на новую строку с конце считанной строки
			if (str[strlen(str) - 1] == 10)
				str[strlen(str) - 1] = 0;

			cout << str << endl;
		}

		// закрытие файла
		fclose(f);
	}

	// пользователь вводит имя файла, программа подсчитывает количество строк в файле и количество 
	// букв 'a' в файле
	*/

	// вывод строки средствами языка C
	//char str[] = "Hello world!!!";
	//puts(str);

	// вывод числа средствами языка С
	/*int n = 345;
	char s[40];
	_itoa(n, s, 10);
	puts(s);*/

	// форматированный вывод средствами языка С (%s - строка, %6.2f - число с плавающей запятой,
	// 6 символов - размер поля, 2 - число разрядов после запятой)
	// printf("My name is %s. I have %6.2f apples", "Alex", 23.67);

	// форматированный вывод в файл имён и возрастов
	/*FILE* f = NULL;

	fopen_s(&f, "c:\\temp\\test.txt", "w");

	if (f != NULL)
	{
		char name[40];
		int age = 0;

		while (true)
		{
			cout << "Enter your name: ";
			cin >> name;
			if (strcmp(name, "exit") == 0)
				break;

			cout << "Enter your age: ";
			cin >> age;

			fprintf(f, "Name: %s, Age: %d\n", name, age);
		}

		fclose(f);
	}*/
	
	// ввод и вывод строки средствами языка C
	/*char str[40];
	gets_s(str, 39);
	puts(str);*/

	// ввод числа средствами языка С
	/*char str[40];
	gets_s(str, 39);
	int num = atoi(str);
	printf("%d", ++num);*/

	// форматированный ввод строки не более 9 символов с игнорированием пробела в качестве разделителя
	/*char s[40];
	puts("Enter a string: ");
	int result = scanf("%9[^\n]s", s);
	puts(s);*/

	// форматированный ввод 2 чисел
	/*int a, b;
	puts("Enter 2 numbers: ");
	int result = scanf("%d %d", &a, &b);
	printf("a = %d, b = %d", a, b);*/

	// форматированный ввод из файла строки и 2 чисел
	/*char filename[40];
	cout << "Enter file name for reading: ";
	cin >> filename;

	FILE* f = NULL;

	//fopen_s(&f, filename, "r");
	f = fopen(filename, "r");

	// если файл удалось открыть
	if (f != NULL)
	{
		char name[100] = "";
		int age = 0;
		int height = 0;

		// пока не достигнут конец файла
		while (!feof(f))
		{
			int res = fscanf(f, "%s %d %d", name, &age, &height);
			printf("Name = %s, Age = %d, Height = %d\n", name, age, height);
		}

		// закрытие файла
		fclose(f);
	}*/

	// сохранение / загрузка массива чисел в бинарный файл
	/*const int array_size = 5;
	int a[array_size];

	for (size_t i = 0; i < array_size; i++)
	{
		cin >> a[i];
	}

	FILE* f = NULL;

	//fopen_s(&f, "c:\\temp\\test.txt", "wb");
	f = fopen("c:\\temp\\test.txt", "wb");

	if (f != NULL)
	{
		fwrite(a, sizeof(int), array_size, f);
		fclose(f);
	}

	int b[array_size] = {0};

	FILE* f2 = NULL;

	//fopen_s(&f2, filename, "rb");
	f2 = fopen("c:\\temp\\test.txt", "rb");

	// если файл удалось открыть
	if (f2 != NULL)
	{
		fread(b, sizeof(int), array_size, f2);

		for (size_t i = 0; i < array_size; i++)
		{
			cout << b[i] << " ";
		}
		cout << endl;

		// закрытие файла
		fclose(f2);
	}*/

	// пользователь вводит имена 2 файлов, программа копирует первый файл во второй
	FILE* f = NULL;

	char source_filename[80];
	cout << "Enter source file name: ";
	cin >> source_filename;

	char dest_filename[80];
	cout << "Enter destination file name: ";
	cin >> dest_filename;

	FILE* f2 = NULL;

	//fopen_s(&f2, source_filename, "rb");
	f2 = fopen(source_filename, "rb");

	// если файл удалось открыть
	if (f2 != NULL)
	{
		long file_size = 0;

		// переместиться в конец открытого файла
		fseek(f2, 0, SEEK_END);

		// получить номер байта, где находится файловый указатель (размер файла)
		file_size = ftell(f2);

		char* buffer = new char[file_size];

		if (buffer != NULL)
		{
			// переместиться в начало открытого файла
			fseek(f2, 0, SEEK_SET);

			// чтение всего файла в память
			fread(buffer, sizeof(char), file_size, f2);

			//fopen_s(&f, "c:\\temp\\test.txt", "wb");
			f = fopen(dest_filename, "wb");

			if (f != NULL)
			{
				// запись в файл из буфера
				fwrite(buffer, sizeof(char), file_size, f);
				fclose(f);
			}
			else
				cout << "Could not open destination file!!!" << endl;

			delete[] buffer;
		}
		else
			cout << "The source file is too big!!!" << endl;

		// закрытие файла
		fclose(f2);
	}
	else
		cout << "Can`t open source file!" << endl;

}
