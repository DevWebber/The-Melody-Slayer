using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapController : MonoBehaviour {

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

	// Use this for initialization
	void Start()
    {
        //currentLevelSong = GetComponent<AudioSource>();
        //Example note
        Note newNote = new Note();
        //Temporary
        simpleMapArray = new List<Note>();

        typeExample = new NoteType[30] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        delayExample = new float[30] { 0.5F, 0.5F, 0.5F, 0.5F, 0.5F, 0.5F, 0.5F, 0.5F, 1F, 1F, 0.4F, 0.4F, 1F, 0.5F, 0.5F, 0.5F, 1F, 0.3F, 0.3F, 0.3F, 0.5F, 0.5F, 0.8F, 0.5F, 0.5F, 1F, 1F, 0.3F, 0.6F, 0.7F };
        indexExample = new int[30] { 0, 1, 2, 3, 4, 5, 6, 7, 0, 1, 2, 3, 4, 5, 6, 7, 5, 4, 3, 6, 7, 3, 2, 4, 4, 5, 7, 2, 1, 2 };

        for (int i = 0; i < typeExample.Length; i++)
        {
            newNote.noteType = typeExample[i];
            newNote.indexOfSpawn = indexExample[i];
            newNote.timeDelay = delayExample[i];

            simpleMapArray.Add(newNote);
        }

        endOfSong = false;
    }
	
	// Update is called once per frame
	void Update()
    {
        //currentTime = AudioSettings.dspTime;
	}
     
    IEnumerator waitForTimeDelay()
    {
        while (!endOfSong)
        {
            for (int i = 0; i < simpleMapArray.Count; i++)
            {
                Instantiate(noteTypes[(int)simpleMapArray[i].noteType], noteSpawnPoints[simpleMapArray[i].indexOfSpawn].position, noteTypes[(int)simpleMapArray[i].noteType].transform.rotation);             
                yield return new WaitForSeconds(simpleMapArray[i].timeDelay);
            }
            for (int i = 0; i < simpleMapArray.Count; i++)
            {
                Instantiate(noteTypes[(int)simpleMapArray[i].noteType], noteSpawnPoints[simpleMapArray[i].indexOfSpawn].position, noteTypes[(int)simpleMapArray[i].noteType].transform.rotation);
                yield return new WaitForSeconds(simpleMapArray[i].timeDelay);
            }
            for (int i = 0; i < simpleMapArray.Count; i++)
            {
                Instantiate(noteTypes[(int)simpleMapArray[i].noteType], noteSpawnPoints[simpleMapArray[i].indexOfSpawn].position, noteTypes[(int)simpleMapArray[i].noteType].transform.rotation);
                yield return new WaitForSeconds(simpleMapArray[i].timeDelay);
            }
            for (int i = 0; i < simpleMapArray.Count; i++)
            {
                Instantiate(noteTypes[(int)simpleMapArray[i].noteType], noteSpawnPoints[simpleMapArray[i].indexOfSpawn].position, noteTypes[(int)simpleMapArray[i].noteType].transform.rotation);
                yield return new WaitForSeconds(simpleMapArray[i].timeDelay);
            }
            endOfSong = true;
        }
    }

    public void SpawnNote()
    {
        endOfSong = false;
        StartCoroutine(waitForTimeDelay());
    }
}
