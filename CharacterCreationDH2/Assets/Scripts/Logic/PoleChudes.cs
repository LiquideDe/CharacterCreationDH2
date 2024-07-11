using System.Collections.Generic;

public static class PoleChudes
{
    public static string GetVariantFrom(List<string> baraban, int naBarabane = 0)
    {
        int variants = 100 / baraban.Count;
        if (naBarabane == 0)
        {
            naBarabane = GenerateIntValue(100);
        }

        int id = (int)(naBarabane / variants);
        if (id >= baraban.Count)
        {
            id = baraban.Count - 1;
        }
        return baraban[id];
    }

    public static int GenerateIntValue(int max)
    {
        System.Random random = new System.Random();
        return random.Next(1, max);
    }
}
