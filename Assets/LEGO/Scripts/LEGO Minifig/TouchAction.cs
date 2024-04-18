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

    private MinifigController minifigController; // MinifigController ������Ʈ�� ���� ���� ���� �߰�

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Character != null) // Character ���� ������Ʈ�� null�� �ƴ��� Ȯ��
        {
            // MinifigController ������Ʈ ��������
            minifigController = Character.GetComponent<MinifigController>();
            if (minifigController != null) // MinifigController ������Ʈ�� null�� �ƴ��� Ȯ��
            {
                switch (touchType)
                {
                    case TouchType.Up:
                        {
                            // MinifigController�� CustomVerticalMove �޼��� ȣ��
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
                Debug.LogWarning("MinifigController ������Ʈ�� ã�� �� �����ϴ�.");
            }
        }
        else
        {
            Debug.LogWarning("Character ���� ������Ʈ�� �������� �ʾҽ��ϴ�.");
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (Character != null) // Character ���� ������Ʈ�� null�� �ƴ��� Ȯ��
        {
            // MinifigController ������Ʈ ��������
            minifigController = Character.GetComponent<MinifigController>();
            if (minifigController != null) // MinifigController ������Ʈ�� null�� �ƴ��� Ȯ��
            {
                switch (touchType)
                {
                    case TouchType.Up:
                        {
                            // MinifigController�� CustomVerticalMove �޼��� ȣ��
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
                Debug.LogWarning("MinifigController ������Ʈ�� ã�� �� �����ϴ�.");
            }
        }
        else
        {
            Debug.LogWarning("Character ���� ������Ʈ�� �������� �ʾҽ��ϴ�.");
        }
    }

}
