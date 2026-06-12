using UnitConversion.Api.Models;

namespace UnitConversion.Api.Services
{
    public interface IUnitConversionService
    {
        ConvertResponse Convert(double value, string fromUnit, string toUnit);
        bool TryGetSupportedUnits(out IEnumerable<string> units);
    }
}
