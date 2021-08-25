using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FootballAI
{
    public class Player : MonoBehaviour
    {
        public Movement movement;
        public PlayerStatues playerStatues;


        public FindTargets findTargets;
        public Vector3 target;

        public bool isFollowEnemy;
        public Player enemy;

        private MeshRenderer meshRenderer;
        private void Start()
        {
            meshRenderer = GetComponent<MeshRenderer>();

            movement = AIManager.Instance.movement;
            SearchNewTarget();
            transform.position = target;
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.layer = LayerMask.NameToLayer(playerStatues.getLayer);
            }

            meshRenderer.material = playerStatues.getMaterial;
            findTargets.ClearAllData();

        }
        public void ChangeStatues()
        {//attackDedector scriptinde event olarak çaðrýlmýþtýr.


            if (movement.turbo.isWorkingTurbo || enemy.movement.turbo.isWorkingTurbo)
            {
                return;
            }

            //playerStatues.ChangeBallStatue();
            if (playerStatues.ChangeBallStatue().haveBall)
            {
                movement.turbo.StartTurbo();
            }
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.layer = LayerMask.NameToLayer(playerStatues.getLayer);
            }

            meshRenderer.material = playerStatues.getMaterial;
        }
        private void Update()
        {
            if (AIManager.Instance.placeRandomly.Over(transform.position))
            { //çember dýþýna çýkarsa geri döner.
                SearchNewTarget();
            }
            movement.turbo.CheckTurbo(Time.deltaTime); //turbo durumunu kontrol et
            if (findTargets.isFindTarget)
            {//düþman tespit edildiyse
                enemy = findTargets.GetClosestTarget();
                if (enemy.playerStatues.haveBall && !playerStatues.haveBall)
                {//düþmanda top varsa ve sende yoksa kovala.
                    target = enemy.transform.position;
                    return;
                }
                else if (!enemy.playerStatues.haveBall && playerStatues.haveBall && !isFollowEnemy)
                {//düþmanda top yoksa ve sende top varsa kaç
                    SearchNewTarget();
                    isFollowEnemy = true;
                    return;
                }

            }
            if (Vector3.Distance(transform.position, target) < 1)
            { //hedef noktaya ulaþttýðýnda ve alan dýþýnda ise
                SearchNewTarget();
            }
        }
        private void FixedUpdate()
        {
            movement.CharacterMove(transform, target, Time.fixedDeltaTime);
            transform.LookAt(target);
        }
        /// <summary>
        /// Hareket edecek hedef noktasý oluþturur.
        /// </summary>
        public void SearchNewTarget()
        {
            target = AIManager.Instance.placeRandomly.GetRandomPosition;
            transform.LookAt(target);
        }

    }

}
