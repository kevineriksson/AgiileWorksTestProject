using System;
using CustomerService_Project.Models;
using CustomerService_Project.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CustomerService_Project.Tests.ServiceTests;
[TestClass]
public class TicketServiceTests
{
    [TestMethod]
    public void GetTickets_ReturnsSortedTickets()
    {
        var service = new TicketServices();
        service.CreateTicket(new Ticket { Id = 2, Description = "Ticket1", Deadline = DateTime.Now.AddDays(1) });
        service.CreateTicket(new Ticket { Id = 1, Description = "Ticket2", Deadline = DateTime.Now });

        var tickets = service.GetTickets();

        Assert.AreEqual(2, tickets.First().Id); 
    }
    [TestMethod]
    public void CreateTicket_SetsIdAutomatically()
    {
        var service = new TicketServices();
        service.CreateTicket(new Ticket { Description = "Ticket1", Deadline = DateTime.Now });
        service.CreateTicket(new Ticket { Description = "Ticket2", Deadline = DateTime.Now });

        var tickets = service.GetTickets();

        Assert.AreEqual(1, tickets[0].Id);
        Assert.AreEqual(2, tickets[1].Id);
    }
    [TestMethod]
    public void CreateTicket_SetsDescription()
    {
        var service = new TicketServices();
        service.CreateTicket(new Ticket { Description = "Ticket1", Deadline = DateTime.Now });

        var ticket = service.GetTickets().First();

        Assert.AreEqual("Ticket1", ticket.Description);
    }
    [TestMethod]
    public void CreateTicket_SetsDeadline()
    {
        var service = new TicketServices();
        var expectedDeadline = DateTime.Now.Date;

        service.CreateTicket(new Ticket { Description = "Ticket1", Deadline = expectedDeadline });
        var ticket = service.GetTickets().First();

        Assert.AreEqual(expectedDeadline, ticket.Deadline.Date);
    }
}

