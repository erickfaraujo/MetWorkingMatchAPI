Funcionalidade: Listar matches efetivados
	Lista todos os matches de um usuário

Cenario: Usuário com matches efetivados anteriormente
	Quando o usuário <idUser> quiser ver a lista de matches efetivados
	Entao o retorno de matches deve ser <isOK>
	E a lista de matches deverá ser exibida <retorno>
	Exemplos:
		| idUser                               | isOK | retorno                              |
		| edaff838-1b0e-475c-88a9-7b127ab7c6ff | True | a6c907f1-f704-4b34-beca-60c8195cce10 |

Cenario: Usuário sem matches efetivados anteriormente
	Quando o usuário <idUser> quiser ver a lista de matches efetivados
	Entao o retorno de matches deve ser <isOK>
	Exemplos:
		| idUser                               | isOK  |
		| b0438f34-2f50-4c9d-a440-c45a8b9c45fe | False |