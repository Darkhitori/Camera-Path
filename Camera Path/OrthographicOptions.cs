using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Darkhitori.PlaymakerActions._CameraPath
{
    using HutongGames.PlayMaker;
    using CameraPath;

    [ActionCategory("Camera Path")]
    [Tooltip("Configuration used when the camera is on the Orthographic projecion mode.")]
    public class OrthographicOptions : FsmStateAction
    {
        [RequiredField]
        [CheckForComponent(typeof(CameraScript))]
        public FsmOwnerDefault gameObject;
        
        [ActionSection("Orthographic Options")]
        [Tooltip ("The size of the camera will be: position.z + offset")]
        public FsmFloat sizeOffset;
        [Tooltip ("Should the result be inverted between positive and negative?")]
        public FsmBool invertValues;
        
        [Tooltip("Repeat every frame while the state is active.")]
        public bool everyFrame;

        CameraScript camComp;
        
        CameraScript.OrthographicOptions oOptions;
        
        public override void Reset()
        {
            gameObject = null;
            sizeOffset = 0f;
            invertValues = true;
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
            
            oOptions.sizeOffset = sizeOffset.Value;
            oOptions.invertValues = invertValues.Value;
            
            var orthographicOptions = oOptions;
            
            camComp.orthographicOptions = orthographicOptions;
            
        }


    }

}
