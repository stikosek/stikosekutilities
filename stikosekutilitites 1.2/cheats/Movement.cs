using UnityEngine;

namespace stikosekutilitites_1._2.cheats
{
    internal class Movement
    {
        // All the activation variables. You can toggle theese cheats via theese variables.
        public static bool flight = false;
        public static bool omegajump = false;
        public static bool noclip = false;
        public static bool speed = false;
        public static bool hover = false;
        public static bool clicktp = false;


        // A update function for all movement hacks. They arent gonna work without calling all the methods
        public static void Update()
        {
            Flight(flight);
            OmegaJump(omegajump);
            NoClip(noclip);
            Speed(speed);
            ClickTp(clicktp);
            Hover(hover);

        }

        // Actual cheats now.
        // GodMode - Infinite health. This method just resets the health & shields to max every frame. Its not the cleanesst way but kinda works.
        public static void Flight(bool activated)
        {
            if (!activated)
                return;

            PlayerMovement.Instance.GetRb().velocity = new Vector3(0f, 0f, 0f);
            float speed = Input.GetKey(KeyCode.LeftControl) ? 0.5f : (Input.GetKey(InputManager.sprint) ? 1f : 0.5f);
            if (Input.GetKey(InputManager.jump))
            {
                PlayerStatus.Instance.transform.position = new Vector3(PlayerStatus.Instance.transform.position.x, PlayerStatus.Instance.transform.position.y + speed, PlayerStatus.Instance.transform.position.z);
            }
            Vector3 playerTransformPosVec = PlayerStatus.Instance.transform.position;
            if (Input.GetKey(InputManager.forward))
            {
                PlayerStatus.Instance.transform.position = new Vector3(playerTransformPosVec.x + Camera.main.transform.forward.x * Camera.main.transform.up.y * speed, playerTransformPosVec.y + Camera.main.transform.forward.y * speed, playerTransformPosVec.z + Camera.main.transform.forward.z * Camera.main.transform.up.y * speed);
            }
            if (Input.GetKey(InputManager.backwards))
            {
                PlayerStatus.Instance.transform.position = new Vector3(playerTransformPosVec.x - Camera.main.transform.forward.x * Camera.main.transform.up.y * speed, playerTransformPosVec.y - Camera.main.transform.forward.y * speed, playerTransformPosVec.z - Camera.main.transform.forward.z * Camera.main.transform.up.y * speed);
            }
            if (Input.GetKey(InputManager.right))
            {
                PlayerStatus.Instance.transform.position = new Vector3(playerTransformPosVec.x + Camera.main.transform.right.x * speed, playerTransformPosVec.y, playerTransformPosVec.z + Camera.main.transform.right.z * speed);
            }
            if (Input.GetKey(InputManager.left))
            {
                PlayerStatus.Instance.transform.position = new Vector3(playerTransformPosVec.x - Camera.main.transform.right.x * speed, playerTransformPosVec.y, playerTransformPosVec.z - Camera.main.transform.right.z * speed);
            }

        }


        public static void OmegaJump(bool activated)
        {
            if (!activated)
                return;
        }


        public static void NoClip(bool activated)
        {
            if (!activated)
            {
                Object.FindObjectOfType<PlayerMovement>().GetPlayerCollider().enabled = true;
                return;
            }

            Object.FindObjectOfType<PlayerMovement>().GetPlayerCollider().enabled = false;
        }


        public static void Speed(bool activated)
        {
            if (!activated)
            {
                PlayerStatus.Instance.currentSpeedArmorMultiplier = 1;
                return;
            }

            PlayerStatus.Instance.currentSpeedArmorMultiplier = 25;
        }


        public static void ClickTp(bool activated)
        {
            if (!activated)
                return;

            if (clicktp && Input.GetKeyDown(KeyCode.Mouse1))
            {
                Object.FindObjectOfType<PlayerMovement>().GetRb().position = SuFindPingPos();
            }
        }

        public static void Hover(bool activated)
        {
            if (!activated)
                return;

            Object.FindObjectOfType<PlayerMovement>().GetRb().velocity = new Vector3(0f, 1f, 0f);
        }

        // Why are you even looking at my code lol, it fucking sucks.
        // Also endore h
        public static Vector3 SuFindPingPos()
        {
            Transform playerCam = PlayerMovement.Instance.playerCam;
            RaycastHit raycastHit;
            if (Physics.Raycast(playerCam.position, playerCam.forward, out raycastHit, 1500f))
            {
                Vector3 b = Vector3.zero;
                if (raycastHit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
                {
                    b = Vector3.one;
                }
                return raycastHit.point + b;
            }
            return Vector3.zero;
        }
    }
}
