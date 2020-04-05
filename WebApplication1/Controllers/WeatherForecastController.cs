using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Consumes("application/json")]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        private readonly ICOnBoardingContext _context;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, ICOnBoardingContext context)
        {
            _logger = logger;
            _context = context;

        }
    
        public String SayHi()
        {
            return "hello I am Felix";
        }
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
     
        [HttpPost]
        public Result AddCustomer(Customer newCustomer)
        {
            var result = new Result { Success = false };

            if (newCustomer.Id.Equals(Guid.Empty))
            {
                result.Message = "CustomerId is Null";
                return result;
            }
           // var optionsBuilder = new DbContextOptionsBuilder<ICOnBoardingContext>();
           // optionsBuilder.UseSqlServer("ICOnBoardingContext");

            using (var context=_context)
            {
                var TempCustomer = context.Customer.Find(newCustomer.Id);
               
                if (TempCustomer == null)
                {
                    /* context.Customer.Add(new Customer()
                     {
                         Id = newCustomer.Id,
                         Name = newCustomer.Name,
                        Address=newCustomer.Address
                     });*/
                    context.Customer.Add(newCustomer);
                }

                context.SaveChanges();
                result.Success = true;
                result.Message = "success";
            }
            return result;
        }


    }
}
