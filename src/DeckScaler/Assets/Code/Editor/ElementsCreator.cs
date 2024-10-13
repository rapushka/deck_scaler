using UnityEditor;
using UnityEngine;

namespace DeckScaler.Editor
{
    public class ElementsCreator
    {
        private const string Prefix = "GameObject/375/";

        [MenuItem(Prefix + "Text 2D", false, -10)] private static void CreateText()   => Create("Assets/Resources/Common/Text.prefab");
        [MenuItem(Prefix + "UI/Text", false, 1)]   private static void CreateUiText() => Create("Assets/Resources/UI/Elements/Text.prefab");
        [MenuItem(Prefix + "UI/Button", false, 2)] private static void CreateButton() => Create("Assets/Resources/UI/Elements/Button.prefab");

        private static void Create(string path)
        {
            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            var instance = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
            instance.transform.SetParent(Selection.activeGameObject.transform, worldPositionStays: false);
        }
    }
}