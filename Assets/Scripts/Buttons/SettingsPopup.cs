using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPopup : MonoBehaviour
{
    public void Close()
    {
        gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Open()
    {
        gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }
}
