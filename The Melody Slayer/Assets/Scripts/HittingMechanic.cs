using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittingMechanic : MonoBehaviour {

    [SerializeField]
    private BoxCollider[] hitColliders;
    private bool[] isColliderActive;
    private GameObject noteHit;


    
    void Start()
    {
        for (int i = 0; i < hitColliders.Length; i++)
        {
            hitColliders[i].enabled = false;
        }

        isColliderActive = new bool[hitColliders.Length];
    }
	
	void Update()
    {
		
	}

    public void HitActivation()
    {
        for (int i = 0; i < hitColliders.Length; i++)
        {
            hitColliders[i].enabled = true;

            if (isColliderActive[i])
            {
                Debug.Log("Hit =" + isColliderActive[i]);
                hitColliders[i].enabled = false;
                break;
            }

            hitColliders[i].enabled = false;
        }
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
