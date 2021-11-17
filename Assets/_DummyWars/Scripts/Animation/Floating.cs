using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace MaranzaWorld
{
    public class Floating : MonoBehaviour
    {
        private float startPos, endPos;

        private void Start()
        {
            startPos = transform.position.y;
            endPos = transform.position.y + 0.5f;

            StartCoroutine(MoveY());
            InvokeRepeating(nameof(ShakeRotation), 0, 3);
            InvokeRepeating(nameof(ShakeScale), 0, 0.5f);
        }


        private IEnumerator MoveY()
        {
            while (true)
            {
                if (transform.position.y == startPos) transform.DOMoveY(endPos, 2);
                yield return new WaitForSeconds(2);
                if (transform.position.y != startPos) transform.DOMoveY(startPos, 2);
                yield return new WaitForSeconds(2);
            }
        }

        private void ShakeRotation() => transform.DOShakeRotation(3, 200, 0);


        private void ShakeScale() => transform.DOShakeScale(0.5f, 0.25f, 1);


    }
}

