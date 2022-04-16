using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloMVC.Data
{
    public class MultiplicationInfo
    {
        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public int Result { get; set; }
    }

    public class MultiplicationTable
    {
        public int Number { get; set; }
        public int HightestMultiple { get; set; }
        public List<MultiplicationInfo> Result { get; set; }
    }

    public class MultiplicationTableGenerator : IMultiplicationTableGenerator
    {
        public MultiplicationTable Generate(int number, int highestMultiple = 10)
        {
            var table = new MultiplicationTable() { Number = number, HightestMultiple = highestMultiple };
            table.Result = new List<MultiplicationInfo>();
            for (int i = 1; i <= highestMultiple; i++)
                table.Result.Add(new MultiplicationInfo()
                {
                    Number1 = number,
                    Number2 = i,
                    Result = number * i
                });

            return table;
        }
    }
}




