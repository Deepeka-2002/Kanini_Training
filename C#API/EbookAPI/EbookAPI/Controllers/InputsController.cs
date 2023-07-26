using EbookAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EbookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InputsController : ControllerBase
    {
        private readonly EbookContext _context;

        public InputsController(EbookContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<List<Input>>> RunProcedure(Input input)
        {
           string StoredProc = "exec BorrowBook" +
               "@Email = '" + input.Email + "'," +
               "@ISBN  = '" + input.ISBN + "'";  

  
            return  _context.Inputs.FromSqlRaw(StoredProc).ToList();
        }
    }

    
}
