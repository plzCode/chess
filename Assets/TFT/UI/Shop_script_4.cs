using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop_script_4 : MonoBehaviour
{
    public List<GameObject> tier1Objects;
    public List<GameObject> tier2Objects;
    public List<GameObject> tier3Objects;
    public List<GameObject> tier4Objects;
    public List<GameObject> tier5Objects;

    public List<GameObject> tier1_Champ;
    public List<GameObject> tier2_Champ;
    public List<GameObject> tier3_Champ;
    public List<GameObject> tier4_Champ;
    public List<GameObject> tier5_Champ;

    public float tier1Probability = 0.19f; // 10% 확률
    public float tier2Probability = 0.3f; // 20% 확률
    public float tier3Probability = 0.35f; // 30% 확률
    public float tier4Probability = 0.15f; // 20% 확률
    public float tier5Probability = 0.01f; // 10% 확률

    public GameObject imagePrefab; // Image 프리팹을 Inspector 창에서 지정해줘야 합니다.
    public GameObject buttonPrefab;
    public Transform panel; // Panel 객체를 Inspector 창에서 지정해줘야 합니다.

    void Start()
    {
        
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Reroll();
        }
    }

    

    private List<GameObject> RandomSelectObjects(List<GameObject> objects, int numToSelect)
    {
        List<GameObject> selectedObjects = new List<GameObject>();

        for (int i = 0; i < numToSelect; i++)
        {
            if (objects.Count == 0)
                break;

            float randomValue = Random.value;
            int randomIndex = Mathf.FloorToInt(randomValue * objects.Count);
            selectedObjects.Add(objects[randomIndex]);
        }

        return selectedObjects;
    }

    List<GameObject> Cards = new List<GameObject>();

    private List<GameObject> CalculateNumObjects()
    {
        Random.InitState(System.DateTime.Now.Millisecond);

        List<GameObject> selectedObjects = new List<GameObject>();
        List<GameObject> selectChamp = new List<GameObject>();

        

        for (int i = 0; i < 5; ++i)
        {
            float rnd = Random.Range(0.0f, 1.0f);
            if (tier1Probability > rnd)
            {
                int randomint = Random.Range(0, tier1Objects.Count);
                selectedObjects.Add(tier1Objects[randomint]);
                selectChamp.Add(tier1_Champ[randomint]);
            }
            else if (tier1Probability + tier2Probability > rnd)
            {
                int randomint = Random.Range(0, tier1Objects.Count);
                selectedObjects.Add(tier2Objects[randomint]);
                selectChamp.Add(tier2_Champ[randomint]);
            }
            else if (tier1Probability + tier2Probability + tier3Probability > rnd)
            {
                int randomint = Random.Range(0, tier1Objects.Count);
                selectedObjects.Add(tier3Objects[randomint]);
                selectChamp.Add(tier3_Champ[randomint]);
            }
            else if (tier1Probability + tier2Probability + tier3Probability + tier4Probability > rnd)
            {
                int randomint = Random.Range(0, tier1Objects.Count);
                selectedObjects.Add(tier4Objects[randomint]);
                selectChamp.Add(tier4_Champ[randomint]);
            }
            else if (tier1Probability + tier2Probability + tier3Probability + tier4Probability + tier5Probability > rnd)
            {
                int randomint = Random.Range(0, tier1Objects.Count);
                selectedObjects.Add(tier5Objects[randomint]);
                selectChamp.Add(tier5_Champ[randomint]);
            }

        }
        return selectedObjects;

        //int totalNumObjects = tier1Objects.Count + tier2Objects.Count + tier3Objects.Count + tier4Objects.Count + tier5Objects.Count;

        //int numToSelect = 5; // We want to select exactly 5 objects

        //// Calculate the total number of objects to select based on the probability
        //int numObjectsToSelect = Mathf.RoundToInt(numToSelect);

        //// Cap the number of objects to select to ensure it doesn't exceed the total number of objects
        //numObjectsToSelect = Mathf.Min(numObjectsToSelect, totalNumObjects);

        // Return the number of objects to select
    }

    public void Reroll()
    {
        Debug.Log("hi");
        Random.InitState(System.DateTime.Now.Millisecond);

        List<GameObject> selectedObjects = new List<GameObject>();


        selectedObjects = CalculateNumObjects();

        //// 각 티어별로 뽑을 개수 계산
        //int numTier1 = CalculateNumObjects(tier1Probability);
        //int numTier2 = CalculateNumObjects(tier2Probability);
        //int numTier3 = CalculateNumObjects(tier3Probability);
        //int numTier4 = CalculateNumObjects(tier4Probability);
        //int numTier5 = CalculateNumObjects(tier5Probability);

        //// 각 티어별로 무작위로 오브젝트 선택
        //selectedObjects.AddRange(RandomSelectObjects(tier1Objects, numTier1));
        //selectedObjects.AddRange(RandomSelectObjects(tier2Objects, numTier2));
        //selectedObjects.AddRange(RandomSelectObjects(tier3Objects, numTier3));
        //selectedObjects.AddRange(RandomSelectObjects(tier4Objects, numTier4));
        //selectedObjects.AddRange(RandomSelectObjects(tier5Objects, numTier5));

        // 기존에 있던 이미지 삭제
        foreach (Transform child in panel)
        {
            Destroy(child.gameObject);
        }

        int i = 0;
        // 선택된 오브젝트들의 이미지를 UI Panel에 출력
        foreach (GameObject obj in selectedObjects)
        {
            GameObject chp = selectChamp[i];
            SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                // UI 버튼 생성
                GameObject newButtonObject = Instantiate(buttonPrefab, panel);
                Button newButton = newButtonObject.GetComponent<Button>();
                newButton.GetComponent<Image>();

                // 버튼에 클릭 이벤트를 추가하려면 다음과 같이 UnityEvent를 사용합니다.
                newButton.onClick.AddListener(() =>
                {
                    // 버튼이 클릭되었을 때 실행할 동작을 여기에 추가합니다.
                    // 예를 들어 해당 아이템을 구매하거나 선택할 수 있습니다.
                    // 이 때 obj를 통해 선택된 아이템에 접근할 수 있습니다.
                    Vector3 spawnPosition = new Vector3(0, 0, 0);
                    Quaternion spawnRotation = Quaternion.identity;
                    SpawnPrefab(obj, spawnPosition, spawnRotation);
                    Debug.Log("Button clicked for item: " + obj.name);
                });

                /*GameObject newImageObject = Instantiate(imagePrefab, buttonPrefab.transform);
                Image newImage = newImageObject.GetComponent<Image>();
                newImage.sprite = spriteRenderer.sprite;*/
                // 이미지를 버튼의 자식으로 추가
                GameObject newImageObject = Instantiate(imagePrefab, newButtonObject.transform);
                Image newImage = newImageObject.GetComponent<Image>();
                //newImage.sprite = spriteRenderer.sprite;
                newButton.image.sprite = spriteRenderer.sprite;

            }
            i++;
        }
    }

    public void SpawnPrefab(GameObject Champ, Vector3 position, Quaternion rotation)
    {
        GameObject spawnedObject = Instantiate(Champ, position, rotation);
        // 생성된 오브젝트를 필요에 따라 추가 설정할 수 있습니다.
    }
}