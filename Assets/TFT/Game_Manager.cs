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
                // ũ�� ���� ���� ���� �߰�
                Vector3 spawnPosition = new Vector3(0, 0, 0);
                Quaternion spawnRotation = Quaternion.identity;
                SpawnPrefab(spawnPosition, spawnRotation);
                break;
            case round.rewardRound:
                Debug.Log("Reward Round");
                // ���� ���� ���� ���� �߰�
                break;
            case round.pvpRound:
                Debug.Log("PVP Round");
                // PVP ���� ���� ���� �߰�
                break;
            default:
                Debug.Log("Unknown Round Type");
                break;
        }
    }

    public GameObject prefabToSpawn; // �������� Inspector â���� ��������� �մϴ�.
    public void SpawnPrefab(Vector3 position, Quaternion rotation)
    {
        GameObject spawnedObject = Instantiate(prefabToSpawn, position, rotation);
        // ������ ������Ʈ�� �ʿ信 ���� �߰� ������ �� �ֽ��ϴ�.
    }
}
