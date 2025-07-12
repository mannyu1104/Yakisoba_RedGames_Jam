using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISlidingObjects
{
    void OnPlayerMove(Vector3 velocityApply);
    int GetCoinsNumber();
}