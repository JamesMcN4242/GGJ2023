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
            bool interactedWith = hitObj.layer == LayerMask.NameToLayer("InteractedWith");
            correct += interactedWith && expectEvil == hitObj.CompareTag("EvilObject") ? 1 : 0;
            wrong += !interactedWith || expectEvil != hitObj.CompareTag("EvilObject") ? 1 : 0;
            Destroy(hitObj);
        }
        
        hitObjs.Clear();
        return (correct, wrong);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (expectEvil || other.gameObject.layer == LayerMask.NameToLayer("InteractedWith"))
        {
            hitObjs.Add(other.gameObject);
        }
    }
}
