using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class RotateCube : MonoBehaviour
{
    public float speed = 60f;

    private GameObject Panel;

    //private bool isShowing = true;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; ++i)
            {
                Touch touch = Input.GetTouch(i);
                Vector3 pos = Camera.main.ScreenToViewportPoint(touch.position);
                //if (touch.phase == TouchPhase.Began)
                //{
                //transform.Rotate(speed*Time.deltaTime, 2*speed*Time.deltaTime, speed*Time.deltaTime);
                //}

                if (pos.x < 0.40f && pos.y < 0.50f)
                {
                    if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                    {
                        // get the touch absolute position and rotate the camera
                        //transform.RotateAround( Cube.transform.position, new Vector3 (1, 0, 0), (pos.y - 0.25f)*speed*Time.deltaTime );
                        //transform.RotateAround( Cube.transform.position, new Vector3 (0, 1, 0), 10*(pos.x - 0.10f)*speed*Time.deltaTime );
                        transform.Rotate(0, 10 * (pos.x - 0.2f) * speed * Time.deltaTime, 0);
                    }
                }
                /*if (pos.x < 0.12f)
                {
                    if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                    {
                        // get the touch absolute position and rotate the camera
                        transform.Rotate( (pos.y - 0.5f)*speed*Time.deltaTime, 0, 0 );
                    }
                }
                if (pos.x > 0.88f )
                {
                    if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                    {
                        // get the touch absolute position and rotate the camera
                        transform.Rotate( 0 , (pos.y - 0.5f)*speed*Time.deltaTime, 0 );
                    }
                }*/
                else if (pos.x > 0.60f && pos.y < 0.50f)
                {
                    if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                    {
                        // get the touch position from the screen touch to world point
                        //Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, Camera.main.WorldToScreenPoint(transform.position).y, Camera.main.WorldToScreenPoint(transform.position).z + 20*(pos.y - 0.5f) ) );
                        float adjustmentX = Mathf.Sin(Camera.main.transform.eulerAngles.y * Mathf.Deg2Rad);
                        float adjustmentZ = Mathf.Cos(Camera.main.transform.eulerAngles.y * Mathf.Deg2Rad);
                        Vector3 touchedPos = new Vector3(transform.position.x + 2 * (pos.x - 0.80f) * adjustmentZ + 2 * (pos.y - 0.25f) * adjustmentX, transform.position.y, transform.position.z - 2 * (pos.x - 0.80f) * adjustmentX + 2 * (pos.y - 0.25f) * adjustmentZ);
                        // lerp and set the position of the current object to that of the touch, but smoothly over time.
                        transform.position = Vector3.Lerp(transform.position, touchedPos, speed * Time.deltaTime);
                    }
                }
            }
        }
    }
}