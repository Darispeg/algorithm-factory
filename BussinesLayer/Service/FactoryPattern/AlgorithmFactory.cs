using BussinesLayer.Service.FactoryPattern;

using BussinesLayer.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using static BussinesLayer.Utils.DefaultData;

namespace BussinesLayer.Service
{
    /** PATRON FACTORY **/
    public class AlgorithmFactory
    {
        public IAlgorithmType GetAlgorithmType(string type)
        {
            switch (type)
            {
                case TypeAlgorithm.SOLUTION_1:
                    return new AlgorithmStringSplitting();
                case TypeAlgorithm.SOLUTION_2:
                    return new AlgorithmOddCalculator();

                default: return null;
            }
        }
    }
}
