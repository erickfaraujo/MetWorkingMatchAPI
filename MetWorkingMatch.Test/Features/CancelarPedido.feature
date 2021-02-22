Funcionalidade: Cancelar pedido de match
	Permite que um usuário possa cancelar um pedido de match enviado

Cenario: Usuário cancela um pedido de match enviado
	Dado que o usuário <IdUser> possua <possui> um pedido de match enviado
	Quando o usuário <IdUser> cancelar o pedido de outro usuário <IdAmigo>
	Entao o sistema deve retornar o status <isOK>

	Exemplos:
		| IdUser                               | possui | IdAmigo                              | isOK |
		| 22598845-3c2d-43de-8e2a-b507dd0b7a50 | True   | 3eec5533-9584-4226-9891-5890e1327269 | True |

Cenario: Usuário tenta cancelar um pedido de match que não está pendente
	Dado que o usuário <IdUser> possua <possui> um pedido de match recebido
	Quando o usuário <IdUser> quiser cancelar o pedido que não existe <IdAmigo>
	Entao o sistema deve retornar o status <isOK>

	Exemplos:
		| IdUser                               | possui | isOK  |
		| d8d7b351-580e-4dd3-8cd1-e89e0daaaaaa | False  | False |