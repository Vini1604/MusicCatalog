using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicCatalogAPI.Models.Dtos
{
    public class MusicDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Gender { get; set; }
        [DisplayFormat(DataFormatString = "yyyy")]
        public DateTime ReleasedDate { get; set; }
    }
}
