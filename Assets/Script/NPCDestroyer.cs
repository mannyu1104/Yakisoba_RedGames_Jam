using UnityEngine;

public class NPCDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Entered: " + other.gameObject.name);
        if (other.CompareTag("NPC"))
        {
            Destroy(other.gameObject);
        }
    }
}
