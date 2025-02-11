Projeto em Grupo feito em sala com objetivo de praticar a colaboração, utilizar o MVC e se preparar para integrar com banco de dados.
Grupo: Julio Cesar Martini , Pedro de Miranda Neto , João Gabriel Mendes , Lucas Bretzke

Documentação do Sistema de Gestão de Cantina
Versão: 1.0
Data: 10/02/2025
Autor: Equipe Variável De Sabor

1. Resumo do Sistema
O sistema de gestão de cantina é uma solução web desenvolvida para gerenciar as operações administrativas de uma cantina ou restaurante. O sistema permite o gerenciamento de Clientes, Pedidos, Produtos e Estoque por meio de operações CRUD (Create, Read, Update, Delete). Cada entidade possui uma interface com grid para facilitar a visualização, edição e exclusão de registros.

2. Funcionalidades Principais
2.1. Clientes
Cadastro de Clientes: Inclui nome, telefone, e-mail e endereço.

Grid de Clientes: Exibe todos os clientes cadastrados com opções de editar e excluir.

Filtros: Pesquisa por nome, telefone ou e-mail.

2.2. Pedidos
Cadastro de Pedidos: Permite registrar pedidos vinculados a clientes e produtos.

Grid de Pedidos: Exibe todos os pedidos com detalhes como data, cliente, produtos e valor total.

Filtros: Pesquisa por data, cliente ou status do pedido (em andamento, finalizado, cancelado).

2.3. Produtos
Cadastro de Produtos: Inclui nome, descrição, preço e categoria (bebida, comida, sobremesa).

Grid de Produtos: Exibe todos os produtos cadastrados com opções de editar e excluir.

Filtros: Pesquisa por nome, categoria ou preço.

2.4. Estoque
Cadastro de Estoque: Registra a quantidade disponível de cada produto.

Grid de Estoque: Exibe o estoque atual de todos os produtos com opções de atualizar quantidade.

Alertas: Notifica quando o estoque de um produto está abaixo do nível mínimo.

3. Tecnologias Utilizadas
Frontend: React.js (interface responsiva com grids e formulários).

Backend: Node.js (API REST para operações CRUD).

Banco de Dados: PostgreSQL (armazenamento de dados).

Autenticação: JWT (JSON Web Token) para segurança.

