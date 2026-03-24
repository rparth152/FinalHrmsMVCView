using HrmsMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HrmsMvc.Controllers
{
    public class ReportController : Controller
    {
        HttpClient client;
        public ReportController() {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            client = new HttpClient(handler);

        }
        public IActionResult Index()
        {
            var empobj = new EstatusDTO();
            string url = "https://localhost:7247/api/Reports/empstatus";
            HttpResponseMessage res = client.GetAsync(url).Result;
            if (res.IsSuccessStatusCode) { 
                var json= res.Content.ReadAsStringAsync().Result;
                var obj = JsonConvert.DeserializeObject<EstatusDTO>(json);
                if (obj != null) {
                    empobj = obj;
                }
            }
            
            return View(empobj);

        }
        public IActionResult FEmp()
        {
            var empobj = new EmpDTO();
            string url = "https://localhost:7247/api/Reports/fetchemp";
            HttpResponseMessage res = client.GetAsync(url).Result;
            if (res.IsSuccessStatusCode)
            {
                var json = res.Content.ReadAsStringAsync().Result;
                var obj = JsonConvert.DeserializeObject<EmpDTO>(json);
                if (obj != null)
                {
                    empobj = obj;
                }
            }
            TempData["EmpObj"]= empobj;
            return View(empobj);
        }
    }
}
