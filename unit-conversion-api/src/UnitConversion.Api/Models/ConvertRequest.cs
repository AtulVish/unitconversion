namespace UnitConversion.Api.Models
{
    public class ConvertRequest
    {
        public double Value { get; set; }
        public string FromUnit { get; set; } = string.Empty;
        public string ToUnit { get; set; } = string.Empty;
    }
}
