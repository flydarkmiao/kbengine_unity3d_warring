using UnityEngine;
using KBEngine;
using System; 

public class UI_Keys : MonoBehaviour {
	void Awake ()     
	{
	}
	
	// Use this for initialization
	void Start () {
	}

	void Update()
	{
        if (Input.GetKeyUp(KeyCode.Alpha0))
        {
        	Common.DEBUG_MSG("UI_Keys::Update: Alpha0");
        }
        else if (Input.GetKeyUp(KeyCode.Alpha1))
        {
        	Common.DEBUG_MSG("UI_Keys::Update: Alpha1");
        	
        	KBEngine.Entity player = KBEngineApp.app.player();
        	if(player != null && TargetManger.target != null)
        		((KBEngine.Avatar)player).useTargetSkill(1000101, TargetManger.target.kbentity.id);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2))
        {
        	Common.DEBUG_MSG("UI_Keys::Update: Alpha2");
        	KBEngine.Entity player = KBEngineApp.app.player();
        	if(player != null && TargetManger.target != null)
        		((KBEngine.Avatar)player).useTargetSkill(2000101, TargetManger.target.kbentity.id);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha3))
        {
        	Common.DEBUG_MSG("UI_Keys::Update: Alpha3");
        	KBEngine.Entity player = KBEngineApp.app.player();
        	if(player != null && TargetManger.target != null)
        		((KBEngine.Avatar)player).useTargetSkill(3000101, TargetManger.target.kbentity.id);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha4))
        {
        	Common.DEBUG_MSG("UI_Keys::Update: Alpha4");
        	KBEngine.Entity player = KBEngineApp.app.player();
        	if(player != null && TargetManger.target != null)
        		((KBEngine.Avatar)player).useTargetSkill(4000101, TargetManger.target.kbentity.id);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha5))
        {
        	Common.DEBUG_MSG("UI_Keys::Update: Alpha5");
        	KBEngine.Entity player = KBEngineApp.app.player();
        	if(player != null && TargetManger.target != null)
        		((KBEngine.Avatar)player).useTargetSkill(5000101, TargetManger.target.kbentity.id);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha6))
        {
        	Common.DEBUG_MSG("UI_Keys::Update: Alpha6");
        	KBEngine.Entity player = KBEngineApp.app.player();
        	if(player != null && TargetManger.target != null)
        		((KBEngine.Avatar)player).useTargetSkill(6000101, TargetManger.target.kbentity.id);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha7))
        {
        	Common.DEBUG_MSG("UI_Keys::Update: Alpha7");
        }
        else if (Input.GetKeyUp(KeyCode.Alpha8))
        {
        	Common.DEBUG_MSG("UI_Keys::Update: Alpha8");
        }
        else if (Input.GetKeyUp(KeyCode.Alpha9))
        {
        	Common.DEBUG_MSG("UI_Keys::Update: Alpha9");
        }
        else if (Input.GetKeyUp(KeyCode.F1))
        {
        	Common.DEBUG_MSG("UI_Keys::Update: F1");
        }
        else if (Input.GetKeyUp(KeyCode.F2))
        {
        	Common.DEBUG_MSG("UI_Keys::Update: F2");
        }
        else if (Input.GetKeyUp(KeyCode.F3))
        {
        	Common.DEBUG_MSG("UI_Keys::Update: F3");
        }
        else if (Input.GetKeyUp(KeyCode.F4))
        {
        	Common.DEBUG_MSG("UI_Keys::Update: F4");
        }
        else if (Input.GetKeyUp(KeyCode.F5))
        {
        	Common.DEBUG_MSG("UI_Keys::Update: F5");
        }
        else if (Input.GetKeyUp(KeyCode.F6))
        {
        	Common.DEBUG_MSG("UI_Keys::Update: F6");
        }
        else if (Input.GetKeyUp(KeyCode.F7))
        {
        	Common.DEBUG_MSG("UI_Keys::Update: F7");
        }
        else if (Input.GetKeyUp(KeyCode.F8))
        {
        	Common.DEBUG_MSG("UI_Keys::Update: F8");
        }
        else if (Input.GetKeyUp(KeyCode.F9))
        {
        	Common.DEBUG_MSG("UI_Keys::Update: F9");
        }
        else if (Input.GetKeyUp(KeyCode.F10))
        {
        	Common.DEBUG_MSG("UI_Keys::Update: F10");
        }
        else if (Input.GetKeyUp(KeyCode.F11))
        {
        	Common.DEBUG_MSG("UI_Keys::Update: F11");
        }
        else if (Input.GetKeyUp(KeyCode.F12))
        {
        	Common.DEBUG_MSG("UI_Keys::Update: F12");
        }
	}
}
 