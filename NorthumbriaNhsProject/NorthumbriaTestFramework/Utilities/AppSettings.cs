namespace NorthumbriaTestFramework.Utilities
{
    public class AppSettings
    { 
        public bool? Headless { get; set; }
        public float? SlowMo { get; set; }
        public DriverType DriverType { get; set; }
        public string? BaseUrl { get; set; }
 
    }

    public enum DriverType
    {
        Chromium,
        Firefox
    }
}