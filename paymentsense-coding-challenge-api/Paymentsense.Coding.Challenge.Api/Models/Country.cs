using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paymentsense.Coding.Challenge.Api.Models
{
    public class Country
    {
        public string Alpha2Code { get; set; }
        public string Name { get; set; }
        public string Flag { get; set; }
        public string[] CallingCodes { get; set; }
        public string Capital { get; set; }
        public string Region { get; set; }
        public int Population { get; set; }
        public string Demonym { get; set; }
        public string[] Timezones { get; set; }
        public Currency[] Currencies { get; set; }
        public Language[] Languages { get; set; }
        public string[] Borders { get; set; }
    }
}
