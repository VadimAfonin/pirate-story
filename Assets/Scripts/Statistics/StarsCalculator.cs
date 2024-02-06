using System;

public static class StarsCalculator
{
    public static int SetStarsCountFromCoinsCountOnLevel(float percent)
    {
        if (50f > percent)
        {
            return 1;
        }
        else if ((Math.Abs(100f - percent) < float.Epsilon))
        {
            return 3;
        }
        else
        {
            return 2;
        }
    }
}
