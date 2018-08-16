using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongAnalysis : MonoBehaviour {

    private AudioSource levelMusic;

    public float[] audioSamples;
    public float[] frequencyBands;
    public float[] bandBuffer;
    private float[] bufferDecrease;

    private float[] frequencyBandHighest;
    public float[] audioBand;
    public float[] audioBandBuffer;

	void Start()
    {
        levelMusic = GetComponent<AudioSource>();
        audioSamples = new float[512];
        frequencyBands = new float[8];
        bandBuffer = new float[8];
        bufferDecrease = new float[8];
        frequencyBandHighest = new float[8];
        audioBand = new float[8];
        audioBandBuffer = new float[8];
    }
	
	void Update()
    {
        GetAudioSourceData();
        MakeFrequencyBands();
        BandBuffer();
        CreateAudioBands();
    }

    void GetAudioSourceData()
    {
        levelMusic.GetSpectrumData(audioSamples, 0, FFTWindow.Blackman);
    }

    void MakeFrequencyBands()
    {
        /*Figure out how many bands of frequency we want to make
        44100 / 512 = 86hz per sample

        0 - 2 = 172hz
        1 - 4 = 344hz
        2 - 8 = 688hz
        3 - 16 = 1376hz
        4 - 32 = 2725hz
        5 - 64 = 5504hz
        6 - 128 = 11008hz
        7 - 256 = 22016hz
        */

        int count = 0;

        for (int i = 0; i < 8; i++)
        {
            float average = 0;
            //Handles each band count as powers of 2
            int sampleCount = (int)Mathf.Pow(2, i) * 2;

            for (int j = 0; j < sampleCount; j++)
            {
                average += audioSamples[count] * (count + 1);
                count++;
            }

            average /= count;

            frequencyBands[i] = average * 10;
        }
    }

    void BandBuffer()
    {
        for (int i = 0; i < 8; i++)
        {
            if (frequencyBands[i] > bandBuffer[i])
            {
                bandBuffer[i] = frequencyBands[i];
                bufferDecrease[i] = 0.005f;
            }

            if (frequencyBands[i] < bandBuffer[i])
            {
                bandBuffer[i] -= bufferDecrease[i];
                bufferDecrease[i] *= 1.2f;
            }
        }
    }

    void CreateAudioBands()
    {
        for (int i = 0; i < 8; i++)
        {
            if (frequencyBands[i] > frequencyBandHighest[i])
            {
                frequencyBandHighest[i] = frequencyBands[i];
            }
            audioBand[i] = (frequencyBands[i] / frequencyBandHighest[i]);
            audioBandBuffer[i] = (bandBuffer[i] / frequencyBandHighest[i]);
        }

    }

    public float[] GetAudioSamples()
    {
        return audioSamples;
    }
    public float[] GetFrequencyBands()
    {
        return frequencyBands;
    }

    public float[] GetBandBuffer()
    {
        return bandBuffer;
    }

    public float[] GetAudioBandBuffer()
    {
        return audioBandBuffer;
    }
}
