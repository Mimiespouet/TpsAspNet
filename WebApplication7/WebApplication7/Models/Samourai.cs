using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication7.Models
{
    public class Samourai
    {
        public int Id { get; set; }
        public int Force { get; set; }
        public string Nom { get; set; }
        public virtual Arme Arme { get; set; }
        public virtual List<ArtMartial> ArtMartiaux { get; set; }
        public int Potentiel { 
            get
            {
                if (this.Arme != null)
                {
                    return (this.Force + this.Arme.Degats) * (this.ArtMartiaux.Count());
                }
                else
                {
                    return this.Force * (this.ArtMartiaux.Count() + 1);
                }
            }  
        }
    }
}