using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ObjectA1;


public class Shop_script : MonoBehaviour
{
    public Image[] images = new Image[5];//상점 기물 이미지
    private ObjectA1 aObject;

    // Start is called before the first frame update
    void Start()
    {
        aObject = FindObjectOfType<ObjectA1>();
       
        for (int i = 0; i < 5; i++)
        {

            
            if (i < aObject.spriteRenderers.Length)
            {
                SpriteRenderer spriteRenderer = aObject.spriteRenderers[i];
                Sprite sprite = spriteRenderer.sprite;
                images[i].sprite = sprite;
                Debug.Log("hi_image_Test");
            }
            else
            {
                // 이미지 슬롯이 부족한 경우 빈 스프라이트를 할당하거나 숨길 수도 있습니다.
                images[i].sprite = null;
                images[i].gameObject.SetActive(false);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //click_image
    public void SwitchImage()
    {
        int prevImageIndex = GetActivateImageIndex();
        images[prevImageIndex].gameObject.SetActive(false);

        int randomIndex = Random.Range(0, images.Length);

        images[randomIndex].gameObject.SetActive(true);
    }

    //활성화 된 이미지의 인덱스 반환
    private int GetActivateImageIndex()
    {
        for(int i = 0; i<images.Length; i++)
        {
            if (images[i].gameObject.activeSelf)
                return i;
        }
        return -1; //활성화 된 이미지가 없을 경우
    }
}
