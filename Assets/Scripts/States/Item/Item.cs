using System.Collections.Generic;
using System.Linq;
using PlasticPipe.Server;
using UnityEngine;

public static class Item
{
    private static string[] goodCategories = { "carrot", "beetroot" };
    private static string[] evilCategories = { "daisy", "dandelion" };
    
    public static void CreateItemObject(Transform parent)
    {
        var itemObj = new GameObject("UnrootItem");
        itemObj.transform.parent = parent;
        
        // I checked these indexes manually.
        // Terrible solution, but really not vibing with re-arranging some prefabs to make this better.
        var smallestX = parent.GetChild(7).position.x;
        var largestX = parent.GetChild(9).position.x;
        var exclude = new HashSet<float>() { };

        int randomAmount = Random.Range(2, 4);
        for (int i = 1; i <= randomAmount; i++)
		{
            var isGood = isNextGood();
            var randomInt = UnityEngine.Random.Range(0, goodCategories.Length);
            var sourceFile = isGood ? goodCategories[randomInt] : evilCategories[randomInt];
            
            var source = Resources.Load<GameObject>($"Art/Plants/{sourceFile}");

            var rangePos = 0f;
            bool rangeAlreadySet = true;
            while (rangeAlreadySet)
            {
                rangeAlreadySet = false;
                rangePos = Random.Range(smallestX, largestX);
                foreach (var item in exclude)
                {
                    rangeAlreadySet |= item - 1 <= rangePos && rangePos <= item + 1;
                }
            }
            
            exclude.Add(rangePos);
            var obj = Object.Instantiate(source, new Vector3(rangePos, -1.2f, -7f), Quaternion.identity, parent);
            
            // What a hack this is.
            var transform = obj.transform;
            transform.parent = null;
            transform.localScale = Vector3.one * 10f;
            transform.parent = parent;
        }
    }

    private static bool isNextGood(int truePercentage = 50)
    {
        return Random.Range(0, 100) < truePercentage;
    }

}

