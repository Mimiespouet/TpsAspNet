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
    public class ValidationIngredientPizza : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var pizzasDb = FakeDb.Instance.Pizzas;

            foreach(var pizzaDb in pizzasDb) {

                return new ValidationResult("Il existe déja une pizza portant ce nom");
            }
            return ValidationResult.Success;
        }
    }
}