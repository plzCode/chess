using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseClick : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Camera camera;
    public Image image;

    //�÷��̾� Ŭ������ �̵�
    private bool isMoving = false;
    private Vector3 targetPosition;

    //���콺�� ��� ó��
    private bool isDragging = false;
    private Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        //��Ŭ��
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                GameObject selectedObject = hit.collider.gameObject;
                if(selectedObject.tag == "Obj")
                {
                    isDragging = true;
                }
            }

        } //���콺 ��Ŭ�� ������ ��
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject selectedObject = hit.collider.gameObject;
                if (selectedObject.tag == "Obj")
                {
                    //������Ʈ �ǸŸ� ���� ����
                    Vector2 mousePosition2 = Input.mousePosition;
                    RectTransformUtility.ScreenPointToLocalPointInRectangle(image.transform as RectTransform, mousePosition2, null, out Vector2 localPosition);
                    bool isInsideImage = RectTransformUtility.RectangleContainsScreenPoint(image.transform as RectTransform, mousePosition2);

                    if (isInsideImage)
                    {
                        Destroy(selectedObject);
                    }
                }
            }

        }
        if (isDragging)
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject selectedObject = hit.collider.gameObject;
                if (selectedObject.tag == "Obj")
                {
                    Vector3 mousePosition = hit.point;
                    mousePosition.y = selectedObject.transform.position.y; // ������Ʈ�� y ��ǥ�� �����ϱ� ����

                    selectedObject.transform.position = mousePosition;

                }
            }

        }

        //��Ŭ��
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
                
            if (Physics.Raycast(ray, out hit))
            {
                // ��ü�� ���� �̺�Ʈ ó��
                //hit.transform.GetComponent<YourObjectScript>().OnClicked();
                GameObject selectedObject = hit.collider.gameObject;
                if (selectedObject.tag == "Obj") {
                    Debug.Log("Obj");
                   // Destroy(selectedObject);

                }
                else
                {
                    targetPosition = hit.point;
                    targetPosition.y = transform.position.y;
                    isMoving = true;

                }
                
            }
        }

        if (isMoving)
        {
            Player_Move();
        }


    }

    void Player_Move()
    {
        // �÷��̾ ���콺 ��ġ�� �̵�
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (transform.position == targetPosition)
        {
            isMoving = false;
        }
    }

    GameObject Get_selectedObject()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            GameObject selectedObject = hit.collider.gameObject;

            return selectedObject;
        }

        return null;
    }
}