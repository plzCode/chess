using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Inf : MonoBehaviour
{
    public float playerLife = 20;
    public float playerGold = 0;
    public float playerExp = 0;
    public float playerLevel = 1;

    int[] experienceLevels = { 2, 6, 10, 24, 40, 60, 84, 100 };
    int[] levelRequirements = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Updating Levels
    public void UpdateLevel()
    {
        for (int i = 0; i < experienceLevels.Length; i++)
        {
            if (playerExp < experienceLevels[i])
            {
                playerLevel = levelRequirements[i];
                Debug.Log("���� ��");
                break;
            }
        }
    }

    public void Gain_Gold(int gold)
    {
        playerGold += gold;
    }

    public void Gain_Exp(int exp)
    {
        int maxLevel = experienceLevels.Length;
        playerExp += exp;

        // ���� ������ �ִ� ����ġ
        int maxExpForCurrentLevel = experienceLevels[(int)playerLevel - 1];

        // ����ġ�� ���� ������ �ִ� ����ġ���� ũ�� ���� ��
        while (playerExp >= maxExpForCurrentLevel)
        {
            if (playerLevel >= maxLevel)
            {
                // �ִ� ������ �����ϸ� �� �̻� ���� �� �Ұ���
                playerExp = maxExpForCurrentLevel;
                break;
            }

            playerExp -= maxExpForCurrentLevel;
            playerLevel++;

            // ���� ������ �ִ� ����ġ
            maxExpForCurrentLevel = experienceLevels[(int)playerLevel - 1];
            Debug.Log("���� ��: " + playerLevel + "���� ����ġ : " + playerExp + "�䱸 ����ġ : " + experienceLevels[(int)playerLevel-1]);
        }

    }
}
