using System;
using System.Collections;
using UnityEngine;

public class GetMoney : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int _moneyAmount;
    
    private bool _first = true;
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
            _moneyAmount =  other.GetComponent<Money>().MoneyAmount;
            _gameManager.AddScore(_moneyAmount);
            Destroy(other.gameObject);
            StartCoroutine(SpawnFood());
            return;
        }
        else
        {
            if (!other.CompareTag("Food"))
            {
                if (_first)
                {
                    _first = false;
                    StartCoroutine(SpawnFood());

                }
            }
            
            
        }
    }

    private IEnumerator SpawnFood()
    {
        OnSpawnFood?.Invoke();
        yield return new WaitForSeconds(1f);
        OnComplete?.Invoke(180f, 0f);
        _first = true;
    }
}
