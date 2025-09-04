using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using Unity.XR.PXR;

public class BeeSceneChange : MonoBehaviour
{
    private VideoPlayer videoPlayer; // The VideoPlayer component


    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>(); // Get the VideoPlayer component

        // Subscribe to the loopPointReached event, which is called when the video finishes
        videoPlayer.loopPointReached += OnVideoEnd;

        videoPlayer.Play(); // Start playing the video
    }

    // This method will be called when the video finishes playing
    private void OnVideoEnd(VideoPlayer vp)
    {
        // Change the scene to the specified scene (replace "YourSceneName" with your desired scene name)
        SceneManager.LoadScene("StressChecker");
    }

    // Update is called once per frame
    void Update()
    {
        // You can add any extra logic here if needed.
    }


}
