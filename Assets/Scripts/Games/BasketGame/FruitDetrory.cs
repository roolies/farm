using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitDetrory : MonoBehaviour
{


    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "KillTrigger")
        {
            Destroy(gameObject);
        }
    }

    //void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.tag == "MiniGame1")
    //    {
    //        TriggerToutched = false;
    //        Debug.Log("trigger Exit");
    //    }
    //
    //    //TriggerToutched = false;
    //    //Debug.Log("trigger not touched");
    //}



}
