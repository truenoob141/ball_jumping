using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Project.Play
{
    [RequireComponent(typeof(Graphic))]
    public class GameArea : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            var pos = Camera.main.ScreenToWorldPoint(eventData.position);
            var hit = Physics2D.Raycast(pos, Vector2.zero);
            if (hit.collider != null)
            {
                var interact = hit.collider.GetComponent<IInteractable>();
                if (interact != null) interact.Interact();
            }
        }
    }
}
