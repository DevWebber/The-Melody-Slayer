using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    /// <summary>
    /// Allows the player to move along the horizontal axis
    /// </summary>
    /// 


    [SerializeField]
    private Transform leftEndPoint;
    [SerializeField]
    private Transform rightEndPoint;

    private float xAxis;
    [SerializeField]
    private float playerSpeed;

    private Vector3 movementVector;

    private void Start()
    {
        movementVector = new Vector3(xAxis, 0, 0);
    }

    void Update()
    {
        xAxis = Input.GetAxis("Horizontal") * Time.deltaTime * playerSpeed;
        movementVector.x = xAxis;
        transform.Translate(movementVector);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftEndPoint.position.x, rightEndPoint.position.x), transform.position.y, transform.position.z);
    }
}
