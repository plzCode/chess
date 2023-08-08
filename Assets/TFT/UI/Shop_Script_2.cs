using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop_Script_2 : MonoBehaviour
{
    public Image[] imageUI;
    public Sprite[] imageSprites; // �̹��� ��������Ʈ �迭

    // Start is called before the first frame update
    void Start()
    {
        // ������ �� �̹����� �����ϰ� �����մϴ�.
        ChangeImage();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // �̹����� �����ϴ� �Լ�
    public void SetImage(Sprite newImage)
    {
        for (int i = 0; i < imageUI.Length; i++)
        {
            if (imageUI[i] != null)
            {
                imageUI[i].sprite = newImage;
            }
            else
            {
                Debug.Log("Image UI is Not Assigned");
            }
        }
    }

    // ������ �̹����� �����ϴ� �Լ�
    public void ChangeImage()
    {
        int randomIndex = Random.Range(0, imageSprites.Length);
        SetImage(imageSprites[randomIndex]);
    }
}
