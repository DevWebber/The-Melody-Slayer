using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    [SerializeField]
    private GameObject playButton;
    [SerializeField]
    private AudioSource song;

    private int totalScore;
    private int totalCombo;
    private float totalAccuracy;

    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text accuracyText;
    [SerializeField]
    private Text comboText;

    private void OnEnable()
    {
        HittingMechanic.OnUpdateHits += HandleOnUpdateHits;
    }

    private void OnDisable()
    {
        HittingMechanic.OnUpdateHits -= HandleOnUpdateHits;
    }

    private void HandleOnUpdateHits(int hitType)
    {
        switch (hitType)
        {
            case 0:
                totalScore += 100;
                totalCombo++;
                break;
            case 1:
                totalScore += 50;
                totalCombo++;
                break;
            case 2:
                totalCombo = 0;
                break;
        }

        scoreText.text = "" + totalScore;
        comboText.text = "" + totalCombo;
        accuracyText.text = "" + totalAccuracy;

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
