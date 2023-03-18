using Services.@interface;

namespace Services.impl;

public class ImportMatchingService : IImportMatchingService
{
    private readonly IFileParsingService _fileParsingService;
    private readonly IMatchingExecutionService _matchingExecutionService;

    public ImportMatchingService(IMatchingExecutionService matchingExecutionService,
        IFileParsingService fileParsingService)
    {
        _matchingExecutionService = matchingExecutionService;
        _fileParsingService = fileParsingService;
    }

    public object ImportAndExecute(MemoryStream file, string problemTypeCode, string algTypeCode)
    {
        var initialMatching = _fileParsingService.ParseTableFile(file, problemTypeCode);
        var finalMatching = _matchingExecutionService.Execute(initialMatching, algTypeCode);
        return finalMatching;
    }
}