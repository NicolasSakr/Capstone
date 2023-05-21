using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace enemy
{
    public class Cover : MonoBehaviour
    {
        public void OnDrawnGizmos()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawCube(transform.position, Vector3.one * 0.3f);
        }
    }

}
