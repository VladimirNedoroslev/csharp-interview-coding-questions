using Microsoft.Extensions.Caching.Memory;

// ReSharper disable ConvertIfStatementToNullCoalescingExpression

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

    public CountryService(
        IMemoryCache memoryCache,
        ICountryRepository countryRepository
    )
    {
        _memoryCache = memoryCache;
        _countryRepository = countryRepository;
    }

    public IEnumerable<Country> GetCountries()
    {
        var countries = (List<Country>)_memoryCache.Get("countriesCacheKey");

        if (countries is null)
        {
            countries = _countryRepository.GetAllCountries(); // very expensive operation
        }

        _memoryCache.Set("countriesCacheKey", countries);

        return countries;
    }
}


// SOLUTION:

// private static readonly object _lock = new();

// public IEnumerable<Country> GetCountries()
// {
//     var countries = (IEnumerable<Country>)_memoryCache.Get("territoryCacheKey");
//
//     if (countries is null)
//     {
//         lock (_lock)
//         {
//             countries = (IEnumerable<Country>)_memoryCache.Get("territoryCacheKey");
//             if (countries is null)
//             {
//                 countries = _countryRepository.GetAllCountries(); // very expensive operation
//                 _memoryCache.Set("territoryCacheKey", countries, TimeSpan.FromHours(1));
//             }
//         }
//     }
//
//     return countries;
// }