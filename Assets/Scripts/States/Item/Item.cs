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


        for (int i = 1; i <= 4; i++)
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
            var source = Resources.Load<Sprite>("Art/"+ sourceFile);
            var image = itemObj.AddComponent<Image>();
            image.sprite = source;//TODO: change daisy to random

        }

        
        //var source = itemObj.AddComponent<SpriteMeshType>();
        //source.clip = Resources.Load<AudioClip>("Audio/Music");
        //source.loop = true;
        //source.Play();

        //GameObject.DontDestroyOnLoad(audioObj);
    }

    private static bool isNextGood(int truePercentage = 50)
    {
        return UnityEngine.Random.Range(0, 100) < truePercentage;
    }
}

