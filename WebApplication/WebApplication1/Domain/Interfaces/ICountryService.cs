﻿using WebApplication1.DAL.Entities;

namespace WebApplication1.Domain.Interfaces
{
    public interface ICountryService
    {

        Task<IEnumerable<Country>> GetCountriesAsync();


        Task<Country> CreateCountryAsync(Country country);

        Task<Country> GetCountryById(Guid id);

        Task<Country> EditCountryAsync(Country country);

        Task<Country> DeleteCountryAsync(Guid id);
        Task CreateCountryAsync();
        Task GetCountryByIdAsync(Guid id);
    }
}
