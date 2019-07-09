using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class test : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    public float test0;
    ScrollRect rect;
    float[] page= { 0, 0.5f, 1 };
    public float smooting = 4;
    float targrthorizontal = 0.5f;
    bool isDrag = false;
    public GameObject background;
    public float test00;
    public void OnBeginDrag(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        isDrag = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        isDrag = false;
        float posX = rect.horizontalNormalizedPosition;
        int index = 0;
        float offset = Mathf.Abs(page[index] - posX);
        for(int i = 1; i < page.Length; i++)
        {
            float temp = Mathf.Abs(page[i] - posX);
            if (temp < offset)
            {
                index = i;
                offset = temp;
            }
        }
        targrthorizontal = page[index];
    }



    // Start is called before the first frame update
    void Start()
    {
        rect = transform.GetComponent<ScrollRect>();
    }

    // Update is called once per frame
    void Update()
    {
        test0 = rect.horizontalNormalizedPosition;
        if (!isDrag)
        {
            rect.horizontalNormalizedPosition = Mathf.Lerp(rect.horizontalNormalizedPosition
                , targrthorizontal, Time.deltaTime * smooting);
        }
        BGMove();
    }

    void BGMove()
    {
        
        background.transform.localPosition = new Vector3((rect.horizontalNormalizedPosition-0.5f)*-Screen.width, 0, 0);
        test00 = background.transform.localPosition.x;
    }
}
