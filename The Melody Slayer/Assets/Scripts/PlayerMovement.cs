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
    [SerializeField]
    private float playerSpeed;

    private float xAxis;
    [SerializeField]
    private bool isKeyboardMovement;

    private Vector3 movementVector;
    private Vector2 mousePosition;

    private void Start()
    {
        movementVector = new Vector3(xAxis, 0, 0);
    }

    void Update()
    {
        if (isKeyboardMovement)
        {
            xAxis = Input.GetAxis("Horizontal") * Time.deltaTime * playerSpeed;
            movementVector.x = xAxis;
            transform.Translate(movementVector);
        }
        else
        {
            mousePosition = Input.mousePosition;
            movementVector = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 5.0f));
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftEndPoint.position.x, rightEndPoint.position.x), transform.position.y, transform.position.z);
    }
}
