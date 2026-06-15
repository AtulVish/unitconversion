using System;
using System.Collections.Generic;

namespace UnitConversion.Api.Services
{
    public enum UnitCategory { Length, Weight, Temperature }

    public record UnitDefinition(
        string Name,
        UnitCategory Category,
        // For linear conversions: factor to convert to base unit (e.g., meters)
        double? ToBaseFactor,
        // Optional custom converter for non-linear conversions (temperature)
        Func<double, double>? ToBaseFunc,
        Func<double, double>? FromBaseFunc
    );

    public static class UnitDefinitions
    {
        // Base units: Length -> meter, Weight -> kilogram, Temperature -> Celsius
        public static readonly IReadOnlyDictionary<string, UnitDefinition> Units =
            new Dictionary<string, UnitDefinition>(StringComparer.OrdinalIgnoreCase)
            {
                // Length (base: meter)
                ["meter"] = new UnitDefinition("meter", UnitCategory.Length, 1.0, null, null),
                ["m"] = new UnitDefinition("m", UnitCategory.Length, 1.0, null, null),
                ["kilometer"] = new UnitDefinition("kilometer", UnitCategory.Length, 1000.0, null, null),
                ["km"] = new UnitDefinition("km", UnitCategory.Length, 1000.0, null, null),
                ["centimeter"] = new UnitDefinition("centimeter", UnitCategory.Length, 0.01, null, null),
                ["cm"] = new UnitDefinition("cm", UnitCategory.Length, 0.01, null, null),
                ["inch"] = new UnitDefinition("inch", UnitCategory.Length, 0.0254, null, null),
                ["in"] = new UnitDefinition("in", UnitCategory.Length, 0.0254, null, null),
                ["foot"] = new UnitDefinition("foot", UnitCategory.Length, 0.3048, null, null),
                ["ft"] = new UnitDefinition("ft", UnitCategory.Length, 0.3048, null, null),

                // Weight (base: kilogram)
                ["kilogram"] = new UnitDefinition("kilogram", UnitCategory.Weight, 1.0, null, null),
                ["kg"] = new UnitDefinition("kg", UnitCategory.Weight, 1.0, null, null),
                ["gram"] = new UnitDefinition("gram", UnitCategory.Weight, 0.001, null, null),
                ["g"] = new UnitDefinition("g", UnitCategory.Weight, 0.001, null, null),
                ["pound"] = new UnitDefinition("pound", UnitCategory.Weight, 0.45359237, null, null),
                ["lb"] = new UnitDefinition("lb", UnitCategory.Weight, 0.45359237, null, null),
                ["ounce"] = new UnitDefinition("ounce", UnitCategory.Weight, 0.0283495231, null, null),
                ["oz"] = new UnitDefinition("oz", UnitCategory.Weight, 0.0283495231, null, null),

                // Temperature (base: Celsius)
                ["celsius"] = new UnitDefinition("celsius", UnitCategory.Temperature, null,
                    ToBaseFunc: v => v, FromBaseFunc: v => v),
                ["c"] = new UnitDefinition("c", UnitCategory.Temperature, null,
                    ToBaseFunc: v => v, FromBaseFunc: v => v),

                ["fahrenheit"] = new UnitDefinition("fahrenheit", UnitCategory.Temperature, null,
                    ToBaseFunc: v => (v - 32.0) * 5.0 / 9.0,
                    FromBaseFunc: v => (v * 9.0 / 5.0) + 32.0),
                ["f"] = new UnitDefinition("f", UnitCategory.Temperature, null,
                    ToBaseFunc: v => (v - 32.0) * 5.0 / 9.0,
                    FromBaseFunc: v => (v * 9.0 / 5.0) + 32.0),

                ["kelvin"] = new UnitDefinition("kelvin", UnitCategory.Temperature, null,
                    ToBaseFunc: v => v - 273.15,
                    FromBaseFunc: v => v + 273.15),
                ["k"] = new UnitDefinition("k", UnitCategory.Temperature, null,
                    ToBaseFunc: v => v - 273.15,
                    FromBaseFunc: v => v + 273.15),
            };
    }
}