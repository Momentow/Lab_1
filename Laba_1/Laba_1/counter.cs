using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_1
{
    class Counter
    {
        public Counter(bool randomise)
        {
            if (!(randomise))
            {
                i = 0;
            }
            else
            {
                Random rand = new Random();
                i = rand.Next(-100, 100);
            }
        }

        private int i { get; set; }

        public void Plus()
        {
            i++;
        }
        public void Minus()
        {
            i--;
        }
        public int Show()
        {
            return i;
        }
        public void GenerateJson()
        {
            string FileName = "JsonFile";
            string PrPath = Path.GetTempPath();
            
        }
    }
}
