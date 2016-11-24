using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIManager  {
	private Dictionary<UIPanelType,string> panelPathDict;
	private Dictionary<UIPanelType,BasePanel> panelDict;
	private Stack<BasePanel> panelStack;

	private static UIManager _instance;
	public static UIManager Instance{
		get{
			if (_instance == null) {
				_instance = new UIManager ();
			}
		
			return _instance;
		}

	}

	private Transform canvasTransform;
	private Transform CanvasTransform{

		get{ 
			if (canvasTransform == null) {
				canvasTransform = GameObject.Find ("Canvas").GetComponent<Transform> ();
				return canvasTransform;
			}
		
			return canvasTransform;
		}

	}
	public void PushPanel(UIPanelType panelType){
		if (panelStack == null) {
			panelStack = new Stack<BasePanel> ();
		}
		BasePanel BP = GetPanel (panelType);
		if(panelStack.Count>0)panelStack.Peek ().OnPause ();
		panelStack.Push (BP);
		BP.OnEnter ();



	}
	public void PopPanel(UIPanelType panelType){
		BasePanel BP = GetPanel (panelType);
		panelStack.Peek ().OnExit ();
		panelStack.Pop ();
		panelStack.Peek ().OnResume();


	}



	private UIManager(){

		ParseUIPanelTypeJson ();
	}

	private BasePanel GetPanel(UIPanelType panelType){
		if (panelDict == null) {
			panelDict = new Dictionary<UIPanelType, BasePanel> ();
		}
		//BasePanel panel;
		//panelDict.TryGetValue (panelType, out panel);
		BasePanel panel = panelDict.TryGet(panelType);
		if (panel == null) {
		
//			string path;
//			panelPathDict.TryGetValue (panelType, out path);

			string path = panelPathDict.TryGet (panelType);
			GameObject instPanel = GameObject.Instantiate (Resources.Load (path)) as GameObject;
			instPanel.transform.SetParent (CanvasTransform,false);//忽略世界坐标
			panelDict.Add (panelType, instPanel.GetComponent<BasePanel> ());

			return instPanel.GetComponent<BasePanel> ();
		} else {
			return panel;
		}
	}
	public class UIPanelJson
	{
		public List<UIPanelInfo> infoList;
	}

	private void ParseUIPanelTypeJson(){
		panelPathDict = new Dictionary<UIPanelType,string> ();

		TextAsset ta = Resources.Load<TextAsset>("UIPanelType");

		UIPanelJson panelInfoList = JsonUtility.FromJson<UIPanelJson> (ta.text);

		foreach (UIPanelInfo info in panelInfoList.infoList) {
            
			panelPathDict.Add(info.paneltype, info.Path);
		}
	}

//	public void test(){
//		string path;
//		panelPathDict.TryGetValue (UIPanelType.Knapsack, out path);
//
//		Debug.Log (path);
//	}

}
