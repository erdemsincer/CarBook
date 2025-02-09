using CarBook.Application.Interfaces.StatisticsInterfaces;
using CarBook.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.StatisticsRepositories
{
    public class StatisticsRepositories : IStatisticsRepository
    {
        private readonly CarBookContext _context;

        public StatisticsRepositories(CarBookContext context)
        {
            _context = context;
        }

        public string BlogTitleByMaxBlogCount()
        {
            throw new NotImplementedException();
        }

        public string BrandNameByMaxCar()
        {
            throw new NotImplementedException();
        }

        public int GetAuthorCount()
        {
            var values = _context.Authors.Count();
            return values;
        }

        public double GetAvgRentPriceForDaily()
        {
            throw new NotImplementedException();
        }

        public double GetAvgRentPriceForMonthly()
        {
            throw new NotImplementedException();
        }

        public double GetAvgRentPriceForWeekly()
        {
            throw new NotImplementedException();
        }

        public int GetBlogCount()
        {
            var values = _context.Blogs.Count();
            return values;
        }

        public int GetBrandCount()
        {
            var values = _context.Brands.Count();
            return values;
        }

        public string GetCarBrandAndModelByRentPriceDailyMax()
        {
            throw new NotImplementedException();
        }

        public string GetCarBrandAndModelByRentPriceDailyMin()
        {
            throw new NotImplementedException();
        }

        public int GetCarCountByFuelElectric()
        {
            var values=_context.Cars.Where(x=>x.Fuel== "Elektrik").Count();
            return values;
        }

        public int GetCarCountByFuelGasolineOrDiesel()
        {
            var value = _context.Cars.Where(x => x.Fuel == "Benzin" || x.Fuel == "Dizel").Count();
            return value;   
        }

        public int GetCarCountByKmSmallerThen1000()
        {
           var values=_context.Cars.Where(x=>x.Km<=1000).Count();
            return values;
        }

        public int GetCarCountByTranmissionIsAuto()
        {
            var values=_context.Cars.Where(x=>x.Transmission== "Otomatik").Count();
            return values;
        }

        public int LocationCount()
        {
            var values = _context.Locations.Count();
            return values;
        }
    }
}
