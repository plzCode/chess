using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Cam : MonoBehaviour
{
    public float Sens = 2f; //���콺 ����
    private float rotationX = 0f; //x�� ȸ����
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("mouseX");
        float mouseY = Input.GetAxis("mouseY");

        //���� ȸ��
        transform.parent.Rotate(Vector3.up, mouseX * Sens);

        //���� ȸ��
        rotationX -= mouseY * Sens;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        
    }

    

}
