#ifndef LUCKYSUMS_H
#define LUCKYSUMS_H

#include "LuckyCriteria.h"

class LuckySums: public LuckyCriteria {
public:
    bool isLucky(Ticket &ticket) override;
};


#endif LUCKYSUMS_H
