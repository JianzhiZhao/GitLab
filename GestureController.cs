using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Jianzhi.Controller
{
    public class GestureController : MonoBehaviour
    {
        public Image controllableImg;

        private Vector3? lastTouchPosition = null;

        

        private void Update() 
        {
            if(Input.touchCount == 1)
            {
                Touch current_Touch = Input.GetTouch(0);
                controllableImg.transform.Translate(current_Touch.deltaPosition);
                
                float x = controllableImg.rectTransform.position.x;
                float width = controllableImg.rectTransform.sizeDelta.x;
                x = Mathf.Max(x, - width / 2f);
                x = Mathf.Min(x, Screen.width + controllableImg.preferredWidth / 2f);

                float y = controllableImg.rectTransform.position.y;
                y = Mathf.Max(y, - controllableImg.preferredHeight / 2f);
                y = Mathf.Min(y, Screen.height + controllableImg.preferredHeight / 2f);

                controllableImg.rectTransform.position = new Vector2(x,y);
            }
        }

        public void Test()
        {
            Debug.Log("Image:"+controllableImg.rectTransform.position+" ("+controllableImg.preferredWidth+","+controllableImg.preferredHeight+")");
            Debug.Log("Screen:("+Screen.width+","+Screen.height+")");
        }
    }
}

