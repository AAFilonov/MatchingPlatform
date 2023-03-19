namespace Models;

public class CommonAllocated
{
    public CommonAllocated(string name)
    {
        this.name = name;
    }

    public CommonAllocated(string name, List<string> preferences)
    {
        this.name = name;
        preferences.ForEach(val => this.preferences.Add(new CommonAllocated(val)));
    }

    public string name { get; set; }
    public CommonAllocated? assigned { get; set; }
    public string assignedName {
        get
        {
            return assigned?.name ?? "";
        }
    }
    public List<CommonAllocated> preferences { get; set; } = new();

    public override string ToString()
    {
        return $"{nameof(name)}: {name}, {nameof(assigned)}: {assigned}, {nameof(preferences)}: {preferences}";
    }
}