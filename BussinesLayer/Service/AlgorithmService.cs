using BussinesLayer.Service;
using BussinesLayer.Service.FactoryPattern;
using BussinesLayer.DTO;
using DataLayer;
using DataLayer.Entities;
using DataLayer.Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BussinesLayer.Utils.DefaultData;

namespace BussinesLayer.Service
{
    public class AlgorithmService : IAlgorithmService
    {
        private readonly IRepository<ApplicationDbContext, RequestEntity> _requestRepository;

        public AlgorithmService(IRepository<ApplicationDbContext, RequestEntity> requestRepository)
        {
            this._requestRepository = requestRepository;
        }

        public async Task<string> StringSplitting(RequestSolution request)
        {
            var entity = new RequestEntity
            {
                InputRequest = $"url: api/solution/string-splitting; input: {request.Input}",
                DateRequest = DateTime.Now.ToString(),
                Response = string.Empty,
                DateResponse = new DateTime().ToString(),
                User = request.User
            };

            AlgorithmFactory algorithm = new AlgorithmFactory();
            IAlgorithmType stringSplitting = algorithm.GetAlgorithmType(TypeAlgorithm.SOLUTION_1);

            string result = stringSplitting.SolutionAlgorithm(request.Input);

            entity.DateResponse = DateTime.Now.ToString();
            entity.Response = result;

            await _requestRepository.AddAsync(entity);

            return result;
        }

        public async Task<List<int>> oddCalculator(RequestSolution request)
        {
            var entity = new RequestEntity
            {
                InputRequest = $"url: api/solution/odd-calculator; input: {request.Input}",
                DateRequest = DateTime.Now.ToString(),
                Response = string.Empty,
                DateResponse = new DateTime().ToString(),
                User = request.User
            };

            AlgorithmFactory algorithm = new AlgorithmFactory();
            IAlgorithmType oddCalculator = algorithm.GetAlgorithmType(TypeAlgorithm.SOLUTION_2);

            string result = oddCalculator.SolutionAlgorithm(request.Input);

            entity.DateResponse = DateTime.Now.ToString();
            entity.Response = result;

            await _requestRepository.AddAsync(entity);

            return result.Split(',').Select(int.Parse).ToList();
        }

        public async Task<List<Solution>> getAllSolutions()
        {
            var result = await _requestRepository.AllAsync();

            var solutions = result.Select(s => new Solution
            {
                User = s.User,
                InputRequest = s.InputRequest,
                DateRequest = s.DateRequest,
                Response = s.Response,
                DateResponse = s.DateResponse
            }).ToList();

            return solutions;
        }
    }
}
