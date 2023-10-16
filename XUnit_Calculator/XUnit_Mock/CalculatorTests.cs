using CalculatorLib;
using Moq;

namespace XUnit_Mock
{
    public class CalculatorTests
    {
        public Mock<ICalculator> calc = new Mock<ICalculator>();
        public Calculator calculator = new Calculator(); 

        #region Without Mock
        [Fact]
        public void AddTest()
        {
            Assert.Equal(5, calculator.Add(2, 3));
        }

        [Fact]
        public void MultiplyTest()
        {
            Assert.Equal(6, calculator.Multiply(2, 3));
        }

        [Fact]
        public void DivideTest()
        {
            Assert.Equal(6, calculator.Divide(12, 2));
        }

        [Fact] 
        public void SubtractTest()
        {
            //var calculator = new Calculator();
            Assert.Equal(5, calculator.Substract(10, 5));
        }
        #endregion

        #region With Mock
        [Fact]
        public void AddTestMock()
        {
            //Arrange
            calc.Setup(x => x.Add(2, 2)).Returns(4);
            //Act
            var result = calc.Object.Add(2, 2);
            //Assert
            Assert.Equal(4, result);
        }

        [Fact]
        public void MultiplyTestMock()
        {
            //Arrange
            calc.Setup(x => x.Multiply(2, 4)).Returns(8);
            //Act
            var result = calc.Object.Multiply(2, 4);
            //Assert
            Assert.Equal(8, result);
        }

        [Fact]
        public void DivideTestMock()
        {
            //Arrange
            calc.Setup(x => x.Divide(10, 2)).Returns(5);
            //Act
            var result = calc.Object.Divide(10, 2);
            //Assert
            Assert.Equal(5, result);
        }

        [Fact]
        public void SubstractTestMock()
        {
            //Arrange
            calc.Setup(x => x.Substract(13, 3)).Returns(10);
            //Act
            var result = calc.Object.Substract(13, 3);
            //Assert
            Assert.Equal(10, result);
        }
        #endregion
    }
}