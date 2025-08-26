using UnityEngine;
using System;

public class InputReader : MonoBehaviour
{
    private KeyCode _fierKey = KeyCode.Space;
    private KeyCode _reloadKey = KeyCode.R;
    private KeyCode _swingKey = KeyCode.F;

    public event Action Shoted;
    public event Action Reloated;
    public event Action Pushed;
    
    private void Update()
    {
        if(Input.GetKeyDown(_fierKey))
            Shoted?.Invoke();
        
        if(Input.GetKeyDown(_reloadKey))
            Reloated?.Invoke();

        if (Input.GetKeyDown(_swingKey))
            Pushed?.Invoke();
    }
}