using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Restaurant_mgmt.Core.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum QuantityUnitEnum
{
    // for food
    [EnumMember(Value = "g")]
    Grams,
    [EnumMember(Value = "kg")]
    Kilograms,
    [EnumMember(Value = "oz")]
    Ounces,
    [EnumMember(Value = "lb")]
    Pounds,
    // for drinks
    [EnumMember(Value = "ml")]
    Milliliters,
    [EnumMember(Value = "cl")]
    Centiliters,
    [EnumMember(Value = "l")]
    Liters,
    [EnumMember(Value = "fl oz")]
    FluidOunces,
    // add other units as needed
}