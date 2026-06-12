using System;
using System.Collections.Generic;
using UnitConversion.Api.Models;

namespace UnitConversion.Api.Services
{
    public class UnitConversionService : IUnitConversionService
    {
        public ConvertResponse Convert(double value, string fromUnit, string toUnit)
        {
            if (!UnitDefinitions.Units.TryGetValue(fromUnit, out var fromDef))
                throw new ArgumentException($"Unknown unit: {fromUnit}");

            if (!UnitDefinitions.Units.TryGetValue(toUnit, out var toDef))
                throw new ArgumentException($"Unknown unit: {toUnit}");

            if (fromDef.Category != toDef.Category)
                throw new InvalidOperationException($"Cannot convert between categories: {fromDef.Category} -> {toDef.Category}");

            double baseValue;

            // If unit uses function-based conversion (temperature)
            if (fromDef.ToBaseFunc is not null)
            {
                baseValue = fromDef.ToBaseFunc(value);
            }
            else if (fromDef.ToBaseFactor is not null)
            {
                baseValue = value * fromDef.ToBaseFactor.Value;
            }
            else
            {
                throw new InvalidOperationException("Invalid unit definition for fromUnit");
            }

            double result;
            if (toDef.FromBaseFunc is not null)
            {
                result = toDef.FromBaseFunc(baseValue);
            }
            else if (toDef.ToBaseFactor is not null)
            {
                result = baseValue / toDef.ToBaseFactor.Value;
            }
            else
            {
                throw new InvalidOperationException("Invalid unit definition for toUnit");
            }

            return new ConvertResponse
            {
                Input = value,
                FromUnit = fromDef.Name,
                Result = result,
                ToUnit = toDef.Name,
                Category = fromDef.Category.ToString()
            };
        }

        public bool TryGetSupportedUnits(out IEnumerable<string> units)
        {
            units = UnitDefinitions.Units.Keys;
            return true;
        }
    }
}
