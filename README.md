# granito

Instruções para executar o projeto
Este repositório contém um projeto com duas APIs: Juros e Calculo. Abaixo estão as instruções para executá-las e também para executar os testes.

Executando o projeto
Para executar as APIs, é necessário ter o .NET Core SDK 3.1 ou superior instalado. Se você ainda não tem, pode baixá-lo aqui: https://dotnet.microsoft.com/download

API de Juros
Para executar a API de Juros, abra o terminal na pasta API/Juros e execute o seguinte comando:

arduino
Copy code
dotnet run
API de Cálculo
Para executar a API de Cálculo, abra o terminal na pasta API/Calculo e execute o seguinte comando:

arduino
Copy code
dotnet run
Executando os testes
Para executar os testes, abra o terminal na pasta Tests e execute o seguinte comando:

bash
Copy code
dotnet test
Executando o projeto com Docker
Para executar o projeto com Docker, é necessário ter o Docker instalado. Se você ainda não tem, pode baixá-lo aqui: https://www.docker.com/products/docker-desktop

API de Juros
Para executar a API de Juros com Docker, abra o terminal na pasta API/Juros e execute os seguintes comandos:

arduino
Copy code
docker build -t juros .
docker run -p 5001:80 juros
API de Cálculo
Para executar a API de Cálculo com Docker, abra o terminal na pasta API/Calculo e execute os seguintes comandos:

arduino
Copy code
docker build -t calculo .
docker run -p 5000:80 calculo


Ambas API possues swagger, para abrir apenas digite /swagger apos a URL da API

Pronto! Agora você já pode acessar as APIs pelo navegador ou através de alguma ferramenta como o Postman ou o Insomnia.