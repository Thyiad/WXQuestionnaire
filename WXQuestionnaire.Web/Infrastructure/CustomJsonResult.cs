using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WXQuestionnaire.Web.Infrastructure
{
    public class CustomJsonResult : ActionResult
    {
        public object Data { get; set; }
        public Encoding ContentEncoding { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            var response = context.HttpContext.Response;
            response.ContentType = "application/json";
            if (ContentEncoding != null)
                response.ContentEncoding = ContentEncoding;

            if (Data == null) return;

            var writer = new JsonTextWriter(response.Output);
            var serializer = JsonSerializer.Create();
            serializer.Serialize(writer, Data);
            writer.Flush();
        }
    }
}
