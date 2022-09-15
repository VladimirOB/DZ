#ifndef TICKETEXCEPTION_H
#define TICKETEXCEPTION_H

#include <string>


class TicketException: std::exception {
private:
    std::string message;
public:
    explicit TicketException(const char* message);
    const char * what() const noexcept override;
};


#endif TICKETEXCEPTION_H
