using MatchingLibrary.Allocation.interfaces;

namespace Models.SMP;

public class SmpMatching : ISmpAllocation<CommonAllocated, CommonAllocated>
{
    public List<CommonAllocated> men = new();
    public List<CommonAllocated> women = new();

    public void assign(CommonAllocated m, CommonAllocated w)
    {
        throw new NotImplementedException();
    }

    public void breakAssigment(CommonAllocated m, CommonAllocated w)
    {
        throw new NotImplementedException();
    }

    public CommonAllocated? getAssignedByM(CommonAllocated m)
    {
        throw new NotImplementedException();
    }

    public CommonAllocated? getAssignedByW(CommonAllocated w)
    {
        throw new NotImplementedException();
    }

    public List<CommonAllocated> getMList()
    {
        throw new NotImplementedException();
    }

    public List<CommonAllocated> getWList()
    {
        throw new NotImplementedException();
    }

    public List<CommonAllocated> getTPreferences(CommonAllocated t)
    {
        throw new NotImplementedException();
    }

    public List<CommonAllocated> getUPreferences(CommonAllocated u)
    {
        throw new NotImplementedException();
    }

    public void setTPreferences(CommonAllocated t, List<CommonAllocated> pref)
    {
        throw new NotImplementedException();
    }

    public void setTPreferencePair(CommonAllocated t, CommonAllocated u)
    {
        throw new NotImplementedException();
    }

    public void setUPreferences(CommonAllocated u, List<CommonAllocated> pref)
    {
        throw new NotImplementedException();
    }

    public void setUPreferencePair(CommonAllocated u, CommonAllocated t)
    {
        throw new NotImplementedException();
    }

    public void deleteFromTPref(CommonAllocated t, CommonAllocated u)
    {
        throw new NotImplementedException();
    }

    public void AddMan(CommonAllocated t)
    {
        men.Add(t);
    }

    public void AddWoman(CommonAllocated t)
    {
        women.Add(t);
    }

    public override string ToString()
    {
        return $"{nameof(men)}: {men}, {nameof(women)}: {women}";
    }
}