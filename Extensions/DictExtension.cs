using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class DictExtension {
	//如果没有得到直接返回空
	public static Tvalue TryGet<Tkey,Tvalue>(this Dictionary<Tkey,Tvalue> dict , Tkey key){
		Tvalue value;
		dict.TryGetValue (key, out value);
		return value;


	}

}
