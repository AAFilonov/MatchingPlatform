using MatchingLibrary.Allocation.interfaces;

namespace Models.SMP;

public class SmpMatching : ISmpAllocation<CommonAllocated, CommonAllocated>
{
    public List<CommonAllocated> men = new();
    public List<CommonAllocated> women = new();
    public string problemType { get; set; }

    public void assign(CommonAllocated m, CommonAllocated w)
    {
        m.assigned = w;
        w.assigned = m;
    }

    public void breakAssigment(CommonAllocated m, CommonAllocated w)
    {
        m.assigned = null;
        w.assigned = null;
    }

    public CommonAllocated? getAssignedByM(CommonAllocated m)
    {
        return m.assigned;
    }

    public CommonAllocated? getAssignedByW(CommonAllocated w)
    {
        return w.assigned;
    }

    public List<CommonAllocated> getMList()
    {
        return men;
    }

    public List<CommonAllocated> getWList()
    {
        return women;
    }

    public List<CommonAllocated> getTPreferences(CommonAllocated t)
    {
        return t.preferences;
    }

    public List<CommonAllocated> getUPreferences(CommonAllocated u)
    {
        return u.preferences;
    }

    public void setTPreferences(CommonAllocated t, List<CommonAllocated> pref)
    {
        t.preferences = pref;
    }

    public void setTPreferencePair(CommonAllocated t, CommonAllocated u)
    {
        t.preferences.Add(u);
    }

    public void setUPreferences(CommonAllocated u, List<CommonAllocated> pref)
    {
        u.preferences = pref;
    }

    public void setUPreferencePair(CommonAllocated u, CommonAllocated t)
    {
        u.preferences.Add(t);
    }

    public void deleteFromTPref(CommonAllocated t, CommonAllocated u)
    {
        t.preferences.Remove(u);
    }

    public SmpMatching Clone()
    {
        var copy = new SmpMatching();
        men.ForEach(val => copy.AddMan(val));
        women.ForEach(val => copy.AddWoman(val));
        return copy;
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