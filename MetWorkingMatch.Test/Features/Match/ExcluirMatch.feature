Funcionalidade: Excluir Match
	Exclui uma conexão (match) entre usuários

Cenario: Usuário exclui uma conexão
	Dado que o usuário <IdUser> possua uma conexão com outro usuário <IdAmigo>
	Quando o usuário <IdUser> quiser excluir a conexão <IdAmigo>
	Então o retorno da exclusão deve ser <isOK>

	Exemplos:
		| IdUser                               | IdAmigo                              | isOK |
		| 11ff6448-aeb9-4fd8-aa3f-dda5a3e385ae | 492bb22d-a131-4ee4-85df-5bfe2287a97f | True |

Cenario: Usuário tenta excluir uma conexão que não existe
	Dado que o usuário <IdUser> não possua uma conexão com o outro usuário informado <IdAmigo>
	Quando o usuário <IdUser> quiser excluir a conexão <IdAmigo>
	Então o retorno da exclusão deve ser <isOK>

	Exemplos:
		| IdUser                               | IdAmigo                              | isOK |
		| 11ff6448-aeb9-4fd8-aa3f-dda5a3e385ae | 492bb22d-a131-4ee4-85df-5bfe2287a97f | False |