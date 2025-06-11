using Microsoft.EntityFrameworkCore;

namespace Kolos2Poprawa.Data;

public class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
        
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
        
    }

    
}