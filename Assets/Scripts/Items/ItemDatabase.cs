using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Database", menuName = "Database")]
public class ItemDatabase : ScriptableObject
{
    public List<ItemProperty> items;
}