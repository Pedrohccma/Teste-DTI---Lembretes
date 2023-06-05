# Sistema de Lembretes
O sistema foi desenvolvido para o desafio técnico realizado pela DTI Digital. Na aplicação em questão é permitido ao usuário criar e e excluir lembretes, com a inserção de um nome e uma data para o lembrete.

## Funcionalidades:
- Adicionar data ao lembrete (formato dd/mm/aaaa)
- Adicionar nome (ex. Consulta com médico X, às 16 horas!)
- Criar lembretes
- Remover lembretes
- Exibir datas futuras nos lembretes

## Stack Utilizada:
- Front-end: JavaScript, Html, Css.
- Back-end: C#
- Testes:

## Requisitos do Projeto
- O site deve apresentar na página principal campos para a adição de nome e data, um botão que permita a criação do lembrete.
- Uma lista que contenha os lembretes criados, agrupados de acordo com a data informada
- Um botão na área de listagem para a remoção de lembretes
- Conter uma validação que impeça o usuãrio de utilizar datas posteriores e de deixar os campos nome e data em branco
- Ao adicionar e remover um bilhete deve ocorrer uma atualização do sistema de forma a mostrar o que foi alterado

## Resoluções do Projeto
- Optou-se por construir um aplicativo Web ASP.NET Core MVC, permitindo uma maior facilidade na criação e  armazenamento dos lembretes como variáveis locais, assim como o acesso para uma listagem mais simples.
- A estilização foi feita em JavaScript, Html e CSS, devido a maior praticidade e familiaridade do individuo responsável pela confecção do projeto
- Por uma questão de estética e maior conforto/acessibilidade do usuãrio, escolheu-se adicionar swal's com textos informativos sobre a necessidade de preenchimento dos campos obrigatórios
- Foi feito o uso de uma variável Id que permitiu um controle mais fácil do processo de criação dos lembretes, assim como sua identificação e de possíveis erros 
- Utilização do XUnit para realização de testes unitários (A função escolhida foi a de criação de Id's dos lembretes(Necessário tornar a função pública!))

## Pontos de melhoria
- Elaborar mais testes no back e front-end
- Clean code
- Acessibilidade

## Instruções para executar o Sistema:
1 - Deve-se clonar o projeto através do link: https://github.com/Pedrohccma/Teste-DTI---Lembretes.git , ou inicializar o código utilizando o Microsoft Visual Studio
2 - Executar a solução, sendo direcionado para a página inicial, onde poderá realizar o cadastro de lembretes, e a visualização da lista contendo os lembretes criados
