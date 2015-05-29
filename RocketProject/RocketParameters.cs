using System;
using System.Collections.Generic;

namespace RocketProject
{
    /// <summary>
    /// Параметры вала.
    /// </summary>
    public class RocketParameters
    {

        #region Designer
        /// <summary>
        /// Ассоциативный массив, отображающий тип параметра на значение параметра.
        /// </summary>
        private readonly Dictionary<ParameterType, Parameter> _parameters = new Dictionary<ParameterType, Parameter>();

        /// <summary>
        /// Начало валидации
        /// </summary>
        private bool _validationStarted;


        /// <summary>
        /// Конструктор.
        /// </summary>
        public RocketParameters()
        {
            _parameters[ParameterType.RocketLength] = new Parameter(9270, 9270, 18540);
            _parameters[ParameterType.ConeLength] = new Parameter(927, 927, 927);
            _parameters[ParameterType.SecondStageLength] = new Parameter(3708, 3708, 7416);
            _parameters[ParameterType.FirstStageLength] = new Parameter(3708, 3708, 7416);
            _parameters[ParameterType.SecondStageDiameter] = new Parameter(220, 220, 440);
            _parameters[ParameterType.FirstStageDiameter] = new Parameter(580, 580, 1060);
            _parameters[ParameterType.SecondStabilizerSpan] = new Parameter(905, 905, 1360);
            _parameters[ParameterType.FirstStabilizerSpan] = new Parameter(1810, 1810, 3620);
            _parameters[ParameterType.SecondStabilizerCount] = new Parameter(4, 2, 8);
            _parameters[ParameterType.FirstStabilizerCount] = new Parameter(4, 2, 8);
            _parameters[ParameterType.StabilizerWidth] = new Parameter(8, 8, 16);
            _parameters[ParameterType.NozzleDiameter] = new Parameter(464, 464, 848);
           

            // Для каждого параметра.
            foreach (var p in _parameters.Values)
            {
                // Подключаем обработчик OnParameterChanged к событию ParameterChanged. 
                p.ParameterChanged += OnParameterChanged;
            }
        }

        #endregion

        #region Validate and math
        /// <summary>
        /// Получить значение параметра по типу параметра.
        /// </summary>
        /// <param name="type">Тип параметра.</param>
        /// <returns>Значение параметра.</returns>
        public Parameter GetParameter(ParameterType type)
        {
            return _parameters[type];
        }

        /// <summary>
        /// Валидация параметров. Привидение параметра к допустимому значению.
        /// </summary>
        private void Validate()
        {
            if (_validationStarted)
                return;
            _validationStarted = true;

            _parameters[ParameterType.SecondStageLength].MaxValue = 0.4 *_parameters[ParameterType.RocketLength].Value;
            _parameters[ParameterType.FirstStageLength].MaxValue = 0.4 * _parameters[ParameterType.RocketLength].Value;
            _parameters[ParameterType.SecondStageDiameter].MaxValue = 
                Math.Max(440,0.5*_parameters[ParameterType.FirstStageDiameter].Value);
            _parameters[ParameterType.NozzleDiameter].MaxValue = _parameters[ParameterType.FirstStageDiameter].Value;

            _validationStarted = false;
        }

        /// <summary>
        /// Обработчик события ParameterChanged параметра.
        /// </summary>
        private void OnParameterChanged(object o, EventArgs e)
        {
            Validate();
        }
        #endregion
    }
}
