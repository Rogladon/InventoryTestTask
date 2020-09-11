using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ConfigObject
{
    public enum Type {
		type1,
		type2,
		type3
	}
	public Type type;
	public string name;
	public int id { get; set; }
	public int weight;
	public Container container { get; set; }
	public InteractiveObject obj { get; set; }
}
