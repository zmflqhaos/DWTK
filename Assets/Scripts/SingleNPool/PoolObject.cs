using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    public virtual void Instaniate()
    {
    }

    public virtual void Pooling()
    {
        PoolManager.Instance.Push(gameObject);
    }
}
