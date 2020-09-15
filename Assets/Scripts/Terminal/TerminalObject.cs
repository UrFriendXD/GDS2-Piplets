using Player;
using UnityEngine;

namespace Terminal
{
    public class TerminalObject : UIInteractableObject
    {
        // 
        [SerializeField] private TerminalUIWindow _terminalUIWindow;

        public override void Start()
        {
            base.Start();
            _terminalUIWindow.Initialise();
        }

        public override void InteractBare(PlayerInputChecker playerInputChecker, PlayerScript playerScript)
        {
            // When player interacts open terminal and set inventory
            base.InteractBare(playerInputChecker, playerScript);
            _terminalUIWindow.OpenTerminal(playerScript.inventory, playerScript.playerStats, playerInputChecker);
            Debug.Log("UI activated");
        }

        public override void InteractWithItem(PlayerInputChecker playerInputChecker, PlayerScript playerScript)
        {
            // When player interacts open terminal and set inventory
            base.InteractBare(playerInputChecker, playerScript);
            _terminalUIWindow.OpenTerminal(playerScript.inventory, playerScript.playerStats, playerInputChecker);
        }

        public override void CloseUI()
        {
            _terminalUIWindow.CloseUI();
        }
    }
}
