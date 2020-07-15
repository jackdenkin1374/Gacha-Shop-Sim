using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaPass
{
    public string name {get; set;}
    public List<Item> common = new List<Item>();
    public List<Item> uncommon = new List<Item>();
    public List<Item> rare = new List<Item>();
    public List<Item> legendary = new List<Item>();

    public GachaPass(string _name, List<Item> _common, List<Item> _uncommon, List<Item> _rare, List<Item> _legendary){
        this.name = _name;
        this.common = _common;
        this.uncommon = _uncommon;
        this.rare = _rare;
        this.legendary = _legendary;
    }

    public GachaPass(string _name){
        this.name = _name;
    }
}
