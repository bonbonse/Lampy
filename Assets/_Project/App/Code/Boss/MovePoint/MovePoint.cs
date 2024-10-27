using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class MovePoint : MonoBehaviour
{
    public List<GameObject> pointsForward = new List<GameObject>(); // точки движения вперед
    public List<GameObject> pointsBack = new List<GameObject>(); // точки движения назад

    public GameObject GetRandomPointGameobject(bool isForwardDir = true)
    {
        if (isForwardDir)
        {
            if (this.pointsForward.Count > 0)
            {
                int indexPoint = Random.Range(0, this.pointsForward.Count - 1);
                return this.pointsForward[indexPoint];
            }
        }
        else
        {
            if (this.pointsBack.Count > 0)
            {
                int indexPoint = Random.Range(0, this.pointsBack.Count - 1);
                return pointsBack[indexPoint];
            }
        }
        return null;
    }
}
