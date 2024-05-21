namespace EstoCasa.Contracts;

public class ReqStorageItem
{
    public required string Name { get; set; }
    public required string Type { get; set; }
    public string? Mark { get; set; }
    public required string Unity { get; set; }
    public required float Quantity { get; set; }
    public DateTime? ExpireDate { get; set; }
}

