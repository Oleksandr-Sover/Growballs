using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "MyGame/ScriptableObject")]
public class Datas : ScriptableObject
{
    [SerializeField]
    public int data;

}
