using UnityEngine;

public class RandomLegOut : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Transform[] _seats;
    [SerializeField] private float _changeInterval = 3f;

    private float _timer;
    private bool _isSeatSelected;
    private bool _isBamHere;
    private bool _spawn = true;
    private Transform _selectedSeat;

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _changeInterval)
        {
            if (!_spawn) return;
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
        transform.position = new Vector3(_selectedSeat.position.x, _selectedSeat.position.y + 0.8f, _selectedSeat.position.z);
        _isSeatSelected = false;
        _changeInterval = Random.Range(1f, 4f); // Randomize the next change interval
    }

    private void StopNPC(float test, float test2)
    {
        _spawn = false;
    }

    private void OnEnable()
    {
        AppyGravity.OnFoodDestroy += StopNPC;
    }

    private void OnDisable()
    {
        AppyGravity.OnFoodDestroy -= StopNPC;
    }
}
