using UnityEngine;


public class QueuePosition : MonoBehaviour
{
    public QueuePosition Next;
    public QueuePosition Prev;

    private Car currentCar = null;

    public bool IsOccupied { get { return currentCar != null; } }

    public void Push(Car car)
    {
        if(IsOccupied)
            return;

        if(Next != null && !Next.IsOccupied)
        {
            Next.Push(car);
        }
        else
        {
            currentCar = car;
            currentCar.MoveTo(transform);
        }
    }

    public Car Pull()
    {
        if(IsOccupied && currentCar.IsStopped)
        {
            var car = currentCar;
            currentCar = Prev != null && Prev.IsOccupied ? Prev.Pull() : null;
            if(currentCar != null) currentCar.MoveTo(transform);

            return car;
        }

        return null;
    }

    public bool CanPull() { return IsOccupied && currentCar.IsStopped; }
}