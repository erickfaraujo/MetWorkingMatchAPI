#language: pt-br
Funcionalidade: Listar pedidos recebidos
	Lista os pedidos que um usuário recebeu e estão pendentes de aprovação

Cenario: Usuário com pedido recebidos
	Quando o usuário <idUser> quiser ver a lista de pedidos recebidos
	Entao o retorno deve ser <isOK>
	E a lista de pedidos recebidos deverá ser exibida <retorno>
	Exemplos:
		| idUser                               | isOK | retorno                              |
		| d3d4b0f4-ee3b-4506-943c-62c88d50e874 | True | 2db41729-5cbc-4d81-ac9e-eca7f8edcb1f |


Cenario: Usuário sem pedido recebidos
	Quando o usuário <idUser> quiser ver a lista de pedidos recebidos
	Entao o retorno deve ser <isOK>
	Exemplos:
		| idUser                               | isOK  |
		| 2db41729-5cbc-4d81-ac9e-eca7f8edcb1f | False |