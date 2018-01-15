using System.Collections;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    public void MoveTo(Transform destination)
    {
        var startRotation = transform.rotation.eulerAngles.y;
        var endRotation = destination.rotation.eulerAngles.y;

        if (Mathf.Abs(startRotation - endRotation) > 0)
        {
            var midPosition = GetMidTransitionPosition(destination);
            // TODO: implement move coroutine
        }

        StartCoroutine(MoveCoroutine(destination.position));
    }

    public void MoveTo(Vector3 position) { StartCoroutine(MoveCoroutine(position)); }

    public void Despawn()
    {
        Destroy(gameObject);
    }

    private IEnumerator MoveCoroutine(Vector3 destination)
    {
        IsStopped = false;

        var start = transform.position;
        var distance = Vector3.Distance(start, destination);
        var progress = 0.0f;

        while (progress < 1.0f)
        {
            gameObject.transform.position = Vector3.Lerp(start, destination, progress);

            yield return new WaitForEndOfFrame();
            progress += Time.deltaTime * speed / distance;
        }

        gameObject.transform.position = destination;
        IsStopped = true;
    }

    private Vector3 GetMidTransitionPosition(Transform destination)
    {
        var startRotation = transform.rotation.eulerAngles.y;
        var endRotation = destination.rotation.eulerAngles.y;

        var start = transform.position;
        var end = destination.position;
        if (Mathf.Abs(startRotation - endRotation) > 0)
        {
            return transform.forward.z > transform.forward.x
                       ? new Vector3(transform.position.x, 0, destination.position.z)
                       : new Vector3(destination.position.x, 0, transform.position.z);
        }

        // Direction are same
        return new Vector3((start.x + end.x) / 2, 0, (start.z + end.z) / 2);
    }

    public bool IsStopped { get; set; }
}