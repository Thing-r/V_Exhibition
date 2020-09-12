using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoMngr : MonoBehaviour
{ 
    public VideoPlayer m_VideoPlayer;
    public List<VideoClip> m_VideoClips;
    private int m_VideoClipIndex = 0;

    public Sprite m_PlaySprite;
    public Sprite m_PauseSprite;
    public Image m_PlayPauseBG;
    public GameObject videoCP;
    public bool onStartVCP = true;

    // SHUFFLE //
    private bool m_Shuffle = false;

    // Start is called before the first frame update
    private void Start(){

    m_VideoPlayer.clip = m_VideoClips[0];
    videoCP.SetActive(onStartVCP);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            Debug.Log("Yeah, that triggered!!!");
            OnClick_PlayPause();
            videoCP.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody)
        {
            OnClick_PlayPause();
            videoCP.SetActive(false);

            //other.attachedRigidbody.AddForce(Vector3.up * 10);
        }
    }

    //  ONCLICK PLAY / PAUSE  ------------------------
    public void OnClick_PlayPause()
{
    if (m_VideoPlayer.isPlaying)
    {
        m_VideoPlayer.Pause();
        SetIsPlayingSprite(false);
    }
    else
    {
        m_VideoPlayer.Play();
        SetIsPlayingSprite(true);
    }
}

private void SetIsPlayingSprite(bool isActive)
{
    m_PlayPauseBG.sprite = (isActive) ? m_PauseSprite : m_PlaySprite;
}

    // SKIP button functionality

    // enable shuffling
    public void OnClick_Shuffle()
    {
        m_Shuffle = !m_Shuffle;
    }

    private void IncrementIndex()
    {
        m_VideoClipIndex++;

        if (m_VideoClipIndex >= m_VideoClips.Count)
            m_VideoClipIndex = m_VideoClipIndex % m_VideoClips.Count;
    }

    private void DecrementIndex()
    {
        m_VideoClipIndex--;

        if (m_VideoClipIndex < 0)
            m_VideoClipIndex = m_VideoClips.Count - 1;
    }

    public void OnClick_Next()
    {
        UnityEngine.Debug.Log(">>>>>>>>>>>>>>");
        m_VideoPlayer.Stop();

        // m_CurrentTimeSlider.value = 0;
        // m_InteractiveSlider.value = 0;

        if (!m_Shuffle)
            IncrementIndex();

        m_VideoPlayer.clip = m_VideoClips[m_VideoClipIndex];
        m_VideoPlayer.Play();
    }

    //  PREVIOUS option ------------------------
    public void OnClick_Previous()
    {
        Debug.Log("<<<<<<<<<<<<<<<<");
        m_VideoPlayer.Stop();

        if (!m_Shuffle)
            DecrementIndex();

        m_VideoPlayer.clip = m_VideoClips[m_VideoClipIndex];

        //SetTotalTimeUI();
        m_VideoPlayer.Play();
    }


}
