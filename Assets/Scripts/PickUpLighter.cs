using UnityEngine;

public class PickUpLighter : MonoBehaviour
{
    public GameObject PickUpText;
    public GameObject LighterOnPlayer;

    void Start()
    {
        // Deactivate objects at the start
        LighterOnPlayer.SetActive(false);
        PickUpText.SetActive(false);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Activate pickup text when player is in trigger area
            PickUpText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                // Deactivate pickup object and activate lighter on player
                this.gameObject.SetActive(false);
                LighterOnPlayer.SetActive(true);

                // Deactivate pickup text
                PickUpText.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Deactivate pickup text when player leaves trigger area
        PickUpText.SetActive(false);
    }
}