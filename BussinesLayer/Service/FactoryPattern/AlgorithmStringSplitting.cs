using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Service.FactoryPattern
{
    public class AlgorithmStringSplitting : IAlgorithmType
    {
        public string SolutionAlgorithm(string input)
        {
            int length = input.Length;
            string str = input;

            if (length % 2 == 0)
            {
                int range = (input.Length / 2) - 1;
                str = str[range..];
                str = str[..(str.Length - range)];
            }
            else
            {
                int position = length / 2;
                str = str[position].ToString();
            }

            return str;
        }
    }
}
