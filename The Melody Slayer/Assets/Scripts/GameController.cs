using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    [SerializeField]
    private GameObject playButton;
    [SerializeField]
    private AudioSource song;

    // Use this for initialization
    void Start()
    {
		
	}
	
	// Update is called once per frame
	void Update()
    {
		
	}

    public void PlayButtonPressed()
    {
        if (!song.isPlaying)
        {
            song.Play();
        }
        playButton.SetActive(false);
    }
}
