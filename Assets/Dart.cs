using UnityEngine;
using System.Collections;

public class Dart : MonoBehaviour
{
    public GameObject ammo;
    public bool startDrag = false;

    // Use this for initialization
    void Start()
    {

    }

    void updateDartRotation()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonUp(0) && startDrag)
        {
            startDrag = false;
            GameObject shoot = (GameObject)Instantiate(ammo, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            shoot.GetComponent<Rigidbody>().AddRelativeForce(0f, 0f, 1f);
        }
        else if (Input.GetMouseButtonDown(0))
        {
            updateDartRotation();
            startDrag = true;
        }
    }
}