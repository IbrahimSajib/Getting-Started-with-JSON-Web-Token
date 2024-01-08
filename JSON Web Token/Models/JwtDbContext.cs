using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JSON_Web_Token.Models
{
    public class JwtDbContext : IdentityDbContext
    {
        public JwtDbContext(DbContextOptions<JwtDbContext> options) : base(options)
        {
        }
    }
}
