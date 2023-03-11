using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitButtonBehavior : MonoBehaviour
{
    public void OnMouseUp()
    {
        Application.Quit();
    }
}
