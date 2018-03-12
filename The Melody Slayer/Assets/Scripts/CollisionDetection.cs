using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour {

    private HittingMechanic parentScript;
    [SerializeField][Range(0,2)]
    private int typeOfCollision;

    private bool[] activeColliders;

    private void OnEnable()
    {
        parentScript = transform.parent.GetComponent<HittingMechanic>();
        activeColliders = new bool[3];
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);

        if (other.tag == "Note")
        {
            activeColliders[typeOfCollision] = true;
            parentScript.ActiveColliders = activeColliders;
            parentScript.NoteHit = other.gameObject;

            Debug.Log("Type activated =" + typeOfCollision);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Note")
        {
            activeColliders[typeOfCollision] = false;
            parentScript.ActiveColliders = activeColliders;
            parentScript.NoteHit = null;
            Debug.Log("Type deactivated =" + typeOfCollision);
        }
    }
}
