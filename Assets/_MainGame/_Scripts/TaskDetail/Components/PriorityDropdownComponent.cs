using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using TMPro;
using System.Linq;

namespace TaskSchedulerApp.Game.Component
{
	public interface IPriorityDropdownComponent
    {
		void Init();
		Priority SetPriority { set; }
        IObservable<Priority> OnSelectPriority { get; }
    }


	public class PriorityDropdownComponent : MonoBehaviour ,IPriorityDropdownComponent
	{
		[SerializeField] TMP_Dropdown _priorityDropdown = default;
		Subject<Priority> _onSelectPriority = new Subject<Priority>();
		

        public Priority SetPriority { set => _priorityDropdown.SetValueWithoutNotify((int)value); }

		public IObservable<Priority> OnSelectPriority => _onSelectPriority;

        public void Init () 
		{

			var options = Enum.GetValues(typeof(Priority)).Cast<Priority>().Select(p => new TMP_Dropdown.OptionData(p.ToString())).ToList();

			_priorityDropdown.ClearOptions();
			_priorityDropdown.AddOptions(options);
			_priorityDropdown.RefreshShownValue();

			_priorityDropdown.onValueChanged.AddListener(value =>
			{
				_onSelectPriority.OnNext((Priority)value);
			});

        }
		
	}
}