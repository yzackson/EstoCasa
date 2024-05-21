using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using EstoCasa.Contracts;
using EstoCasa.Models;
using Microsoft.AspNetCore.Mvc;

namespace EstoCasa.Controllers;

[ApiController]
[Route("[Controller]")]
public class StorageController(IDynamoDBContext context) : ControllerBase
{
    [HttpGet("GetItem")]
    public IActionResult GetAllItems()
    {
        var result = context.ScanAsync<StorageItem>(default).GetRemainingAsync();
        return Ok(result.Result);
    }

    [HttpGet("GetItem/{id}")]
    public async Task<StorageItem> GetItembyId(long id)
    {
        var item = await context.LoadAsync<StorageItem>(id);
        return item;
    }
    
    [HttpGet("GetItem/{field}/{name}")]
    public async Task<List<StorageItem>> GetItemsbyField(string field, string name)
    {
        var item = await context.ScanAsync<StorageItem>(default).GetRemainingAsync();
        return field switch
        {
            "name" => item.Where(x => x.Name.Equals(name)).ToList(),
            "type" => item.Where(x => x.Type.Equals(name)).ToList(),
            "mark" => item.Where(x => x.Mark.Equals(name)).ToList(),
            _ => new List<StorageItem>()
        };
    }
    
    [HttpPost("CreateItem")]
    public async Task<IActionResult> CreateItem(ReqStorageItem item)
    {
        var i = new StorageItem()
        {
            Id = DateTime.Now.Ticks,
            Name = item.Name,
            Mark = item.Mark,
            Type = item.Type,
            Quantity = item.Quantity,
            Unity = item.Unity,
            ExpireDate = item.ExpireDate
        };
        await context.SaveAsync(i);
        return Ok(i);
    }
    
    [HttpPut("UpdateItem")]
    public async Task<IActionResult> UpdateItem(StorageItem newItem)
    {
        await context.SaveAsync(newItem);
        return Ok(newItem);
    }
    
    [HttpDelete("DeleteItem/{id}")]
    public async Task<IActionResult> DeleteItem(long id)
    {
        var item = context.LoadAsync<StorageItem>(id);
        await context.DeleteAsync<StorageItem>(id);
        return Ok(item);
    }
}