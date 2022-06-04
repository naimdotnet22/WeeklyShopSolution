using MassTransit;
using System.Threading.Tasks;
using zModelEntities.Models.NotificationModels;

namespace ProductApp.Consumers
{
    public class NotificationConsumer : IConsumer<Notificattion>
    {
        public Task Consume(ConsumeContext<Notificattion> context)
        {
            var msg = context.Message;
            return Task.CompletedTask;
        }
    }
}
