using DIGGSCompiling.Dto.DIGGS;
using DIGGSCompiling.Services.Contract;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Xml;

namespace DIGGSCompiling.Controllers
{
    [Route("api/[controller]")]
    public class DIGGSCompilingController : Controller
    {
        private readonly IDIGGSCompilingAppService _iDIGGSCompilingAppService;

        public DIGGSCompilingController(IDIGGSCompilingAppService iDIGGSCompilingAppService)
        {
            _iDIGGSCompilingAppService = iDIGGSCompilingAppService;
        }

        [HttpPost]
        public string Compiling(HttpRequestMessage request)
        {
            var doc = new XmlDocument();
            doc.Load(request.Content.ReadAsStreamAsync().Result);
            return doc.DocumentElement.OuterXml;
        }
    }
}
