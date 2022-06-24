using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Laba_1
{
    class Program
    { 
        class Counter
        {
            public Counter(bool randomise, int a)
            {
                if (!(randomise))
                {
                    count = a;
                    counter = count;
                }
                else
                {
                    Random rand = new Random();
                    count = rand.Next(-100, 100);
                    counter = count;
                }
            }

            private static int count = 4;

            public int counter = count;

            public void Plus()
            {
                count++;
                counter = count;
            }
            public void Minus()
            {
                count--;
                counter = count;
            }
            public int Show()
            {
                return count;
            }
            public void GenerateJson(string FileName)
            {
                
                string jsonCounter = JsonConvert.SerializeObject(this);
                Console.WriteLine(jsonCounter);
                File.WriteAllText(FileName, jsonCounter);
            }
            public static Counter MakeClassJson(string FileName)
            {
                string jsonStr = File.ReadAllText(FileName);
                dynamic json = JsonConvert.DeserializeObject(jsonStr);
                int a = json.counter;
                Counter coun = new Counter(false, a);
                return coun;
            }
        }
        static void Main(string[] args)
        {
            Counter counter = new Counter(true, 0);
            Console.WriteLine($"First random counter is {counter.Show()}");
            Console.WriteLine($"Next the counter ({counter.Show()}) minus 1");
            counter.Minus();
            Console.WriteLine($"Now the counter is {counter.Show()}");
            Console.WriteLine($"Next counter ({counter.Show()}) plus 1");
            counter.Plus();
            Console.WriteLine($"Now the counter is {counter.Show()}");
            
            string FileName = "C:\\Университет\\II семестр\\ОП 2\\Проекты\\Laba_1\\JsonFile.json";
            counter.GenerateJson(FileName);
            Counter coun = Counter.MakeClassJson(FileName);
            string ara = JsonConvert.SerializeObject(coun);
            Console.WriteLine("New Deserialised object is " + ara);
        }
    }
}