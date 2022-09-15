#include "LuckyBackSequence.h"
#include "Ticket.h"

bool LuckyBackSequence::isLucky(Ticket& ticket) {
    if (LuckyCriteria::isLucky(ticket)) {
        for (int i = 0; i < Ticket::NUMBERS_COUNT - 1; ++i) {
            if (ticket[i] != ticket[i + 1] + 1) return false;
        }

        return true;

    }
    else return false;
}
