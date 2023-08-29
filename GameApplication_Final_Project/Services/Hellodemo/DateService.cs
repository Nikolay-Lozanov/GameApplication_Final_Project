using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameApplication_Final_Project.Services.Hellodemo
{
    public class DateService : IDateService
    {

        public DateTime GetTime()
        {
            return DateTime.Now;
        }
    }
}
