using UnityEngine;
using System.Collections;

public class DartScript : MonoBehaviour
{
    Rigidbody rb;

	// Use this for initialization
	void Start () {
	    rb = this.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        
        // align dart with velocity vector
        Vector3 vel = rb.velocity;
        rb.rotation = Quaternion.LookRotation(vel);
      //  print("update rotation vel is " + vel.x + " " + vel.y + " " + vel.z);
    }
}
