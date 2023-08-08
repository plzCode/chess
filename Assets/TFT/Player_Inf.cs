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
                Debug.Log("레벨 업");
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

        // 현재 레벨의 최대 경험치
        int maxExpForCurrentLevel = experienceLevels[(int)playerLevel - 1];

        // 경험치가 현재 레벨의 최대 경험치보다 크면 레벨 업
        while (playerExp >= maxExpForCurrentLevel)
        {
            if (playerLevel >= maxLevel)
            {
                // 최대 레벨에 도달하면 더 이상 레벨 업 불가능
                playerExp = maxExpForCurrentLevel;
                break;
            }

            playerExp -= maxExpForCurrentLevel;
            playerLevel++;

            // 다음 레벨의 최대 경험치
            maxExpForCurrentLevel = experienceLevels[(int)playerLevel - 1];
            Debug.Log("레벨 업: " + playerLevel + "현재 경험치 : " + playerExp + "요구 경험치 : " + experienceLevels[(int)playerLevel-1]);
        }

    }
}
