using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FealdLayout : MonoBehaviour
{
    [SerializeField] int _column;
    [SerializeField] LayoutList _layoutList;
    LayoutList[] _feald;
    
    void Start()
    {
        _feald = new LayoutList[_column];
        for(int i = 0; i < _column; i++)
        {
            _feald[i] = Instantiate(_layoutList,transform);
            _feald[i].transform.position = new Vector3(-_column / 2 + i + 0.5f, 0, 0);
        }
    }
}
