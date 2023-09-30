using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;

    private void Update()
    {
        // Obt�m a entrada do jogador
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        float movimentoVertical = Input.GetAxis("Vertical");

        // Calcula a dire��o de movimento
        Vector3 direcaoMovimento = new Vector3(movimentoHorizontal, movimentoVertical, 0);

        // Normaliza a dire��o para evitar movimento mais r�pido na diagonal
        direcaoMovimento.Normalize();

        // Move o personagem
        transform.Translate(direcaoMovimento * speed * Time.deltaTime);
    }
}
