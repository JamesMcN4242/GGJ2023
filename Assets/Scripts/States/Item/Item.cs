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
        
        for (int i = 1; i <= 3; i++)
		{
            var isGood = isNextGood();
            var randomInt = UnityEngine.Random.Range(0, goodCategories.Length);
            var sourceFile = isGood ? goodCategories[randomInt] : evilCategories[randomInt];
            
            var source = Resources.Load<GameObject>($"Art/Plants/{sourceFile}");

            var rangePos = Random.Range(smallestX, largestX);
            Debug.Log($"sourceFile: {sourceFile}. rangePos: {rangePos}");
            
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

