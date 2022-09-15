#include "TicketException.h"

TicketException::TicketException(const char *message) {
    this->message = message;
}

const char *TicketException::what() const noexcept {
    return this->message.c_str();
}
