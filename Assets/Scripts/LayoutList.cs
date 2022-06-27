using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayoutList : MonoBehaviour
{
    List<GameObject> layoutList = new List<GameObject>();

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
            layoutList.Add(obj.gameObject);
        }
        SortLayout();
    }
}
