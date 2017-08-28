using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if(collision.gameObject.name == "Player")
        //{
            Destroy(collision.gameObject);
       // }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}
}
