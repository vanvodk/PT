using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Paymentsense.Coding.Challenge.Api.Models
{
    public class PaginationModel
    {
        [Range(1, double.MaxValue)]
        public int Page { get; set; }
        [Range(5, double.MaxValue)]
        public int PageSize { get; set; }
    }
}
