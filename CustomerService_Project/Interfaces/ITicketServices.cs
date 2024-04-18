using System;
using CustomerService_Project.Models;

namespace CustomerService_Project.Interfaces;
public interface ITicketServices
{
    List<Ticket> GetTickets();

    public void CreateTicket(Ticket ticket);

    public void ResolveTicket(int id);
}

