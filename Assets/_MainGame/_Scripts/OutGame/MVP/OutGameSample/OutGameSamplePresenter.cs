using System;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace MVPTemplateEditor.Game.Presenter
{
	using OutGameSample;

	public interface IOutGameSamplePresenter
	{
		
	}

	public class OutGameSamplePresenter : IOutGameSamplePresenter
	{
		private IOutGameSampleView _outGameSampleView = null;
		private IOutGameSampleModel _outGameSampleModel = null;

		public OutGameSamplePresenter(IOutGameSampleView view,IOutGameSampleModel model) 
		{
			_outGameSampleView = view ?? throw new ArgumentNullException(nameof(view));
			_outGameSampleModel = model ?? throw new ArgumentNullException(nameof(model));
			

			Bind();
		}
		
		private void Bind () 
		{
			

		}
	}
}