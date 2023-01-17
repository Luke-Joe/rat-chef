using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpen = false;

    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private float rotationAmount = 90f;

    private Vector3 startRotation;

    private Coroutine animationCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        startRotation = transform.rotation.eulerAngles;
    }

    public void Open()
    {
        if (!isOpen)
        {
            if (animationCoroutine != null)
            {
                StopCoroutine(animationCoroutine);
            }

            animationCoroutine = StartCoroutine(DoRotationOpen());

        }
    }

    private IEnumerator DoRotationOpen()
    {
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation;
        endRotation = Quaternion.Euler(new Vector3(0, startRotation.eulerAngles.y + rotationAmount, 0));


        isOpen = true;

        float time = 0;
        while (time < 1)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, time);
            yield return null;
            time += Time.deltaTime * speed;
        }
    }

    public void Close()
    {
        if (isOpen)
        {
            if (animationCoroutine != null)
            {
                StopCoroutine(animationCoroutine);
            }

            animationCoroutine = StartCoroutine(DoRotationClose());
        }
    }

    private IEnumerator DoRotationClose()
    {
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(new Vector3(0, startRotation.eulerAngles.y - rotationAmount, 0));


        isOpen = false;

        float time = 0;
        while (time < 1)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, time);
            yield return null;
            time += Time.deltaTime * speed;
        }

    }
}
