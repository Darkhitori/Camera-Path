using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Darkhitori.PlaymakerActions._CameraPath
{
    using HutongGames.PlayMaker;
    using CameraPath;


    [ActionCategory("Camera Path")]
    [Tooltip("Should it be called at the OnTriggerEnter or OnTriggerExit?")]
    public class WhenCall : FsmStateAction
    {
        [RequiredField]
        [CheckForComponent(typeof(TriggerChangePath))]
        public FsmOwnerDefault gameObject;
        
        [Tooltip("")]
        [ObjectType(typeof(TriggerChangePath.WhenCall))]
        public FsmEnum whenCall;
        
        [Tooltip("Repeat every frame while the state is active.")]
        public bool everyFrame;

        TriggerChangePath triggComp;
        
        public override void Reset()
        {
            gameObject = null;
            whenCall = null;
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
            
            triggComp = go.GetComponent<TriggerChangePath>();
            
            triggComp.whenCall = (TriggerChangePath.WhenCall)whenCall.Value;
            
        }


    }

}
