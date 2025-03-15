
public class GenericAvereageCalculate
{
    public void CalculateAverage()
    {
        var genericList = new GenericList<object>();
        genericList.Add(1);
        genericList.Add(2);
        genericList.Add(1);
        genericList.Add("4");
        genericList.Add("8");
        genericList.AddRange(new List<object>() { 1, 2, 3, "5" });

        foreach (var item in genericList.GetValues())
        {
            Console.WriteLine(item.ToString());
        }

        System.Console.WriteLine($"Avereage of the list {genericList.GetAverage()}");
    }
}
public class GenericList<T>
{
    private List<T> values = new List<T>();

    public void Add(T value)
    {
        values.Add(value);
    }

    public void Remove(T value)
    {
        values.Remove(value);
    }

    public List<T> GetValues()
    {
        return values;
    }
    public double GetAverage()
    {
        var numericValues = values.Select(x => double.TryParse(x?.ToString(), out double value) ? value : (double?)null)
        .Where(x => x.HasValue)
        .Select(x => x != null ? x.Value : 0);
        return numericValues.Any() ? numericValues.Average() : 0;
    }

    internal void AddRange(IEnumerable<T> rangeValues)
    {
        values.AddRange(rangeValues);
    }
}