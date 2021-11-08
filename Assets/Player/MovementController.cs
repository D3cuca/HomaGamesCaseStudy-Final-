using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public enum SpatialPosition
    {
        Left,
        Center,
        Right, 
        Free
    }

    [Header("Components")]
    private InputControl thisInputControl;
    private Transform transform;
    private Animator anim;

    [Header("Movement Variables")]
    private SpatialPosition currentSpacialPosition = SpatialPosition.Center;
    private bool canMove;

    [Header("Signals")]
    public SignalSent increaseSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        thisInputControl = GetComponent<InputControl>();
        transform = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        canMove = true;
    }

    public void InputWasReceived()
    {
        float differenceX = thisInputControl.touchStartPosition.x - thisInputControl.touchEndPosition.x;
        float differenceY = thisInputControl.touchStartPosition.y - thisInputControl.touchEndPosition.y;
        if(Mathf.Abs(differenceX) > Mathf.Abs(differenceY))
        {
            StartCoroutine(MoveLeftOrRight());
        }
        else if(Mathf.Abs(differenceX) < Mathf.Abs(differenceY))
        {
            increaseSpeed.Raise();
        }
    }

    private IEnumerator MoveLeftOrRight()
    {
        if (canMove)
        {
            canMove = false;
            if (thisInputControl.touchStartPosition.x > thisInputControl.touchEndPosition.x)
            {
                if (currentSpacialPosition != SpatialPosition.Left)
                {
                    anim.SetTrigger("Left");

                    switch (currentSpacialPosition)
                    {
                        case SpatialPosition.Center:
                            currentSpacialPosition = SpatialPosition.Left;
                            break;
                        case SpatialPosition.Right:
                            currentSpacialPosition = SpatialPosition.Center;
                            break;
                    }
                }
            }
            else if (thisInputControl.touchStartPosition.x < thisInputControl.touchEndPosition.x)
            {
                if (currentSpacialPosition != SpatialPosition.Right)
                {
                    anim.SetTrigger("Right");
                    switch (currentSpacialPosition)
                    {
                        case SpatialPosition.Center:
                            currentSpacialPosition = SpatialPosition.Right;
                            break;
                        case SpatialPosition.Left:
                            currentSpacialPosition = SpatialPosition.Center;
                            break;
                    }
                }
            }
            //Wait for the duration of the animation 
            yield return new WaitForSeconds(0.33f);
            canMove = true;
        }
    }
}
