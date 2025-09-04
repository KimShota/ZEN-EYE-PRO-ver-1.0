using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public class PositionChange
{
    public float delayTime;           // How long to wait before moving
    public Vector3 newLocalPosition;  // The local position to move to
}

public class positionChanger : MonoBehaviour
{
    public List<PositionChange> changes = new List<PositionChange>();

    private float timer = 0f;
    private int currentIndex = 0;

    void Start()
    {
        if (changes.Count > 0)
        {
            transform.localPosition = changes[0].newLocalPosition;
        }
    }

    void Update()
    {
        if (changes.Count == 0) return;

        timer += Time.deltaTime;

        if (timer >= changes[currentIndex].delayTime)
        {
            // Move to the next local position in the list
            currentIndex = (currentIndex + 1) % changes.Count;
            transform.localPosition = changes[currentIndex].newLocalPosition;

            // Reset the timer for the next move
            timer = 0f;
        }
    }
}