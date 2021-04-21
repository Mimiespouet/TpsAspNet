using System;

namespace ConsoleApp1
{
    public class Cercle : Forme
    {
        public int Rayon { get; set; }

        public override double Aire => Math.PI * Rayon * Rayon;
        public override double Perimetre => 2 * Math.PI * Rayon;

        public override string ToString()
        {
            return $"Cercle de rayon {this.Rayon}" + " \r\n" + base.ToString();
        }
    }
}