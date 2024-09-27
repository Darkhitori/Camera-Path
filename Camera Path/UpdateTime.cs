using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Darkhitori.PlaymakerActions._CameraPath
{
    using HutongGames.PlayMaker;
    using CameraPath;


    [ActionCategory("Camera Path")]
    [Tooltip("When should the camera update it's position, remember it MUST be at the same time your target is moving.")]
    public class UpdateTime : FsmStateAction
    {
        [RequiredField]
        [CheckForComponent(typeof(CameraScript))]
        public FsmOwnerDefault gameObject;
        
        [Tooltip("")]
        [ObjectType(typeof(CameraScript.UpdateTime))]
        public FsmEnum updateTime;
        
        [Tooltip("Repeat every frame while the state is active.")]
        public bool everyFrame;

        CameraScript camComp;
        
        public override void Reset()
        {
            gameObject = null;
            updateTime = null;
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
            
            camComp.updateTime = (CameraScript.UpdateTime)updateTime.Value;
            
        }


    }

}
