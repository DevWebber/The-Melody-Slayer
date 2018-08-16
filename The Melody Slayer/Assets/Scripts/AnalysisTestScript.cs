using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnalysisTestScript : MonoBehaviour {
    /*
     * Script used to test the song analysis and the band buffers
     */
    [SerializeField]
    private GameObject analysisTestCube;
    [SerializeField]
    private GameObject analysisClassHolder;
    private SongAnalysis analysisClass;

    [SerializeField]
    private GameObject[] testCubes;
    private float[] localAudioSamples;
    private float[] localFrequencyBands;
    private float[] localFrequencyBuffer;
    private float[] localAudioBandBuffer;

    [SerializeField]
    private Material testCubeMaterial;

    [SerializeField]
    private float startScale;
    [SerializeField]
    private float scaleMultiplier;


	void Start()
    {
        analysisClass = analysisClassHolder.GetComponent<SongAnalysis>();
	}
	
	// Update is called once per frame
	void Update()
    {
        //AudioBandBuffer will always be between 0 and 1;
        for (int i = 0; i < 8; i++)
        {
            if (testCubes != null)
            {
                localFrequencyBuffer = analysisClass.GetBandBuffer();
                localAudioBandBuffer = analysisClass.GetAudioBandBuffer();
                testCubes[i].transform.localScale = new Vector3(testCubes[i].transform.localScale.x, (localFrequencyBuffer[i] * scaleMultiplier) + startScale, testCubes[i].transform.localScale.z);

                if (localAudioBandBuffer[2] >= 0.95)
                {
                    Debug.Log("Above Threshold");
                }

            }
        }
	}
}
