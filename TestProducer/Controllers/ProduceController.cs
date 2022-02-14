using System;
using System.Threading.Tasks;
using MassTransit.KafkaIntegration;
using Microsoft.AspNetCore.Mvc;

namespace TestProducer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProduceController : Controller
    {
        private readonly ITopicProducer<TestMsg> _producer;

        public ProduceController(ITopicProducer<TestMsg> producer)
        {
            _producer = producer;
        }

        [HttpGet("test")]
        public async Task<IActionResult> GetTest()
        {
            var test = await Task.FromResult("test");
            return Ok(test);
        }

        [HttpGet("send")]
        public async Task<IActionResult> SendMsg()
        {
            try
            {
                await _producer.Produce(new TestMsg()
                {
                    Name = "Test"
                });
            }
            catch (Exception e)
            {
                return Ok(e);
            }
            return Ok("ok");
        }
    }
}