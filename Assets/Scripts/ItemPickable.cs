using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickable : MonoBehaviour, IPickable
{
    public ItemsScriptObj weaponScriprableObject;

    public void PickItem()
    {
        Destroy(gameObject);
    }
}
