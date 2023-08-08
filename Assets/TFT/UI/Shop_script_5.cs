using System.Collections.Generic;
using UnityEngine;

public class Shop_script_5 : MonoBehaviour
{
    public List<GameObject> listA;
    public List<GameObject> listB;
    public List<GameObject> listC;
    public List<GameObject> listD;
    public List<GameObject> listE;

    private List<GameObject> selectedObjects;

    private void Start()
    {
        selectedObjects = new List<GameObject>();
        SelectObjectsWithProbability(listA, 0.2f);
        SelectObjectsWithProbability(listB, 0.4f);
        SelectObjectsWithProbability(listC, 0.1f);
        SelectObjectsWithProbability(listD, 0.3f);
        SelectObjectsWithProbability(listE, 0.5f);

        // ���õ� ��ü���� ����ϰų� ����ϴ� ���� �۾� ����
        // ...

        for(int i = 0; i<5; i++)
        {
            Debug.Log(selectedObjects.Count);
        }
    }

    private void SelectObjectsWithProbability(List<GameObject> objList, float probability)
    {
        int maxSelections = 5 - selectedObjects.Count;
        int numSelections = Mathf.Min(Mathf.FloorToInt(objList.Count * probability), maxSelections);

        // ����Ʈ���� Ȯ���� ���� �������� numSelections ��ŭ ����
        for (int i = 0; i < numSelections; i++)
        {
            int randomIndex = Random.Range(0, objList.Count);
            GameObject selectedObject = objList[randomIndex];
            selectedObjects.Add(selectedObject);
            
        }
    }

    // ���õ� ��ü ���� Ȯ���ϴ� �Լ� (���õ� ��ü�� ��Ȯ�� 5������ Ȯ��)
    private void CheckSelectedObjectCount()
    {
        if (selectedObjects.Count < 5)
        {
            Debug.LogError("���õ� ��ü ���� 5�� �̸��Դϴ�.");
        }
        else if (selectedObjects.Count > 5)
        {
            Debug.LogWarning("���õ� ��ü ���� 5���� �ʰ��մϴ�.");
        }
    }
}