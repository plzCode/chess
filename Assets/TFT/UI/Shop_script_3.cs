using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop_script_3 : MonoBehaviour
{
    public Image[] imageArray;
    // �̹����� �Ҵ��� ��������Ʈ �迭
    Sprite[] sprites = new Sprite[5]; // �� �κ��� �ʿ信 ���� �̹����� �ҷ��ͼ� �Ҵ��ϸ� �˴ϴ�.
    public Transform imagePanel;

    // Start is called before the first frame update
    void Start()
    {
        load();
        // �̹��� �迭�� �̹��� �Ҵ�
        for (int i = 0; i < imageArray.Length; i++)
        {
            if (i < sprites.Length) // �̹��� �迭 ũ�⺸�� ���� ���������� �Ҵ�
            {
                imageArray[i].sprite = sprites[i];
            }
            else
            {
                // �迭 ũ�⺸�� ���� �̹����� ���� ���, ���� ó��
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
