using System;
using UnityEngine;
using UnityEngine.UI;

public static class Item
{

    public static void CreateItemObject(Transform parent)
    {
        var itemObj = new GameObject("UnrootItem");
        itemObj.transform.parent = parent;
        string[] goodCategories = { "carrot", "beetroot" };
        string[] evilCategories = { "daisy", "dandelion" };


        for (int i = 1; i <= 3; i++)
		{
            var isGood = isNextGood();
            var sourceFile = "";
            var randomInt = UnityEngine.Random.Range(0, goodCategories.Length);
            if(isGood)
            {
                sourceFile = goodCategories[randomInt];
            } else
            {
                sourceFile = evilCategories[randomInt];
            }
            var source = Resources.Load<GameObject>("Art/Plants/"+ sourceFile);
            var rangePos = UnityEngine.Random.Range(-5, 30);
            Debug.Log("sourceFile: " + sourceFile + " rangePos " + rangePos);
            GameObject.Instantiate(source, new Vector3(rangePos, 0f, 0f), Quaternion.identity, parent);
        }
    }

    private static bool isNextGood(int truePercentage = 50)
    {
        return UnityEngine.Random.Range(0, 100) < truePercentage;
    }
}

