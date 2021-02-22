Funcionalidade: Enviar pedido de match
	Permite que um usuário possa enviar um pedido de match à outro usuário

Cenario: Usuário envia pedido à outro usuário
	Quando o usuário <IdUser> enviar um pedido de match ao <IdAmigo>
	Entao o sistema deve retornar o status <isOK>

	Exemplos:
		| IdUser                               | IdAmigo                              | isOK |
		| 2db41729-5cbc-4d81-ac9e-eca7f8edcb1f | d3d4b0f4-ee3b-4506-943c-62c88d50e874 | True |
		| 9f62b1aa-76a7-4b77-92ed-eff5824332cb | d8d7b351-580e-4dd3-8cd1-e89e0daaaaaa | True |
		| 0a3c8043-1820-41d0-b9b0-4a3250cc180a | de12b17f-e9a7-48b2-b910-c92751b8b0c4 | True |
		| 22598845-3c2d-43de-8e2a-b507dd0b7a50 | 3eec5533-9584-4226-9891-5890e1327269 | True |

Cenario: Usuário envia pedido à um usuário que já é uma conexão ativa
	Quando o usuário <IdUser> enviar um pedido de match ao <IdAmigo>
	Entao o sistema deve retornar o status <isOK>

	Exemplos:
		| IdUser                               | IdAmigo                              | isOK  |
		| 9f62b1aa-76a7-4b77-92ed-eff5824332cb | d8d7b351-580e-4dd3-8cd1-e89e0daaaaaa | False |