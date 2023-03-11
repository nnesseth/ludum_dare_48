using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeButton : MonoBehaviour
{
    [SerializeField] private SettingsPopup popup;

    public void Resume()
    {
        popup.Close();    
    }
}
