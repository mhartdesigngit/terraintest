using UnityEngine;
using System.Collections;

public class landscapeRot : MonoBehaviour
{

    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 25f);
    }
	
}
