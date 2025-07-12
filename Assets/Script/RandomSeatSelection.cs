using UnityEngine;

public class RandomSeatSelection : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Transform[] _seats;

    private Transform _selectedSeat;

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
        if (_seats == null || _seats.Length == 0) return;

        // Randomly select a seat
        int randomIndex = Random.Range(0, _seats.Length);
        _selectedSeat = _seats[randomIndex];

        // Set the position of the GameObject to the selected seat
        transform.position = new Vector3 (_selectedSeat.position.x, _selectedSeat.position.y + 0.5f, _selectedSeat.position.z);    
    }
}

