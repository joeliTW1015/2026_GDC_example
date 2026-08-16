using System.IO;
using UnityEditor;
using UnityEngine;

namespace GDCBuild
{
    /// <summary>教材各種資產的存放路徑，以及讀取用的小工具。</summary>
    public static class GDCPaths
    {
        public const string Root          = "Assets/_GDC";
        public const string Sprites       = Root + "/Art/Sprites";
        public const string Fonts         = Root + "/Art/Fonts";
        public const string PhysicsMats   = Root + "/Physics";
        public const string Prefabs       = Root + "/Prefabs";
        public const string Scenes        = Root + "/Scenes";
        public const string TeacherScenes = Root + "/Teacher/Scenes";
        public const string Answers       = Root + "/Teacher/Answers";
        public const string Docs          = Root + "/Docs";

        static readonly string[] All =
        {
            Root, Root + "/Art", Sprites, Fonts, PhysicsMats, Prefabs, Scenes,
            Root + "/Teacher", TeacherScenes, Answers, Docs,
            Root + "/Scripts", Root + "/Scripts/Core", Root + "/Scripts/Student"
        };

        public static void EnsureFolders()
        {
            foreach (var p in All)
            {
                var abs = Path.Combine(Directory.GetParent(Application.dataPath).FullName, p);
                if (!Directory.Exists(abs)) Directory.CreateDirectory(abs);
            }
            AssetDatabase.Refresh();
        }

        public static Sprite Sprite(string shape)
        {
            var s = AssetDatabase.LoadAssetAtPath<Sprite>($"{Sprites}/{shape}.png");
            if (s == null) Debug.LogError($"[GDC] 找不到 sprite：{shape}，請先執行 GDC/建置/1. 產生美術素材");
            return s;
        }

        public static PhysicsMaterial2D Phys(string name)
            => AssetDatabase.LoadAssetAtPath<PhysicsMaterial2D>($"{PhysicsMats}/{name}.physicsMaterial2D");
    }
}
