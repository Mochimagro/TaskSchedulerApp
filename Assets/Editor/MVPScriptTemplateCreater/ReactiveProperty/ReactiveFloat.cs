using System;

namespace Mochi.ReactiveProperty
{
    public class ReactiveFloat
    {
        private float _value;
        private Action<float> _onValueChanged;

        public ReactiveFloat(float init)
        {
            _value = init;
        }

        public ReactiveFloat() : this(default) { }

        public float Value
        {
            get { return _value; }
            set
            {
                if (value != _value)
                {
                    _value = value;
                    _onValueChanged?.Invoke(_value);
                }
            }
        }

        public Action<float> OnValueChanged
        {
            get => _onValueChanged;
            set => _onValueChanged = value;
        }

    }

}