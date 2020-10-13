using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Dto
{
    public class CommandCreateDto
    {
   
        
      
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]

        public string HowTo { get; set; }

        [Required]
        public string Line { get; set; }

        [Required]
        public string Platform { get; set; }
    }
}
