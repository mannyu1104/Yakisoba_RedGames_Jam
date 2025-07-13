using System;
using System.Collections;
using UnityEngine;

public class CollectMoney : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private GameObject[] _money;
    [SerializeField] private GameObject _tray;

    public static Action<float, float> OnGetReward;
    public static Action OnGetMoney;

    private GameObject _spawnedMoney;
    private int _moneyIndex;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            Debug.Log("food");
            StartCoroutine(FoodConvertion(other.gameObject));
        }
    }

    private IEnumerator FoodConvertion(GameObject food)
    {
        yield return new WaitForSeconds(1f);
        Destroy(food);

        float amount = food.GetComponent<Food>().MoneyAmount;

        switch (amount)
        {
            case 5:
                _moneyIndex = 0;
                break;
            case 10:
                _moneyIndex = 1;
                break;
            case 15:
                _moneyIndex = 2;
                break;
            case 20:
                _moneyIndex = 3;
                break;
            case 25:
                _moneyIndex = 4;
                break;
            default:
                _moneyIndex = 0;
                break;
        }

        _spawnedMoney = Instantiate(_money[_moneyIndex], _tray.transform.position, Quaternion.identity);
        _spawnedMoney.transform.SetParent(_tray.transform); 
        _spawnedMoney.SetActive(true);
        yield return new WaitForSeconds(1f);
        OnGetReward?.Invoke(0f, -180f);
        OnGetMoney?.Invoke();

    }
}
