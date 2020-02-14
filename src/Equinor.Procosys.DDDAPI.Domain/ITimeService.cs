using System;

namespace Equinor.Procosys.DDDAPI.Domain
{
    public interface ITimeService
    {
        DateTime GetCurrentTimeUtc();
    }
}
