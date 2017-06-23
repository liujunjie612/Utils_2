using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UGUI_AutoClick : MonoBehaviour
{
    public Button uiButton1;
    public Button uiButton2;
    public Image uiImage;

    void Start()
    {
        uiButton1.onClick.AddListener(this.__onClick);
        uiButton2.onClick.AddListener(this.__onClick);
    }

    void OnGUI()
    {

        if (GUI.Button(new Rect (100,100,200,200), "Auto Button"))
        {
            //调用会触发Button的按钮变色
            ExecuteEvents.Execute<ISubmitHandler>(uiButton1.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.submitHandler);
        }

        if (GUI.Button(new Rect(300, 100, 200, 200), "Auto Button"))
        {
            //调用不会触发按钮变色
            ExecuteEvents.Execute<IPointerClickHandler>(uiButton2.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
        }

        if (GUI.Button(new Rect(100, 300, 200, 200), "Auto Image"))
        {
            ExecuteEvents.Execute<IPointerClickHandler>(uiImage.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
        }

    }

    private void __onClick()
    {
        Debug.Log("按钮点击");
    }

}
