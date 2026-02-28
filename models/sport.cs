namespace PR8.classes
{
    public class Sport : Shop
    {
        public string Size { get; set; }
        public int IdShop { get; set; }
        public Sport() { }
        public Sport(string Name, int Price, string Size, int IdShop) : base(IdShop, Name, Price)
        {
            this.Size = Size;

        }
    }
}
