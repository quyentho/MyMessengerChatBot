using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessengerBot.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MessengerBot.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WebHookController : ControllerBase
    {
        private const string VerifyToken = "hello";
        private const string PageToken = "EAAFHrBoiOQsBAHpe8N1Ej91ZBOEvuBmdOcNoArFeDWEMOrJ136l8ERcbI5O3HZBRJpEZAl27tg0gOEdl03JXZCk2l0L8YGZCqZC7B6aixJYFPoKvA6lfU8rwj8uXKWDnBHDFcBOaBjVAAQaj78xtOZCwwuX3lpYeOwwMhvnwnm6WQZDZD";
        private const string AppSecret = "df2cb148626ad0d9458258e13153bb43";

        [HttpGet]
        public ActionResult Get()
        {
            var requestQueries = Request.Query;

            if (requestQueries["hub.verify_token"] == VerifyToken && requestQueries["hub.mode"] == "subscribe")
            {
                return Ok(requestQueries["hub.challenge"]);
            }

            return Unauthorized();
        }

        [HttpPost]
        public ActionResult Post(WebhookModel webhookModel)
        {
            Console.WriteLine(webhookModel);

            return Ok(webhookModel);
            //WebhookModel requestBody = JsonConvert.DeserializeObject<WebhookModel>(Request.Body.ToString());

            //if (requestBody._object.Equals("page"))
            //{
            //    foreach (var entry in requestBody.entry)
            //    {
            //        var webhookEvent = entry.messaging.FirstOrDefault();
                    
            //        Console.WriteLine(webhookEvent);
            //    }

            //    return Ok("EVENT_RECEIVED");
            //}

            //return NotFound();

        }
    }
}


