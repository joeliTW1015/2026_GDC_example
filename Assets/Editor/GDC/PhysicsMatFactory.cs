using UnityEditor;
using UnityEngine;

namespace GDCBuild
{
    /// <summary>產生教學用的 2D 物理材質，讓學生直接拖到 Collider 上比較差異。</summary>
    public static class PhysicsMatFactory
    {
        // 名稱, 摩擦力, 彈性
        static readonly (string name, float friction, float bounciness)[] Mats =
        {
            ("Normal",      0.4f,  0.0f),   // 一般
            ("Slippery",    0.02f, 0.0f),   // 光滑如冰
            ("Sticky",      1.0f,  0.0f),   // 很澀
            ("Bouncy",      0.3f,  0.6f),   // 會彈
            ("SuperBouncy", 0.1f,  0.95f),  // 超級彈
        };

        public static void Run()
        {
            GDCPaths.EnsureFolders();

            foreach (var (name, friction, bounciness) in Mats)
            {
                string path = $"{GDCPaths.PhysicsMats}/{name}.physicsMaterial2D";
                var mat = AssetDatabase.LoadAssetAtPath<PhysicsMaterial2D>(path);

                if (mat == null)
                {
                    mat = new PhysicsMaterial2D(name);
                    AssetDatabase.CreateAsset(mat, path);
                }
                mat.friction   = friction;
                mat.bounciness = bounciness;
                EditorUtility.SetDirty(mat);
            }

            AssetDatabase.SaveAssets();
            Debug.Log($"[GDC] 物理材質產生完成：{Mats.Length} 個");
        }
    }
}
