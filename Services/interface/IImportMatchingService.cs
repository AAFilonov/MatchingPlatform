namespace Services.@interface;

public interface IImportMatchingService
{
    public object ImportAndExecute(MemoryStream file, string problemTypeCode, string algTypeCode);
}