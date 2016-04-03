using UnityEngine;
using System.Collections;

public class Balloon : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	public void DestroyBalloonDelay()
    {
        Invoke("DestroyThis", 1);
    }

    public void DestroyThis()
    {
        print("DESTROYY");
        Transform parent;
        Destroy(gameObject);
    }
	// Update is called once per frame
	void Update () {
	    
	}
}
