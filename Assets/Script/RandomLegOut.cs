using System.Collections;
using UnityEngine;

public class RandomLegOut : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Transform[] _seats;
    [SerializeField] private float _changeInterval = 3f;
    [SerializeField] private LayerMask whatIsCharacter;

    private float _timer;
    private bool _isSeatSelected;
    private bool _isBamHere;
    private bool _isMove;
    private bool _spawn = true;
    private Transform _selectedSeat;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

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

        _isBamHere = Physics.CheckSphere(_selectedSeat.position, 2f, whatIsCharacter);

        if (_isBamHere)
        {
            _isSeatSelected = false;
        }
        else if (!_isBamHere)
        {
            if (!_isMove)
            {
                _animator.SetBool("LegOut", false);
            }
            else
            {
                _animator.SetBool("MoveOut", false);
            }
            if (_selectedSeat.CompareTag("LeftSeat"))
            {
                transform.parent.localScale = new Vector3(-1f, 1f, 1f);
            }
            else if (_selectedSeat.CompareTag("RightSeat"))
            {
                transform.parent.localScale = new Vector3(1f, 1f, 1f);
            }
            _isSeatSelected = true;

        }
    }
       

    private void MoveToTheSeat()
    {

        // Set the position of the GameObject to the selected seat
        transform.parent.position = new Vector3(_selectedSeat.position.x, _selectedSeat.position.y + 1.5f, _selectedSeat.position.z);
        _isSeatSelected = false;
        _changeInterval = Random.Range(1f, 4f); // Randomize the next change interval
        if (!_isMove)
        {
            _animator.SetBool("LegOut", true);
        }
        else
        {
            _animator.SetBool("LegOut", false);
            _animator.SetTrigger("ComeDown");
            StartCoroutine(Chill());
        }
        
    }

    private IEnumerator Chill()
    {
        yield return new WaitForSeconds(1f);
        _animator.SetBool("MoveOut", true);
    }

    private void StopNPC(float test, float test2)
    {
        _spawn = false;
    }

    private void StartNPC()
    {
        _spawn = true;
    }

    private void MoveBehaviour()
    {
        _spawn = true;
        _isMove = true;
    }

    private void OnEnable()
    {
        AppyGravity.OnFoodDestroy += StopNPC;
        GetMoney.OnSpawnFood += StartNPC;
        CollectMoney.OnGetMoney += MoveBehaviour;
    }

    private void OnDisable()
    {
        AppyGravity.OnFoodDestroy -= StopNPC;
        GetMoney.OnSpawnFood -= StartNPC;
        CollectMoney.OnGetMoney -= MoveBehaviour;
    }

    private void OnDrawGizmos()
    {
        if (_selectedSeat == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_selectedSeat.position, 2f);
    }
}
