using System;

namespace Mochi.ReactiveProperty
{
    public class ReactiveString
    {
        private string _value;
        private Action<string> _onValueChanged;

        public ReactiveString(string init)
        {
            _value = init;
        }

        public ReactiveString() : this(default) { }

        public string Value 
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

        public Action<string> OnValueChanged
        {
            get => _onValueChanged;
            set => _onValueChanged = value;
        }

    }

}