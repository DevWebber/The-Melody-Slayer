using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittingMechanic : MonoBehaviour {

    public delegate void UpdateHits(int hitType);
    public static event UpdateHits OnUpdateHits;

    [SerializeField]
    private BoxCollider[] hitColliders;
    private bool[] isColliderActive;
    private GameObject noteHit;

    public Queue<GameObject> noteQueue;
    
    void Start()
    {
        for (int i = 0; i < hitColliders.Length; i++)
        {
            //hitColliders[i].enabled = false;
        }

        isColliderActive = new bool[hitColliders.Length];
        noteQueue = new Queue<GameObject>();
    }
	
	void Update()
    {
		
	}

    public void HitActivation()
    {
        for (int i = 0; i < hitColliders.Length; i++)
        {
            //hitColliders[i].enabled = true;

            if (isColliderActive[i])
            {
                noteHit = noteQueue.Dequeue();
                Destroy(noteHit);
                OnUpdateHits(i);
                //hitColliders[i].enabled = false;
                break;
            }

            //hitColliders[i].enabled = false;
        }
    }

    public void MissBarrierActivation()
    {
        //Simulate a miss
        noteHit = noteQueue.Dequeue();
        Destroy(noteHit);
        OnUpdateHits(2);
    }

    public bool[] ActiveColliders
    {
        set
        {
            isColliderActive = value;
        }
        get
        {
            return isColliderActive;
        }
    }

    public GameObject NoteHit
    {
        set
        {
            noteHit = value;
        }
    }
}
