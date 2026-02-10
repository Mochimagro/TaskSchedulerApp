using System;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace TaskSchedulerApp.Game.Presenter
{
	using Header;

	public interface IHeaderPresenter
	{
		
	}

	public class HeaderPresenter : IHeaderPresenter
	{
		private IHeaderView _headerView = null;
		private IHeaderModel _headerModel = null;

		public HeaderPresenter(IHeaderView view,IHeaderModel model) 
		{
			_headerView = view ?? throw new ArgumentNullException(nameof(view));
			_headerModel = model ?? throw new ArgumentNullException(nameof(model));
			

			_headerView.Init();
			Bind();
		}
		
		private void Bind () 
		{
			_headerView.OnClickAddTask.Subscribe(_ =>
			{
				// Modelでタスクを追加する処理
				Debug.Log("Click Add Button");
			});

		}
	}
}