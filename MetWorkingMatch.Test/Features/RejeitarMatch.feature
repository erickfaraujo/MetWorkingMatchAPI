Funcionalidade: Rejeitar pedido de match
	Permite que um usuário possa rejeitar um pedido de match recebido

Cenario: Usuário rejeita um pedido de match
	Dado que o usuário <IdUser> possua <possui> um pedido de match recebido
	Quando o usuário <IdUser> rejeitar o pedido de outro usuário
	Entao o sistema deve retornar o status <isOK>

	Exemplos:
		| IdUser                               | possui | isOK |
		| de12b17f-e9a7-48b2-b910-c92751b8b0c4 | True   | True |

Cenario: Usuário tenta rejeitar um pedido de match que não está pendente
	Dado que o usuário <IdUser> possua <possui> um pedido de match recebido
	Quando o usuário <IdUser> quiser rejeitar o pedido que não existe
	Entao o sistema deve retornar o status <isOK>

	Exemplos:
		| IdUser                               | possui | isOK  |
		| de12b17f-e9a7-48b2-b910-c92751b8b0c4 | False  | False |