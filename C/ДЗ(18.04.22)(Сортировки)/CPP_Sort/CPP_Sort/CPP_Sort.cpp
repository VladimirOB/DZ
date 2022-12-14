#include <iostream>
#include <time.h>

using namespace std;

const int ArraySize = 20;

/// <summary>
/// вывод массива на экран
/// </summary>
/// <param name="arr">массив для вывода на экран</param>
/// <param name="size">размер массива</param>
void PrintArray(int* arr, int size)
{
	for (size_t i = 0; i < size; i++)
	{
		cout << arr[i] << " ";
	}
	cout << endl;
}

/// <summary>
/// сортировка методом "пузырька"
/// </summary>
/// <param name="array"></param>
/// <param name="size"></param>
void BubbleSort(int* array, int size)
{
	// перебор всех элементов массива
	for (int i = 1; i < size; i++)
	{
		// проход массива от конца в начало со "всплыванием" одного элемента
		for (int j = size - 1; j >= i; j--)
		{
			if (array[j - 1] > array[j])
			{
				// перестановка элементов
				int temp = array[j - 1];
				array[j - 1] = array[j];
				array[j] = temp;
			}
		}

		cout << i << ". ";
		// вывести промежуточный результат
		PrintArray(array, ArraySize);
	}
}

/// <summary>
/// сортировка выбором
/// </summary>
/// <param name="arr">сортируемый массив</param>
/// <param name="size">размер массива</param>
void SelectionSort(int* arr, long size) 
{
	long i, j, k;
	int x;

	// i - номер текущего шага
	for (i = 0; i < size; i++) 
	{   	
		k = i; 
		x = arr[i];

		// цикл выбора наименьшего элемента
		for (j = i + 1; j < size; j++)
		{
			if (arr[j] < x)
			{
				// k - индекс наименьшего элемента
				k = j;
				x = arr[j];
			}
		}

		// поменять местами наименьший элемент с a[i]
		arr[k] = arr[i];
		arr[i] = x;

		// вывести промежуточный результат
		PrintArray(arr, ArraySize);
	}
}

/// <summary>
/// сортировка вставками
/// </summary>
/// <param name="array">сортируемый массив</param>
/// <param name="size">размер массива</param>
void InsertionSort(int* array, int size)
{
	int i, j, k, temp;

	// цикл по всем элементам массива
	for (i = 1; i < size; i++)
	{
		// текущий элемент, для которого подыскивается позиция
		temp = array[i];

		// поиск правильной позиции (j - искомый индекс - результат работы цикла)
		for (j = 0; j < i; j++)
			if (array[j] > temp) break;

		// если элемент стоит на своём месте - продолжить
		if (j == i) continue;

		// смещение элементов слева-направо
		for (k = i; k > j; k--)
			array[k] = array[k - 1];

		// поставить элемент в правильную позицию
		array[j] = temp;

		// вывести промежуточный результат
		PrintArray(array, ArraySize);
	}
}

/// <summary>
/// рекурсивная функция быстрой сортировки
/// </summary>
/// <param name="array">сортируемый массив</param>
/// <param name="start">индекс начала сортировки</param>
/// <param name="end">индекс конца сортировки</param>
void QSort(int* array, int start, int end)
{
	// в случае неправильных данных - выйти
	if (start >= end) return;
	int i = start, j = end;

	// выбрать середину массива
	int baseElementIndex = start + (end - start) / 2;

	// пока индекс левой части меньше индекса правой части
	while (i < j)
	{
		// значение пограничного элемента
		int value = array[baseElementIndex];

		// перемещать индекс левой части массива вперёд, пока не встретится слишком большой элемент
		while (i < baseElementIndex && (array[i] <= value)) i++;

		// перемещать индекс правой части массива назад, пока не встретится слишком маленький элемент
		while (j > baseElementIndex && (array[j] >= value)) j--;

		// i, j - индексы элементов, которые нужно поменять местами
		// если индесы правильные (есть смысл обмена элементов)
		if (i < j)
		{
			// обменять элемент с левой стороны на элемент с правой стороны
			int temp = array[i];
			array[i] = array[j];
			array[j] = temp;

			//PrintArray(array, ArraySize);

			// корректировка базового элемента
			if (i == baseElementIndex) baseElementIndex = j;
			else if (j == baseElementIndex) baseElementIndex = i;
		}
	}

	// рекурсивная сортировка левой и правой частей массива
	QSort(array, start, baseElementIndex);
	QSort(array, baseElementIndex + 1, end);
}


void QuickSort(int* arr, int size)
{
	QSort(arr, 0, size - 1);
}

int main()
{
	srand(time(0));
	
	int arr[ArraySize];

	for (size_t i = 0; i < ArraySize; i++)
	{
		arr[i] = rand() % 100 - 50;
	}

	PrintArray(arr, ArraySize);

	cout << endl;

	//BubbleSort(arr, ArraySize);

	SelectionSort(arr, ArraySize);
	
	//InsertionSort(arr, ArraySize);
	
	//QuickSort(arr, ArraySize);

	cout << endl;
	PrintArray(arr, ArraySize);

}
