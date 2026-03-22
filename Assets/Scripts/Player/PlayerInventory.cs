using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
   public bool HasKey {get; private set;} = false;
   public bool HasMoney {get; private set;} = false;

   public void AddKey()
    {
        HasKey = true;
        HUDManager.Instance.UpdateKeyStatus(true);
        Debug.Log("Key added to inventory!");
    }

    public bool UseKey()
    {
        if (!HasKey) return false;
        HasKey = false;
        HUDManager.Instance.UpdateKeyStatus(false);
        return true;
    }

    public void AddMoney()
    {
        HasMoney = true;
        HUDManager.Instance.UpdateMoneyStatus(true);
        Debug.Log("Money added to inventory!");
    }
}
