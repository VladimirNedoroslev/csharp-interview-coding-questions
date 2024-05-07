using Microsoft.Extensions.Caching.Memory;

namespace Refactoring;

public class Country
{
    public string Id { get; set; }
    public string Name { get; set; }
}

public interface ICountryRepository
{
    List<Country> GetAllCountries();
}

public class CountryService
{

    private readonly IMemoryCache _memoryCache;
    private readonly ICountryRepository _countryRepository;


    public CountryService(IMemoryCache memoryCache, ICountryRepository countryRepository)
    {
        _memoryCache = memoryCache;
        _countryRepository = countryRepository;
    }

    public IEnumerable<Country> GetCountries()
    {
        
        var countries = (IEnumerable<Country>)_memoryCache.Get("territoryCacheKey");

        countries = _countryRepository.GetAllCountries(); // very expensive operation

        _memoryCache.Set("territoryCacheKey", countries);
        return countries;
    }
}