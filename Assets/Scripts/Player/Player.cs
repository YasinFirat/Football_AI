using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FootballAI
{
    public class Player : MonoBehaviour
    {
        public Movement movement;
        public PlayerStatues playerStatues;
        public GrabTheBall grabTheBall;

        public FindTargets findTargets;
        public Vector3 target;

        public bool isFollowEnemy;
        private Player enemy;

        private MeshRenderer meshRenderer;
        private void Start()
        {
            meshRenderer = GetComponent<MeshRenderer>();

            movement = AIManager.Instance.movement;
            SearchNewTarget();
            transform.position = target;
            playerStatues.haveBall = grabTheBall.haveBall;
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.layer = LayerMask.NameToLayer(playerStatues.getLayer);
            }

            meshRenderer.material = playerStatues.getMaterial;
            findTargets.ClearAllData();

        }
        /// <summary>
        /// Topa sahiplik durumunu g�nceller.
        /// </summary>
        public void UpdateStatues()
        {
            if (grabTheBall.haveBall)
            {
                movement.turbo.StartTurbo();
            }
            CheckStatues();
        }
        /// <summary>
        /// Aktif olarak s�rekli topa sahiplik durumunu kontrol eder.
        /// </summary>
        private void CheckStatues()
        {
            playerStatues.haveBall = grabTheBall.haveBall;
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.layer = LayerMask.NameToLayer(playerStatues.getLayer);
            }

            meshRenderer.material = playerStatues.getMaterial;
        }
        private void Update()
        {
            CheckStatues(); //topa sahiplik durumunu kontrol et.


            if (AIManager.Instance.placeRandomly.Over(transform.position))
            { //�ember d���na ��karsa geri d�ner.(d�zenle : d��ar�da saniye ba�� s�rekli yeni konum istiyor.)
                target = AIManager.Instance.placeRandomly.orgin;
            }
            movement.turbo.CheckTurbo(Time.deltaTime); //turbo durumunu kontrol et
            if (findTargets.isFindBall)
            {
                Debug.Log("ATA : SAH�PLENMEM�� TOP VAR");
                target = findTargets.GetBall().transform.position;
                return;
            }
            if (findTargets.isFindTarget)
            {//d��man tespit edildiyse
                enemy = findTargets.GetClosestTarget(); //top'u g�rd�yse sald�rs�n
                if (enemy.playerStatues.haveBall && !playerStatues.haveBall)
                {//d��manda top varsa ve sende yoksa kovala.
                    target = enemy.transform.position;
                    return;
                }
                else if (!enemy.playerStatues.haveBall && playerStatues.haveBall && !isFollowEnemy)
                {//d��manda top yoksa ve sende top varsa ka�
                    SearchNewTarget();
                    Debug.Log("ATA : TOPU ALDIN KA� VEYA SUT CEKECEG�N ALANA G�T");
                    isFollowEnemy = true;
                    return;
                }

            }
            if (Vector3.Distance(transform.position, target) < 1)
            { //hedef noktaya ula�tt���nda ve alan d���nda ise
                SearchNewTarget();
            }
        }
        private void FixedUpdate()
        {
            movement.CharacterMove(transform, target, Time.fixedDeltaTime);
            transform.LookAt(target);
        }
        /// <summary>
        /// Hareket edecek hedef noktas� olu�turur.
        /// </summary>
        public void SearchNewTarget()
        {
            target = AIManager.Instance.placeRandomly.GetRandomPosition;
            transform.LookAt(target);
        }

    }

}
