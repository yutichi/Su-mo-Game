using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BallDataBase : ScriptableObject
{
    public List<BallData> _ballDataBase;
}

[Serializable]
public class BallData
{
    public string _name;
    public int _colorId;
    public int _score;
}
