using UnityEngine;
using UnityEngine.UI;
 
using UnityEditor;

#if UNITY_EDITOR


// ---------------
//  TypeThing => TransformDomain
// ---------------
[UnityEditor.CustomPropertyDrawer(typeof(TypeThingTransformDictionary))]
public class TypeThingTransformDictionaryDrawer : SerializableDictionaryDrawer<ConfigObject.Type, Transform> {
	protected override SerializableKeyValueTemplate<ConfigObject.Type, Transform> GetTemplate() {
		return GetGenericTemplate<TypeThingTransformDictionaryTemplate>();
	}
}
internal class TypeThingTransformDictionaryTemplate : SerializableKeyValueTemplate<ConfigObject.Type, Transform> { }



#endif
