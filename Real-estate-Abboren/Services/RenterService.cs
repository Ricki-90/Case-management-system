using Microsoft.EntityFrameworkCore;
using Real_estate_Abboren.Contexts;
using Real_estate_Abboren.Models;
using Real_estate_Abboren.Models.Entities;

namespace Real_estate_Abboren.Services;

internal class RenterService
{
    private static DataContext _context = new DataContext();

    public static async Task SaveAsync(Renter renter)
    {
        var renterEntity = new RenterEntity
        {
            FirstName = renter.FirstName,
            LastName = renter.LastName,
            Email = renter.Email,
            PhoneNumber = renter.PhoneNumber,
        };

        var addressEntity = await _context.Addresses.FirstOrDefaultAsync(x => x.StreetName == renter.StreetName && x.PostalCode == renter.PostalCode && x.City == renter.City);
        if (addressEntity != null)
            renterEntity.AddressId = addressEntity.Id;
        else
            renterEntity.Address = new AddressEntity
            {
                StreetName = renter.StreetName,
                PostalCode = renter.PostalCode,
                City = renter.City,
            };

        _context.Add(renterEntity);
        await _context.SaveChangesAsync();
    }        

    public static async Task<IEnumerable<Renter>> GetAllAsync()
    {
        var renters = new List<Renter>();

        foreach (var renter in await _context.Renters.Include(x => x.Address).ToListAsync())
            renters.Add(new Renter
            {
                FirstName = renter.FirstName,
                LastName = renter.LastName,
                Email = renter.Email,
                PhoneNumber = renter.PhoneNumber,
                StreetName = renter.Address.StreetName,
                PostalCode = renter.Address.PostalCode,
                City = renter.Address.City,
            });

        return renters;
    }

    public static async Task<Renter> GetAsync(string email)
    {
        var renter = await _context.Renters.Include(x => x.Address).FirstOrDefaultAsync(x => x.Email == email);
        if (renter !=null)
    }

    public static async Task UpdateAsync(Renter renter)
    {

    }

    public static async Task DeleteAsync(string email)
    {

    }

}
