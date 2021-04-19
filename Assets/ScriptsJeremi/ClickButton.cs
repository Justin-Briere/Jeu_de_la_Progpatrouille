using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickButton : MonoBehaviour
{
    public Material normalMaterial;
    public Material whiteMaterial;
    Renderer zeRenderer;
    Vector3 position;

    public int number = 1;
    public RandomButton random;

    public delegate void PressedEvent(int number);

    public event PressedEvent onClick;
    void Awake()
    {
        zeRenderer = GetComponent<Renderer>();
        zeRenderer.enabled = true;
        position = transform.position;
    }

    private void OnMouseDown()
    {
        if (random.player)
        {
            SelectedColor();
            transform.position = new Vector3(position.x, -0.1f, position.z);
            onClick.Invoke(number);
        }
    }

    private void OnMouseUp()
    {
        UnSelectedColor();
        transform.position = new Vector3(position.x, position.y, position.z);
    }

    public void SelectedColor()
    {
        zeRenderer.sharedMaterial = whiteMaterial;
    }

    public void UnSelectedColor()
    {
        zeRenderer.sharedMaterial = normalMaterial;
    }

}
