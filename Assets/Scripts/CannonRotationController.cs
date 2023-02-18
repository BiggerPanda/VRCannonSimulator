using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonRotationController : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 1f;
    [SerializeField] private float rotationAngle = 90f;
    [SerializeField] private CannonRotationKnob rotationKnobHortizontal;
    [SerializeField] private CannonRotationKnob rotationKnobVertical;
    [SerializeField] private GameObject verticalRotationObject;
    [SerializeField] private GameObject rotationObjectParent;

    private float currentRotationAngleHortizontal;
    private float currentRotationAngleVertical;

    private InputController inputController;

    private void Start()
    {
        inputController = new InputController();
    }

    private void Update()
    {
        handleRotation();

        if (inputController.PreciseMode())
        {
            rotationSpeed = 2f;
        }
        else
        {
            rotationSpeed = 10f;
        }
    }



    private void handleRotation()
    {
        if (rotationKnobHortizontal.IsRotating && rotationKnobHortizontal.IsRotatingPositive)
        {
            currentRotationAngleHortizontal += rotationSpeed * Time.deltaTime;

            rotationObjectParent.transform.localRotation = Quaternion.Euler(0, currentRotationAngleHortizontal, 0);
        }
        else if (rotationKnobHortizontal.IsRotating && !rotationKnobHortizontal.IsRotatingPositive)
        {
            currentRotationAngleHortizontal -= rotationSpeed * Time.deltaTime;

            rotationObjectParent.transform.localRotation = Quaternion.Euler(0, currentRotationAngleHortizontal, 0);
        }


        if (rotationKnobVertical.IsRotating && rotationKnobVertical.IsRotatingPositive)
        {
            currentRotationAngleVertical -= rotationSpeed * Time.deltaTime;
            if (currentRotationAngleVertical >= rotationAngle)
            {
                currentRotationAngleVertical = rotationAngle;
            }
            verticalRotationObject.transform.localRotation = Quaternion.Euler(currentRotationAngleVertical, 0, 0);
        }
        else if (rotationKnobVertical.IsRotating && !rotationKnobVertical.IsRotatingPositive)
        {
            currentRotationAngleVertical += rotationSpeed * Time.deltaTime;
            if (currentRotationAngleVertical <= -rotationAngle)
            {
                currentRotationAngleVertical = -rotationAngle;
            }
            verticalRotationObject.transform.localRotation = Quaternion.Euler(currentRotationAngleVertical, 0, 0);
        }
    }
}
