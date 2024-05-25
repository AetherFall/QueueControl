namespace Shared.Models;

public class PrintDocument
{
    public int Id { get; set; }
    public string DocumentName { get; set; }
    public string DocumentPathReference { get; set; }
    public string DocumentSQLQuery { get; set; }
    public bool IsActive { get; set; }
    public int PrintTypeId { get; set; }
    public PrintType PrintType { get; set; }
}