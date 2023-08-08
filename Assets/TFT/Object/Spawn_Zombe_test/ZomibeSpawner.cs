using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ZombieType { Normal, Special }

public class ZomibeSpawner : MonoBehaviour
{
    [SerializeField]
    private List<ObjectData> zombieDatas;
    [SerializeField]
    private GameObject zombiePrefab;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i<zombieDatas.Count; i++)
        {
            var zombie = SpawnZombie((ZombieType)i);
            zombie.PrintZombieData();

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Zombie SpawnZombie(ZombieType type)
    {
        var newZombie = Instantiate(zombiePrefab).GetComponent<Zombie>();
        newZombie.zombieData = zombieDatas[(int)type];
        newZombie.name = newZombie.zombieData.ObjName;
        return newZombie;
    }
}
