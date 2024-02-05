using System;

public static class FloatExtensions
{
    public static bool IsEqualsZero(this float v)
    {
        return Math.Abs(v) <= float.Epsilon;
    }
}