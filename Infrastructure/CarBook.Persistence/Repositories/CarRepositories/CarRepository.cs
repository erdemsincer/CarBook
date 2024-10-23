﻿using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarBookContext carBookcontext;

        public CarRepository(CarBookContext carBookcontext)
        {
            this.carBookcontext = carBookcontext;
        }

        public List<Car> GetCarsListWithBrands()
        {
            var values=carBookcontext.Cars.Include(x=>x.Brand).ToList();
            return values;
            
            
        }
    }
}