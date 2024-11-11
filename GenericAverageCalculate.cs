
public class GenericList<T> {
    private List<T> values = new List<T>();

    public void Add(T value) {
        values.Add(value);
    }

    public void Remove(T value) {
        values.Remove(value);
    }

    public List<T> GetValues() {
        return values;
    }
    public double GetAverage() {
        var numericValues = values.Select(x => double.TryParse(x?.ToString(), out double value) ? value : (double?)null)
        .Where(x => x.HasValue)
        .Select(x => x.Value);
        return numericValues.Any() ? numericValues.Average() : 0;
    }

    internal void AddRange(IEnumerable<T> rangeValues)
    {
        values.AddRange(rangeValues);
    }
}