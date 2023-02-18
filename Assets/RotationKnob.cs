using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationKnob : MonoBehaviour
{
    [SerializeField] private bool isHorizontal;
    [SerializeField] private Transform knobTransform;
    private Rigidbody KnobRigidbody;
    private Vector3 lastPosition;
    private Vector3 currentPosition;
    private float spinSpeed = 1000f;

    public bool IsRotating { get; private set; }
    public bool IsRotatingPositive { get; private set; }

    private void Start()
    {

    }

    private void Update()
    {
        handleSpin();

        if(InputController.Instance.PreciseMode())
        {
            spinSpeed = 200f;
        }
        else
        {
            spinSpeed = 1000f;
        }
    }

    private void handleSpin()
    {
        if (isHorizontal)
        {
            if (InputController.Instance.RotateRight())
            {
                IsRotating = true;
                gameObject.transform.Rotate(new Vector3(0, 1, 0) * spinSpeed * Time.deltaTime);
                IsRotatingPositive = true;
            }
            else if (InputController.Instance.RotateLeft())
            {
                IsRotating = true;
                gameObject.transform.Rotate(new Vector3(0, -1, 0) * spinSpeed * Time.deltaTime);
                IsRotatingPositive = false;
            }
            else
            {
                IsRotating = false;
            }
        }
        else
        {
            if (InputController.Instance.RotateTop())
            {
                IsRotating = true;
                gameObject.transform.Rotate(new Vector3(0, 1, 0) * spinSpeed * Time.deltaTime);
                IsRotatingPositive = true;
            }
            else if (InputController.Instance.RotateDown())
            {
                IsRotating = true;
                gameObject.transform.Rotate(new Vector3(0, -1, 0) * spinSpeed * Time.deltaTime);
                IsRotatingPositive = false;
            }
            else
            {
                IsRotating = false;
            }
        }
    }
}
