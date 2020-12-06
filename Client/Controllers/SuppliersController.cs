using Client.Base;
using Client.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Client.Controllers
{
    public class SuppliersController : Controller
    {
        BaseAddress baseAddress = new BaseAddress();

        // GET: Suppliers
        public async Task<ActionResult> Index()
        {
            IEnumerable<SupplierVM> suppliers = null;

            using (var client = new HttpClient())
            {
                // define URL API
                client.BaseAddress = new Uri(baseAddress.Url());

                // define Request
                HttpResponseMessage responseTask = await client.GetAsync("Suppliers");


                if (responseTask.IsSuccessStatusCode)
                {
                    var readTask = responseTask.Content.ReadAsStringAsync().Result;
                    suppliers = JsonConvert.DeserializeObject<IEnumerable<SupplierVM>>(readTask);
                }
                else
                {
                    suppliers = Enumerable.Empty<SupplierVM>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }   
            return View(suppliers);
        }

        public JsonResult Create(SupplierVM supplierVM)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress.Url());
                var myContent = JsonConvert.SerializeObject(supplierVM);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var responseTask = client.PostAsync("Suppliers", byteContent).Result;
                return Json(responseTask);
            }
        }

        // Edit 
        public async Task<ActionResult> Index()
        {
            IEnumerable<SupplierVM> suppliers = null;

            using (var client = new HttpClient())
            {
                // define URL API
                client.BaseAddress = new Uri(baseAddress.Url());

                // define Request
                HttpResponseMessage responseTask = await client.GetAsync("Suppliers");


                if (responseTask.IsSuccessStatusCode)
                {
                    var readTask = responseTask.Content.PutAsync().Result;
                    suppliers = JsonConvert.DeserializeObject<IEnumerable<SupplierVM>>(readTask);
                }
                else
                {
                    suppliers = Enumerable.Empty<SupplierVM>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(suppliers);
        }

        // Delete
        public async Task<ActionResult> Index()
        {
            IEnumerable<SupplierVM> suppliers = null;

            using (var client = new HttpClient())
            {
                // define URL API
                client.BaseAddress = new Uri(baseAddress.Url());

                // define Request
                HttpResponseMessage responseTask = await client.GetAsync("Suppliers");


                if (responseTask.IsSuccessStatusCode)
                {
                    var readTask = responseTask.Content.DeleteAsync().Result;
                    suppliers = JsonConvert.DeserializeObject<IEnumerable<SupplierVM>>(readTask);
                }
                else
                {
                    suppliers = Enumerable.Empty<SupplierVM>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(suppliers);
        }
    }