using UnityEngine;
using UnityEngine.Video;

public class WebMenuVideo : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();

        videoPlayer.source = VideoSource.Url;

        videoPlayer.url =
            Application.streamingAssetsPath + "/MainMenu.mp4";

        videoPlayer.isLooping = true;
        videoPlayer.playOnAwake = false;
        videoPlayer.waitForFirstFrame = true;

        // Background video does not need audio.
        videoPlayer.audioOutputMode = VideoAudioOutputMode.None;
    }

    void Start()
    {
        videoPlayer.prepareCompleted += OnVideoPrepared;
        videoPlayer.Prepare();
    }

    void OnVideoPrepared(VideoPlayer player)
    {
        player.Play();
    }

    void OnDestroy()
    {
        if (videoPlayer != null)
        {
            videoPlayer.prepareCompleted -= OnVideoPrepared;
        }
    }
}