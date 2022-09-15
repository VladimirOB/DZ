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

	char filename[40];
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

}
