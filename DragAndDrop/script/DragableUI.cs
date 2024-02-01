using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystem;

public class DropableUI : MonoBehaviour, IBeginHandler, IDragHandler, IEndDragHandler
{
    private Transform canvas;           //UI가 소속되어 있는 최상단의 Canvas Transform
    private Transform previousParent;   //해당 오브젝트가 직전에 소속되어 있었던 부모 Transform
    private RectTransform rect;         //UI 위치 제어를 위한 RectTransform
    private CavasGroup;                 //UI의 알파값과 상호작용 제어를 위한 CanvasGroup

    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>().transform;
        rect = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //드래그 시작 시 UI를 최상단 Canvas의 자식으로 만들고, 상호작용을 끔
        previousParent = transform.parent;
        transform.SetParent(canvas); //UI를 최상단 Canvas의 자식으로 만듦
        transform.SetAsLastSibling(); //UI를 Canvas의 자식 중 가장 마지막으로 만듦

        //알파값을 0.5로 설정하고, 광선 충돌 처리가 되지 않도록 상호작용을 끔
        canvasGroup.alpha = 0.5f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //드래그 중일 때 UI의 위치를 마우스 위치로 이동
        rect.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(transform.parent == canvas)
        {
            //드래그가 끝났을 때 UI를 직전에 소속되어 있던 부모의 자식으로 만들고, 상호작용을 켬
            transform.SetParent(previousParent);
            rect.position = previousParent.GetComponent<RectTransform>().position;
        }

        //알파값을 1로 설정하고, 광선 충돌 처리가 가능하도록 상호작용을 켬
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
    }
    
}
