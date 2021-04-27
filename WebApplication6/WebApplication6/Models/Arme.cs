using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    public class Arme
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int Degats { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}