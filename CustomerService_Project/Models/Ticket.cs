using System;
namespace CustomerService_Project.Models;
public class Ticket
{
	public int Id { get; set; }
    public string Description { get; set; }
    public DateTime SubmissionDate { get; set; }
    public DateTime Deadline { get; set; }
	private bool IsSolved { get; set; }
}

