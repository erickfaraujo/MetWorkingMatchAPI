#language: pt-br

Funcionalidade: Listar pedidos enviados
	Lista os pedidos que um usuário solicitou e estão pendentes de aprovação

@mytag
Cenario: Listar pedidos enviados
	Quando o usuário <idUser> quiser ver a lista de pedidos enviados pendentes
	Entao a lista de pedidos enviados deverá ser exibida <retorno>
	Exemplos: 
	| idUser                               | retorno                              |
	| 2db41729-5cbc-4d81-ac9e-eca7f8edcb1f | d3d4b0f4-ee3b-4506-943c-62c88d50e874 |
	#| d3d4b0f4-ee3b-4506-943c-62c88d50e874 | ???????? |