namespace GameSource.Scripts.Units
{
    public class PatrolEnemy : AIEnemy
    {
        private void Update()
        {
            if (!isAvailable) return;

            Patrol();
        }
    }
}