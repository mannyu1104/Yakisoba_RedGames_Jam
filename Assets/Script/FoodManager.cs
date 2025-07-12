using UnityEngine;

public class FoodManager : MonoBehaviour
{
    private PlayerMovement _playerMovement;

    [Header("Settings")]
    [SerializeField] private GameObject[] _food;
    [SerializeField] private Transform _player;

    private GameObject _currentFood;
    private GameObject _spawnedFood;
    private Vector3 _foodSpawnPoint;
    private void Start()
    {
        _playerMovement = GetComponentInParent<PlayerMovement>();

        SpawnFood();
    }

    private void SpawnFood()
    {
        _currentFood = _food[Random.Range(0, _food.Length)];
        _foodSpawnPoint = new Vector3(transform.position.x, transform.position.y + 0.25f, transform.position.z);

        _spawnedFood = Instantiate(_currentFood, _foodSpawnPoint, Quaternion.identity);
        _spawnedFood.transform.SetParent(transform);
    }

    private void OnEnable()
    {
        GetMoney.OnSpawnFood += SpawnFood;
    }

    private void OnDisable()
    {
        GetMoney.OnSpawnFood -= SpawnFood;
    }
}
