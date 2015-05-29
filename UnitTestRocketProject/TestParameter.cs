using NUnit.Framework;
using RocketProject;

namespace UnitTestRocketProject
{
     ///<summary>
     ///Тест класса Параметр.
     ///</summary>
    [TestFixture]
    public class TestParameter
    {
        /// <summary>
        /// Тестирование валидного, минимального и максимального значений класса Parameter.
        /// </summary>
        /// <param name="newValue"></param>
        /// <param name="expectedValue"></param>
        [TestCase(5,5)]
        [TestCase(1,3)]
        [TestCase(18,12)]
        public void ParameterTest(double newValue, double expectedValue)
        {
            double value = 5;
            double minValue = 3;
            double maxValue = 12;
            
            Parameter parameter = new Parameter(value, minValue, maxValue);
            parameter.Value = newValue;
            
            Assert.AreEqual(expectedValue, parameter.Value);
        }
    }
}
