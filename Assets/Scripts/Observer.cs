using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    private bool isPlayerInRange = false;

    public Transform player;

    public GameEnding gameEnding;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isPlayerInRange = false;
        }
    }

    private void Update()
    {
        if (isPlayerInRange == true)
        {
            Vector3 direction = player.position - this.transform.position;

            Ray ray = new Ray(this.transform.position, direction);
            RaycastHit raycastHit;

            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 2f);

            // Raycast(Ray ray, out RaycastHit hitInfo);
            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.tag == "Player")
                {
                    Debug.Log("Caught!!");
                    gameEnding.CaughtPlayer();
                }
            }
        }
    }
}
