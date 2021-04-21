namespace ConsoleApp1
{
    public class Rectangle : Forme
    {
        public virtual int Largeur { get; set; }
        public int Longueur { get; set; }

        public override double Aire => Largeur * Longueur;

        public override double Perimetre => 2 * Largeur + 2 * Longueur;

        public override string ToString()
        {
            return $"Rectangle de longueur={this.Longueur} et largeur={this.Largeur}" + " \r\n" + base.ToString();
        }
    }
}