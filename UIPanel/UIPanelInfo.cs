using UnityEngine;
using System.Collections;
using System;
[Serializable]
public class UIPanelInfo : ISerializationCallbackReceiver {
	[NonSerialized]
	public UIPanelType paneltype;	
	public string panelTypesString;
//	{
//		get{ 
//			return paneltype.ToString ();
//		}
//		set{ 
//			UIPanelType type = (UIPanelType)System.Enum.Parse (typeof(UIPanelType), value);
//			paneltype = type;
//		}
//	}
	public string Path;
	public void OnAfterDeserialize(){

		UIPanelType type = (UIPanelType)System.Enum.Parse (typeof(UIPanelType), panelTypesString);
		paneltype = type;

	}
	public void OnBeforeSerialize(){


	}
}
