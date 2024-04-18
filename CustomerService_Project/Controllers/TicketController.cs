using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CustomerService_Project.Services;
using CustomerService_Project.Models;
using CustomerService_Project.Interfaces;

namespace CustomerService_Project.Controllers;
public class TicketController : Controller
{
    private readonly ITicketServices _ticketServices;

    public TicketController(ITicketServices ticketServices)
    {
        _ticketServices = ticketServices;
    }

    // GET: Ticket
    [HttpGet]
    public IActionResult Ticket()
    {
        var tickets = _ticketServices.GetTickets();
        if (tickets.Count == 0)
        {
            tickets = new List<Ticket>();
        }
        return View(tickets);
    }


    //POST: Ticket
    [HttpPost]
    public IActionResult AddTicket(Ticket ticket)
    {
        if (ModelState.IsValid)
        {
            _ticketServices.CreateTicket(ticket);
            return RedirectToAction("Ticket");
        }
        return View(ticket);
    }

    //DELETE: Ticket
    [HttpPost]
    public IActionResult ResolveTicket(int Id)
    {
        _ticketServices.ResolveTicket(Id);
        return RedirectToAction("Ticket");
    }
}