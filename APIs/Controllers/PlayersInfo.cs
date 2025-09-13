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
        public async Task<ActionResult<List<Players>>> GetAll()
        {
            var result = await _supabase.From<Players>().Get();

            if (result.Models == null || result.Models.Count == 0)
                return NotFound();

            return result.Models; 
        }
    }
}

public class Players : BaseModel
{
    [PrimaryKey("id", false)]
  
    public string email { get; set; }
  
    public string name { get; set; }

    public string created_at { get; set; }
    public string updated_at { get; set; }
}
