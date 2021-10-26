﻿using System;
using System.ComponentModel;
using System.Globalization;

namespace TestConfiguration
{
    public class StringToTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string stringValue)
            {
                return Type.GetType(stringValue);
            }

            return base.ConvertFrom(context, culture, value);
        }
    }
}
