using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Darkhitori.PlaymakerActions._CameraPath
{
    using HutongGames.PlayMaker;
    using CameraPath;

    [ActionCategory("Camera Path")]
    [Tooltip("Besides the followSpeed, everthing else will only work if you are moving the target using CharacterController or Rigidbody.")]
    public class MovementSetup : FsmStateAction
    {
        [RequiredField]
        [CheckForComponent(typeof(CameraScript))]
        public FsmOwnerDefault gameObject;
        
        [ActionSection("Movement Setup")]
        [Tooltip("How many meters multiplied by the player speed shoud the camera sets its desired position forward")]
        public FsmFloat xOffset;
        [Tooltip ("How fast should this offset Change?")]
        public FsmFloat xLerp;
        [Tooltip ("The maximum distance of this offset based on target position")]
        public FsmFloat maxOffsetDistance;
        [Tooltip ("How Fast will the camera move to the desired position?")]
        public FsmFloat followSpeed;
        [ObjectType(typeof(CameraScript.MovementSetup.FollowMode))]
        public  FsmEnum followMode;
        public FsmVector3 fixedOffset;
        
        [Tooltip("Repeat every frame while the state is active.")]
        public bool everyFrame;

        CameraScript camComp;
        
        CameraScript.MovementSetup mSetup;
        
        public override void Reset()
        {
            gameObject = null;
            xOffset = 2f;
            xLerp = 1f;
            maxOffsetDistance = 2.5f;
            followSpeed = 2.5f;
            followMode = CameraScript.MovementSetup.FollowMode.Path;
            fixedOffset = new Vector3 (0f, 0f, -10f);
            everyFrame = false;
        }

        // Code that runs on entering the state.
        public override void OnEnter()
        {
            DoMethod();
            if (!everyFrame)
            {
                Finish();
            }
        }
        
        public override void OnUpdate()
        {
            DoMethod();
        }

        void DoMethod()
        {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            if(go == null)
            {
                return;
            }
            
            camComp = go.GetComponent<CameraScript>();
            
            mSetup.xOffset = xOffset.Value;
            mSetup.xLerp = xLerp.Value;
            mSetup.maxOffsetDistance = maxOffsetDistance.Value;
            mSetup.followSpeed = followSpeed.Value;
            mSetup.followMode = (CameraScript.MovementSetup.FollowMode)followMode.Value;
            mSetup.fixedOffset = fixedOffset.Value;
            
            var movementSetup = mSetup;
            
            camComp.movementSetup = movementSetup;
            
        }


    }

}
