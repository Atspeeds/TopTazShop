namespace TopTaz.Domain.VisitorAgg
{
    public class VisitorVersion
    {
        public string Family { get; set; }
        public string Version { get; set; }

        public VisitorVersion()
        {
        }

        public VisitorVersion(string family, string version)
        {
            Family = family;
            Version = version;
        }
    }
}