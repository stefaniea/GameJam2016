using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Wall : MonoBehaviour {
    public Text time;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        time.text = Time.time.ToString();
	}

    void OnCollisionEnter(Collision collision)
    {
        print("collide with wall");
        Destroy(collision.gameObject);
    }
}
