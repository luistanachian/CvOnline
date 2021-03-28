using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Cv.Net5.API
{
    public class ExceptionManagerFilter : IExceptionFilter
    {
        private readonly IWebHostEnvironment host;
        private readonly IModelMetadataProvider model;
        public ExceptionManagerFilter(IWebHostEnvironment host, IModelMetadataProvider model)
        {
            this.host = host;
            this.model = model;
        }
        public void OnException(ExceptionContext context)
        {
            context.ExceptionHandled = true;
            context.Result = new JsonResult($"Fallo la app {host.ApplicationName}, Error: {context.Exception.Message}");
        }
    }
}