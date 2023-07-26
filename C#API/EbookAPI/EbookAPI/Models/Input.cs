using Microsoft.EntityFrameworkCore;

namespace EbookAPI.Models
{
    [Keyless]
    public class Input
    {
       public string Email { get; set; }
       public string ISBN{ get; set; }    
    }
}
