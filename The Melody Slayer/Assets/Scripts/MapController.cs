using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapController : MonoBehaviour {

    public delegate void UpdateNoteState(bool stateChange);
    public static event UpdateNoteState OnUpdateNoteState;

    private AudioSource song;

    private enum NoteType { Single, Hold, Swipe }
    //Structure to hold the attributes of a note.
    struct Note
    {
        public NoteType noteType;
        public float timeDelay;
        public int indexOfSpawn;
    }

    //Array that holds the notes, acting as the map.
    private List<Note> simpleMapArray;
    //private AudioSource currentLevelSong;

    [SerializeField]
    private GameObject[] noteTypes;
    [SerializeField]
    private Transform[] noteSpawnPoints;

    private NoteType[] typeExample;
    private float[] delayExample;
    [Range(0, 7)]
    private int[] indexExample;

    //private double currentTime;
    private int currentNoteIndex = 0;
    private bool endOfSong;
    private bool startedSong;

    private float songLength;
    private float currentTime;
    private bool abilityTriggered;

	// Use this for initialization
	void Start()
    {
        song = GetComponent<AudioSource>();

        TestMapWithoutAnalysis();

        songLength = song.clip.length;

        endOfSong = false;
        startedSong = false;
        abilityTriggered = false;
    }
	
	// Update is called once per frame
	void LateUpdate()
    {
        //currentTime = AudioSettings.dspTime;
        if (!song.isPlaying && startedSong)
        {
            Debug.Log(!song.isPlaying + "" + startedSong);
            endOfSong = true;
        }

        currentTime += Time.deltaTime;

        if ((int)currentTime >= (songLength / 3) && (int)currentTime <= (songLength / 3) + 0.125 && !abilityTriggered)
        {
            abilityTriggered = true;
            OnUpdateNoteState(true);
            Debug.Log("Activate Ability");
        }
	}
     
    IEnumerator WaitForTimeDelay()
    {
        while (!endOfSong)
        {
            for (int i = 0; i < simpleMapArray.Count; i++)
            {
                Instantiate(noteTypes[(int)simpleMapArray[i].noteType], noteSpawnPoints[simpleMapArray[i].indexOfSpawn].position, noteTypes[(int)simpleMapArray[i].noteType].transform.rotation);             
                yield return new WaitForSeconds(simpleMapArray[i].timeDelay);

                if (i == simpleMapArray.Count - 1)
                {
                    i = 0;
                }
            }
        }
    }

    public void SpawnNote()
    {
        endOfSong = false;
        StartCoroutine(WaitForTimeDelay());
    }

    private void TestMapWithoutAnalysis()
    {
        //Example note
        Note newNote = new Note();
        //Temporary
        simpleMapArray = new List<Note>();

        if (SceneManager.GetActiveScene().name == "FirstLevel")
        {
            typeExample = new NoteType[30] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            delayExample = new float[30] { 0.5F, 0.5F, 0.5F, 0.5F, 0.5F, 0.5F, 0.5F, 0.5F, 1F, 1F, 0.4F, 0.4F, 1F, 0.5F, 0.5F, 0.5F, 1F, 0.3F, 0.3F, 0.3F, 0.5F, 0.5F, 0.8F, 0.5F, 0.5F, 1F, 1F, 0.3F, 0.6F, 0.7F };
            indexExample = new int[30] { 0, 1, 2, 3, 4, 5, 6, 7, 0, 1, 2, 3, 4, 5, 6, 7, 5, 4, 3, 6, 7, 3, 2, 4, 4, 5, 7, 2, 1, 2 };

        }
        else if (SceneManager.GetActiveScene().name == "SecondLevel")
        {
            typeExample = new NoteType[30] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            delayExample = new float[30] { 1F, 0.5F, 0.6F, 0.3F, 0.4F, 0.5F, 0.6F, 0.5F, 0.7F, 0.7F, 0.4F, 0.4F, 1F, 0.9F, 0.9F, 0.5F, 0.5F, 0.4F, 0.6F, 0.6F, 0.6F, 1.5F, 0.2F, 0.2F, 1.5F, 0.7F, 1F, 0.6F, 0.3F, 0.7F };
            indexExample = new int[30] { 1, 1, 2, 5, 7, 5, 5, 7, 0, 2, 1, 7, 6, 3, 6, 7, 5, 4, 2, 3, 7, 0, 2, 5, 5, 4, 7, 2, 1, 4 };
        }
        else if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            typeExample = new NoteType[30] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            delayExample = new float[30] { 1F, 0.5F, 0.6F, 0.3F, 0.4F, 0.5F, 0.6F, 0.5F, 0.7F, 0.7F, 0.4F, 0.4F, 1F, 0.9F, 0.9F, 0.5F, 0.5F, 0.4F, 0.6F, 0.6F, 0.6F, 1.5F, 0.2F, 0.2F, 1.5F, 0.7F, 1F, 0.6F, 0.3F, 0.7F };
            indexExample = new int[30] { 1, 1, 2, 5, 7, 5, 5, 7, 0, 2, 1, 7, 6, 3, 6, 7, 5, 4, 2, 3, 7, 0, 2, 5, 5, 4, 7, 2, 1, 4 };
        }

        for (int i = 0; i < typeExample.Length; i++)
        {
            newNote.noteType = typeExample[i];
            newNote.indexOfSpawn = indexExample[i];
            newNote.timeDelay = delayExample[i];

            simpleMapArray.Add(newNote);
        }
    }

    private void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
