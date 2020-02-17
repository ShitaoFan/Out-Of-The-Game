using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstKey : MonoBehaviour
{
    protected HighlightableObject ho;
    public Renderer rder1;
    public GameObject firstKey;
    public Animator keyAnimator;
    public bool showCondition = false;
    
    KeyImageManager keyImageManager;
    // Start is called before the first frame update
    void Start()
    {
        ho = gameObject.AddComponent<HighlightableObject>();
        rder1 = firstKey.GetComponent<Renderer>();
        keyAnimator = firstKey.GetComponent<Animator>();
        keyImageManager = FindObjectOfType<KeyImageManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void glowing()
    {
        ho.ConstantOn();
        rder1.material.EnableKeyword("_EMISSION");
        keyAnimator.SetBool("KeyUp", true);
    }
    void OnMouseDown()
    {
        if (showCondition == true)
        {
            firstKey.SetActive(false);
            keyImageManager.firstKeyImage.enabled = true;
            
        }
    }
}
