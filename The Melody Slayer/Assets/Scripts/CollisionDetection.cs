﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour {

    [SerializeField]
    private HittingMechanic parentScript;
    [SerializeField][Range(0,2)]
    private int typeOfCollision;

    [SerializeField]
    private bool isMissBarrier;

    private bool[] activeColliders;
    MaterialPropertyBlock props;

    private void Awake()
    {
        props = new MaterialPropertyBlock();
        props.SetColor("Color", Color.red);
    }
    private void OnEnable()
    {
        activeColliders = new bool[3];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isMissBarrier)
        {
            if (!parentScript.noteQueue.Contains(other.gameObject))
            {
                parentScript.noteQueue.Enqueue(other.gameObject);
            }
            parentScript.MissBarrierActivation();
        }
        else
        {
            activeColliders[typeOfCollision] = true;
            parentScript.ActiveColliders = activeColliders;
            if (!parentScript.noteQueue.Contains(other.gameObject))
            {
                parentScript.noteQueue.Enqueue(other.gameObject);
                other.gameObject.GetComponent<Renderer>().SetPropertyBlock(props);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        activeColliders[typeOfCollision] = false;
        parentScript.ActiveColliders = activeColliders;
    }
}
