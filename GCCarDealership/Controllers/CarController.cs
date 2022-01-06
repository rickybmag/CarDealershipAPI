using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCCarDealership.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        public List<Car> Cars = new List<Car>()
        {
            new Car("Chevy", "Silverado", 1996, "Black"),
            new Car("Chevy", "Impala", 1961, "Red"),
            new Car("Toyota", "Tacoma", 2018, "White"),
            new Car("Toyota", "Tundra", 2018, "Red"),
            new Car("Ford", "Bronco", 1990, "Primer")
        };


        [HttpGet]
        public List<Car> GetCars()
        {
            return Cars;
        }
                
        [HttpGet("GetIndex/{index}")]
        public Car GetCarByIndex(int index)
        {
            try
            {
                return Cars[index];
            }
            catch(ArgumentOutOfRangeException)
            {
                Car nothing = new Car("","",0,"");
                return nothing;
            }
        }

        [HttpGet("SearchMake/{make}")]
        public List<Car> SearchByMake(string make)
        {
            List<Car> carMake = new List<Car>();
            foreach (var v in Cars)
            {
                if(make.ToLower().Trim() == v.Make.ToLower().Trim())
                {
                    carMake.Add(v);
                }
            }
            return carMake;
        }

        [HttpGet("SearchModel/{model}")]
        public List<Car> SearchByModel(string model)
        {
            List<Car> carModel = new List<Car>();
            foreach (var v in Cars)
            {
                if (model.ToLower().Trim() == v.Model.ToLower().Trim())
                {
                    carModel.Add(v);
                }
            }
            return carModel;
        }

        [HttpGet("SearchYear/{year}")]
        public List<Car> SearchByYear(int year)
        {
            List<Car> carYear = new List<Car>();
            foreach (var v in Cars)
            {
                if (year == v.Year)
                {
                    carYear.Add(v);
                }
            }
            return carYear;
        }

        [HttpGet("SearchColor/{color}")]
        public List<Car> SearchByColor(string color)
        {
            List<Car> carColor = new List<Car>();
            foreach (var v in Cars)
            {
                if (color.ToLower().Trim() == v.Color.ToLower().Trim())
                {
                    carColor.Add(v);
                }
            }
            return carColor;
        }
    }
}
