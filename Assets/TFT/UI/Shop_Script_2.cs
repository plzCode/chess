using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop_Script_2 : MonoBehaviour
{
    public Image[] imageUI;
    public Sprite[] imageSprites; // 이미지 스프라이트 배열

    // Start is called before the first frame update
    void Start()
    {
        // 시작할 때 이미지를 랜덤하게 설정합니다.
        ChangeImage();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // 이미지를 변경하는 함수
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

    // 랜덤한 이미지로 변경하는 함수
    public void ChangeImage()
    {
        int randomIndex = Random.Range(0, imageSprites.Length);
        SetImage(imageSprites[randomIndex]);
    }
}
