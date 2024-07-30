using Microsoft.AspNetCore.Mvc;
using RabbitMQMongoExample.Models;
using RabbitMQMongoExample.Services;

namespace RabbitMQMongoExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly RabbitMQService _rabbitMQService;
        private readonly MongoDBService _mongoDBService;

        public MessagesController(RabbitMQService rabbitMQService, MongoDBService mongoDBService)
        {
            _rabbitMQService = rabbitMQService;
            _mongoDBService = mongoDBService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] MessageModel message)
        {
            _rabbitMQService.SendMessage(message.Text);
            _mongoDBService.InsertMessage(message);
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var messages = _mongoDBService.GetMessages();
            return Ok(messages);
        }
    }
}
