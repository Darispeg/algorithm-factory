using BussinesLayer.Service;
using BussinesLayer.Service.FactoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using static BussinesLayer.Utils.DefaultData;

namespace AlgorithmTest
{
    public class FactoryPatternTest
    {
        [Fact]
        public void BuildInstance_In_Factory_ShouldReturn_Success()
        {
            // Arrange
            AlgorithmFactory algorithm = new AlgorithmFactory();

            // Act
            IAlgorithmType stringSplitting = algorithm.GetAlgorithmType(TypeAlgorithm.SOLUTION_1);

            // Assert
            Assert.NotNull(stringSplitting);
        }

        [Fact]
        public void CreateAlgorithm_StringSplitting_ShouldReturn_Success()
        {
            // Arrange
            AlgorithmFactory algorithmFactory = new AlgorithmFactory();

            // Act
            IAlgorithmType algorithm = algorithmFactory.GetAlgorithmType(TypeAlgorithm.SOLUTION_1);

            // Assert
            Assert.NotNull(algorithm);
            Assert.IsType<AlgorithmStringSplitting>(algorithm);
        }

        [Fact]
        public void CreateAlgorithm_OddCalculator_ShouldReturn_Success()
        {
            // Arrange
            AlgorithmFactory algorithmFactory = new AlgorithmFactory();

            // Act
            IAlgorithmType algorithm = algorithmFactory.GetAlgorithmType(TypeAlgorithm.SOLUTION_2);

            // Assert
            Assert.NotNull(algorithm);
            Assert.IsType<AlgorithmOddCalculator>(algorithm);
        }

        [Fact]
        public void BuildInstance_In_Factory_ShoulReturn_Null()
        {
            // Arrange
            AlgorithmFactory algorithm = new AlgorithmFactory();

            // Act
            IAlgorithmType undefinedAlgorithm = algorithm.GetAlgorithmType("INDEFINIDO");

            // Assert
            Assert.Null(undefinedAlgorithm);
        }

        [Fact]
        public void AlgorithmStringSplittingSolution_ShouldReturn_Success()
        {
            // Arrange
            AlgorithmFactory algorithm = new AlgorithmFactory();

            // Act
            IAlgorithmType stringSplitting = algorithm.GetAlgorithmType(TypeAlgorithm.SOLUTION_1);
            string result = stringSplitting.SolutionAlgorithm("n3urcaVsw4r7");

            // Assert
            Assert.Equal("aV", result);
        }

        [Fact]
        public void AlgorithmStringSplittingSolution_ShouldReturn_Success_Test2()
        {
            // Arrange
            AlgorithmFactory algorithm = new AlgorithmFactory();

            // Act
            IAlgorithmType stringSplitting = algorithm.GetAlgorithmType(TypeAlgorithm.SOLUTION_1);
            string result = stringSplitting.SolutionAlgorithm("Qc1uoTgfd");

            // Assert
            Assert.Equal("o", result);
        }

        [Fact]
        public void AlgorithmStringSplittingSolution_ShouldReturn_Unsuccess()
        {
            // Arrange
            AlgorithmFactory algorithm = new AlgorithmFactory();

            // Act
            IAlgorithmType stringSplitting = algorithm.GetAlgorithmType(TypeAlgorithm.SOLUTION_1);
            string result = stringSplitting.SolutionAlgorithm("n3urcaVsw4r7T");

            // Assert
            Assert.NotEqual("aV", result);
        }

        [Fact]
        public void AlgorithmOddCalculatorSolution_ShouldReturn_Success()
        {
            // Arrange
            AlgorithmFactory algorithm = new AlgorithmFactory();
            List<int> oddList = new List<int> { 1, 2, 3, 5, 7 };

            // Act
            IAlgorithmType oddCalculator = algorithm.GetAlgorithmType(TypeAlgorithm.SOLUTION_2);
            string result = oddCalculator.SolutionAlgorithm("1-10");
            List<int> listResult = result.Split(',').Select(int.Parse).ToList();

            // Assert
            Assert.Equal(oddList, listResult);
        }

        [Fact]
        public void AlgorithmOddCalculatorSolution_ShouldReturn_Unsuccess()
        {
            // Arrange
            AlgorithmFactory algorithm = new AlgorithmFactory();
            List<int> oddList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Act
            IAlgorithmType oddCalculator = algorithm.GetAlgorithmType(TypeAlgorithm.SOLUTION_2);
            string result = oddCalculator.SolutionAlgorithm("1-10");
            List<int> listResult = result.Split(',').Select(int.Parse).ToList();

            // Assert
            Assert.NotEqual(oddList, listResult);
        }

        [Fact]
        public void CreateAlgorithm_MultiplesInstances()
        {
            // Arrange
            AlgorithmFactory algorithmFactory = new AlgorithmFactory();

            // Act
            IAlgorithmType algorithm1 = algorithmFactory.GetAlgorithmType(TypeAlgorithm.SOLUTION_1);
            IAlgorithmType algorithm2 = algorithmFactory.GetAlgorithmType(TypeAlgorithm.SOLUTION_2);

            // Assert
            Assert.NotNull(algorithm1);
            Assert.NotNull(algorithm2);
            Assert.NotSame(algorithm1, algorithm2);
        }
    }
}
