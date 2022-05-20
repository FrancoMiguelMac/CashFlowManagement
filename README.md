#Como subir aplicação local:
Para subir a aplicação local basta clonar esse repositório, abrir o projeto no visual studio e dar play no projeto web api CashFlowManagement.

#Como simular os serviços:
A api possui 3 endpoints:

1) Http post para registrar os lançamentos:
Exemplo de contrato pra registrar um crédito:
{
  "description": "Venda de cerveja",
  "value": 10,
  "cashFlowTypeId": "223c9d39-7635-4625-80e1-a341e0497a0a"
}
Exemplo de contrato pra registrar um débito:
{
  "description": "Compra de cerveja",
  "value": 5.99,
  "cashFlowTypeId": "7b24b08d-c18a-416b-b17d-704e221c8bb7"
}

2) Http get para retornar todos os lançamentos detalhados do dia

3) Http get para retornar o consolidado diário em saldo


#Observações importantes sobre o projeto:
1)Dados armazenados somente no MemoryCache da aplicação. Portanto enquanto o servidor tiver "vivo" os dados estarão lá. Quando derrubar e subir de novo irá resetar os dados.
2)Foi usado o FluentValidation nas validações de domínio
3)Foram escritos testes para as regras de domínio usando xunit.