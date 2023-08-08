using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_Rotation : MonoBehaviour
{
    public float sensitivity = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var c = Camera.main.transform;
        c.Rotate(0, Input.GetAxis("Mouse X") * sensitivity, 0);
        c.Rotate(-Input.GetAxis("Mouse Y") * sensitivity, 0, 0);
        c.Rotate(new Vector3(0, 0, -Input.GetAxis("QandE") * 90 * Time.deltaTime));
        if (Input.GetMouseButtonDown(0))
            Cursor.lockState = CursorLockMode.Locked;
    }
}
