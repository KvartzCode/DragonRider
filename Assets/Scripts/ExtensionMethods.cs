using System;
using System.Linq;

public static class ExtensionMethods
{
    /// <summary>
    /// Converts the int to an array.
    /// </summary>
    public static int[] ToArray(this int value)
    {
        return value.ToString().Select(o => Convert.ToInt32(o) - 48).ToArray();
    }
}
