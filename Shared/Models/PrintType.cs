namespace Shared.Models;

public class PrintType
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Printer> Printers { get; set; }
    public ICollection<PrintDocument> PrintDocuments { get; set; }
}