using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RandomRotation : MonoBehaviour
{
    public float timer;
    public float interval = 2f;
    public float speed = 90f;
    private Quaternion targetRotation;
   
    // Start is called before the first frame update
    void Start()
    {
        targetRotation = Random.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            Vector3 randomEuler = new Vector3 (Random.Range(0f,360f), Random.Range(0f, 360f), Random.Range(0f, 360f));
            targetRotation = Quaternion.Euler (randomEuler);
            timer = 0; //reset timer
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation , targetRotation, speed * Time.deltaTime);//rotate the object
    }
}
