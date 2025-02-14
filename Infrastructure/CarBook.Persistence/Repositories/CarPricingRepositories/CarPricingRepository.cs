
using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Application.ViewModels;
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

		public List<CarPricingViewModel> GetCarPricingWithTimePeriod()
		{
            List<CarPricingViewModel> values= new List<CarPricingViewModel>();
            using(var command = _carBookcontext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "Select * From (Select Model,Name,CoverImageUrl,PricingId,Amount From CarPricings Inner Join Cars On Cars.CarId=CarPricings.CarId Inner Join Brands On Brands.BrandId=Cars.BrandId) As SourceTable Pivot (Sum(Amount) For PricingId In ([2],[5],[6])) as PivotTable;";
                command.CommandType=System.Data.CommandType.Text;
                _carBookcontext.Database.OpenConnection();
                using(var reader = command.ExecuteReader()) {
                    while (reader.Read())
                    {
                        CarPricingViewModel carPricingViewModel = new CarPricingViewModel()
                        {
                            Brand = reader["Name"].ToString(),
                            Model = reader["Model"].ToString(),
                            CoverImageUrl = reader["CoverImageUrl"].ToString(),
                            Amounts = new List<decimal>
                            {
                                Convert.ToDecimal(reader["2"]),
                                Convert.ToDecimal(reader["5"]),
                                Convert.ToDecimal(reader["6"])
                            }
                        };
                        values.Add(carPricingViewModel);
                    }
                }
                _carBookcontext.Database.CloseConnection();
                return values;
            }
        }
		}
		}
	

