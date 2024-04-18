using System;
using CustomerService_Project.Interfaces;
using CustomerService_Project.Models;

namespace CustomerService_Project.Services;
public class TicketServices : ITicketServices
{
    List<Ticket> _tickets = new List<Ticket>();
	public int _newId = 1;

	public List<Ticket> GetTickets()
	{
		return _tickets.OrderBy(t => t.Deadline).ToList();
	}

    public void CreateTicket(Ticket ticket)
	{
		ticket.Id = _newId++;
		ticket.SubmissionDate = DateTime.Now;
		_tickets.Add(ticket);
	}

	public void ResolveTicket(int Id)
	{
		var ticket = _tickets.FirstOrDefault(o => o.Id == Id);
		if (ticket != null)
		{
			_tickets.Remove(ticket);
		}
	}
}

