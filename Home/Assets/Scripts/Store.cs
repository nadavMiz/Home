using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    public inventory m_charectedInventory;
    public itemData m_item;

    private void Start()
    {
        Character charecter = Object.FindObjectOfType<Character>();
    }

    public void BuyItem()
    {


        if (m_charectedInventory.IsFull())
        {
            Debug.Log("inventory is full");
            return;
        }

        if (m_charectedInventory.GetMoney() == m_charectedInventory.RemoveMoney(m_item.m_value))
        {
            Debug.Log("not enough money");
            return;
        }

        m_charectedInventory.AddItem(m_item);

        return;
    }
}
