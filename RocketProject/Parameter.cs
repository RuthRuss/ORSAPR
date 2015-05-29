using System;

namespace RocketProject
{
    /// <summary>
    /// Класс инкапсулирует параметры _value, _minValue, _maxValue с ограничениями.
    /// </summary>
    public class Parameter
    {
        #region Denotes parameters
        /// <summary>
        /// Параметр по умолчанию
        /// </summary>
        private double _value;

        /// <summary>
        /// Минимальный параметр
        /// </summary>
        private double _minValue;

        /// <summary>
        /// Максимальный параметр
        /// </summary>
        private double _maxValue;

        #endregion

        #region Designer
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="value">Значение параметра.</param>
        /// <param name="minValue">Минимальное значение параметра.</param>
        /// <param name="maxValue">Максимальное значение параметра.</param>
        public Parameter(double value, double minValue, double maxValue)
        {
            _value = value;
            _minValue = minValue;
            _maxValue = maxValue;
        }

        /// <summary>
        /// Значение параметра.
        /// </summary>
        public double Value
        {
            get { return _value; }
            set
            {
                if (value < 1)
                    // throw new ArgumentException();
                    value = _minValue;

                if (value < _minValue)
                    value = _minValue;

                if (value > _maxValue)
                    value = _maxValue;

                _value = value;

                //при изменении параметра вызывается событие OnParameterChanged(ValParameter)
                //которое вызывает validate в валпараметр AND перерисовку в валконтроле
                if (ParameterChanged != null) 
                    ParameterChanged(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Минимальное значение параметра.
        /// </summary>
        public double MinValue
        {
            get { return _minValue; }
            set
            {
                if (value < 1)
                    throw new ArgumentException();

                if (value >= _maxValue)
                    _maxValue = value + 10;

                if (value > _value)
                    _value = value;

                _minValue = value;

                if (ParameterChanged != null)
                    ParameterChanged(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Максимальное значение параметра.
        /// </summary>
        public double MaxValue
        {
            get { return _maxValue; }
            set
            {
                //if (value <= 1)
                if (value < 1)
                    throw new ArgumentException();

                if (value <= _minValue)
                {
                    _minValue = value - 1;
                    if (_minValue < 1)
                        _minValue = 1;
                }

                if (value < _value)
                    _value = value;

                _maxValue = value;

                if (ParameterChanged != null)
                    ParameterChanged(this, EventArgs.Empty);
            }
        }

        #endregion

        /// <summary>
        /// Вызывается при установке параметров.
        /// </summary>
        public event EventHandler ParameterChanged;
    }
}
