using UnityEngine;
using System.Collections;

public class Dart : MonoBehaviour
{
    public GameObject ammo;
    public bool startDrag = false;

    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody>().detectCollisions = false;
    }

    void updateDartRotation()
    {
        print("update rotation");
        var v3 = Input.mousePosition;
        v3.z = 10.0f;
        v3 = Camera.main.ScreenToWorldPoint(v3);

        float yRotation = v3.x*15f;
        float xRotation = -v3.y*15f;
        print("x rotation" + xRotation);

        this.GetComponent<Rigidbody>().rotation = Quaternion.Euler(xRotation, yRotation, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        updateDartRotation();

        if (Input.GetMouseButtonUp(0) && startDrag)
        {
            startDrag = false;
			GameObject shoot = (GameObject)Instantiate(ammo, transform.position, transform.rotation);
            shoot.GetComponent<Rigidbody>().detectCollisions = true;
            shoot.GetComponent<Rigidbody>().velocity = -20 * shoot.transform.forward;
            
          //  shoot.GetComponent<Rigidbody>().AddRelativeForce(0f, 0f, -50f);
           // shoot.GetComponent<Rigidbody>().AddRelativeForce(0f, -3*9.81f, 0f);
        }
        else if (Input.GetMouseButtonDown(0) || startDrag)
        {
            startDrag = true;
        }
    }
}