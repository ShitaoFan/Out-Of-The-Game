using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject Character;
    TriggerManager triggerManager;
    // Start is called before the first frame update
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
            triggerManager.doorTriggerCondition = true;
            //chairScript.chairUsedCondition = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Character")
        {
            triggerManager.doorTriggerCondition = false;
            //chairScript.chairUsedCondition = false;
        }
    }
}
