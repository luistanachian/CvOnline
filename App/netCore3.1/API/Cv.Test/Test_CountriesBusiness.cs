using Cv.Business.Class;
using Cv.Models;
using Cv.Repository.Interface;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace Cv.Test
{
    public class Test_CountriesBusiness
    {
        [Test]
        public void GetAll_Ok()
        {
            var list = new List<CountryModel>
            {
                new CountryModel{ id = 76253 },
                new CountryModel{ id = 93892 }
            };
            var mockCountries = new Mock<ICountriesRepository>();
            mockCountries.Setup(c => c.GetAll()).Returns(list);
            var bus = new CountriesBusiness(mockCountries.Object);
            var result = bus.GetAll();
            Assert.AreEqual(true, result != null && result.Count > 0);
            mockCountries.Verify(c => c.GetAll());
        }
        [Test]
        public void GetAll_Empty_False()
        {
            var mockCountries = new Mock<ICountriesRepository>();
            mockCountries.Setup(c => c.GetAll()).Returns(new List<CountryModel>());
            var bus = new CountriesBusiness(mockCountries.Object);
            var result = bus.GetAll();
            Assert.AreEqual(false, result != null && result.Count > 0);
            mockCountries.Verify(c => c.GetAll());
        }
        [Test]
        public void GetAll_Null_False()
        {
            List<CountryModel> list =  null;
            var mockCountries = new Mock<ICountriesRepository>();
            mockCountries.Setup(c => c.GetAll()).Returns(list);
            var bus = new CountriesBusiness(mockCountries.Object);
            var result = bus.GetAll();
            Assert.AreEqual(false, result != null && result.Count > 0);
            mockCountries.Verify(c => c.GetAll());
        }
        [Test]
        public void GetById_Ok()
        {
            var mockCountries = new Mock<ICountriesRepository>();
            mockCountries.Setup(c => c.GetById(1)).Returns(new CountryModel());
            var bus = new CountriesBusiness(mockCountries.Object);
            var result = bus.GetById(1);
            Assert.AreEqual(true, result != null);
            mockCountries.Verify(c => c.GetById(1));
        }
        [Test]
        public void GetById_Null_False()
        {
            CountryModel country = null;
            var mockCountries = new Mock<ICountriesRepository>();
            mockCountries.Setup(c => c.GetById(1)).Returns(country);
            var bus = new CountriesBusiness(mockCountries.Object);
            var result = bus.GetById(1);
            Assert.AreEqual(false, result != null);
            mockCountries.Verify(c => c.GetById(1));
        }
    }
}
