using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorAffordance : MonoBehaviour {

    CameraRaycaster cameraRaycaster;
    Layer hitLayer;

    [Tooltip ( "Unknown, Walk, Unwalk, Attack")]
    [SerializeField] Texture2D[] cursors;

    private void Start()
    {
        cameraRaycaster = GetComponentInChildren<CameraRaycaster>();
    }

    // Update is called once per frame
    void Update () {
        if(cameraRaycaster.layerHit != hitLayer)
        {

            hitLayer = cameraRaycaster.layerHit;


            Vector2 cursorHotspot = new Vector2(100, 100);

            int cursorIDX = 0;

            switch (cameraRaycaster.layerHit)
            {
                case Layer.Walkable:
                    cursorIDX = 1;
                    break;
                case Layer.Unwalkable:
                    cursorIDX = 2;
                    break;
                case Layer.Enemy:
                    cursorIDX = 3;
                    break;

                default:
                    break;
            }

            Cursor.SetCursor(cursors[cursorIDX], cursorHotspot, CursorMode.Auto);
        }

	}
}
