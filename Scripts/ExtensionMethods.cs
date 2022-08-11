using System.Collections.Generic;

public static class ExtensionMethods
{
    public static void Shuffle<T>(this List<T> baseList)
    {
        int listCount = baseList.Count;

        while (listCount > 1)
        {
            listCount--;

            int randomIndex = UnityEngine.Random.Range(0, baseList.Count);
            (baseList[randomIndex], baseList[listCount]) = (baseList[listCount], baseList[randomIndex]);
        }
    }
}