using UnityEngine;

public class InputReader
{
    private const string Horisontal = "Horizontal";
    private const string Vertical = "Vertical";
    
    public Vector2 GetMovementInput()
    {
        float horizontal = Input.GetAxis(Horisontal);
        float vertical = Input.GetAxis(Vertical);
        
        return new Vector2(horizontal, vertical);
    }
}
