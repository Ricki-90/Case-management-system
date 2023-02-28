using Microsoft.EntityFrameworkCore;

namespace Real_estate_Abboren.Contexts;

internal class DataContexts : DbContext
{
    public DataContexts(DbContextOptions<DataContexts> options) : base(options)
    {
    }
}
