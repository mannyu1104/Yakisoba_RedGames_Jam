using UnityEngine;

public class RandomSeatSelection : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Transform[] seats;  

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
        if (seats == null || seats.Length == 0)
        {
            Debug.LogError("No seats assigned for random selection.");
            return;
        }
        // Randomly select a seat
        int randomIndex = Random.Range(0, seats.Length);
        Transform selectedSeat = seats[randomIndex];
        // Set the position of the GameObject to the selected seat
        transform.position = selectedSeat.position;
        transform.rotation = selectedSeat.rotation;
        Debug.Log($"Selected seat: {selectedSeat.name} at position {selectedSeat.position}");
    }
}

