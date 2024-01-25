using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Service.FactoryPattern
{
    public class AlgorithmOddCalculator : IAlgorithmType
    {
        public string SolutionAlgorithm(string input)
        {
            string[] range = input.Split("-");

            int start = int.Parse(range[0]); 
            int finish = int.Parse(range[1]);

            List<int> odd = new List<int>();

            while (start < finish)
            {
                bool isOdd = true;

                for (int i = 2; i < start; i++)
                {
                    if (start % i == 0)
                    {
                        isOdd = false;
                        break;
                    }

                }

                if (isOdd)
                {
                    odd.Add(start);
                }

                start++;
            }

            return string.Join(", ", odd);
        }
    }
}
