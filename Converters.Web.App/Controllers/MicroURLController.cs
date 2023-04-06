using Converters.Domain.Abstractions.Services;
using Converters.Web.App.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;

namespace Converters.Web.App.Controllers;

public class MicroURLController : BaseController
{
    private readonly ILogger<MicroURLController> _logger;
    private readonly IMicroURLService _microURLService;

    public MicroURLController(
        ILogger<MicroURLController> logger,
        IMicroURLService microURLService)
    {
        _logger = logger;
        _microURLService = microURLService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var model = new MicroURLViewModel();

#if DEBUG
        //model.Input = "https://www.google.co.uk";
#endif

        return View(model);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> Index(string id)
    {
        if (int.TryParse(await Base64DecodeAsync(id), out var result))
        {
            var dbURL = await _microURLService.GetURLAsync(result);

            if (!string.IsNullOrWhiteSpace(dbURL?.Value))
                return Redirect(dbURL.Value);
        }

        return BadRequest();
    }

    [HttpPost]
    public async Task<IActionResult> Index(MicroURLViewModel model)
    {
        model.IsPostBack = true;

        if (ModelState.IsValid)
        {
            var baseURL = $"{Request.Scheme}://{Request.Host}/";
            var id = await _microURLService.SaveURLAsync(model.Input);

            model.Output = $"{baseURL}{await Base64EncodeAsync(id.ToString())}";
        }

        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        var model = new ErrorViewModel
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        };

        return View(model);
    }

    #region Helpers
    private Task<string> Base64EncodeAsync(string value)
    {
        var bytes = Encoding.UTF8.GetBytes(value);

        return Task.FromResult(Convert.ToBase64String(bytes).Replace("/", "\\"));
    }

    private Task<string> Base64DecodeAsync(string value)
    {
        var bytes = Convert.FromBase64String(value.Replace("\\", "/"));

        return Task.FromResult(Encoding.UTF8.GetString(bytes));
    }
    #endregion
}
