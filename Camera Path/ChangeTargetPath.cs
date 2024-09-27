using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Darkhitori.PlaymakerActions._CameraPath
{
    using HutongGames.PlayMaker;
    using CameraPath;

    [ActionCategory("Camera Path")]
    [Tooltip("Here it just change the index from the data array to get values from the next path.")]
    public class ChangeTargetPath : FsmStateAction
    {
        [RequiredField]
        [CheckForComponent(typeof(CameraScript))]
        public FsmOwnerDefault gameObject;
        
        public FsmString newPathName;
        
        [Tooltip("Repeat every frame while the state is active.")]
        public bool everyFrame;

        CameraScript camComp;
        
        public override void Reset()
        {
            gameObject = null;
            newPathName = null;
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
            
            camComp.ChangeTargetPath(newPathName.Value);
            
        }


    }

}
