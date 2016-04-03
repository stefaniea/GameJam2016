using UnityEngine;
using System.Collections;

public class DartScript : MonoBehaviour
{
    Rigidbody rb;
   // public int countBalloon;
    public Canvas winCanvas; // canvas to show when all balloons popped
    public string levelToLoad = "level2Scene"; // after win load this scene

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
            // already exploding this balloon or collision was not with a balloon
            if (!collision.gameObject.GetComponent<Balloon>() || 
                collision.gameObject.GetComponent<Balloon>().isExploding())
                return;

            print("BALLOON");
            explode(collision.gameObject.transform.position);
            var em = collision.gameObject.GetComponent<ParticleSystem>().emission;
            em.enabled = true;
            // hide balloon mesh and play explosion
            if (collision.gameObject.transform.Find("narwhal")) 
                collision.gameObject.transform.Find("narwhal").localScale = new Vector3(0, 0, 0);
            collision.gameObject.GetComponent<ParticleSystem>().Play();
            collision.gameObject.GetComponent<Balloon>().DestroyBalloonDelay();

            
            Balloon[] balloons = FindObjectsOfType<Balloon>();

            int countBalloon = balloons.Length;
            print("countBalloon is " + countBalloon);
            if (countBalloon <= 1) // no idea why there is one left at the end..
            {
                winCanvas.enabled = true;
                UnityEngine.SceneManagement.SceneManager.LoadScene(levelToLoad);
            }


        }
    }
}
