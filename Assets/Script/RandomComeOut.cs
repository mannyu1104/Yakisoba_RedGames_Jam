using UnityEngine;

public class RandomComeOut : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Transform[] _seats;
    [SerializeField] private GameObject _npcPrefab;
    [SerializeField] private Transform _npcSpawnPoint;

    private Transform _selectedSeat;
    private Transform _spawnPoint;
    private float _timer;
    private float _npcCooldown = 4f;

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > _npcCooldown)
        {
            
            _timer = 0f;
            ComeOut();
        }
    }

    private void ComeOut()
    {
        if (_seats == null || _seats.Length == 0) return;

        // Randomly select a seat
        int randomIndex = Random.Range(0, _seats.Length);
        _selectedSeat = _seats[randomIndex];

        // Set the position of the GameObject to the selected seat
        _spawnPoint = _selectedSeat;

        if (_selectedSeat.CompareTag("LeftSeat"))
        {
            _npcSpawnPoint.position = new Vector3(_spawnPoint.position.x + 1.5f, _spawnPoint.position.y + 1f, _spawnPoint.position.z);
        }
        else if (_selectedSeat.CompareTag("RightSeat"))
        {
            _npcSpawnPoint.position = new Vector3(_spawnPoint.position.x - 1.5f, _spawnPoint.position.y + 1f, _spawnPoint.position.z);
        }


        Instantiate(_npcPrefab, _npcSpawnPoint.position, Quaternion.identity);
    }
}
