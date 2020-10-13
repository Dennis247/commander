using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Dto
{
    public class CommandUpdateDto
    {

        [Required]
        public int Id { get; set; }

        [Required]
 

        public string HowTo { get; set; }

        [Required]
        public string Line { get; set; }


        public string Platform { get; set; }
    }
}
