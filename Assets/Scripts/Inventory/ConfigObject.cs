
[System.Serializable]
public struct ConfigObject {

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
