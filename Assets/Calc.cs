using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calc : MonoBehaviour
{
    public int Tmp1;
    public int Tmp2;

    public int result;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Onclick1()
    {
        Tmp1 += 1;
        Debug.Log(Tmp1);
    }
    public void Onclick2()
    {
        Tmp1 += 2;
        Debug.Log(Tmp1);
    }
}
