namespace TopTaz.Domain.VisitorAgg
{
    public class Device
    {
        public string Brand { get; set; }
        public string Family { get; set; }
        public string Model { get; set; }
        public bool IsSpider { get; set; }

        public Device(string brand, string family, string model, bool isSpider)
        {
            Brand = brand;
            Family = family;
            Model = model;
            IsSpider = isSpider;
        }

        public Device()
        {
        }
    }
}