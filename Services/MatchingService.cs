using MatchingLibrary.Algorithms.impl;
using MatchingLibrary.Utils;

namespace Services;

public class MatchingService
{
    private DAAAlgorithm<SimpleAllocated, SimpleAllocated> alg = new DAAAlgorithm<SimpleAllocated, SimpleAllocated>();

    public string СomputeMatching(Object allocation)
    {
        //выполнить матчинг уеликом
        return "Matching done!";
    }
    public string СomputeMatchingIteration(Object allocation)
    {
        //выполнить итерацию матчинга
        return "Matching done!";
    }
    
}