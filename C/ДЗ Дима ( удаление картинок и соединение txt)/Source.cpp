#include <iostream>
#include <cstdlib>
#include <string>
#include <conio.h>
#include <stdio.h>
#include <io.h>
#include <windows.h>
using namespace std;
//Подсчёт общего размера файлов в папке
//void main()
//{
//	_finddata_t c_file;
//	long sum = 0;
//	int cnt = 0;
//	double hFile;
//	hFile = _findfirst("C:\\yes\\*.txt*", &c_file);
//	if (c_file.attrib & _A_SUBDIR)
//	{
//		cout << c_file.name << "   " << "<DIR>" << endl;		
//	}
//
//	else
//	{
//		cout << c_file.name << "   " << c_file.size << endl;
//		sum += c_file.size;
//		cnt++;
//	}
//
//	while (_findnext(hFile, &c_file) == 0)
//	{
//		if (c_file.attrib & _A_SUBDIR)
//			cout << c_file.name << "   " << "<DIR>" << endl;
//		else
//		{
//			cout << c_file.name << "   " << c_file.size << endl;
//			sum += c_file.size;
//			cnt++;
//		}
//
//		
//	}
//	_findclose(hFile);
//	cout << endl << sum << endl << cnt;
//}
// Объединение всех текстовых файлов в один
void main()
{
	_finddata_t c_file;
	int filesize;
	char folder[100];
	char curfile[40];
	double hFile;	
	char path[40];//Ввод пути
	char mask[40];//Ввод маски
	cin >> path;
	FILE* FOUT = NULL;
	FILE* FIN = NULL;
	cin >> mask;
    sprintf_s(folder, "%s\\%s", path, mask);
	hFile = _findfirst(folder, &c_file);
	sprintf_s(curfile, "%s\\%s", path, c_file.name);
	fopen_s(&FOUT, curfile, "rb");
	if (FOUT!=NULL)
	{
		fseek(FOUT, 0, SEEK_END);
		filesize = ftell(FOUT);		
		fseek(FOUT, 0, SEEK_SET);
		char* buffer = new char[filesize];
		fread(buffer, sizeof(char), filesize, FOUT);		
		FIN = fopen("test.txt", "wb");
		fwrite(buffer, sizeof(char), filesize, FIN);
	}	
	while (_findnext(hFile, &c_file) == 0)
	{
		sprintf_s(curfile, "%s\\%s", path, c_file.name);
		fopen_s(&FOUT, curfile, "rb");
		if (FOUT != NULL)
		{
			fseek(FOUT, 0, SEEK_END);
			filesize = ftell(FOUT);
			fseek(FOUT, 0, SEEK_SET);
			char* buffer = new char[filesize];
			if (FIN!=NULL)
			{
				fread(buffer, sizeof(char), filesize, FOUT);
				fwrite(buffer, sizeof(char), filesize, FIN);
			}
			else
			{
				cout << "ERROR";
				exit(-1);
			}						
		}
	}
	fclose(FIN);
	fclose(FOUT);
 _findclose(hFile);
}
//Удаление изображений
//void main()
//{
//	_finddata_t c_file;
//	char folder[100];
//	char curfile[40];
//	double hFile;	
//	char path[40];
//	char mask[40];
//	cin >> path;//Ввод пути
//	cin >> mask;//Ввод маски
//	sprintf_s(folder, "%s\\%s", path, mask);
//	hFile = _findfirst(folder, &c_file);
//	sprintf_s(curfile, "%s\\%s", path, c_file.name);
//	remove(curfile);
//	while (_findnext(hFile, &c_file) == 0)
//	{
//		sprintf_s(curfile, "%s\\%s", path, c_file.name);
//		remove(curfile);
//	}
//	cout << "CLEAN DONE!";
// _findclose(hFile);
//}


