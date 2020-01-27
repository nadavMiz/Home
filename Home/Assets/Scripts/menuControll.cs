using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class menuControll : MonoBehaviour
{
    public EventSystem m_eventSystem;
    public GameObject m_firstSelected;

    private void OnEnable()
    {
        m_eventSystem.SetSelectedGameObject(m_firstSelected);
    }
}
