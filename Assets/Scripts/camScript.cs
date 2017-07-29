using UnityEngine;
using System.Collections;

public class camScript : MonoBehaviour
{
    Camera cam;
    public float speed = 5f;
    Terrain terrain;
    Vector3 target;
	
	void Start ()
    {
        cam = GetComponent<Camera>();
        terrain = GameObject.Find("Terrain").GetComponent<Terrain>();
        target = new Vector3(terrain.terrainData.size.x/2,0, terrain.terrainData.size.z / 2);
	}
	
	
	void Update ()
    {
        cam.transform.LookAt(target);

        transform.RotateAround(target,Vector3.up ,Input.GetAxis("Horizontal") * Time.deltaTime*speed);
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * Time.deltaTime * speed);

	}
}
