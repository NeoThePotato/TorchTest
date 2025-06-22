using UnityEngine;

public class Torch : MonoBehaviour
{
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
        if (rend != null)
            rend.material.color = isLit ? Color.yellow : Color.gray;
    }
}
