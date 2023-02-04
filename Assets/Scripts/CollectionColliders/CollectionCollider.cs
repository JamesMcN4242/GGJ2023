using System.Collections.Generic;
using UnityEngine;

public class CollectionCollider : MonoBehaviour
{
    [SerializeField] private bool expectEvil;
    private List<GameObject> hitObjs = new (5);

    public (int correct, int wrong) ConsumeObjs()
    {
        int correct = 0, wrong = 0;
        
        foreach (var hitObj in hitObjs)
        {
            correct += expectEvil == hitObj.CompareTag("EvilObject") ? 1 : 0;
            wrong += expectEvil != hitObj.CompareTag("EvilObject") ? 1 : 0;
        }
        
        hitObjs.Clear();
        return (correct, wrong);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        hitObjs.Add(other.gameObject);
    }
}
