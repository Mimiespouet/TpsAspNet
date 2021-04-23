using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApplication4.Models;
using WebApplication4.Utils;

namespace WebApplication4.ValidationAttributs
{
    public class ValidationName : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            PizzaViewModel vm = validationContext.ObjectInstance as PizzaViewModel;
            Pizza pizzaExist = FakeDb.Instance.Pizzas.FirstOrDefault(p => p.Nom == vm.Pizza.Nom);

            if (pizzaExist != null && vm.Pizza.Nom.ToUpper() == pizzaExist.Nom.ToUpper() && vm.Pizza.Id != pizzaExist.Id) {
                return new ValidationResult("Le nom d une pizza est unique");
            }
            return ValidationResult.Success;
        }
    }
}