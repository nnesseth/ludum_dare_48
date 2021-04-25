using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class QuitToMainMenu : MonoBehaviour
{
    [SerializeField] SettingsPopup popup;
    private void Start()
    {
        popup.Close();
    }
    public void OnMouseUp()
    {
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            popup.Open();
        }
    }
}
