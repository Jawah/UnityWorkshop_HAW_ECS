// ----------------------------------------------------------------------------
// Unity Workshop - HAW Hamburg
// 
// Author: Nenad Slavujevic
// Date:   10/09/18
// ----------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

// See ECS_MoveSpeed.cs for more comments.
public struct ECS_RotationSpeed : IComponentData {

    public float RotationValue;
}
