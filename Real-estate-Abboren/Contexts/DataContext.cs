using Microsoft.EntityFrameworkCore;
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

    #region entitites

    #endregion
}
