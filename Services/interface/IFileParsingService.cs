namespace Services.@interface;

public interface IFileParsingService
{
    public object ParseTableFile(MemoryStream file, string problemCode);
}