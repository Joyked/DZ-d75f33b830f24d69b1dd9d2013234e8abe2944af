using System;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForse;

    private Material _material;
    private Color _color;
    
    private void Awake()
    {
        _material = GetComponent<Renderer>().material;
        _color = _material.color;
    }

    private void OnEnable() =>
        _material.color = new Color(_material.color.r, _material.color.g, _material.color.b, 1f);

    public void Repaint(float canalA) =>
        _material.color = new Color(_material.color.r, _material.color.g, _material.color.b, canalA);
    
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
