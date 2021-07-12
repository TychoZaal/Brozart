using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeToLaunch : MonoBehaviour
{
    bool isDown = false;
    Vector3 swipeOrigin;

    public Transform originalBall, destinationBall;
    public Camera camera;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1 && !isDown)
        {
            Vector3 touch = Input.GetTouch(0).position;
            touch.z = transform.position.z;
            swipeOrigin = camera.ScreenToWorldPoint(touch);
        }

        if (Input.touchCount > 0) isDown = true;

        originalBall.position = swipeOrigin;
        //if (isDown) destinationBall.position = swipeOrigin + (swipeOrigin - Camera.main.ScreenToWorldPoint(Input.touches[0].position));

        if (isDown && TouchRelease())
        {
            // destinationBall.position = swipeOrigin + (swipeOrigin - Camera.main.ScreenToWorldPoint(Input.touches[0].position));
            isDown = false;
            swipeOrigin = Vector3.zero;
        }
    }

    public bool TouchRelease()
    {
        bool b = false;
        for (int i = 0; i < Input.touches.Length; i++)
        {
            b = Input.touches[i].phase == TouchPhase.Ended;
            if (b)
                break;
        }
        return b;
    }
}
