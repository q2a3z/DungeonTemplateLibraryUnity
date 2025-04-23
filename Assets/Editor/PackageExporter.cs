using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PackageExporter
{
    // Packages以下を指定する場合フォルダパスではなく Packages/{パッケージ名} なので注意
    private static readonly string PackagePath = "Packages/com.sitRyo.DungeonTemplateLibrary";

    [MenuItem("Tools/ExportPackage")]
    // 必ずstaticにする
    private static void Export()
    {
        // 出力ファイル名
        var exportPath = "./DungeonTemplateLibrary.unitypackage";

        var exportedPackageAssetList = new List<string>();
        foreach (var guid in AssetDatabase.FindAssets("", new[] { PackagePath }))
        {
            var path = AssetDatabase.GUIDToAssetPath(guid);
            exportedPackageAssetList.Add(path);
        }

        AssetDatabase.ExportPackage(exportedPackageAssetList.ToArray(),
            exportPath,
            ExportPackageOptions.Recurse);
    }
}