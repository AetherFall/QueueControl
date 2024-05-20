namespace Shared.Models;

public class Printer
{
    public int Id { get; set; }
    public string PrinterName { get; set; }
    public bool IsPrinterTCP { get; set; }
    public string IPv4 { get; set; }
    public int Port { get; set; }
    public string PortSerial { get; set; }
    public string Driver { get; set; }
    public int PrintTypeId { get; set; }
    public PrintType PrintType { get; set; }
}