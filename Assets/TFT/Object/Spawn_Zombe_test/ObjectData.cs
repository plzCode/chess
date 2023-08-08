using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Object Data", menuName = "Scriptable Object/Zombie Data", order = int.MaxValue)]
public class ObjectData : ScriptableObject
{
    [SerializeField]
    private string objName;
    public string ObjName { get { return objName; } }

    [SerializeField]
    private int hp;
    public int Hp { get { return hp; } }

    [SerializeField]
    private int damage;
    public int Damage { get { return damage; } }

    [SerializeField]
    private float sightRange;
    public float SightRange { get { return sightRange; } }

    [SerializeField]
    private float moveSpeed;
    public float MoveSpeed { get { return moveSpeed; } }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
