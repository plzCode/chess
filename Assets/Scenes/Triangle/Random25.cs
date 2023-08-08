using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random25 : MonoBehaviour
{
    private List<int> numbers = new List<int>();

    private void Start()
    {
        GenerateRandomNumbers();
        PrintNumbers();
    }

    private void GenerateRandomNumbers()
    {
        for (int i = 0; i <= 25; i++)
        {
            numbers.Add(i);
        }

        // ���� ����Ʈ�� �ڼ��� ���� Fisher-Yates �˰����� ����մϴ�.
        System.Random rand = new System.Random();
        for (int i = numbers.Count - 1; i > 0; i--)
        {
            int j = rand.Next(0, i + 1);
            int temp = numbers[i];
            numbers[i] = numbers[j];
            numbers[j] = temp;
        }
    }

    private void PrintNumbers()
    {
        foreach (int number in numbers)
        {
            Debug.Log(number);

        }
    }
}
