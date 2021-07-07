using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void ModifiedEvent();
[System.Serializable]
public class ModifiableInt
{
    private int itemAmount = 0;

    [SerializeField]
    private int baseValue;
    public int BaseValue { get { return baseValue; } set { baseValue = value; UpdateModifiedValue(itemAmount); } }

    [SerializeField]
    private int modifiedValue;
    public int ModifiedValue { get { return modifiedValue; } private set { modifiedValue = value; } }

    public List<IModifier> modifiers = new List<IModifier>();

    public event ModifiedEvent ValueModified;
    public ModifiableInt(ModifiedEvent method = null)
    {
        modifiedValue = BaseValue;
        if (method != null)
            ValueModified += method;
    }

    public void RegisterModEvent(ModifiedEvent method)
    {
        ValueModified += method;
    }
    public void UnregisterModEvent(ModifiedEvent method)
    {
        ValueModified -= method;
    }

    public void UpdateModifiedValue(int _amount)
    {
        var valueToAdd = 0;
        for (int j = 0; j < modifiers.Count; j++)
        {
            modifiers[j].AddValue(ref valueToAdd);

            ModifiedValue = baseValue + (valueToAdd * _amount);
        }
        
        
        if (ValueModified != null)
            ValueModified.Invoke();
        
    }
    public void AddModifier(IModifier _modifier, int _amount)
    {
        modifiers.Add(_modifier);
        UpdateModifiedValue(_amount);
    }
    public void RemoveModifier(IModifier _modifier, int _amount)
    {
        modifiers.Remove(_modifier);
        UpdateModifiedValue(_amount);
    }
}
