using UnityEngine;
using System.Collections;

public class BasePanel : MonoBehaviour {
	public virtual void OnEnter(){
		
	}
	public virtual void OnPause(){

	}
	public virtual void OnResume(){

	}
	public virtual void OnExit(){

	}
	public void OnExitPanel(string st){
		UIPanelType type = (UIPanelType)System.Enum.Parse (typeof(UIPanelType), st);
		UIManager.Instance.PopPanel (type);

	}
}
