using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory : MonoBehaviour, IEnumerable
{
    public List<itemData> m_startItems;
    public uint m_startMoney;
    private List<itemData> m_itemList = new List<itemData>();
    private uint m_capacity = 5;
    private uint m_money;

    private void Start()
    {
        m_itemList.AddRange(m_startItems);
        if (m_capacity < m_startItems.Count)
        {
            m_capacity = (uint)m_startItems.Count;
        }
        m_money = m_startMoney;
    }

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

    public bool SetCapicity(uint newCapicity)
    {
        if (m_itemList.Count < newCapicity)
        {
            Debug.Log("newCapicity is too small");
            return false;
        }

        return true;
    }

    public itemData RemoveItem(itemData _item)
    {
        return RemoveItem(_item.m_itemName);
    }

    public uint GetMoney() { return m_money; }

    public uint AddMoney(uint amount) { return m_money += amount; }

    public uint RemoveMoney(uint amount)
    {
        if (amount >= m_money)
        {
            Debug.Log("not enough money :-(");
            return m_money;
        }

        return m_money -= amount;
    }

    public bool IsFull()
    {
        return m_itemList.Capacity == m_capacity;
    }

    public bool HasGun()
    {
        foreach (itemData item in m_itemList)
        {
            if (item.m_itemName == "gun")
            {
                return true;
            }
        }
        return false;
    }
}
