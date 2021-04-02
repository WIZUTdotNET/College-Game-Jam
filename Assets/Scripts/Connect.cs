using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connect : MonoBehaviour
{
<<<<<<< HEAD
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
=======

    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("We Smashing");
        if (coll.gameObject.tag == "Player")
        {
            this.transform.parent.parent = coll.gameObject.transform.parent;
            this.transform.gameObject.tag = "Player";
        }
    }
}
>>>>>>> main
