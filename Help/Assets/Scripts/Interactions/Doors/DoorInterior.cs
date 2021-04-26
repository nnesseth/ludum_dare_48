using UnityEngine;

public class DoorInterior : MonoBehaviour
{
    private Animator doorSwing;
    private bool doorOpen = false;


    private void Start()
    {
        doorSwing = GetComponent<Animator>();
    }


    public void DoorAnimation()
    {
        if (!doorOpen)
        {
            doorSwing.Play("Door(Interior)Opening", 0, 0f);
            doorOpen = true;

        }
        else
        {
            doorSwing.Play("Door(Interior)Closing", 0, 0f);
            doorOpen = false;
        }
    }
}
