using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connect : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            // this.transform.parent = coll.gameObject.transform.GetChild(0).transform;
            this.transform.parent = coll.gameObject.transform;
            this.transform.gameObject.tag = "Player";
        }
    }
}