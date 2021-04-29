using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication7.Models
{
    public class SamouraiViewModel
    {
        public Samourai Samourai { get; set; }
        public List<Arme> Armes { get; set; }
        public int? ArmeId { get; set; }
        public List<ArtMartial> ArtMartiaux { get; set; }
        public List<int> ArtMartialId { get; set; }
    }
}