using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using zModelEntities.Models.NotificationModels;

namespace EmployeeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IBus _bus;
        public NotificationController(IBus bus)
        {
            _bus = bus;
        }

        [HttpPost("Notification")]
        public async Task<IActionResult> Notification(Notificattion notificattion)
        {
            if (notificattion != null)
            {
                Uri uri = new Uri("rabbitmq://localhost/notifyQueue");
                var endPoint = await _bus.GetSendEndpoint(uri);
                await endPoint.Send(notificattion);
                return Ok();
            }
            return BadRequest();
        }
    }
}
