using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPopupManager : MonoBehaviour
{
    public GameObject videoPopup;
    public VideoPlayer videoPlayer;

    // Start is called before the first frame update
    public void OpenVideo()
    {
        videoPopup.SetActive(true);
        videoPlayer.Stop();
        videoPlayer.Play();
    }

    public void CloseVideo()
    {
        videoPlayer.Stop();
        videoPopup.SetActive(false);
    }
}
