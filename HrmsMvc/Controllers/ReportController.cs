using HrmsMvc.Models;
using HrmsMvc.services;
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

            if (res.IsSuccessStatusCode)
            {
                var json = res.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<ApiResponse<EstatusDTO>>(json);
                var obj = result?.Data;

                if (obj != null)
                {
                    empobj = obj;
                }
            }
            var empList = new List<EmpDTO>();
            string url2 = "https://localhost:7247/api/Reports/fetchemp";
            HttpResponseMessage res2 = client.GetAsync(url2).Result;

            if (res2.IsSuccessStatusCode)
            {
                var json2 = res2.Content.ReadAsStringAsync().Result;
                var result1 = JsonConvert.DeserializeObject<ApiResponse<List<EmpDTO>>>(json2);
                var obj2 = result1?.Data;
                if (obj2 != null)
                {
                    empList = obj2;
                }
            }

            TempData["EmpObj"] = JsonConvert.SerializeObject(empList);

            return View(empobj);
        }

        
        //public IActionResult FEmp()
        //{
        //    var empobj = new EmpDTO();
        //    string url = "https://localhost:7247/api/Reports/fetchemp";
        //    HttpResponseMessage res = client.GetAsync(url).Result;
        //    if (res.IsSuccessStatusCode)
        //    {
        //        var json = res.Content.ReadAsStringAsync().Result;
        //        var obj = JsonConvert.DeserializeObject<EmpDTO>(json);
        //        if (obj != null)
        //        {
        //            empobj = obj;
        //        }
        //    }
        //    TempData["EmpObj"]= empobj;
        //    return View(empobj);
        //}
    }
}
