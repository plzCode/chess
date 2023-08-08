using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ObjectA1;


public class Shop_script : MonoBehaviour
{
    public Image[] images = new Image[5];//���� �⹰ �̹���
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
                // �̹��� ������ ������ ��� �� ��������Ʈ�� �Ҵ��ϰų� ���� ���� �ֽ��ϴ�.
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

    //Ȱ��ȭ �� �̹����� �ε��� ��ȯ
    private int GetActivateImageIndex()
    {
        for(int i = 0; i<images.Length; i++)
        {
            if (images[i].gameObject.activeSelf)
                return i;
        }
        return -1; //Ȱ��ȭ �� �̹����� ���� ���
    }
}
