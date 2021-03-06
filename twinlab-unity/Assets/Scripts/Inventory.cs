﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Header("Potions")]

    static Inventory instance;
    void Start()
    {
        instance = this;
    }

    public static GameObject GetPotionPrefab(Potion.Type t)
    {
        return PotionSelector.GetPotionElementOfType(t).prefab;
    }

    public static Sprite GetPotionSprite(Potion.Type t)
    {
        return PotionSelector.GetPotionElementOfType(t).sprite;
    }

    public static int GetPotionAmount(Potion.Type t)
    {
        PotionSelector.PotionElement pe = PotionSelector.GetPotionElementOfType(t);
        return pe.GetCount();
    }

    public static void SetCountOfPotion(Potion.Type t, int i)
    {
        PotionSelector.GetPotionElementOfType(t).SetCount(i);
    }

    public static void AddToCountOfPotion(Potion.Type t, int i)
    {
        PotionSelector.PotionElement pe = PotionSelector.GetPotionElementOfType(t);
        pe.SetCount(pe.GetCount() + i);
    }

    public static void SubtractFromCountOfPotion(Potion.Type t, int i)
    {
        PotionSelector.PotionElement pe = PotionSelector.GetPotionElementOfType(t);
        pe.SetCount(pe.GetCount() - i);
    }
}
