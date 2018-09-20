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

// This is our Component (data).
// It needs to derive from IComponentData to be recognized as one.
// In our case we just need a single value which is affects the cubes movement.
public struct ECS_MoveSpeed : IComponentData {

    public float MoveValue;
}
