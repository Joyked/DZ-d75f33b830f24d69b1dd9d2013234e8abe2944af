using System;
using UnityEngine;

[RequireComponent(typeof(SpringJoint))]
public class Сatapult : MonoBehaviour
{
    [SerializeField] private float _fierSpring = 15;
    [SerializeField] private float _reloadSpring = 1.3f;
    [SerializeField] private InputReader _inputReader;
    
    private SpringJoint _hingeJoint;

    private void Awake()
    {
        _hingeJoint = GetComponent<SpringJoint>();
    }

    private void OnEnable()
    {
        _inputReader.Shoted += Shot;
        _inputReader.Reloated += Reload;
    }

    private void OnDisable()
    {
        _inputReader.Shoted -= Shot;
        _inputReader.Reloated -= Reload;
    }

    private void Shot() =>
        _hingeJoint.spring = _fierSpring;
    
    private void Reload() =>
        _hingeJoint.spring = _reloadSpring;
}
