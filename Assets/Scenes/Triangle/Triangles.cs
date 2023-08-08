using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangles : MonoBehaviour
{

    public GameObject Triangle;
 
    // Start is called before the first frame update
    void Start()
    {
        Tri();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Tri()
    {
        for(int i = 3; i>0; i--)
        {
            int j = 2 * i - 1;
            for (; j>0; j--) 
            {
                GameObject Tir = GameObject.Instantiate(Triangle);
                Tir.transform.position = new Vector3(i * -
                    2, j * 2 -(i*2), 0);
            }
        }
    }
}
