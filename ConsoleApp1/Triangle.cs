using System;

namespace ConsoleApp1
{
    public class Triangle : Forme
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
        private double perim => (A + B + C) / 2;

        public override double Aire => Math.Sqrt(perim * (perim - A) * (perim - B) * (perim - C));

        public override double Perimetre => A + B + C;

        public override string ToString()
        {
            return $"Triangle de coté A={this.A}, B={this.B}, C={this.C}" + " \r\n" + base.ToString();
        }
    }
}