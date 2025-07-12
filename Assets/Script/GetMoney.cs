using System;
using UnityEngine;
using System.Collections;

public class GetMoney : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int _moneyAmount;

    private GameManager _gameManager;

    public static Action OnSpawnFood;
    public static Action<float, float> OnComplete;

    private void Start()
    {
        _gameManager = FindAnyObjectByType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Money"))
        {
            _moneyAmount = other.GetComponent<Money>().MoneyAmount;
            _gameManager.AddScore(_moneyAmount);
            StartCoroutine(SpawnFood());
        }
    }

    private IEnumerator SpawnFood()
    {
        yield return new WaitForSeconds(1f);
        OnSpawnFood?.Invoke();
        yield return new WaitForSeconds(1f);
        OnComplete?.Invoke(0f, 180f);
    }
}
