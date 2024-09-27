using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Darkhitori.PlaymakerActions._CameraPath
{
    using HutongGames.PlayMaker;
    using CameraPath;

    [ActionCategory("Camera Path")]
    [Tooltip("The tag of the object that will trigger this script.")]
    public class OtherTag : FsmStateAction
    {
        [RequiredField]
        [CheckForComponent(typeof(TriggerChangePath))]
        public FsmOwnerDefault gameObject;
        
        [Tooltip("")]
        public FsmString otherTag;
        
        [Tooltip("Repeat every frame while the state is active.")]
        public bool everyFrame;

        TriggerChangePath triggComp;
        
        public override void Reset()
        {
            gameObject = null;
            otherTag = "Player";
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
            
            triggComp.otherTag = otherTag.Value;
            
        }


    }

}
