using UnityEngine;

public class Money : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int _moneyAmount;

    public int MoneyAmount => _moneyAmount;

}
