#include <iostream>
#include "Ticket.h"
#include "Ticket.h"
#include "LuckySums.h"
#include "LuckySequence.h"
#include "LuckyBackSequence.h"
#include <list>

bool luckySum(const unsigned *items) {
    unsigned sum = 0, sum1 = 0, count = Ticket::NUMBERS_COUNT;

    for (unsigned i = 0; i < count / 2; ++i) sum += items[i];
    for (unsigned i = count / 2; i < count; ++i) sum1 += items[i];

    return sum == sum1;
}

bool luckySequence(const unsigned *items) {
    for (int i = 0; i < Ticket::NUMBERS_COUNT - 1; ++i) {
        if (items[i] > items[i + 1]) return false;
    }
    return true;
}

/*
int main() {
    srand(time(nullptr));

    std::list<Ticket::luckyFunctions> functions;

    functions.push_back(luckySum);
    functions.push_back(luckySequence);

    std::list<Ticket *> tickets;

    for (int i = 0; i < 100; ++i) {
        auto *ticket = new Ticket();
        ticket->generateNumbers();

        if (ticket->isLucky(functions)) 
            tickets.push_back(ticket);

        else delete ticket;
    }

    FILE *dest;
    if (fopen_s(&dest, "C:\\Temp\\tickets_res.txt", "w") == 0) {
        auto iterator = tickets.begin();
        while (iterator != tickets.end()) {
            (**iterator).print();
            (**iterator).save(dest);
            ++iterator;
        }

        fclose(dest);
    }
    return 0;
}*/

// Полиморфизм
int main()
{
    srand(time(nullptr));

    std::list<Ticket*> tickets;
    std::list<LuckyCriteria*> criteriaList;

    criteriaList.push_back(new LuckySums);
    criteriaList.push_back(new LuckySequence);
    criteriaList.push_back(new LuckyBackSequence);

    for (int i = 0; i < 100; ++i) {
        Ticket*ticket = new Ticket();
        ticket->generateNumbers();

        if (ticket->isLucky(criteriaList)) 
            tickets.push_back(ticket);
        else delete ticket;
    }

    FILE *dest;
    if (fopen_s(&dest, "tickets_res.txt", "w") == 0) {
        auto iterator = tickets.begin();
        while (iterator != tickets.end()) {
            (*iterator)->print();
            (**iterator).save(dest);
            ++iterator;
        }

        fclose(dest);
    }
    
    return 0;
}