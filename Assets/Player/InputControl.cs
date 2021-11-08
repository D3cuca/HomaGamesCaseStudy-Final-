using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class InputControl : MonoBehaviour
{
    public Vector2 touchStartPosition;
    public Vector2 touchEndPosition;
    public SignalSent touchEnded;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchCurrentPos = touch.position;

            if(touch.phase == TouchPhase.Began)
            {
                touchStartPosition = touchCurrentPos;
            }

            if(touch.phase == TouchPhase.Ended)
            {
                touchEndPosition = touchCurrentPos;
                touchEnded.Raise();
            }
        }
    }
}
