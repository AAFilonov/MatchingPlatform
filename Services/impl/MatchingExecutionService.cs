using MatchingLibrary.Algorithms.impl;
using MatchingLibrary.Algorithms.interfaces;
using MatchingLibrary.Allocation.interfaces;
using Models;
using Models.SMP;
using Services.@interface;

namespace Services.impl;

public class MatchingExecutionService : IMatchingExecutionService
{
    public object Execute(object matching, string algTypeCode)
    {
        //выбрать алгоритм
        var alg = ChooseAlg(algTypeCode);
        //прогнать алгоритм на 
        if (alg is DAAAlgorithm<CommonAllocated, CommonAllocated> oneToOneAlg)
        {
          var allocation =  (matching as SmpMatching)?.Clone();
          while (!oneToOneAlg.isFinal(allocation))
          {
              oneToOneAlg.computeIteration(allocation);
          }
          return allocation;
        }
        throw new Exception("Unexpected error during matching execution!");
    }

    private object ChooseAlg(string algTypeCode)
    {
        switch (algTypeCode)
        {
            case "MSPA":
                return new DAAAlgorithm<CommonAllocated, CommonAllocated>();
            default:
                throw new Exception(algTypeCode + " is not supported");
        }
    }
}