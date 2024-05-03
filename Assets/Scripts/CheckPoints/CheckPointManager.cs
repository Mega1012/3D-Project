using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Plataformer.Core.Singleton;

public class CheckPointManager : Singleton<CheckPointManager>
{
    public int LastCheckPointKey = 0;

    public List<CheckPointBase> checkpoints;

    public bool HasCheckPoint()
    {
        return LastCheckPointKey > 0;
    }

    public void SaveCheckPoint(int i)
    {
        if( i > LastCheckPointKey)
        {
            LastCheckPointKey = i;
        }
    }

    public Vector3 GetPositionFromLastCheckPoint()
    {
        var checkpoint = checkpoints.Find(i => i.key == LastCheckPointKey);
        return checkpoint.transform.position;
    }
}
