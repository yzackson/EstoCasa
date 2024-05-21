using Amazon.DynamoDBv2.DataModel;
using EstoCasa.Sources;

namespace EstoCasa.Models;

[DynamoDBTable("estocasa_storage")]
public class StorageItem
{
    [DynamoDBHashKey("id")]
    public required long Id { get; set; }
    [DynamoDBProperty("name")]
    public required string Name { get; set; }
    [DynamoDBProperty("type")]
    public required string Type { get; set; }
    [DynamoDBProperty("mark")]
    public string? Mark { get; set; }
    
    [DynamoDBProperty("unity")]
    public required string Unity { get; set; }
    [DynamoDBProperty("quantity")]
    public required float Quantity { get; set; }
    [DynamoDBProperty("expire_date")]
    public DateTime? ExpireDate { get; set; }
}