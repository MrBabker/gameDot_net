using APIs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Supabase;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System.Numerics;

namespace APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersInfo : ControllerBase
    {
        
        private readonly Client _supabase;

       public PlayersInfo(Client supabase)
        {
            _supabase = supabase;
        }
        [HttpGet]
public async Task<ActionResult<List<PlayerDto>>> GetAll()
{
    var result = await _supabase.From<Players>().Get();

    if (result.Models == null || result.Models.Count == 0)
        return NotFound();

    // نحول Players -> PlayerDto
    var dtoList = result.Models.Select(p => new PlayerDto
    {
        Email = p.email,
        Name = p.name,
        CreatedAt = p.created_at,
        UpdatedAt = p.updated_at
    }).ToList();

    return Ok(dtoList);
}

    }
}

public class Players : BaseModel
{
    [PrimaryKey("id", false)]
    public int Id { get; set; }   

    public string email { get; set; }
    public string name { get; set; }
    public string created_at { get; set; }
    public string updated_at { get; set; }
}
