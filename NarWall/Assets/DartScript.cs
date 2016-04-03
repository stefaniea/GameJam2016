using UnityEngine;
using System.Collections;

public class DartScript : MonoBehaviour
{
    Rigidbody rb;
    public int countBalloon;

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
    void explode(Vector3 position)
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        print("collide with wall");
        if (collision.gameObject.name != "Wall")
        {
            print("BALLOON");
            explode(collision.gameObject.transform.position);
            var em = collision.gameObject.GetComponent<ParticleSystem>().emission;
            em.enabled = true;
            collision.gameObject.GetComponent<ParticleSystem>().Play();
            collision.gameObject.GetComponent<Balloon>().DestroyBalloonDelay();
            countBalloon--;
            if (countBalloon == 0)
            {
                
            }


        }
    }
}
