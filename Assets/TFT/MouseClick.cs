using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseClick : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Camera camera;
    public Image image;

    //플레이어 클릭으로 이동
    private bool isMoving = false;
    private Vector3 targetPosition;

    //마우스로 끌어서 처리
    private bool isDragging = false;
    private Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        //좌클릭
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

        } //마우스 좌클릭 놓았을 때
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
                    //오브젝트 판매를 위한 삭제
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
                    mousePosition.y = selectedObject.transform.position.y; // 오브젝트의 y 좌표를 유지하기 위해

                    selectedObject.transform.position = mousePosition;

                }
            }

        }

        //우클릭
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
                
            if (Physics.Raycast(ray, out hit))
            {
                // 객체에 대한 이벤트 처리
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
        // 플레이어를 마우스 위치로 이동
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