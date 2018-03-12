using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour {

    [SerializeField]
    private HittingMechanic parentScript;
    [SerializeField][Range(0,2)]
    private int typeOfCollision;

    private bool[] activeColliders;

    private void OnEnable()
    {
        activeColliders = new bool[3];
    }

    private void OnTriggerEnter(Collider other)
    {
        activeColliders[typeOfCollision] = true;
        parentScript.ActiveColliders = activeColliders;
        parentScript.NoteHit = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        activeColliders[typeOfCollision] = false;
        parentScript.ActiveColliders = activeColliders;
        parentScript.NoteHit = null;
    }
}
