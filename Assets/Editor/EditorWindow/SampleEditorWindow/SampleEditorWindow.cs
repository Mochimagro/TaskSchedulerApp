using Mochi.ChillVox.Presenter;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public class SampleEditorWindow : EditorWindow
{
    static EditorWindow _window;
    static SampleEditorWindowPresenter _presenter;

    [MenuItem("EditorWindow/SampleEditorWindow")]
    public static void ShowWindow()
    {
        _presenter = new SampleEditorWindowPresenter();
        _window = GetWindow<SampleEditorWindow>();
    }

    private void CreateGUI()
    {
        rootVisualElement.Add(_presenter.VisualElement);
    }

}
