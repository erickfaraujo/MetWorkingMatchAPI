Funcionalidade: Excluir Match
	Exclui uma conexão (match) entre usuários

Cenario: Usuário exclui uma conexão
	Dado que o usuário <IdUser> possua uma conexão com o <IdAmigo>
	Quando o usuário <IdUser> quiser excluir a conexão <IdAmigo>
	Então o retorno da exclusão deve ser <isOK>

	Exemplos:
		| IdUser                               | IdAmigo                              | isOK |
		| 2db41729-5cbc-4d81-ac9e-eca7f8edcb1f | d3d4b0f4-ee3b-4506-943c-62c88d50e874 | True |
		| 9f62b1aa-76a7-4b77-92ed-eff5824332cb | d8d7b351-580e-4dd3-8cd1-e89e0daaaaaa | True |

Cenario: Usuário tenta excluir uma conexão que não existe
	Quando o usuário <IdUser> quiser excluir a conexão <IdAmigo> que não existe
	Então o retorno da exclusão deve ser <isOK>

	Exemplos:
		| IdUser                               | IdAmigo                              | isOK |
		| 0a3c8043-1820-41d0-b9b0-4a3250cc180a | de12b17f-e9a7-48b2-b910-c92751b8b0c4 | False |