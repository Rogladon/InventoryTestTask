using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ConfigObject {

	public ConfigObject(ConfigObject c) {
		type = c.type;
		weight = c.weight;
		name = c.name;
		id = c.id;
	}

	public enum Type {
		sword,
		mat,
		axe
	}
	public Type type;
	public string name;
	public int id { get; set; }
	public int weight;
	public Container container { get; set; }
	public InteractiveObject obj { get; set; }

	
}
