using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Counter : MonoBehaviour
{
    protected float maxValue = 100;
    [SerializeField]
    protected float curValue = 0;

    virtual public void AddProgress(float value)
    {
        curValue += value;
    }

}
