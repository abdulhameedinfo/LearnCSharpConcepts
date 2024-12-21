using Newtonsoft.Json;

public static class ZipIEnumerable
{
    static ZipIEnumerable()
    {
        int[] studentIds = new int[] { 1, 2, 3, 4, 5, 6 };
        string[] studentNames = ["Abdul Hameed", "Alp Arsalan", "Maria", "Zahra"];

        IEnumerable<dynamic> students = studentNames.Zip(studentIds, (name, id) => new
        {
            Id = id,
            Name = name
        });

        System.Console.WriteLine(JsonConvert.SerializeObject(students, Formatting.Indented));
    }

}