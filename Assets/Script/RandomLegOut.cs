using UnityEngine;

public class RandomLegOut : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Transform[] _seats;
    [SerializeField] private float _changeInterval = 3f;

    private float _timer;
    private bool _isSeatSelected;
    private bool _isBamHere;
    private Transform _selectedSeat;

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _changeInterval)
        {
            if (!_isSeatSelected)
            {
                ChangeBiggiePosition();
            }
            else
            {
                MoveToTheSeat();
            }
                
            _timer = 0f; 
        }
    }

    private void ChangeBiggiePosition()
    {
        if (_seats == null || _seats.Length == 0) return;

        // Randomly select a seat
        int randomIndex = Random.Range(0, _seats.Length);
        _selectedSeat = _seats[randomIndex];

        _isBamHere = Physics.CheckBox(_selectedSeat.position, _selectedSeat.localScale / 2, Quaternion.identity, LayerMask.GetMask("Bam"));

        if (_isBamHere)
        {
            _isSeatSelected = false;
        }
        else if (!_isBamHere)
        {
            _isSeatSelected = true;

        }
    }
       

    private void MoveToTheSeat()
    {
        // Set the position of the GameObject to the selected seat
        transform.position = _selectedSeat.position;
        transform.rotation = _selectedSeat.rotation;
        _isSeatSelected = false;
        _changeInterval = Random.Range(1f, 4f); // Randomize the next change interval
    }
}
