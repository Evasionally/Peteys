using UnityEngine;

public class SniperAttackController : AttackController
{
    private Transform shotSpawn;
    private LineRenderer lr;

    private bool onSoftCooldown = false;
    [Tooltip("If the sniper's line of sight is blocked, wait this time until trying to attack again")]
    public float softCooldown = 1f;

    public float spread;
    public float damage;
    
    public new void Start()
    {
        aiController = gameObject.GetComponent<EnemyAI>();
        shotSpawn = transform.GetChild(0);
        lr = gameObject.GetComponent<LineRenderer>();
    }

    public override void BeginAttack()
    {
        transform.LookAt(aiController.player);
        if (onCooldown || onSoftCooldown)
            return;

        Vector3 trueAim = aiController.player.transform.position - shotSpawn.position;
        
        bool canSeePlayer = Physics.Raycast(shotSpawn.position, trueAim, Mathf.Infinity, aiController.whatIsPlayer);
        if (!canSeePlayer)
        {
            SoftCooldown();
            return;
        }
        
        Attack(trueAim + Variation());
        Cooldown();
    }

    private void Attack(Vector3 shot)
    {
        bool hitPlayer = Physics.Raycast(origin:shotSpawn.position, direction:shot, out var hit, maxDistance:Mathf.Infinity);
        DrawAttack(hit.point);

        if (hit.collider.gameObject.name == "Petey")
        {
            aiController.player.GetComponent<HealthController>().Damage(damage);
        }
    }

    private void DrawAttack(Vector3 hitPos)
    {
        lr.positionCount = 2;
        lr.SetPosition(index:0, shotSpawn.position);
        lr.SetPosition(index:1, hitPos);
        Invoke(nameof(ClearAttack), 0.3f);
    }

    private void ClearAttack()
    {
        lr.positionCount = 0;
    }

    private Vector3 Variation()
    {
        Rigidbody playerRB = aiController.player.GetComponent<Rigidbody>();

        float velocity = playerRB.velocity.magnitude;
        
        float xVariance = Random.Range(-spread, spread) * velocity;
        float yVariance = Random.Range(-spread, spread) * velocity;
        float zVariance = Random.Range(-spread, spread) * velocity;
        
        Vector3 variation = new Vector3(xVariance, yVariance, zVariance);
        variation.Normalize();

        return variation;
    }
    
    private void SoftCooldown()
    {
        onSoftCooldown = true;
        Invoke(nameof(EndSoftCooldown), softCooldown);
    }

    private void EndSoftCooldown()
    {
        onSoftCooldown = false;
    }
    
}