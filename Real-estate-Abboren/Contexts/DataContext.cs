using Microsoft.EntityFrameworkCore;
using Real_estate_Abboren.Models.Entities;

namespace Real_estate_Abboren.Contexts;

internal class DataContext : DbContext
{
    private readonly string _connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Berrr\Desktop\Case-management-system\Case-management-system\Real-estate-Abboren\Contexts\sql_db.mdf;Integrated Security=True;Connect Timeout=30";

    #region constructors
    public DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    #endregion

    #region overrides
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer(_connectionstring);
    }

    #endregion

    public DbSet<AddressEntity> Addresses { get; set; } = null!;
    public DbSet<RenterEntity>  Renters { get; set; } = null!;
    public DbSet<CaseEntity> Cases { get; set; } = null!;


}
