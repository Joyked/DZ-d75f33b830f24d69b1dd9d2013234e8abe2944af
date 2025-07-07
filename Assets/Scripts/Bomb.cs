using System;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Exploder _exploder;

    private void Awake()=>
        _exploder = GetComponent<Exploder>();

    public void BlowUp() =>
        _exploder.Explode();
}
