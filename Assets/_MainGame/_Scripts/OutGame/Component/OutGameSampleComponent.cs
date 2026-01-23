using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace MVPTemplateEditor.Game.Component
{
	public interface IOutGameSampleComponent
    {
		void Init();
    }


	public class OutGameSampleComponent : MonoBehaviour ,IOutGameSampleComponent
	{
		public void Init () 
		{
			

		}
		
	}
}