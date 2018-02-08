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
    private Note[] simpleMapArray;

    [SerializeField]
    private GameObject singleNote;
    [SerializeField]
    private Transform[] noteSpawnPoints;

    private float currentTime;
    private int currentNoteIndex = 0;

	// Use this for initialization
	IEnumerator Start()
    {
        //Example note
        Note newNote = new Note();

        newNote.noteType = NoteType.Single;
        newNote.indexOfSpawn = 0;
        newNote.timeDelay = 0.0f;

        yield return StartCoroutine(waitForTimeDelay(2f));
	}
	
	// Update is called once per frame
	void Update()
    {
        currentTime = Time.time;
	}

    IEnumerator waitForTimeDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);


    }
}
