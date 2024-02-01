using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystem;
using UnityEngine.UI;

public class DropableUI : MonoBehaviour, IpointerEnterHandler, IPointerExitHandler, IDropHandler
{
    private Image image;                //드롭 가능한 UI의 이미지
    private RectTransform rect;        //드롭 가능한 UI의 위치 제어를 위한 RectTransform

    private void Awake()
    {
        image = GetComponent<Image>();
        rect = GetComponent<RectTransform>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //드롭 가능한 UI에 마우스가 들어왔을 때 이미지의 색상을 노란색으로 변경
        image.color = Color.yellow;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //드롭 가능한 UI에서 마우스가 나갔을 때 이미지의 색상을 흰색으로 변경
        image.color = Color.white;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            //드롭 가능한 UI에 다른 UI가 드롭되었을 때 드롭된 UI의 부모를 해당 UI로 변경
            eventData.pointerDrag.transform.SetParent(transform);

            //드롭된 UI의 위치를 드롭 가능한 UI의 위치로 변경
            eventData.pointerDrag.GetComponent<RectTransform>().position = rect.position;
        }
    }
    
}
