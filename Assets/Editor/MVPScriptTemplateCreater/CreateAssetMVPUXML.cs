using UnityEngine;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEditor.ProjectWindowCallback;

namespace EditorExpand.CreateAsset
{
    public class CreateAssetMVPUXML : EndNameEditAction
    {
        string _templatePath = "Assets/Editor/MVPScriptTemplateCreater/Template/";

        [MenuItem("Assets/Create/ScriptTemplate/MVP_UXML", false,81)]
        private static void CreateMVPUXML()
        {
            // use the duplicate icon provided by unity. 
            var groupIcon =
                EditorGUIUtility.IconContent("TreeEditor.Duplicate").image as Texture2D;

            // create as an instance of ScriptableObject
            var endNameEditAction =
                ScriptableObject.CreateInstance<CreateAssetMVPUXML>();

            // create Scripts from the selscted infomation in menu
            ProjectWindowUtil.StartNameEditingIfProjectWindowExists(
                0,
                endNameEditAction,
                "NewMVPUXML",
                groupIcon,
                string.Empty);

        }

        public override void Action(int instanceId, string pathName, string resourceFile)
        {
            string[] fileType = new string[] { "Model", "View", "Presenter","Window" };

            var groupName = Path.GetFileNameWithoutExtension(pathName);
            var pathes = pathName.Split('/');

            // ディレクトリの作成
            var directoryPath = pathName.Replace(pathes[pathes.Length - 1],groupName);
            Directory.CreateDirectory(directoryPath);

            foreach(var type in fileType)
            {
                var resourceModelFile = _templatePath + type + ".cs.txt";
                CreateScript(directoryPath, resourceModelFile, type);
            }

            CreateUXML(directoryPath, _templatePath + "UXML" + ".uxml.txt");

            return;

        }

        private void CreateScript(string pathName,string resourceFile,string fileType)
        {
            var text = File.ReadAllText(resourceFile);
            var pathes = Application.dataPath.Split('/');

            var groupName = Path.GetFileNameWithoutExtension(pathName);
            var projectName = pathes[pathes.Length - 2];
            projectName = projectName.Replace(" ", "");

            text = text.Replace("#NAME#", groupName);
            text = text.Replace("#NAMETOLOWER#", char.ToLower(groupName[0]) +groupName.Substring(1));
            text = text.Replace("#PROJECTNAME#", projectName);
            text = text.Replace("#NOTRIM#", "\n");
            text = text.Replace("#UXMLPATH#", pathName + "/" + groupName + ".uxml");

            var encording = new UTF8Encoding(true, false);

            var filePath = pathName + "/" + groupName + fileType + ".cs";

            File.WriteAllText(filePath, text, encording);

            AssetDatabase.ImportAsset(filePath);
            var asset = AssetDatabase.LoadAssetAtPath<MonoScript>(filePath);

            ProjectWindowUtil.ShowCreatedAsset(asset);

        }

        private void CreateUXML(string pathName, string resourceFile)
        {
            var text = File.ReadAllText(resourceFile);
            var pathes = Application.dataPath.Split('/');

            var groupName = Path.GetFileNameWithoutExtension(pathName);
            var projectName = pathes[pathes.Length - 2];
            projectName = projectName.Replace(" ", "");

            text = text.Replace("#NAME#", groupName);
            text = text.Replace("#NAMETOLOWER#", char.ToLower(groupName[0]) + groupName.Substring(1));
            text = text.Replace("#PROJECTNAME#", projectName);
            text = text.Replace("#NOTRIM#", "\n");

            var encording = new UTF8Encoding(true, false);

            var filePath = pathName + "/" + groupName + ".uxml";

            File.WriteAllText(filePath, text, encording);

            AssetDatabase.ImportAsset(filePath);
            var asset = AssetDatabase.LoadAssetAtPath<MonoScript>(filePath);

            ProjectWindowUtil.ShowCreatedAsset(asset);


        }

    }

}