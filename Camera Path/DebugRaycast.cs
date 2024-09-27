using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Darkhitori.PlaymakerActions._CameraPath
{
    using HutongGames.PlayMaker;
    using CameraPath;

    [ActionCategory("Camera Path")]
    [Tooltip("A ray that indicates to where the camera is looking.")]
    public class DebugRaycast : FsmStateAction
    {
        [RequiredField]
        [CheckForComponent(typeof(CameraScript))]
        public FsmOwnerDefault gameObject;
        
        [ActionSection("Debug Raycast")]
        [Tooltip("")]
        public FsmBool drawRay;
        public FsmColor rayColor;
        public FsmFloat rayDistance;
        
        [Tooltip("Repeat every frame while the state is active.")]
        public bool everyFrame;

        CameraScript camComp;
        
        CameraScript.DebugRaycast dRaycast;
        
        public override void Reset()
        {
            gameObject = null;
            drawRay = true;
            rayColor = Color.blue;
            rayDistance = 10f;
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
            
            dRaycast.drawRay = drawRay.Value;
            dRaycast.rayColor = rayColor.Value;
            dRaycast.rayDistance = rayDistance.Value;
            
            var debugRaycast = dRaycast;
            
            camComp.debugRaycast = debugRaycast;
            
        }


    }

}
