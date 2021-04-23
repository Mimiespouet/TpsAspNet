using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.ValidationAttributs
{
    public class ValidationIngredientList : ValidationAttribute
    {
        public int min = 2;
        public int max = 5;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            PizzaViewModel vm = validationContext.ObjectInstance as PizzaViewModel;

            if (vm.IngredientIds == null || vm.IngredientIds.Count() < min || vm.IngredientIds.Count() > max) {
                return new ValidationResult("Une pizza doit avoir entre 2 et 5 ingrédients");
            }
            return ValidationResult.Success;
        }
    }
}