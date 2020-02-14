using System;
using Equinor.Procosys.DDDAPI.Domain;

namespace Equinor.Procosys.DDDAPI.WebApi.Misc
{
    public class TimeService : ITimeService
    {
        public DateTime GetCurrentTimeUtc() => DateTime.UtcNow;
    }
}
