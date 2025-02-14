
using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarPricingRepositories
{
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly CarBookContext _carBookcontext;

        public CarPricingRepository(CarBookContext context)
        {
            _carBookcontext = context;
        }

        public List<CarPricing> GetCarPricingWithCars()
        {
            var values = _carBookcontext.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(x=> x.Pricing).Where(z=>z.PricingId==2).ToList();
            return values;
        }

		public List<CarPricing> GetCarPricingWithTimePeriod()
		{
            return _carBookcontext.CarPricings.Include(x => x.Pricing).ToList();
		}
		}
	}

