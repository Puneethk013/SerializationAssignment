using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
namespace SerializationAssignment
{
    [Serializable]
    class AgeCal
    {
        public int yearOfBirth;
        [NonSerialized] public int age;

        public void AgeCalculator()
        {
            age = DateTime.Now.Year - yearOfBirth;
        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            AgeCal ac = new AgeCal();
            Console.WriteLine("enter the year of birth : ");
            ac.yearOfBirth = int.Parse(Console.ReadLine());
            //ac.AgeCalculator();
            FileStream fs = new FileStream(@"agecal.txt",FileMode.OpenOrCreate,FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs,ac);
            fs.Seek(0, SeekOrigin.Begin);
            AgeCal res = (AgeCal)bf.Deserialize(fs);
            res.AgeCalculator();
            Console.WriteLine("Current Age is: "+res.age);
            Console.ReadLine();
        }
    }
}
