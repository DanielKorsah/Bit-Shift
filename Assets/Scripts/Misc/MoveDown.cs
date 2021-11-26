using UnityEngine;

namespace BitShift.Misc
{
    public class MoveDown : MonoBehaviour
    {
        public float speed = 3;
        public float destructTime = 2.0f;

        // Update is called once per frame
        void Update()
        {
            if (transform.position.y > -6)
                transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
        }

        void Destruct()
        {
            Destroy(gameObject);

        }
    }
}