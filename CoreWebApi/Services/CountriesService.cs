using CoreWebApi.DataAccess;
using CoreWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Services
{
    public class CountriesService
    {
        ICountryDal _countryDal;
        public CountriesService(ICountryDal countryDal)
        {
            _countryDal = countryDal;
        }

        public List<Country> GetCountries()
        {
            var results = _countryDal.GetList();
            return results;
        }

        public Country GetCountry(int Id)
        {
            var result = _countryDal.Get(x=>x.Id==Id);
            return result;
        }

        public Country AddCountry(Country country)
        {
            _countryDal.Add(country);
            return country;
        }
        public Country UpdateCountry(Country country)
        {
            _countryDal.Update(country);
            return country;
        }
        public int DeleteCountry(int Id)
        {
            _countryDal.Delete(new Country {Id=Id });
            return Id;
        }
    }
}
