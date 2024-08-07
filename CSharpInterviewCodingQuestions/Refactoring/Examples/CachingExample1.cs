using Microsoft.Extensions.Caching.Memory;

namespace Refactoring.Examples;

file class Country
{
    public string Id { get; set; }
    public string Name { get; set; }
}

file interface ICountryRepository
{
    List<Country> GetAllCountries();
}

file class CountryService
{
    private readonly IMemoryCache _memoryCache;
    private readonly ICountryRepository _countryRepository;

    public CountryService(IMemoryCache memoryCache, ICountryRepository countryRepository)
    {
        _memoryCache = memoryCache;
        _countryRepository = countryRepository;
    }

    private object _lock = new object();
    
    public IEnumerable<Country> GetCountries()
    {
        
        var countries = (IEnumerable<Country>)_memoryCache.Get("territoryCacheKey");

        if (countries is null)
        {
            lock (_lock)
            {

                if (countries is null)
                    countries = _countryRepository.GetAllCountries(); // very expensive operation    
            }
        }
        

        if (countries is not null)
            _memoryCache.Set("territoryCacheKey", countries, TimeSpan.FromHours(1));
        return countries;
    }
}