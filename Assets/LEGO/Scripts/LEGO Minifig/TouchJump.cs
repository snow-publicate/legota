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
        // 동작이 실행되지 않은 상태라면 실행합니다.
        if (!isExecuted)
        {
            // 한 프레임 동안만 실행될 동작을 여기에 작성합니다.
            Debug.Log("One frame execution");
            minifigController.jumpTry = true;

            // 동작이 실행되었음을 표시합니다.
            isExecuted = true;

            // 한 프레임 대기합니다.
            yield return null;
        }

        // 동작이 한 번 실행된 후에는 코루틴을 중단합니다.
        minifigController.jumpTry = false;
        isExecuted = false;
        yield break;
    }
}
