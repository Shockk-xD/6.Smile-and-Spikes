using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BlockLineContainer
{
    public Difficult difficult;
    public List<GameObject> blocks;
    public int threshold;
}

public enum Difficult {
    Easy,
    Medium,
    Hard
}