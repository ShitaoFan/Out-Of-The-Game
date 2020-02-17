using UnityEngine;
using System.Collections;

public class CUBE2 : MonoBehaviour
{
    protected HighlightableObject ho;

    void Start()
    {
        ho = gameObject.AddComponent<HighlightableObject>();
    }

    void OnMouseOver()
    {
        ho.FlashingOn();
    }
    void OnMouseExit()
    {
        ho.Off();
    }
}
