using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MilesPerGallon.Models
{
    public class DataPage
    {
        /*FirstName, LastName, CarModel, MilesDriven, GallonsFilled, FillUpDate*/

        public int Id { get; set; }
        [Required]
        [Display(Name ="First Name")]
        public string FirstName {get; set;}
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set;}
        [Required]
        [Display(Name = "Car Model")]
        public string CarModel { get; set;}
        [Required]
        [Display(Name = "Miles Driven")]
        public float MilesDriven { get; set;}
        [Required]
        [Display(Name = "Gallons Filled")]
        public int GallonsFilled { get; set;}
        [Required]
        [Display(Name = "Date of fill up")]
        [DataType(DataType.Date)]
        public DateTime FillUpDate { get; set;}
    }
}
