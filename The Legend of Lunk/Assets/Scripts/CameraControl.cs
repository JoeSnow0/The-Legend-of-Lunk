using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    Camera mCamera;
    [SerializeField] GameObject mTargetObject;
    [SerializeField] Bounds mTileSize;
    [SerializeField] float mOffsetDepth;
    Vector2 mCameraCenter;
    Vector2 mNextCameraCenter;

    // Start is called before the first frame update
    void Start()
    {
        mCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //CheckForTargetInBounds();

    }
   
    void MoveCamera()
    {
        LerpToNextLocation();
        Vector3 position = new Vector3(mCameraCenter.x, mCameraCenter.y, mOffsetDepth);
        mCamera.transform.Translate(position);
    }
    void LerpToNextLocation()
    {
        Mathf.Lerp(mCameraCenter.x, mNextCameraCenter.x, Time.deltaTime);
        Mathf.Lerp(mCameraCenter.y, mNextCameraCenter.y, Time.deltaTime);
    }
    void CheckForTargetInBounds()
    {
        if (!ContainsTarget(mTargetObject.transform.position,
            new Vector2(mCameraCenter.x - mTileSize.size.x, mCameraCenter.y - mTileSize.size.y),
            new Vector2(mCameraCenter.x + mTileSize.size.x, mCameraCenter.y + mTileSize.size.y)))
        {
            MoveCamera();
        }
    }
    bool ContainsTarget(Vector2 pointOnScreen, Vector2 screenMin, Vector2 screenMax)
    {
        if (pointOnScreen.x <= screenMax.x || pointOnScreen.y <= screenMax.y || pointOnScreen.x >= screenMin.x || pointOnScreen.y >= screenMin.y)
        {
            return true;
        }
        return false;
    }
}
