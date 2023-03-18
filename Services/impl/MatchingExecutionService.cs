using Services.@interface;

namespace Services.impl;

public class MatchingExecutionService : IMatchingExecutionService
{
    public object Execute(object matching, string objectTypeCode)
    {
        //выбрать алгоритм
        //прогнать алгоритм на матчинге
        return matching;
    }
}