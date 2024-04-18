using System;
using CustomerService_Project.Controllers;
using CustomerService_Project.Services;
using CustomerService_Project.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Microsoft.AspNetCore.Mvc;
using CustomerService_Project.Interfaces;

namespace CustomerService_Project.Tests.ControllerTests;
[TestClass]
public class TicketControllerTests
{
    private Mock<ITicketServices> _mockService;
    private TicketController _controller;

    [TestInitialize]
    public void Setup()
    {
        _mockService = new Mock<ITicketServices>();
        _controller = new TicketController(_mockService.Object);
    }

    [TestMethod]
    public void GetTickets_ReturnsTickets()
    {
        var tickets = new List<Ticket>() {
            new Ticket { Id = 1, Description = "Ticket1", Deadline = DateTime.Now.AddDays(1) },
            new Ticket { Id = 2, Description = "Ticket2", Deadline = DateTime.Now }
        };

        _mockService.Setup(s => s.GetTickets()).Returns(tickets);

        var result = _controller.Ticket() as ViewResult;

        Assert.IsNotNull(result);
        Assert.AreEqual(1, tickets.First().Id);
    }
    [TestMethod]
    public void AddTickets_ReturnsTickets()
    {
        var ticket = new Ticket { Id = 1, Description = "Ticket1", Deadline = DateTime.Now.AddDays(1) };

        _mockService.Setup(s => s.CreateTicket(ticket));

        var result = _controller.AddTicket(ticket);

        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        _mockService.Verify(s => s.CreateTicket(It.Is<Ticket>(t => t.Description == "Ticket1" && t.Deadline == ticket.Deadline)), Times.Once());
    }
    [TestMethod]
    public void ResolveTickets_ReturnsTickets()
    {
        int ticketId = 1;

        _mockService.Setup(s => s.ResolveTicket(ticketId));

        var result = _controller.ResolveTicket(ticketId);

        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        _mockService.Verify(s => s.ResolveTicket(ticketId), Times.Once());
    }
}

