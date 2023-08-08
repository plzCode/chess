using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Cam : MonoBehaviour
{
    public float Sens = 2f; //마우스 감도
    private float rotationX = 0f; //x축 회전값
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("mouseX");
        float mouseY = Input.GetAxis("mouseY");

        //수평 회전
        transform.parent.Rotate(Vector3.up, mouseX * Sens);

        //수직 회전
        rotationX -= mouseY * Sens;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        
    }

    

}
