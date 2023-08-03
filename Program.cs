using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment22
{
    internal class Program
    {
        public static void MapProperties(Source sour,Destination nation)
        {
            Type sourType = sour.GetType();
            Type nationType = nation.GetType();
            PropertyInfo[] sourProps = sourType.GetProperties();
            PropertyInfo[] nationProps = nationType.GetProperties();
            foreach (var sourProp in sourProps)
            {
                foreach (var nationProp in nationProps)
                {
                    if (sourProp.Name == nationProp.Name && sourProp.PropertyType == nationProp.PropertyType)
                    {
                        var value = sourProp.GetValue(sour);
                        nationProp.SetValue(nation, value);
                        break;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            Source sour = new Source { Id = 18, Name = "Virat Kholi", Age = 34 };
            Destination nation = new Destination { Id = 0, Name = "Virat kholi", Salary = 400000, City = "Delhi" };
            MapProperties(sour, nation);
            Console.WriteLine("Destination properties :");
            Console.WriteLine($"Id : {nation.Id}\nName : {nation.Name}\nSalary : {nation.Salary}\nCity : {nation.City}");
        }
    }
}
