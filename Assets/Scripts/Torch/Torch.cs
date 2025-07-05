using UnityEngine;

public class Torch : MonoBehaviour
{
    public static readonly Color LIT_COLOR = Color.yellow, UNLIT_COLOR = Color.gray;

    public bool isLit = false;
    public Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        UpdateVisual();
    }

    public void LightUp()
    {
        isLit = true;
        UpdateVisual();
    }

    void UpdateVisual()
    {
        if (rend)
            rend.material.color = isLit ? LIT_COLOR : UNLIT_COLOR;
    }
}
