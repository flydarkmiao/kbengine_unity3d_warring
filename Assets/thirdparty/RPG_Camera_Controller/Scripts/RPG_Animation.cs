using UnityEngine;
using KBEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class RPG_Animation : MonoBehaviour {

    public static RPG_Animation instance = null;
	SceneEntityObject seo = null;
	
    public enum CharacterMoveDirection {
        None, Forward, Backward, StrafeLeft, StrafeRight, StrafeForwardLeft, StrafeForwardRight, StrafeBackLeft, StrafeBackRight
    }
    
    public enum CharacterState {
        Idle, Walk, WalkBack, StrafeLeft, StrafeRight, Jump
    }

    public CharacterMoveDirection currentMoveDir; // this is the current move direction of "PlayerChar"
    public CharacterState currentState; // this is its current (animation) state


	void Awake() 
	{
	}
	
	void Start() 
	{
		seo = (SceneEntityObject)KBEngineApp.app.player().renderObj;

		if(seo != null)
		{
			if(seo.gameObject != null && seo.gameObject != transform.gameObject)
			{
				Transform parent = transform.parent;
				seo.gameObject.transform.rotation = transform.rotation;
				UnityEngine.GameObject.Destroy(transform.gameObject);
				seo.gameObject.transform.parent = parent;
				seo.gameObject.name = "entity";
				seo.gameObject.layer = LayerMask.NameToLayer("kbentity");
				this.transform.gameObject.layer = LayerMask.NameToLayer("kbentity");
				seo.gameObject.tag = "Player";
			}
			
			if(seo.gameObject != null && seo.gameObject == transform.gameObject)
				instance = this;
		}
	}
	
	void Update() 
	{
		if(RPG_Controller.instance == null)
			return;
		
        SetCurrentState();
        StartAnimation();
	}


    public void SetCurrentMoveDir(Vector3 playerDir) { // this method is called in "RPG_Controller" in line 60 when it is checking for movement inputs and sets the variable currentMoveDir 
        bool forward = false;
        bool backward = false;
        bool left = false;
        bool right = false;

        if (playerDir.z > 0)
            forward = true;
        if (playerDir.z < 0)
            backward = true;
        if (playerDir.x < 0)
            left = true;
        if (playerDir.x > 0)
            right = true;

        if (forward) { 
            if (left)
                currentMoveDir = CharacterMoveDirection.StrafeForwardLeft;
            else if (right)
                currentMoveDir = CharacterMoveDirection.StrafeForwardRight;
            else
                currentMoveDir = CharacterMoveDirection.Forward;
        } else if (backward) {
            if (left)
                currentMoveDir = CharacterMoveDirection.StrafeBackLeft;
            else if (right)
                currentMoveDir = CharacterMoveDirection.StrafeBackRight;
            else
                currentMoveDir = CharacterMoveDirection.Backward;
        } else if (left)
            currentMoveDir = CharacterMoveDirection.StrafeLeft;
        else if (right)
            currentMoveDir = CharacterMoveDirection.StrafeRight;
        else
            currentMoveDir = CharacterMoveDirection.None;
    }


    public void SetCurrentState() { // sets the variable currentState with help of currentMoveDir
        if (RPG_Controller.instance.characterController.isGrounded) {
            switch (currentMoveDir) {
                case CharacterMoveDirection.None: currentState = CharacterState.Idle;
                    break;
                case CharacterMoveDirection.Forward: currentState = CharacterState.Walk;
                    break;
                case CharacterMoveDirection.StrafeForwardLeft: currentState = CharacterState.Walk;
                    break;
                case CharacterMoveDirection.StrafeForwardRight: currentState = CharacterState.Walk;
                    break;
                case CharacterMoveDirection.Backward: currentState = CharacterState.WalkBack;
                    break;
                case CharacterMoveDirection.StrafeBackLeft: currentState = CharacterState.WalkBack;
                    break;
                case CharacterMoveDirection.StrafeBackRight: currentState = CharacterState.WalkBack;
                    break;
                case CharacterMoveDirection.StrafeLeft: currentState = CharacterState.StrafeLeft;
                    break;
                case CharacterMoveDirection.StrafeRight: currentState = CharacterState.StrafeRight;
                    break;
            }
        }
    }


    public void StartAnimation() { // reads the variable currentState and calls the corresponding animation method
        switch (currentState) {
            case CharacterState.Idle: Idle();
                break;
            case CharacterState.Walk:
                if (currentMoveDir == CharacterMoveDirection.StrafeForwardLeft)
                    StrafeForwardLeft();
                else if (currentMoveDir == CharacterMoveDirection.StrafeForwardRight)
                    StrafeForwardRight();
                else
                    Walk();
                break;
            case CharacterState.WalkBack:
                if (currentMoveDir == CharacterMoveDirection.StrafeBackLeft)
                    StrafeBackLeft();
                else if (currentMoveDir == CharacterMoveDirection.StrafeBackRight)
                    StrafeBackRight();
                else
                    WalkBack();
                break;
            case CharacterState.StrafeLeft: StrafeLeft();
                break;
            case CharacterState.StrafeRight: StrafeRight();
                break;
        }
    }

    // every animation clip has its own method
    #region Animation Methods 
    
    void Idle() {
    	if(seo != null)
			seo.playIdleAnimation();
    }

    void Walk() {
    	if(seo != null)
    	{
    		seo.stopPlayAnimation("");
    	    seo.playRunAnimation();
    	}
    }

    void StrafeForwardLeft() {
    	if(seo != null)
    		seo.playWalkAnimation();
        //animation.CrossFade("strafeforwardleft");
    }

    void StrafeForwardRight() {
    	if(seo != null)
    		seo.playWalkAnimation();
        //animation.CrossFade("strafeforwardright");
    }

    void WalkBack() {
    	if(seo != null)
    	{
    		seo.stopPlayAnimation("");
    		seo.playWalkAnimation();
    	}
        //animation.CrossFade("walkback");
    }

    void StrafeBackLeft() {
    	if(seo != null)
    		seo.playWalkAnimation();
        //animation.CrossFade("strafebackleft");
    }

    void StrafeBackRight() {
    	if(seo != null)
    		seo.playWalkAnimation();
        //animation.CrossFade("strafebackright");
    }
        
    void StrafeLeft() {
    	if(seo != null)
    		seo.playWalkAnimation();
        //animation.CrossFade("strafeleft");
    }

    void StrafeRight() {
    	if(seo != null)
    		seo.playWalkAnimation();
       // animation.CrossFade("straferight");
    }

    public void Jump() { // this method is an exception because it is called by "RPG_Controller" (line 73) if the jump button was hit. Therefore it has the access level "public".
        currentState = CharacterState.Jump;
        if(seo != null)
        {
	        seo.stopPlayAnimation("jump");
	        seo.playJumpAnimation();
	        if(seo.kbentity != null)
	        	((KBEngine.Avatar)seo.kbentity).jump();
	    }
    }
    #endregion
}
