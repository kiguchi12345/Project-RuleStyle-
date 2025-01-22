using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// êŠO
/// </summary>
public class OutPosition : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
