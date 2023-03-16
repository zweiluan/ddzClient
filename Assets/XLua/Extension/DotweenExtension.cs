using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace XLua.Extension
{
  public class DotweenExtension
  {
    public static Tweener Float_To(float start, float to, float duration, LuaFunction setter)
    {
      return DOTween.To(() => start, (v) => setter.Call(v), to, duration);
    }

    public static Tweener Double_To(double start, double to, float duration, LuaFunction setter)
    {
      return DOTween.To(() => start, (v) => setter.Call(v), to, duration);
    }

    public static Tweener Int_To(int start, int to, float duration, LuaFunction setter)
    {
      return DOTween.To(() => start, (v) => setter.Call(v), to, duration);
    }

    public static Tweener Unit_To(uint start, uint to, float duration, LuaFunction setter)
    {
      return DOTween.To(() => start, (v) => setter.Call(v), to, duration);
    }

    public static Tweener Long_To(long start, long to, float duration, LuaFunction setter)
    {
      return DOTween.To(() => start, (v) => setter.Call(v), to, duration);
    }

    public static Tweener Ulong_To(ulong start, ulong to, float duration, LuaFunction setter)
    {
      return DOTween.To(() => start, (v) => setter.Call(v), to, duration);
    }

    public static Tweener String_To(string start, string to, float duration, LuaFunction setter)
    {
      return DOTween.To(() => start, (v) => setter.Call(v), to, duration);
    }

    public static Tweener Vector2_To(Vector2 start, Vector2 to, float duration, LuaFunction setter)
    {
      return DOTween.To(() => start, (v) => setter.Call(v), to, duration);
    }

    public static Tweener Vector3_To(Vector3 start, Vector3 to, float duration, LuaFunction setter)
    {
      return DOTween.To(() => start, (v) => setter.Call(v), to, duration);
    }

    public static Tweener Vector4_To(Vector4 start, Vector4 to, float duration, LuaFunction setter)
    {
      return DOTween.To(() => start, (v) => setter.Call(v), to, duration);
    }

    public static Tweener Quaternion_To(Quaternion start, Vector3 to, float duration, LuaFunction setter)
    {
      return DOTween.To(() => start, (v) => setter.Call(v), to, duration);
    }

    public static Tweener Color_To(Color start, Color to, float duration, LuaFunction setter)
    {
      return DOTween.To(() => start, (v) => setter.Call(v), to, duration);
    }

    public static Tweener Rect_To(Rect start, Rect to, float duration, LuaFunction setter)
    {
      return DOTween.To(() => start, (v) => setter.Call(v), to, duration);
    }

    public static Tweener RectOffset_To(RectOffset start, RectOffset to, float duration, LuaFunction setter)
    {
      return DOTween.To(() => start, (v) => setter.Call(v), to, duration);
    }

    public static Tweener ToAxis(Vector3 start, float to, float duration, LuaFunction setter)
    {
      return DOTween.ToAxis(() => start, (v) => setter.Call(v), to, duration);
    }

    public static Tweener ToAlpha(Color start, float to, float duration, LuaFunction setter)
    {
      return DOTween.ToAlpha(() => start, (v) => setter.Call(v), to, duration);
    }
    
    
  }
}