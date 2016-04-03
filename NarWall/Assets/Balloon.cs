using UnityEngine;
using System.Collections;

public class Balloon : MonoBehaviour {

    private bool hasExploded = false; // true if it exists + is exploding

	// Use this for initialization
	void Start () {
        hasExploded = false;
	}

    public bool isExploding()
    {
        return hasExploded;
    }

	public void DestroyBalloonDelay()
    {
        hasExploded = true;
        Invoke("DestroyThis", 1);
    }

    public void DestroyThis()
    {
        print("DESTROYY");
        Destroy(gameObject);
    }
	// Update is called once per frame
	void Update () {
	    
	}
}
