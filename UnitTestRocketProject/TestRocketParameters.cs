using NUnit.Framework;
using RocketProject;
//using Microsoft.Office.Interop.Excel;
//using Application = Microsoft.Office.Interop.Excel.Application;
using Inventor;
namespace UnitTestRocketProject
{
  
    /// <summary>
    /// Тест класса Rocket.
    /// </summary>
    [TestFixture]
    public class TestRocketParameters
    {

        /// <summary>
        /// Тестирование максимальных значений от изменяемого параметра длины ракеты
        /// </summary>
        [TestCase(15000.0, 0.4, ParameterType.RocketLength, ParameterType.SecondStageLength, Description = "Average Value for Second Stage Stabilizer Lenght")]
        [TestCase(15000.25, 0.4, ParameterType.RocketLength, ParameterType.SecondStageLength, Description = "Average Fractional Value for Second Stage Stabilizer Lenght")]
        [TestCase(9270.0, 0.4, ParameterType.RocketLength, ParameterType.SecondStageLength, Description = "Minimal Value for Second Stage Stabilizer Lenght")]
        [TestCase(18540.0, 0.4, ParameterType.RocketLength, ParameterType.SecondStageLength, Description = "Maximal Value for Second Stage Stabilizer Lenght")]
        [TestCase(15000.0, 0.4, ParameterType.RocketLength, ParameterType.FirstStageLength, Description = "Average Value for First Stage Stabilizer Lenght")]
        [TestCase(15000.25, 0.4, ParameterType.RocketLength, ParameterType.FirstStageLength, Description = "Average Fractional Value for First Stage Stabilizer Lenght")]
        [TestCase(9270.0, 0.4, ParameterType.RocketLength, ParameterType.FirstStageLength, Description = "Minimal Value for First Stage Stabilizer Lenght")]
        [TestCase(18540.0, 0.4, ParameterType.RocketLength, ParameterType.FirstStageLength, Description = "Maximal Value for First Stage Stabilizer Lenght")]
        [TestCase(580, 1, ParameterType.FirstStageDiameter, ParameterType.NozzleDiameter, Description = "Minimal Value for Nozzle Diameter")]
        [TestCase(1060, 1, ParameterType.FirstStageDiameter, ParameterType.NozzleDiameter, Description = "Maximal Value for Nozzle Diameter")]
        [TestCase(590.25, 1, ParameterType.FirstStageDiameter, ParameterType.NozzleDiameter, Description = "Average Fractional Value for Nozzle Diameter")]
        [TestCase(600.0, 1, ParameterType.FirstStageDiameter, ParameterType.NozzleDiameter, Description = "Average Value for Nozzle Diameter")]
         public void ParamneterMaxValueTest(double parameterValue, double factor, ParameterType parameterType1, ParameterType parameterType2)
        {
            var rocket = new RocketBuilder();
            rocket.RocketParameters.GetParameter(parameterType1).Value = parameterValue;
            Assert.AreEqual(rocket.RocketParameters.GetParameter(parameterType2).MaxValue, factor * parameterValue);
        }

        /// <summary>
        /// Тестирования параметра сопла от параметра диаметра первой ступени
        /// </summary>
        [TestCase(440.0, 0.5, 440, ParameterType.FirstStageDiameter, ParameterType.SecondStageDiameter, Description = "Minimal Fractional Value for Second Stage Diameter")]
        [TestCase(580.0, 0.5, 440, ParameterType.FirstStageDiameter, ParameterType.SecondStageDiameter, Description = "Optimale Fractional Value for Second Stage Diameter")]
        [TestCase(1060.0, 0.5, 440, ParameterType.FirstStageDiameter, ParameterType.SecondStageDiameter, Description = "Maximal Value for Second Stage Stabilizer Diameter")]
        [TestCase(1000.0, 0.5, 440, ParameterType.FirstStageDiameter, ParameterType.SecondStageDiameter, Description = "Average Value for Second Stage Stabilizer Diameter")]
        [TestCase(1000.25, 0.5, 440, ParameterType.FirstStageDiameter, ParameterType.SecondStageDiameter, Description = "Average Fractional Value for Second Stage Diameter")]
        public void ParamneterMaxValueTest(double parameterValue, double factor, int limit, ParameterType parameterType1, ParameterType parameterType2)
        {
            var rocket = new RocketBuilder();
            rocket.RocketParameters.GetParameter(parameterType1).Value = parameterValue;
            if (limit < factor * parameterValue)
                 Assert.AreEqual(rocket.RocketParameters.GetParameter(parameterType2).MaxValue, factor * parameterValue);
            else
                Assert.AreEqual(rocket.RocketParameters.GetParameter(parameterType2).MaxValue, limit);
        }
    }
}
