using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connect : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        this.transform.parent = coll.gameObject.transform;
        Debug.Log("Czemu to nie dziala?");
    }

    //void OnTriggerEnter2D(Collider2D coll)
    //{
    //    this.transform.parent = coll.gameObject.transform;
    //    Debug.Log("Czemu to nie dziala?");
    //}
}
