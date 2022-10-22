namespace Photos.Shared;

public class PrintRequestPhoto
{
    public long Id { get; set; }
    public long PhotoId { get; set; }
    public Photo Photo { get; set; }
    public long PrintRequestId { get; set; }
    public PrintRequest PrintRequest { get; set; }
    public string Size { get; set; }
    public int Quantity { get; set; }
}
