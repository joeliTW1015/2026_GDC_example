using UnityEngine;

/// <summary>全專案共用配色。改這裡就能一次換掉所有顏色。</summary>
public static class GDCPalette
{
    public static readonly Color Background = Hex("#1B2430"); // 背景
    public static readonly Color Platform   = Hex("#4A5A6A"); // 地面、平台
    public static readonly Color Player     = Hex("#FFD166"); // 玩家
    public static readonly Color Coin       = Hex("#FFC93C"); // 金幣
    public static readonly Color Hazard     = Hex("#EF476F"); // 危險物
    public static readonly Color Goal       = Hex("#06D6A0"); // 目標
    public static readonly Color Grapple    = Hex("#7B61FF"); // 鉤點
    public static readonly Color Box        = Hex("#C98B5E"); // 木箱
    public static readonly Color Text       = Hex("#F5F7FA"); // 一般文字
    public static readonly Color TextDim    = Hex("#8A97A6"); // 次要文字
    public static readonly Color Board      = Hex("#2F3D4F"); // 看板底色

    public static Color Hex(string hex)
    {
        Color c;
        return ColorUtility.TryParseHtmlString(hex, out c) ? c : Color.magenta;
    }
}
