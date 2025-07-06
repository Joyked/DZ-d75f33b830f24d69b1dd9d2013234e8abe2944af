using System;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForse;
    
    public void Explode()
    {
        foreach (var explodableObject in GetExplodableObjects())
            explodableObject.AddExplosionForce(_explosionForse, transform.position, _explosionRadius);
    }
    
    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);
        List<Rigidbody> explodableObjects = new();

        foreach (var hit in hits)
        {
            if (hit.attachedRigidbody != null)
                explodableObjects.Add(hit.attachedRigidbody);
        }

        return explodableObjects;
    }
}
