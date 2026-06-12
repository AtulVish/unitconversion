namespace UnitConversion.Api.Models
{
    public class ConvertResponse
    {
        public double Input { get; set; }
        public string FromUnit { get; set; } = string.Empty;
        public double Result { get; set; }
        public string ToUnit { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
    }
}
