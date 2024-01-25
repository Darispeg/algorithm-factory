using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Service.FactoryPattern
{
    public interface IAlgorithmType
    {
        string SolutionAlgorithm(string input); 
    }
}
