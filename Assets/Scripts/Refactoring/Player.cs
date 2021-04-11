using System;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Refactoring
{
    public abstract class Player : MonoBehaviour, IPlayerMovment, IPlayerLogicView, IIPlayerGameRps
    {
        [SerializeField] private string id;
        [SerializeField] private TextMeshProUGUI nameUi;
        [SerializeField] private float timeForChangeDirection;
        [SerializeField] private GameObject prefabBullet;
        [SerializeField]private float radius;
        [SerializeField]private float timeOfShoot;
        [SerializeField]protected float speed;
        
        protected string name;
        protected int life;
        protected float reloadSpeed;
        protected Vector3 direction;
        protected float safeDistance;


        private EnginMovment _movment;
        private LogicPlayer _logic;
        private Vector3 _targetDirection;
        
        
        public string Name => name;
        public int Life => life;
        public string Id => id;
        

        private void Start()
        {
            _movment = new EnginMovment(timeForChangeDirection,this);
            _logic = new LogicPlayer(this,timeOfShoot);
            ChangeDirection();
        }

        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position,_targetDirection, speed * Time.deltaTime);
            _movment.EvaluateChangeDirection(Time.deltaTime);
            var list = Physics2D.OverlapCircleAll(transform.position, radius);
            foreach (var collider2D in list)
            {
                if (collider2D.name.Equals(name))
                {
                    continue;
                }
                _logic.GettingCloserRival(collider2D.gameObject.transform.position);
            }
            _logic.AddDeltaTimeShooterTime(Time.deltaTime);
        }

        public void Configuration(string integrante)
        {
            name = integrante;
            gameObject.name = name;
            nameUi.text = name;
        }

        public float GetRandomAxis(float min, float max)
        {
            return Random.Range(min, max);
        }

        public void ChangeDirection()
        {
            _targetDirection = _movment.CalculateDirection();
        }

        public void ChangeDirection(Vector3 target)
        {
            _targetDirection = target;
        }

        public float GetRandomTimeForChangeDirection()
        {
            return GetRandomAxis(3,6);
        }

        public void ShootingBullet(Vector3 target)
        {
            Vector3 direction = target - transform.position;
            direction.Normalize();
            var rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            var bullet = Instantiate(prefabBullet, transform.position, Quaternion.Euler(0f, 0f, rotation));
            bullet.GetComponent<BalaMovimientoEnemigo>().Configurate(name);
        }

        public int GetRandom(int min, int max)
        {
            return Random.Range(min, max);
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawSphere(transform.position,radius);
        }
    }
}