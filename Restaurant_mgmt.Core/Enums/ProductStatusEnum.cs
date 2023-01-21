﻿using System.Text.Json.Serialization;

namespace Restaurant_mgmt.Core.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ProductStatusEnum
{
    InStock,
    OutOfStock,
    LowStock
}