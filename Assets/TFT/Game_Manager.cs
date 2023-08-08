using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Round_Start();
        }
    }
    public enum round
    {
        creepRound,
        rewardRound,
        pvpRound
    }

    public void Round_Start()
    {
        CreateRound(0);
    }

    public void Round_End()
    {

    }

    void CreateRound(round round)
    {
        switch (round)
        {
            case round.creepRound:
                Debug.Log("Creep Round");
                // 크립 라운드 생성 로직 추가
                Vector3 spawnPosition = new Vector3(0, 0, 0);
                Quaternion spawnRotation = Quaternion.identity;
                SpawnPrefab(spawnPosition, spawnRotation);
                break;
            case round.rewardRound:
                Debug.Log("Reward Round");
                // 보상 라운드 생성 로직 추가
                break;
            case round.pvpRound:
                Debug.Log("PVP Round");
                // PVP 라운드 생성 로직 추가
                break;
            default:
                Debug.Log("Unknown Round Type");
                break;
        }
    }

    public GameObject prefabToSpawn; // 프리팹을 Inspector 창에서 지정해줘야 합니다.
    public void SpawnPrefab(Vector3 position, Quaternion rotation)
    {
        GameObject spawnedObject = Instantiate(prefabToSpawn, position, rotation);
        // 생성된 오브젝트를 필요에 따라 추가 설정할 수 있습니다.
    }
}
