using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    private bool isPlaying = false; // Track whether the video is playing

    void Update()
    {
        // Check for space bar press on the computer
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TogglePlayback();
        }

        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            TogglePlayback();
        }
    }

    private void TogglePlayback()
    {
        if (videoPlayer != null)
        {
            if (isPlaying)
            {
                videoPlayer.Pause();
            }
            else
            {
                videoPlayer.Play();
            }
            isPlaying = !isPlaying; // Toggle the playing state
        }
    }
}
