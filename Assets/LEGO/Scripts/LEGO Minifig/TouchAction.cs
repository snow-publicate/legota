using System;
using System.Collections;
using Unity.LEGO.Minifig;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchAction : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject Character;
    enum TouchType
    {
        Up,
        Down,
        Right,
        Left,
    }

    [Header("Controls")]
    [SerializeField]
    TouchType touchType = TouchType.Up;

    private MinifigController minifigController; // MinifigController 컴포넌트에 대한 참조 변수 추가

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Character != null) // Character 게임 오브젝트가 null이 아닌지 확인
        {
            // MinifigController 컴포넌트 가져오기
            minifigController = Character.GetComponent<MinifigController>();
            if (minifigController != null) // MinifigController 컴포넌트가 null이 아닌지 확인
            {
                switch (touchType)
                {
                    case TouchType.Up:
                        {
                            // MinifigController의 CustomVerticalMove 메서드 호출
                            minifigController.customVerticalMoveForward();
                            break;
                        }
                    case TouchType.Down:
                        {
                            minifigController.customVerticalMoveBackword();
                            break;
                        }
                    case TouchType.Right:
                        {
                            minifigController.customHorizontalMoveRight();
                            break;
                        }
                    case TouchType.Left:
                        {
                            minifigController.customHorizontalMoveLeft();
                            break;
                        }

                }
            }
            else
            {
                Debug.LogWarning("MinifigController 컴포넌트를 찾을 수 없습니다.");
            }
        }
        else
        {
            Debug.LogWarning("Character 게임 오브젝트가 설정되지 않았습니다.");
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (Character != null) // Character 게임 오브젝트가 null이 아닌지 확인
        {
            // MinifigController 컴포넌트 가져오기
            minifigController = Character.GetComponent<MinifigController>();
            if (minifigController != null) // MinifigController 컴포넌트가 null이 아닌지 확인
            {
                switch (touchType)
                {
                    case TouchType.Up:
                        {
                            // MinifigController의 CustomVerticalMove 메서드 호출
                            minifigController.customVerticalMoveStop();
                            break;
                        }
                    case TouchType.Down:
                        {
                            minifigController.customVerticalMoveStop();
                            break;
                        }
                    case TouchType.Right:
                        {
                            minifigController.customHorizontalMoveStop();
                            break;
                        }
                    case TouchType.Left:
                        {
                            minifigController.customHorizontalMoveStop();
                            break;
                        }

                }
            }
            else
            {
                Debug.LogWarning("MinifigController 컴포넌트를 찾을 수 없습니다.");
            }
        }
        else
        {
            Debug.LogWarning("Character 게임 오브젝트가 설정되지 않았습니다.");
        }
    }

}
