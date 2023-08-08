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

        // 선택된 객체들을 사용하거나 출력하는 등의 작업 수행
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

        // 리스트에서 확률에 따라 무작위로 numSelections 만큼 선택
        for (int i = 0; i < numSelections; i++)
        {
            int randomIndex = Random.Range(0, objList.Count);
            GameObject selectedObject = objList[randomIndex];
            selectedObjects.Add(selectedObject);
            
        }
    }

    // 선택된 객체 수를 확인하는 함수 (선택된 객체가 정확히 5개인지 확인)
    private void CheckSelectedObjectCount()
    {
        if (selectedObjects.Count < 5)
        {
            Debug.LogError("선택된 객체 수가 5개 미만입니다.");
        }
        else if (selectedObjects.Count > 5)
        {
            Debug.LogWarning("선택된 객체 수가 5개를 초과합니다.");
        }
    }
}