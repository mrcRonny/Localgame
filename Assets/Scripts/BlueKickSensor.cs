using Mirror;
using UnityEngine;

public class KickArea : NetworkBehaviour
{
    private bool isBallInside = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("top"))
        {
            isBallInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("top"))
        {
            isBallInside = false;
        }
    }

    public bool IsBallInside()
    {
        return isBallInside;
    }
}
