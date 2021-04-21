using System;

namespace ConsoleApp1
{
    public abstract class Forme
    {
        public abstract double Aire { get; }
        public abstract double Perimetre { get; }


        public override string ToString()
        {
            return $"Aire = {this.Aire}" + " \r\n" + $"Périmètre = {this.Perimetre}" + " \r\n";
        }
    }
}