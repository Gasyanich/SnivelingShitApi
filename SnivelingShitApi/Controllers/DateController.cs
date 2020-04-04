using System;
using Microsoft.AspNetCore.Mvc;

namespace SnivelingShitApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DateController : Controller
    {
        private readonly DateTime _startDate = new DateTime(2020, 1, 3, 20, 30, 0);

        [HttpGet]
        public ActionResult<OurDateTime> GetTime()
        {
            var dateTimeNow = DateTime.Now;

            var result = dateTimeNow - _startDate;

            return new OurDateTime {Hour = (int) result.TotalHours, Minute = result.Minutes, Second = result.Seconds};
        }
    }

    public class OurDateTime
    {
        public int Hour { get; set; }
        public int Minute { get; set; }

        public int Second { get; set; }
    }
}