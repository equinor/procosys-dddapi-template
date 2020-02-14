using Equinor.Procosys.DDDAPI.Domain;
using Equinor.Procosys.DDDAPI.Domain.Events;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Equinor.Procosys.DDDAPI.Infrastructure.Tests
{
    public class ContextHelper
    {
        public ContextHelper()
        {
            DbOptions = new DbContextOptions<DDDAPIContext>();
            EventDispatcherMock = new Mock<IEventDispatcher>();
            PlantProviderMock = new Mock<IPlantProvider>();
            ContextMock = new Mock<DDDAPIContext>(DbOptions, EventDispatcherMock.Object, PlantProviderMock.Object);
        }

        public DbContextOptions<DDDAPIContext> DbOptions { get; }
        public Mock<IEventDispatcher> EventDispatcherMock { get; }
        public Mock<IPlantProvider> PlantProviderMock { get; }
        public Mock<DDDAPIContext> ContextMock { get; }
    }
}
