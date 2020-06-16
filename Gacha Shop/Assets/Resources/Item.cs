using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

public class Item
{
    [XmlAttribute("name")]
    public string name;

    [XmlAttribute("Description")]
    public string description;

    [XmlAttribute("Rarity")]
    public int rarity;
}


