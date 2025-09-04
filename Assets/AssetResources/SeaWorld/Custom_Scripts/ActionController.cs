using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionController : MonoBehaviour
{

    [SerializeField]
    public float speed = 60f;
    private GameObject Cube;

    // Start is called before the first frame update
    void Start()
    {
        Camera_follower();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Cube = GameObject.Find("Cube");

            for (int i = 0; i < Input.touchCount; ++i)
            {
                Touch touch = Input.GetTouch(i);
                Vector3 pos = Camera.main.ScreenToViewportPoint(touch.position);

                Camera_follower();

                /*if ( pos.x < 0.40f && pos.y < 0.50f )
                {
                    if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                    {
                        // get the touch absolute position and rotate the camera
                        //transform.RotateAround( Cube.transform.position, new Vector3 (1, 0, 0), (pos.y - 0.25f)*speed*Time.deltaTime );
                        //transform.RotateAround( Cube.transform.position, new Vector3 (0, 1, 0), 10*(pos.x - 0.20f)*speed*Time.deltaTime );
                        //Camera_follower();
                    }
                }
                else if ( pos.x > 1.0f && pos.y < 0.50f )
                {
                    if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                    {
                        //Camera_follower();
                        //Camera_follower();
                    }
                }*/
            }
        }

    }

    private void Camera_follower()
    {
        // get the touch position from the screen touch to world point
        float adjustmentX = Mathf.Sin((Cube.transform.eulerAngles.y) * Mathf.Deg2Rad);
        float adjustmentZ = Mathf.Cos((Cube.transform.eulerAngles.y) * Mathf.Deg2Rad);
        Vector3 NewPos = new Vector3(Cube.transform.position.x - 10 * adjustmentX, Cube.transform.position.y, Cube.transform.position.z - 10 * adjustmentZ);
        // lerp and set the position of the current object to that of the touch, but smoothly over time.
        transform.position = Vector3.Lerp(transform.position, NewPos, 2 * speed * Time.deltaTime);
        transform.eulerAngles = new Vector3(0, Cube.transform.eulerAngles.y, 0);
    }
}
