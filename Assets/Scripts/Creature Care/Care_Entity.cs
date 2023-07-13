using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Care_Entity : MonoBehaviour
{
    [SerializeField]
    private float maxThrowForce = 20.0f;

    private Vector3 offset, currentPosition, currentVelocity;

    private enum eggState { DROPPED, HELD, THROWN };
    private eggState currState;
    

    private Vector3 thrownForce;
    
    
    private void Start()
    {
        currState = eggState.DROPPED;
        currentPosition = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if (currState == eggState.HELD)
        {
            transform.GetComponent<Rigidbody2D>().MovePosition(Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset);
        }
        else
        {
        }
    }

    private void FixedUpdate()
    {
        currentVelocity = (transform.position - currentPosition) / Time.deltaTime;
        currentPosition = transform.position;
    }

    private void OnMouseDown()
    {
        currState = eggState.HELD;
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    private void OnMouseUp()
    {
        currState = eggState.DROPPED;
        transform.GetComponent<Rigidbody2D>().velocity = Vector3.ClampMagnitude(currentVelocity, maxThrowForce);
    }
}