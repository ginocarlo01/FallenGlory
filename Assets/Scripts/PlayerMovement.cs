using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;

    private void Update()
    {
        // Obtém a entrada do jogador
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        float movimentoVertical = Input.GetAxis("Vertical");

        // Calcula a direção de movimento
        Vector3 direcaoMovimento = new Vector3(movimentoHorizontal, movimentoVertical, 0);

        // Normaliza a direção para evitar movimento mais rápido na diagonal
        direcaoMovimento.Normalize();

        // Move o personagem
        transform.Translate(direcaoMovimento * speed * Time.deltaTime);
    }
}
