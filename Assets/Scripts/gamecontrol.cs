using UnityEngine;
using System.Collections;

public class gamecontrol : MonoBehaviour
{

    [SerializeField]
    float speed = 10f;
    [SerializeField]
    float rotspeed = 10f;
    Camera gamecam;

    void Start()
    {
        Cursor.visible = false;
        gamecam = GetComponentInChildren<Camera>();
    }
    
	
	void Update ()
    {
        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime,0,Input.GetAxis("Vertical")*speed*Time.deltaTime);
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * rotspeed * Time.deltaTime);
	    gamecam.transform.Rotate(Vector3.left * Input.GetAxis("Mouse Y") * rotspeed * Time.deltaTime);
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
