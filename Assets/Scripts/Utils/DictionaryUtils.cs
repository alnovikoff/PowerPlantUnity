using System.Collections.Generic;

public class DictionaryUtils
{
    private static System.Random rng = new System.Random();

    public static void Shuffle<T>(List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = UnityEngine.Random.Range(0, n + 1);
            T temp = list[k];
            list[k] = list[n];
            list[n] = temp;
        }
    }
}