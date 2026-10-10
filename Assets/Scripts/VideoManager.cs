using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;
public class VideoManager : MonoBehaviour
{
    [Header("Video")]
    public VideoPlayer videoPlayer;

    [Header("UI Controls")]
    public Button btnPlayPause;
    public Slider videoProgress;
    public TMP_Text videoTime;
    public Button btnVolume;

    [Header("Icons")]
    public Sprite playIcon;
    public Sprite pauseIcon;
    public Sprite volumeOnIcon;
    public Sprite volumeOffIcon;

    private Image playPauseImage;
    private Image volumeImage;

    private bool isDragging = false;
    private bool isMuted = false;

    void Start()
    {
        playPauseImage = btnPlayPause.GetComponent<Image>();
        volumeImage = btnVolume.GetComponent<Image>();

        btnPlayPause.onClick.AddListener(TogglePlayPause);
        btnVolume.onClick.AddListener(ToggleVolume);

        videoProgress.onValueChanged.AddListener(OnSliderChanged);

        videoPlayer.prepareCompleted += OnVideoPrepared;

        UpdatePlayPauseIcon();
        UpdateVolumeIcon();
        UpdateTime();
    }

    void Update()
    {
        if (videoPlayer == null)
            return;

        if (videoPlayer.isPrepared)
        {
            if (!isDragging)
            {
                UpdateProgress();
            }

            UpdateTime();
        }
    }

    // =========================
    // PLAY / PAUSE
    // =========================

    public void TogglePlayPause()
    {
        if (!videoPlayer.isPrepared)
            return;

        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
        }
        else
        {
            videoPlayer.Play();
        }

        UpdatePlayPauseIcon();
    }

    void UpdatePlayPauseIcon()
    {
        if (playPauseImage == null)
            return;

        if (videoPlayer != null && videoPlayer.isPlaying)
        {
            playPauseImage.sprite = pauseIcon;
        }
        else
        {
            playPauseImage.sprite = playIcon;
        }
    }

    // =========================
    // SLIDER
    // =========================

    void UpdateProgress()
    {
        if (videoPlayer.length <= 0)
            return;

        float progress = (float)(videoPlayer.time / videoPlayer.length);

        videoProgress.SetValueWithoutNotify(progress);
    }

    public void OnSliderChanged(float value)
    {
        if (!isDragging)
            return;

        if (!videoPlayer.isPrepared)
            return;

        double newTime = value * videoPlayer.length;

        videoPlayer.time = newTime;
    }

    public void StartDragging()
    {
        isDragging = true;
    }

    public void EndDragging()
    {
        isDragging = false;

        if (videoPlayer.isPrepared)
        {
            double newTime = videoProgress.value * videoPlayer.length;
            videoPlayer.time = newTime;
        }
    }

    // =========================
    // WAKTU VIDEO
    // =========================

    void UpdateTime()
    {
        if (videoTime == null)
            return;

        double currentTime = videoPlayer.time;
        double totalTime = videoPlayer.length;

        videoTime.text = FormatTime(currentTime) + " / " + FormatTime(totalTime);
    }

    string FormatTime(double time)
    {
        int minutes = Mathf.FloorToInt((float)time / 60f);
        int seconds = Mathf.FloorToInt((float)time % 60f);

        return minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    // =========================
    // VOLUME
    // =========================

    public void ToggleVolume()
    {
        isMuted = !isMuted;

        if (videoPlayer.audioTrackCount > 0)
        {
            videoPlayer.SetDirectAudioMute(0, isMuted);
        }

        UpdateVolumeIcon();
    }

    void UpdateVolumeIcon()
    {
        if (volumeImage == null)
            return;

        if (isMuted)
        {
            volumeImage.sprite = volumeOffIcon;
        }
        else
        {
            volumeImage.sprite = volumeOnIcon;
        }
    }

    // =========================
    // VIDEO READY
    // =========================

    void OnVideoPrepared(VideoPlayer vp)
    {
        videoProgress.SetValueWithoutNotify(0);
        UpdateTime();
        UpdatePlayPauseIcon();
    }

    // =========================
    // PLAY VIDEO
    // =========================

    public void PlayVideo(VideoClip clip)
    {
        if (clip == null)
            return;

        videoPlayer.Stop();

        videoPlayer.clip = clip;

        videoPlayer.Prepare();

        videoPlayer.prepareCompleted -= OnVideoPrepared;
        videoPlayer.prepareCompleted += OnVideoPrepared;

        videoPlayer.Play();

        UpdatePlayPauseIcon();
    }

    // =========================
    // STOP VIDEO
    // =========================

    public void StopVideo()
    {
        if (videoPlayer != null)
        {
            videoPlayer.Stop();
        }

        videoProgress.SetValueWithoutNotify(0);

        UpdateTime();
        UpdatePlayPauseIcon();
    }
}
