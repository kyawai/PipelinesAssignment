using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
[Serializable]
public struct CameraPositionTarget
{
    public Transform position;
    public Transform target;

    public Vector3 dir()
    {
        return (target.position - position.position).normalized;
    }
}
