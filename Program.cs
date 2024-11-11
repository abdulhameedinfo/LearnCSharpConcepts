using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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