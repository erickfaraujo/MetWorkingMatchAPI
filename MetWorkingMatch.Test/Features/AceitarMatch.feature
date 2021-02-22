Funcionalidade: Aceitar pedido de match
	Permite que um usuário possa aceitar um pedido de match recebido

Cenario: Usuário aceita um pedido de match
	Dado que o usuário <IdUser> possua <possui> um pedido de match recebido
	Quando o usuário <IdUser> aceitar o pedido de outro usuário
	Entao o sistema deve retornar o status <isOK>

	Exemplos:
		| IdUser                               | possui | isOK |
		| d3d4b0f4-ee3b-4506-943c-62c88d50e874 | True   | True |
		| d8d7b351-580e-4dd3-8cd1-e89e0daaaaaa | True   | True |

Cenario: Usuário tenta aceitar um pedido de match que não está pendente
	Dado que o usuário <IdUser> possua <possui> um pedido de match recebido
	Quando o usuário <IdUser> aceitar o pedido de outro usuário
	Entao o sistema deve retornar o status <isOK>

	Exemplos:
		| IdUser                               | possui | isOK  |
		| d8d7b351-580e-4dd3-8cd1-e89e0daaaaaa | False  | False |