using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using TMPro;

namespace TaskSchedulerApp.Game.Component
{
	public interface IPriorityDropdownComponent
    {
		void Init();
		Priority SetPriority { set; }
    }


	public class PriorityDropdownComponent : MonoBehaviour ,IPriorityDropdownComponent
	{
		[SerializeField] TMP_Dropdown _priorityDropdown = default;

        public Priority SetPriority { set => _priorityDropdown.SetValueWithoutNotify((int)value); }

        public void Init () 
		{
			_priorityDropdown.value = 0;

		}
		
	}
}