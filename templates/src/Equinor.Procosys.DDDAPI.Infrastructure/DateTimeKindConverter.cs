﻿using System;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Equinor.Procosys.DDDAPI.Infrastructure
{
    public class DateTimeKindConverter : ValueConverter<DateTime, DateTime>
    {
        public DateTimeKindConverter() : base(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc))
        {}
    }
}
