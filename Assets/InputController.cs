using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController
{
    public static InputController Instance { get; private set; }
    private TestInput testInput;

    public InputController()
    {      
        Instance = this;
        testInput = new TestInput();
        testInput.Enable();
        testInput.rotateCannon.Left.performed += ctx => RotateLeft();
        testInput.rotateCannon.Right.performed += ctx => RotateRight();
        testInput.rotateCannon.Top.performed += ctx => RotateTop();
        testInput.rotateCannon.Down.performed += ctx => RotateDown();
        testInput.rotateCannon.PreciseMode.performed += ctx => PreciseMode();
    }

    public bool RotateLeft()
    {
        return testInput.rotateCannon.Left.inProgress;
    }

    public bool RotateRight()
    {
        return testInput.rotateCannon.Right.inProgress;
    }

    public bool RotateTop()
    {
        return testInput.rotateCannon.Top.inProgress;
    }

    public bool RotateDown()
    {
        return testInput.rotateCannon.Down.inProgress;
    }

    public bool PreciseMode()
    {
        return testInput.rotateCannon.PreciseMode.inProgress;
    }   

    public void OnDisable()
    {
        testInput.Disable();
    }
}
