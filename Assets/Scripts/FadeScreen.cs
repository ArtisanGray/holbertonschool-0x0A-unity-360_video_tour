using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.Animations;

public class FadeScreen : MonoBehaviour
{
    public GameObject BlackOutFrame;
    public VideoClip[] videoClips;
    public GameObject videoPlayer;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }
    public void ChangeScene(string videoName)
    {
        string currentlyPlaying = videoPlayer.GetComponent<VideoPlayer>().clip.name;
        Debug.Log(currentlyPlaying);
        BlackOutFrame.GetComponent<Animator>().Play("transition");
        videoPlayer.transform.Find(currentlyPlaying).gameObject.SetActive(false);
        if (videoName == "LivingRoom")
        {
            videoPlayer.GetComponent<VideoPlayer>().clip = videoClips[0];
        }
        else if (videoName == "Cube")
        {
            videoPlayer.GetComponent<VideoPlayer>().clip = videoClips[1];
        }
        else if (videoName == "Cantina")
        {
            videoPlayer.GetComponent<VideoPlayer>().clip = videoClips[2];
        }
        else if (videoName == "Mezzanine")
        {
            videoPlayer.GetComponent<VideoPlayer>().clip = videoClips[3];
        }
        GameObject sceneToEnable = FindObject(videoPlayer, videoName);
        BlackOutFrame.GetComponent<Animator>().Play("Default");
        if (BlackOutFrame.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Default"))
        {
            sceneToEnable.SetActive(true);
        }
        
    }
    public static GameObject FindObject(GameObject parent, string name)
    {
        Transform[] trs = parent.GetComponentsInChildren<Transform>(true);
        foreach (Transform t in trs)
        {
            if (t.name == name)
            {
                return t.gameObject;
            }
        }
        return null;
    }
}

