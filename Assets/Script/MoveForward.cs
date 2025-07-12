using System.Collections;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * 2f);
    }
}
