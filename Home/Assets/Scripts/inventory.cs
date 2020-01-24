using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory : MonoBehaviour, IEnumerable
{
    private List<itemData> m_itemList;
    private uint m_capacity;

    public bool AddItem(itemData item)
    {
        if (m_itemList.Count == m_capacity)
        {
            // inventory is full
            return false;
        }
        m_itemList.Add(item);
        item.m_item.transform.parent = transform;
        return true;
    }

    public IEnumerator GetEnumerator()
    {
        foreach (itemData item in m_itemList)
        {
            yield return item;
        }
    }

    public itemData RemoveItem(int _index)
    {
        if (_index >= m_capacity)
        {
            return null;
        }
        itemData item = m_itemList[_index];
        m_itemList.RemoveAt(_index);
        item.m_item.transform.parent = null;
        return item;
    }

    public itemData RemoveItem(string _itemName)
    {
        foreach (itemData item in m_itemList)
        {
            if (item.m_itemName == _itemName)
            {
                m_itemList.Remove(item);
                item.m_item.transform.parent = null;
                return item;
            }
        }
        return null;
    }

    public itemData RemoveItem(itemData _item)
    {
        return RemoveItem(_item.m_itemName);
    }
}
