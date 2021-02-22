Funcionalidade: Listar matches efetivados
	Lista todos os matches de um usuário

Cenario: Usuário com matches efetivados anteriormente
	Quando o usuário <idUser> quiser ver a lista de matches efetivados
	Entao o retorno de matches deve ser <isOK>
	E a lista de matches deverá ser exibida <retorno>

	Exemplos:
		| idUser                               | isOK | retorno                              |
		| 2db41729-5cbc-4d81-ac9e-eca7f8edcb1f | True | d3d4b0f4-ee3b-4506-943c-62c88d50e874 |

Cenario: Usuário sem matches efetivados anteriormente
	Quando o usuário <idUser> quiser ver a lista de matches efetivados
	Entao o retorno de matches deve ser <isOK>

	Exemplos:
		| idUser                               | isOK  |
		| 0a3c8043-1820-41d0-b9b0-4a3250cc180a | False |