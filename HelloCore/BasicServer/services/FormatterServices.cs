using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicServer.services
{
    public interface IFormatterService
    {
        string Format(string str);
    }

    public class UpperCaseFormatter : IFormatterService
    {
        public string Format(string str)
        {
            return str.ToUpper();
        }
    }

}
