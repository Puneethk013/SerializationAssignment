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
    class AgeCal1
    {
        public int yearOfBirth;
        public int monthOfBirth;
        [NonSerialized] public int ageYear;
        [NonSerialized] public int ageMonth;
        public void AgeCalculator()
        {
            if (monthOfBirth <= DateTime.Now.Month) {
                ageYear = DateTime.Now.Year - yearOfBirth;
                ageMonth = DateTime.Now.Month - monthOfBirth;
            }
            else
            {
                ageYear = DateTime.Now.Year - yearOfBirth - 1;
                ageMonth =12-monthOfBirth+DateTime.Now.Month;
            }
        }

    }
    class Program1
    {
        static void Main(string[] args)
        {
            AgeCal1 ac = new AgeCal1();
            Console.WriteLine("enter the year of birth : ");
            ac.yearOfBirth = int.Parse(Console.ReadLine());
            Console.WriteLine("enter the month of Birth: ");
            ac.monthOfBirth = int.Parse(Console.ReadLine());
            //ac.AgeCalculator();
            FileStream fs = new FileStream(@"newagecal.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, ac);
            fs.Seek(0, SeekOrigin.Begin);
            AgeCal1 res = (AgeCal1)bf.Deserialize(fs);
            res.AgeCalculator();
            Console.WriteLine("Current Age is: " + res.ageYear+" Years "+res.ageMonth+" Months");
            Console.ReadLine();
        }
    }
}
