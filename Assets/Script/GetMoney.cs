using UnityEngine;

public class GetMoney : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int _moneyAmount;
    
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = FindAnyObjectByType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Money"))
        {
            _moneyAmount =  other.GetComponent<Money>().MoneyAmount;
            _gameManager.AddScore(_moneyAmount);
            Destroy(other.gameObject);
        }
    }
}
