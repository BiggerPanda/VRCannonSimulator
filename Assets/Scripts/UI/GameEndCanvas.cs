using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameEndCanvas : MonoBehaviour
{
    [SerializeField] private TMP_Text textField = null;
    [SerializeField] private Canvas canvas = null;
    [SerializeField] private Button returnButton = null;

    private void Start()

    {
        returnButton.onClick.AddListener(ReturnToMenu);


    }

    private void DisplayWindow()
    {

    }

    private void DisplayWin()
    {

    }

    private void DisplayLose()
    {

    }

    private void DisplayDraw()
    {

    }

    private void ReturnToMenu()
    {
        SceneLoader.instance.LoadScene(0);
    }
}
