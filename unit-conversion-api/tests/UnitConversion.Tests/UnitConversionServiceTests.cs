using UnitConversion.Api.Services;
using Xunit;

public class UnitConversionServiceTests
{
    private readonly UnitConversionService _svc = new UnitConversionService();

    [Fact]
    public void MeterToFoot()
    {
        var res = _svc.Convert(1.0, "meter", "foot");
        Assert.InRange(res.Result, 3.2808, 3.2809);
    }

    [Fact]
    public void CelsiusToFahrenheit()
    {
        var res = _svc.Convert(0.0, "celsius", "fahrenheit");
        Assert.Equal(32.0, Math.Round(res.Result, 6));
    }

    [Fact]
    public void KilogramToPound()
    {
        var res = _svc.Convert(1.0, "kg", "lb");
        Assert.InRange(res.Result, 2.20462, 2.20463);
    }

    [Fact]
    public void UnknownUnitThrows()
    {
        Assert.Throws<ArgumentException>(() => _svc.Convert(1, "unknown", "meter"));
    }

    [Fact]
    public void CategoryMismatchThrows()
    {
        Assert.Throws<InvalidOperationException>(() => _svc.Convert(1, "meter", "celsius"));
    }
}
