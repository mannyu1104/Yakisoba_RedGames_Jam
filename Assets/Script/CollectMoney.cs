using System.Collections;
using UnityEngine;

public class CollectMoney : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private GameObject[] _money;
    [SerializeField] private GameObject _tray;


    private GameObject _spawnedMoney;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            StartCoroutine(FoodConvertion(other.gameObject));
        }
    }

    private IEnumerator FoodConvertion(GameObject food)
    {
        yield return new WaitForSeconds(1f);
        Destroy(food);
        _spawnedMoney = Instantiate(_money[0], _tray.transform.position, Quaternion.identity);
        _spawnedMoney.transform.SetParent(_tray.transform); _spawnedMoney.SetActive(true);
        
    }
}
