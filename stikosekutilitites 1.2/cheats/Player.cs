namespace stikosekutilitites_1._2.cheats
{
    internal class Player
    {
        // All the activation variables. You can toggle theese cheats via theese variables.
        public static bool godmode = false;
        public static bool stamina = false;
        public static bool food = false;
        public static bool instamine = false;
        public static bool instakill = false;
        public static bool freechests = false;


        // A update function for all player hacks. They arent gonna work without calling all the methods
        public static void Update()
        {
            GodMode(godmode);
            Stamina(stamina);
            Food(food);

        }
        // Accual cheats now.
        // GodMode - Infinite health.This method just resets the health & shields to max every frame. Its not the cleanesst way but kinda works.
        public static void GodMode(bool activated)
        {
            if (!activated)
                return;

            PlayerStatus.Instance.hp = PlayerStatus.Instance.maxHp;
            PlayerStatus.Instance.shield = PlayerStatus.Instance.maxShield;

        }

        // Stamina - Bassicaly god mode but it resets stamina instead
        public static void Stamina(bool activated)
        {
            if (!activated)
                return;

            PlayerStatus.Instance.stamina = PlayerStatus.Instance.maxStamina;

        }

        // Food - Stamina but food. You get the point.
        public static void Food(bool activated)
        {
            if (!activated)
                return;
            PlayerStatus.Instance.hunger = PlayerStatus.Instance.maxHunger;
        }

        // Why are you even looking at my code lol, it fucking sucks.
        // Also endore h
    }
}
