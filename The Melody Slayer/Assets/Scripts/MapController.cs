using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [SerializeField]
    private GameObject[] noteTypes;
    [SerializeField]
    private Transform[] noteSpawnPoints;

    [SerializeField]
    private NoteType typeExample;
    [SerializeField]
    private float delayExample;
    [SerializeField][Range(0, 7)]
    private int indexExample;

    private float currentTime;
    private int currentNoteIndex = 0;
    private bool endOfSong;

	// Use this for initialization
	void Start()
    {
        //Example note
        Note newNote = new Note();
        //Temporary
        simpleMapArray = new List<Note>();

        newNote.noteType = typeExample;
        newNote.indexOfSpawn = indexExample;
        newNote.timeDelay = delayExample;

        simpleMapArray.Add(newNote);

        endOfSong = false;
    }
	
	// Update is called once per frame
	void Update()
    {
        currentTime = Time.time;
	}

    IEnumerator waitForTimeDelay()
    {
        while (!endOfSong)
        {
            for (int i = 0; i < simpleMapArray.Count; i++)
            {
                Instantiate(noteTypes[i], noteSpawnPoints[Random.Range(0, 7)].position, noteTypes[i].transform.rotation);
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
