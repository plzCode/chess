using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop_script_3 : MonoBehaviour
{
    public Image[] imageArray;
    // 이미지를 할당할 스프라이트 배열
    Sprite[] sprites = new Sprite[5]; // 이 부분은 필요에 따라 이미지를 불러와서 할당하면 됩니다.
    public Transform imagePanel;

    // Start is called before the first frame update
    void Start()
    {
        load();
        // 이미지 배열에 이미지 할당
        for (int i = 0; i < imageArray.Length; i++)
        {
            if (i < sprites.Length) // 이미지 배열 크기보다 작은 범위에서만 할당
            {
                imageArray[i].sprite = sprites[i];
            }
            else
            {
                // 배열 크기보다 많은 이미지가 있을 경우, 예외 처리
                Debug.LogWarning("Image array is smaller than the number of images to display.");
            }
        }
    }

    public void load()
    {
        foreach(Sprite sprite in sprites)
        {
            GameObject imageGO = new GameObject("Image", typeof(Image));
            imageGO.transform.SetParent(imagePanel, false);
            Image imageComponent = imageGO.GetComponent<Image>();
            imageComponent.sprite = sprite;
        }
    }
}
