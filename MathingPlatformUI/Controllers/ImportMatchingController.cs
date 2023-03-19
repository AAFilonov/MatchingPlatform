using Microsoft.AspNetCore.Mvc;
using Models.SMP;
using Newtonsoft.Json;
using Services.@interface;

namespace ASP.NETCoreWebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class ImportMatchingController : ControllerBase
{
    private readonly IImportMatchingService _importMatchingService;
    private readonly ILogger<ImportMatchingController> _logger;

    public ImportMatchingController(ILogger<ImportMatchingController> logger,
        IImportMatchingService importMatchingService)
    {
        _logger = logger;
        _importMatchingService = importMatchingService;
    }


    [HttpPost("upload")]
    public async Task<IActionResult> UploadMatchingData(IFormCollection fromData)
    {
        var file = fromData.Files[0];
        var problemType = (string?)fromData["problemType"] ?? "Unknown";
        var algType = (string?)fromData["algType"] ?? "Unknown";

        _logger.Log(LogLevel.Information, "Accepting matching upload - problem={}, alg={},  filename={}", problemType,
            algType, file.FileName);

        await using var fileStream = new MemoryStream();
        await file.CopyToAsync(fileStream);
        var matching = (SmpMatching)_importMatchingService.ImportAndExecute(fileStream, problemType, algType);

        _logger.Log(LogLevel.Information, "Matching {} was processed successfully? return JSON value", file.FileName);
        var json = JsonConvert.SerializeObject(new { data = matching }, Formatting.Indented,new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        });
        return Ok(json);
    }
}