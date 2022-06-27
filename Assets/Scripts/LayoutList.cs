using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayoutList : MonoBehaviour
{
    List<GameObject> layoutList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnValidate()
    {
        
    }

    public void SortLayout()
    {
        if (layoutList == null) return;
        for (int i = 0; i < layoutList.Count; i++)
        {
            layoutList[i].transform.position = this.transform.position + new Vector3(0, 0, -i);
        }
    }

    public void AddLayoutList(GameObject mapPile)
    {
        var obj = mapPile.GetComponent<MapPile>();
        if (obj.TileMode == TileMode.Map)
        {
            Debug.Log("AddList");
            layoutList.Add(obj.gameObject);
        }
        SortLayout();
    }
}
