using UnityEngine;

public class ColorChangerBomb : MonoBehaviour
{
    private Material _material;
    
    private void Awake() =>
        _material = GetComponent<Renderer>().material;

    private void OnEnable() =>
        _material.color = new Color(_material.color.r, _material.color.g, _material.color.b, 1f);

    public void Repaint(float canalA) =>
        _material.color = new Color(_material.color.r, _material.color.g, _material.color.b, canalA);
}
