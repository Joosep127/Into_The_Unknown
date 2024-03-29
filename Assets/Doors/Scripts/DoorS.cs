using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Animator doorAnimator;
    public KeyCode interactKey = KeyCode.E;

    private bool isPlayerNearby = false;
    private bool isOpen = false;

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(interactKey))
        {
            if (isOpen)
            {
                CloseDoor();
            }
            else
            {
                OpenDoor();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "FirstPersonController")
        {
            isPlayerNearby = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "FirstPersonController")
        {
            isPlayerNearby = false;
        }
    }

    void OpenDoor()
    {
        if (doorAnimator != null)
        {
            doorAnimator.SetTrigger("Open"); // Assuming the animation trigger is named "Open"
            isOpen = true;
        }
    }

    void CloseDoor()
    {
        if (doorAnimator != null)
        {
            doorAnimator.SetTrigger("Close"); // Assuming the animation trigger is named "Close"
            isOpen = false;
        }
    }
}
