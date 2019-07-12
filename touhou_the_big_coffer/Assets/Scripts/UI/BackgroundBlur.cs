using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundBlur : MonoBehaviour
{
    public ScrollRect rect;
    public Image BGimage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rect.horizontalNormalizedPosition < 0.5)
            BGimage.color = new Color(1, 1, 1, (1 - 2 * rect.horizontalNormalizedPosition));
    }
}
