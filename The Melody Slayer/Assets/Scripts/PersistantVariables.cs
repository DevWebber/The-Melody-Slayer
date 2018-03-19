using UnityEngine;
using System.Collections;

[System.Serializable]
public class PersistantVariables : MonoBehaviour {
    /// <summary>
    /// This is an object which will persist through all scenes. Stores important variables such as
    /// free aim being enabled, the difficulty and the fps counter.
    /// 
    /// This script needs to save itself, for the second set of variables.
    /// </summary>
    private static PersistantVariables persistantVariableScript;

    public float levelOneTopScore;
    public int levelOneRank;
    public float levelOneHighCombo;
    public float levelOnePassed;

    //public float distanceTravelled;
	// Use this for initialization
	void Awake()
    {
        //ensures we don't duplicate it
        DontDestroyOnLoad(gameObject);

        if (persistantVariableScript == null)
        {
            persistantVariableScript = this;
        }
        else
        {
            DestroyObject(gameObject);
        }
	}
}
