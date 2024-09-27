using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Darkhitori.PlaymakerActions._CameraPath
{
    using HutongGames.PlayMaker;
    using CameraPath;

    [ActionCategory("Camera Path")]
    [Tooltip("If left as null it will use the object tagged as Player.")]
    public class Target : FsmStateAction
    {
        [RequiredField]
        [CheckForComponent(typeof(CameraScript))]
        public FsmOwnerDefault gameObject;
        
        [Tooltip("")]
        public FsmGameObject target;
        
        [Tooltip("Repeat every frame while the state is active.")]
        public bool everyFrame;

        CameraScript camComp;
        
        public override void Reset()
        {
            gameObject = null;
            target = null;
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
            
            camComp.target = target.Value.transform;
            
        }


    }

}
