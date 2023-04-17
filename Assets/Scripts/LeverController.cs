using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Assets.Scripts
{
    public class LeverController : MonoBehaviour
    {
        [SerializeField] private GameObject leverText;
        [SerializeField] private GameObject IsOpenDoor;
        [SerializeField] private Animator _anim;

        

        private bool isTrue = false;
        private void Start()
        {
            _anim = GetComponent<Animator>();
            leverText.SetActive(false);
            IsOpenDoor.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isTrue = !isTrue; // �������� �������� ���������� �� ��������������� (����� ����� ������ true ��������, ���� ����� � ��� ������� �������)
                _anim.SetBool("IsActive", true); // ������������� �������� ��������� isActiveLever � ���������
                IsOpenDoor.SetActive(true);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                leverText.SetActive(true);
                StartCoroutine("WaitForSec");
            }
        }

        IEnumerator WaitForSec()
        {
            yield return new WaitForSeconds(5);
            Destroy(leverText);
            //Destroy(gameObject);
        }
    }
}
