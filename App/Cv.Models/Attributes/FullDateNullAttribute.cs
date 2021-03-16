﻿using Cv.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace Cv.Models.Attributes
{
    public class FullDateNullAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var fecha = value as string;
            if (fecha == null)
                return true;

            return DateTime.TryParseExact(fecha, ValuesReadonly.FormatDate_yyyyMMdd_hhmmss, null, System.Globalization.DateTimeStyles.None, out DateTime date);
        }
    }
}