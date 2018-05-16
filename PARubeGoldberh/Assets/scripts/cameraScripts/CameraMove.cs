using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public List<CameraPositionTarget> cameraPlaces;
    public float transitionTime = 1.0f;

    public float _transitionTimer;
    private bool _isTransitioning = false;

    private int _currentIndex = 0;
    private int _previousIndex = 0;

    void Start()
    {
        Debug.Assert(cameraPlaces.Count > 0);

        transform.position = cameraPlaces[0].position.position;
        transform.LookAt(cameraPlaces[0].target.position);

        _transitionTimer = transitionTime;
    }
    void Update()
    {
        Debug.Assert(cameraPlaces.Count > 0);

        if (_isTransitioning)
        {
            _transitionTimer -= Time.deltaTime;

            var curr = getPrevTarget();
            var next = getCurrentTarget();

            float t = 1.0f - (_transitionTimer / transitionTime);

            transform.position = smoothstepVec3(curr.position.position, next.position.position, t);
            transform.rotation = Quaternion.LookRotation(smoothstepVec3(curr.dir(), next.dir(), t));


            if (_transitionTimer < 0.0f)
            {
                _isTransitioning = false;
                _transitionTimer = transitionTime;

            }
        }
        else
        {
            var target = getCurrentTarget();
            transform.position = target.position.position;
            transform.LookAt(target.target);
        }
    }
    CameraPositionTarget getCurrentTarget()
    {
        return cameraPlaces[_currentIndex];
    }
    CameraPositionTarget getPrevTarget()
    {
        return cameraPlaces[_previousIndex];
    }

    Vector3 smoothstepVec3(Vector3 a, Vector3 b, float t)
    {
        t = Mathf.Clamp01(t);
        return new Vector3(Mathf.SmoothStep(a.x, b.x, t), Mathf.SmoothStep(a.y, b.y, t), Mathf.SmoothStep(a.z, b.z, t));
    }
    public void goToNextTarget()
    {
        _previousIndex = _currentIndex;
        _currentIndex = (_currentIndex + 1) % cameraPlaces.Count;
        _isTransitioning = true;
        _transitionTimer = transitionTime;
    }
}
