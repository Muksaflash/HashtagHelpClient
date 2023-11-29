using HashtagHelpClient.Models;
using HashtagHelpClient.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HashtagHelpClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly FunnelService _funnelService;

        public HomeController(FunnelService funnelService)
        {
            _funnelService = funnelService;
        }

        public IActionResult Index()
        {
            // Предзаполнение модели данными по умолчанию
            var defaultFormData = new FormDataModel
            {
                TableName = "1pDUBUiOVuZyxXQIofxk_6MIq5pjqHTIRK6Eulsz44yI",
                SemiAreasSheetName = "Смежные",
                AreaSheetName = "Целевые",
                ParsedSheetName = "Спарщенные",
                MinHashtagFollowers = 50,
                OutputGoogleSheet = "Выход"
            };

            return View(defaultFormData);
        }

        [HttpPost]
        public async Task<IActionResult> ProcessFormData(FormDataModel formData)
        {
            // Тут можешь добавить логику обработки данных, например, сохранение в базу данных или выполнение других операций.

            // Подготовим данные для отправки на другой сервер
            var requestData = new
            {
                tableName = formData.TableName,
                semiAreasSheetName = formData.SemiAreasSheetName,
                areaSheetName = formData.AreaSheetName,
                parsedSheetName = formData.ParsedSheetName,
                minHashtagFollowers = formData.MinHashtagFollowers,
                outputGoogleSheet = formData.OutputGoogleSheet
            };

            string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(requestData);

            // Отправим данные на другой сервер
            string result = await _funnelService.SendDataAsync(jsonData);

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
