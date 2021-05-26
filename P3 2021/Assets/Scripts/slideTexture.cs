using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slideTexture : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private RectTransform _parentRectTransform;
    [SerializeField] private RawImage _image;
    [Header("Settings")]
    [SerializeField] private Vector2 repeatCount;
    [SerializeField] private Vector2 scroll;
    [SerializeField] private Vector2 offset;

    private void Awake()
    {
        if (!_image) _image = GetComponent<RawImage>();

        _image.uvRect = new Rect(offset, repeatCount);
    }

    // Start is called before the first frame update
    private void Start()
    {
        if (!_rectTransform) _rectTransform = GetComponent<RectTransform>();
        if (!_parentRectTransform) _parentRectTransform = GetComponentInParent<RectTransform>();


    }

    // Update is called once per frame
    private void Update()
    {
#if UNITY_EDITOR
        // Only done in the Unity editor since later it is unlikely that your screensize changes

#endif
        offset += scroll * Time.deltaTime;
        _image.uvRect = new Rect(offset, repeatCount);
    }


}
