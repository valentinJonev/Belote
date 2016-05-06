using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belot.Backend.ViewModels
{
    public class PagingModel
    {
        [Required]
        public int? Offset { get; set; }

        [Required]
        public int? Limit { get; set; }
    }
}
