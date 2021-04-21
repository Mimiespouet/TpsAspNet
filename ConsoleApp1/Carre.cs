namespace ConsoleApp1
{
    public class Carre : Rectangle
    {
        public override int Largeur => this.Longueur;

        public override string ToString()
        {
            return $"Carré de coté={Longueur}" + "\r\n" + base.ToString();
        }
    }
}