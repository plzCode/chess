using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public ObjectData zombieData;

    public void PrintZombieData()
    {
        Debug.Log("���� �̸� : " + zombieData.ObjName);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
