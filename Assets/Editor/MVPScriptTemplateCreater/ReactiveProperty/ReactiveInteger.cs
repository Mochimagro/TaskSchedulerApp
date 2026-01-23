using System;

namespace Mochi.ReactiveProperty
{

    public class ReactiveInteger
    {
        private int _value;
        private Action<int> _onValueChanged = default;

        public ReactiveInteger(int init)
        {
            _value = init;
        }

        public ReactiveInteger()
        {
            _value = default;
        }

        // 値プロパティ。値を設定したときに変更を検知してコールバックを実行する
        public int Value
        {
            get { return _value; }
            set
            {
                if (_value != value)
                {
                    _value = value;
                    _onValueChanged?.Invoke(_value); // 値が変わった時にコールバックを呼ぶ
                }
            }
        }

        public Action <int> OnValueChanged
        {
            get => _onValueChanged;
            set => _onValueChanged = value;
        }

    }
}