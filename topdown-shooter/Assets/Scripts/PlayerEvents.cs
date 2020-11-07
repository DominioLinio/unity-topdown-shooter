using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
        public float speedModifier = 0.1f;
        float speedLevel = 0f;
        int currentClicks = 0;
        bool onTreadmill = false;

  
    void Update()
    {
        if (onTreadmill && Input.GetKeyDown("space"))
        {
            TrainOnTreadmill();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Usable"){
            Debug.Log("On treadmill");
            onTreadmill = true;
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Usable")
        {
            Debug.Log("Off treadmill");
            onTreadmill = false;
        }
    }

    void TrainOnTreadmill()
    {
        Debug.Log("Curent clicks: " + currentClicks);
        currentClicks++;
        if (currentClicks == Mathf.Pow(2, speedLevel))
        {
            speedLevel++;
            currentClicks = 0;
            Debug.Log(this.gameObject.GetComponent<PlayerMovement>().baseMoveSpeed + speedModifier * speedLevel);
            this.gameObject.GetComponent<PlayerMovement>().baseMoveSpeed += speedModifier * speedLevel;
        }
    }

}
