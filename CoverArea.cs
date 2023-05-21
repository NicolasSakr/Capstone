using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using enemy;

public class CoverArea : MonoBehaviour
{
    private Cover[] covers;

    void Awake()
    {
        covers = GetComponentsInChildren<Cover>();
    }

    public Cover GetRandomCover ( Vector3 agentLocation )
    {
        return covers [ Random.Range (0, covers.Length - 1) ] ;
    }
}
