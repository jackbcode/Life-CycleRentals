using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AutoMapper;
using Life_CycleRentals.Dtos;

namespace Life_CycleRentals.Models
{
    public class Min18YearsIfAMember: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //var customer = (Customer)validationContext.ObjectInstance;


            //MAY NEED TO CHANGE

            Customer customer = new Customer();
            if (validationContext.ObjectType == typeof(Customer))
                customer = (Customer)validationContext.ObjectInstance;
            else
                customer = Mapper.Map((CustomerDto)validationContext.ObjectInstance, customer);








            if (customer.MembershipTypeId == MembershipType.Unknown ||
                customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.Birthdate == null)
                return new ValidationResult("Birthdate is required");

            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

            return (age >= 18) 
                ? ValidationResult.Success 
                : new ValidationResult("Customer should be at least 18 years old to go on a membership plan");
        }
    }
}