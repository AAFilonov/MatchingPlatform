using MatchingLibrary.Allocation.impl;

namespace Models;

public class SMPMatchingOnSets : SmpAllocation<CommonAllocated, CommonAllocated>
{
    public SMPMatchingOnSets(List<CommonAllocated> listT, List<CommonAllocated> listU) : base(listT, listU)
    {
    }
}