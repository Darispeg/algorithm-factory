using BussinesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Service
{
    public interface IAlgorithmService
    {
        Task<string> StringSplitting(RequestSolution input);
        Task<List<int>> oddCalculator(RequestSolution input);
    }
}
