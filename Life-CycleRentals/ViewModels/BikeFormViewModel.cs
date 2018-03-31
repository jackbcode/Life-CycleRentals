using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Life_CycleRentals.Models;

namespace Life_CycleRentals.ViewModels
{
    public class BikeFormViewModel
    {

        public IEnumerable<Style> Styles { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public String Name { get; set;}

     
        [Url]
        public String Picture { get; set; }


        [Display(Name = "Style")]
        [Required]
        public byte? StyleId { get; set; }

        [Display(Name = "Build Year")]
        [Required]
        public DateTime? YearBuilt { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        [Required]
        public byte? NumberInStock { get; set; }


        public string Title
        {
            get
        {
                return Id != 0 ? "Edit Bike" : "New Bike";

            }

        }


        public BikeFormViewModel()
        {

            Id = 0;
        }

        public BikeFormViewModel(Bike bike)
        {
            Id = bike.Id;
            Name = bike.Name;
            Picture = bike.Picture;
            YearBuilt = bike.YearBuilt;
            NumberInStock = bike.NumberInStock;
            StyleId = bike.StyleId;
           
        }









    }

} 








    
