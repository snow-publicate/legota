using UnityEngine;
using UnityEngine.EventSystems;
using Unity.LEGO.Minifig;
using System.Collections;

public class TouchJump : MonoBehaviour, IPointerClickHandler
{
    public GameObject Character;
    private MinifigController minifigController;
    bool isExecuted;
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        minifigController = Character.GetComponent<MinifigController>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        StartCoroutine(ExecuteOneFrame());
    }

    IEnumerator ExecuteOneFrame()
    {
        // ������ ������� ���� ���¶�� �����մϴ�.
        if (!isExecuted)
        {
            // �� ������ ���ȸ� ����� ������ ���⿡ �ۼ��մϴ�.
            Debug.Log("One frame execution");
            minifigController.jumpTry = true;

            // ������ ����Ǿ����� ǥ���մϴ�.
            isExecuted = true;

            // �� ������ ����մϴ�.
            yield return null;
        }

        // ������ �� �� ����� �Ŀ��� �ڷ�ƾ�� �ߴ��մϴ�.
        minifigController.jumpTry = false;
        isExecuted = false;
        yield break;
    }
}
