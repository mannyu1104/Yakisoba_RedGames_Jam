using UnityEngine;

public class RandomSeatSelection : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Transform[] seats;

    private Transform selectedSeat;

    private void Start()
    {
       ///...
    }

    private void Update()
    {
        // Check for user input to change position
        if (Input.GetKeyDown(KeyCode.Space)) // Change KeyCode as needed
        {
            ChangeBamPosition();
        }
    }

    private void ChangeBamPosition()
    {
        if (seats == null || seats.Length == 0) return;

        // Randomly select a seat
        int randomIndex = Random.Range(0, seats.Length);
        selectedSeat = seats[randomIndex];

        // Set the position of the GameObject to the selected seat
        transform.position = new Vector3 (selectedSeat.position.x, selectedSeat.position.y + 0.5f, selectedSeat.position.z);    
    }
}

