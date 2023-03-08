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
        var _renterEntity = new RenterEntity
        {
            FirstName = renter.FirstName,
            LastName = renter.LastName,
            Email = renter.Email,
            PhoneNumber = renter.PhoneNumber,
        };

        var _addressEntity = await _context.Addresses.FirstOrDefaultAsync(x => x.StreetName == renter.StreetName && x.PostalCode == renter.PostalCode && x.City == renter.City);
        if (_addressEntity != null)
            _renterEntity.AddressId = _addressEntity.Id;
        else
            _renterEntity.Address = new AddressEntity
            {
                StreetName = renter.StreetName,
                PostalCode = renter.PostalCode,
                City = renter.City,
            };

        _context.Add(_renterEntity);
        await _context.SaveChangesAsync();
    }        

    public static async Task<IEnumerable<Renter>> GetAllAsync()
    {
        var _renters = new List<Renter>();

        foreach (var _renter in await _context.Renters.Include(x => x.Address).ToListAsync())
            _renters.Add(new Renter
            {
                Id = _renter.Id,
                FirstName = _renter.FirstName,
                LastName = _renter.LastName,
                Email = _renter.Email,
                PhoneNumber = _renter.PhoneNumber,
                StreetName = _renter.Address.StreetName,
                PostalCode = _renter.Address.PostalCode,
                City = _renter.Address.City,
            });

        return _renters;
    }

    public static async Task<Renter> GetAsync(string email)
    {
        var _renter = await _context.Renters.Include(x => x.Address).FirstOrDefaultAsync(x => x.Email == email);
        if (_renter != null)
            return new Renter
            {
                Id = _renter.Id,
                FirstName = _renter.FirstName,
                LastName = _renter.LastName,
                Email = _renter.Email,
                PhoneNumber = _renter.PhoneNumber,
                StreetName = _renter.Address.StreetName,
                PostalCode = _renter.Address.PostalCode,
                City = _renter.Address.City
            };
        else
            return null!;
    }

    public static async Task UpdateAsync(Renter renter)
    {
        
        var _renterEntity = await _context.Renters.Include(x => x.Address).FirstOrDefaultAsync(x => x.Id == renter.Id);
        if (_renterEntity != null)
        {
            if (!string.IsNullOrEmpty(renter.FirstName))
                _renterEntity.FirstName = renter.FirstName;

            if (!string.IsNullOrEmpty(renter.LastName))
                _renterEntity.LastName = renter.LastName;

            if (!string.IsNullOrEmpty(renter.Email))
                _renterEntity.Email = renter.Email;

            if (!string.IsNullOrEmpty(renter.PhoneNumber))
                _renterEntity.PhoneNumber = renter.PhoneNumber;

            if (!string.IsNullOrEmpty(renter.StreetName) || !string.IsNullOrEmpty(renter.PostalCode) || !string.IsNullOrEmpty(renter.City))
            {
                var _addressEntity = await _context.Addresses.FirstOrDefaultAsync(x => x.StreetName == renter.StreetName && x.PostalCode == renter.PostalCode && x.City == renter.City);
                if (_addressEntity != null)
                    _renterEntity.AddressId = _addressEntity.Id;
                else
                    _renterEntity.Address = new AddressEntity
                    {
                        StreetName = renter.StreetName,
                        PostalCode = renter.PostalCode,
                        City = renter.City
                    };
            }

            _context.Update(_renterEntity);
            await _context.SaveChangesAsync();
        }
    }

    public static async Task DeleteAsync(string email)
    {
        var renter = await _context.Renters.Include(x => x.Address).FirstOrDefaultAsync(x => x.Email == email);
        if (renter != null)
        {
            _context.Remove(renter);
            await _context.SaveChangesAsync();
        }
    }

}
