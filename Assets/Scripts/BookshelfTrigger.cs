using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookshelfTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    TriggerManager triggerManager;
    void Start()
    {
        triggerManager = FindObjectOfType<TriggerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Character")
        {
            triggerManager.bookshelfTriggerCondition = true;
            //chairScript.chairUsedCondition = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Character")
        {
            triggerManager.bookshelfTriggerCondition = false;
            //chairScript.chairUsedCondition = false;
        }
    }
}
