using System.Linq;
using UnityEngine;

    public class MouseInteractionsPresenter : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private SelectableValue _selectableValue;

        private void Update()
        {
            if (!Input.GetMouseButtonUp(0))
            {
                return;
            }
            var hits = Physics.RaycastAll(_camera.ScreenPointToRay(Input.mousePosition));
            if (hits.Length == 0)
            {
                return;
            }
            var selectable = hits
                .Select(hit => hit.collider.GetComponentInParent<ISelectableItem>())
                .FirstOrDefault(c => c != null);
            _selectableValue.SetValue(selectable);
        }
    }