using UnityEngine;

public class RandomLegOut : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Transform[] seats;
    [SerializeField] private float changeInterval = 3f;

    private float _timer;

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= changeInterval)
        {
            ChangeBiggiePosition();
            _timer = 0f; // Reset the timer after changing position
        }
    }

    private void ChangeBiggiePosition()
    {
        if (seats == null || seats.Length == 0) return;

        // Randomly select a seat
        int randomIndex = Random.Range(0, seats.Length);
        Transform selectedSeat = seats[randomIndex];
        // Set the position of the GameObject to the selected seat
        transform.position = selectedSeat.position;
        transform.rotation = selectedSeat.rotation;
        Debug.Log($"Selected seat: {selectedSeat.name} at position {selectedSeat.position}");
    }
}
