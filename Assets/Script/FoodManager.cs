using UnityEngine;

public class FoodManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private GameObject[] _food;
    [SerializeField] private Transform _player;

    private GameObject _currentFood;
    private GameObject _spawnedFood;
    private Vector3 _foodSpawnPoint;
    private void Start()
    {
        
        SpawnFood();
    }

    private void Update()
    {
        transform.LookAt(_player);
    }

    private void SpawnFood()
    {
        _currentFood = _food[Random.Range(0, _food.Length)];
        _foodSpawnPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        _spawnedFood = Instantiate(_currentFood, _foodSpawnPoint, Quaternion.identity);
        _spawnedFood.transform.SetParent(transform);
    }
}
