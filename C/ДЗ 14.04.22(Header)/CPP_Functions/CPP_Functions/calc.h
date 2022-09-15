#pragma once

enum Operations {
	Plus, Minus, Production, Division, Mod
};

enum States {
	WaitForFirstNumber,		// автомат ожидает первое число
	FirstNumber,			// автомат движется по первому числу
	WaitForOperator,		// автомат ожидает оператор
	WaitForNextNumber,		// автомат ожидает второе число
	NextNumber,				// автомат движется по второму числу
	ErrorState, 			// состояние ошибки парсинга
	FinalState  			// состояние окончания парсинга
};

int calc(char* str);