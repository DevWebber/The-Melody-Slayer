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
    private float currentHealth = 100;

    [SerializeField][Range(1, 100)]
    private int mapHealthRecovery;
    [SerializeField][Range(1,40)]
    private int mapHealthDecay;

    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text accuracyText;
    [SerializeField]
    private Text comboText;
    [SerializeField]
    private Slider healthSlider;

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
                if (currentHealth <= 100)
                {
                    currentHealth += mapHealthRecovery;
                }
                break;
            case 1:
                totalScore += 50;
                totalCombo++;
                if (currentHealth <= 100)
                {
                    currentHealth += mapHealthRecovery;
                }
                break;
            case 2:
                totalCombo = 0;
                if (currentHealth > 0)
                {
                    currentHealth -= mapHealthDecay;
                }
                break;
        }

        scoreText.text = "" + totalScore;
        comboText.text = "" + totalCombo;
        accuracyText.text = "" + totalAccuracy;
        healthSlider.value = currentHealth / 100;

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
