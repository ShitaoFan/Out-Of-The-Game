using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enlarge : MonoBehaviour
{
    public GameObject game;
    Vector3 previousPosition;
    AudioSource error;
    BookShelfController bookShelfScript;
    protected HighlightableObject ho;
    // Start is called before the first frame update
    void Start()
    {
        previousPosition = game.transform.localPosition;
        bookShelfScript = FindObjectOfType<BookShelfController>();
        ho = gameObject.AddComponent<HighlightableObject>();
        error=GetComponent<AudioSource>();
    }
        // Update is called once per frame
        void Update()
    {
        
    }
    
    void OnMouseEnter()
    {
        if (bookShelfScript.bookFocusStatus == true)
        {
            game.transform.localPosition = game.transform.localPosition + new Vector3(-35.0f, 0f, 0f);
            ho.ConstantOn();
            error.Play();
        }
    }
    void OnMouseExit()
    {
        game.transform.localPosition = previousPosition;
        ho.ConstantOff();
    }
}
