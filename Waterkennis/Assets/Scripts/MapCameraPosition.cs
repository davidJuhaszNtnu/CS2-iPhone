using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MapCameraPosition : MonoBehaviour
{
    public GameObject player;
    private float currentDistance, minDistance, maxDistance, rotateSpeed;
    float height;
    Vector3 currentDirection;

    float distance;

    void Start()
    {
        rotateSpeed = 0.01f;
        currentDistance = Vector3.Magnitude(player.transform.position - transform.position);
        minDistance = 3f;
        maxDistance = 50.0f;
        height = transform.position.y - Mathf.Abs(transform.position.z) / Mathf.Tan(Mathf.PI / 2f - (transform.localRotation.eulerAngles.x / 180f * Mathf.PI));
        currentDirection = Vector3.Normalize(new Vector3(player.transform.position.x, height, player.transform.position.z) - transform.position);
        currentDistance = Vector3.Magnitude(new Vector3(player.transform.position.x, height, player.transform.position.z) - transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, height, player.transform.position.z) - currentDirection * currentDistance;
        RotateZoom();
    }

    void RotateZoom(){
        if (Input.touchCount == 2) {
            Touch touchZero = Input.GetTouch (0);
            Touch touchOne = Input.GetTouch (1);

            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            float newDistance = currentDistance + deltaMagnitudeDiff * 0.1f;
            if (newDistance >= maxDistance)
                newDistance = maxDistance;
            else if (newDistance <= minDistance)
                newDistance = minDistance;
            Vector3 newPosition = new Vector3(player.transform.position.x, height, player.transform.position.z) - currentDirection * newDistance;
            if(newPosition.y > 5f){
                transform.position = newPosition;
                currentDistance = newDistance;
            }
            transform.rotation = Quaternion.LookRotation(new Vector3(player.transform.position.x, height, player.transform.position.z) - transform.position, Vector3.up);
        }
        if(Input.touchCount == 1){
            Vector2 touchPosition = Input.GetTouch (0).position;
            Vector2 touchDeltaPosition = Input.GetTouch (0).deltaPosition;

            float angle = Vector2.Angle(new Vector2(1, 0), touchDeltaPosition);
            float angle135 = Vector2.Angle(new Vector2(1, 0), new Vector2(0, Screen.height) - new Vector2(Screen.width, 0));
            float angle45 = 180f - angle135;

            float rotation_direction = 0f;
            // upper left quadrant
            if(touchPosition.x < Screen.width / 2 && touchPosition.y > Screen.height / 2){
                if(touchDeltaPosition.y > 0)
                    if(angle <= angle135)
                        rotation_direction = 1f;
                    else rotation_direction = -1f;
                if(touchDeltaPosition.y <= 0)
                    if(angle <= angle45)
                        rotation_direction = 1f;
                    else rotation_direction = -1f;
            }
            // upper right quadrant
            if(touchPosition.x >= Screen.width / 2 && touchPosition.y > Screen.height / 2){
                if(touchDeltaPosition.y > 0)
                    if(angle <= angle45)
                        rotation_direction = 1f;
                    else rotation_direction = -1f;
                if(touchDeltaPosition.y <= 0)
                    if(angle <= angle135)
                        rotation_direction = 1f;
                    else rotation_direction = -1f;
            }
            // lower right quadrant
            if(touchPosition.x >= Screen.width / 2 && touchPosition.y <= Screen.height / 2){
                if(touchDeltaPosition.y > 0)
                    if(angle >= angle135)
                        rotation_direction = 1f;
                    else rotation_direction = -1f;
                if(touchDeltaPosition.y <= 0)
                    if(angle >= angle45)
                        rotation_direction = 1f;
                    else rotation_direction = -1f;
            }
            // lower left quadrant
            if(touchPosition.x < Screen.width / 2 && touchPosition.y <= Screen.height / 2){
                if(touchDeltaPosition.y > 0)
                    if(angle >= angle45)
                        rotation_direction = 1f;
                    else rotation_direction = -1f;
                if(touchDeltaPosition.y <= 0)
                    if(angle >= angle135)
                        rotation_direction = 1f;
                    else rotation_direction = -1f;
            }
            if(touchDeltaPosition.x == 0f && touchDeltaPosition.y == 0f)
                rotation_direction = 0f;

            // if(rotation_direction != 0f)
                // Debug.Log(touchDeltaPosition + ", " + rotation_direction);
            float rotateByAngle = touchDeltaPosition.magnitude * rotateSpeed * rotation_direction;
            Vector3 currentPosition = transform.position;
            Vector3 centerOfRotation = new Vector3(player.transform.position.x, height, player.transform.position.z);
            currentPosition -= centerOfRotation;
            transform.position = new Vector3(Mathf.Cos(rotateByAngle) * currentPosition.x - Mathf.Sin(rotateByAngle) * currentPosition.z, currentPosition.y, Mathf.Sin(rotateByAngle) * currentPosition.x + Mathf.Cos(rotateByAngle) * currentPosition.z);
            transform.position += centerOfRotation;
            currentDirection = Vector3.Normalize(centerOfRotation - transform.position);
            transform.rotation = Quaternion.LookRotation(centerOfRotation - transform.position, Vector3.up);
        }
    }
}
