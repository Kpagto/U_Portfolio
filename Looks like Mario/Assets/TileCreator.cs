using UnityEngine;
using UnityEditor;
using UnityEngine.Tilemaps;

public class TileCreator
{
    [MenuItem("Assets/Create/2D/Tile (Basic)")]
    public static void CreateBasicTile()
    {
        Tile tile = ScriptableObject.CreateInstance<Tile>();
        string path = AssetDatabase.GenerateUniqueAssetPath("Assets/NewBasicTile.asset");
        AssetDatabase.CreateAsset(tile, path);
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = tile;
    }
}
