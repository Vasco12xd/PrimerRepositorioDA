using Microsoft.AspNetCore.Mvc;
using WebApplication1.Domain.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]//Nombre inicial de mi ruta, URL O PATH
    [ApiController]
    public class CountriesController : Controller
    {
        private readonly ICountryService _countryService;

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpPost, ActionName("Get")]
        [Route("GetAll")]
        public async Task<IActionResult<IEnumerable<Country>>> GetCountriesAsync()
        {
            var countries = await _countryService.GetCountriesAsync(); // Correctly define 'countries'

            if (countries == null || !countries.Any()) return (IActionResult<IEnumerable<Country>>)NotFound();

            return (IActionResult<IEnumerable<Country>>)Ok(countries);
        }

        [HttpPost, ActionName("Get")]
        [Route("GetById/{id}")]
        public async Task<IActionResult<Country>> GetCountryByIdAsync(Guid id)
        {
            var country = await _countryService.GetCountryById(id); // Correct method name

            if (country == null) return (IActionResult<Country>)NotFound();

            return (IActionResult<Country>)Ok(country);
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<IActionResult<Country>> CreateCountryAsync(Country country)
        {
            try
            {
                var newCountry = await _countryService.CreateCountryAsync(country);
                if (newCountry == null) return (IActionResult<Country>)NotFound();
                return (IActionResult<Country>)Ok(newCountry);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return (IActionResult<Country>)Conflict($"El país {country.Name} ya existe");

                return (IActionResult<Country>)Conflict(ex.Message);
            }
        }

        [HttpPost, ActionName("Edit")]
        [Route("Edit")]
        public async Task<IActionResult<Country>> EditCountryAsync(Country country)
        {
            try
            {
                var editedCountry = await _countryService.EditCountryAsync(country);
                if (editedCountry == null) return (IActionResult<Country>)NotFound();
                return (IActionResult<Country>)Ok(editedCountry);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return (IActionResult<Country>)Conflict($"El país {country.Name} ya existe");

                return (IActionResult<Country>)Conflict(ex.Message);
            }
        }

        [HttpPost, ActionName("Delete")]
        [Route("Delete")]
        public async Task<IActionResult<Country>> DeleteCountryAsync(Guid id)
        {
            if (id == Guid.Empty) return (IActionResult<Country>)BadRequest();

            var deletedCountry = await _countryService.DeleteCountryAsync(id);

            if (deletedCountry == null) return (IActionResult<Country>)NotFound();

            return (IActionResult<Country>)Ok(deletedCountry);
        }
    }


}