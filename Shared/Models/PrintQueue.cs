namespace Shared.Models;

public class PrintQueue
{
    public int Id { get; set; }
    public int DocumentId { get; set; }
    public PrintDocument Document { get; set; }
    public string DocumentParameters { get; set; }
    public int PrinterId { get; set; }
    public Printer Printer { get; set; }
    public int NumberOfCopy { get; set; }
}