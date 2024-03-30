using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAimAndShoot : MonoBehaviour
{
    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletSpawnPoint;

    private GameObject bulletInst;

    private Vector2 worldPosition;
    private Vector2 direction;

    private float angle;
    // Update is called once per frame
    void Update()
    {
        HandleGunRotation();
        HandleGunShooting();
    }

    private void HandleGunRotation()
    {
        worldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        direction = (worldPosition - (Vector2)gun.transform.position).normalized;
        Debug.DrawRay(gun.transform.position, direction);

        gun.transform.right = direction;

        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Vector3 localScale = new Vector3(1f, 1f, 1f);
        if (angle > 90 || angle < -90)
        {
            localScale.y = -1f;
        }
        else
        {
            localScale.y = 1f;
        }
        gun.transform.localScale = localScale;
    }
    private void HandleGunShooting ()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            bulletInst = Instantiate(bullet, bulletSpawnPoint.position, gun.transform.rotation);
        }
    }
}
