#language: pt-br
Funcionalidade: Listar pedidos recebidos
	Lista os pedidos que um usuário recebeu e estão pendentes de aprovação

@mytag
Cenario: Listar pedidos recebidos pendentes
	Quando o usuário <idUser> quiser ver a lista de pedidos recebidos
	Entao a lista de pedidos pendentes deverá ser exibida <retorno>

	Exemplos:
		| idUser                               | retorno                              |
		| d3d4b0f4-ee3b-4506-943c-62c88d50e874 | 2db41729-5cbc-4d81-ac9e-eca7f8edcb1f |