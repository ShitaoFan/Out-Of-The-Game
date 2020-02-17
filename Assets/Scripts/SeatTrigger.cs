using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeatTrigger : MonoBehaviour
{
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
            triggerManager.seatTriggerCondition = true;
            //chairScript.chairUsedCondition = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Character")
        {
            triggerManager.seatTriggerCondition = false;
            //chairScript.chairUsedCondition = false;
        }
    }
}
