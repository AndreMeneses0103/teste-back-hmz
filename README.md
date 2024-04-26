# Teste Back-End HMZ

Este é o projeto desenvolvido para o teste back-end da empresa HMZ. O desafio consiste na criação de uma API utilizando C# e .NET para gerenciamento de usuários, registro e login.

Nesta API Rest, o Administrador pode realizar registros, logins, receber tokens, atualizar e deletar usuários.

## Desenvolvido por:

- [@AndreMeneses0103](https://github.com/AndreMeneses0103)

## 🔗 Links


[![linkedin](https://img.shields.io/badge/linkedin-0A66C2?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/andre-meneses-dev/)

[![github](https://img.shields.io/badge/github-181717?style=for-the-badge&logo=github&logoColor=white)](https://github.com/AndreMeneses0103)

  
## Requisitos

- .NET SDK 8.0
- MySql


## Banco de Dados

Para utilizar o projeto, é necessário ter o banco de dados MySql instalado em sua máquina. Nele, você deve apenas executar esse código:
```bash
  create database hmz
```
Não é necessário criar tabelas, pois o EntityFramework realizará a criação.

## Comandos para Recriar o Projeto

Para recriar este projeto em seu ambiente local, siga as instruções abaixo:

1. **Clone o Repositório:**
```bash
  git clone https://github.com/AndreMeneses0103/teste-back-hmz.git
```

2. **Acesse o Diretório do Projeto:**

```bash
  cd Back-HMZ
```

3. **Caso não tenha, instale o dotnet-ef**
```bash
  dotnet tool install --global dotnet-ef
```

4. **Instale as Dependências NuGet:**
```bash
  dotnet restore
```

5. **Abra o arquivo appsettings.json e altere "MySqlConnection" com informações de acordo com o seu banco de dados:**
```bash
    "ConnectionStrings": {
    "MySqlConnection": "(Inserir conexão do seu banco de dados MySql)"
  }
```

6. **Execute esse comando para atualizar o seu banco de dados com as tabelas a serem utilizadas**
```bash
   dotnet ef database update
```

7. **Compile o projeto**
 ```bash
   dotnet build
```

8. **Inicie o projeto**
 ```bash
   dotnet run
```

9. **Acesse a API através do Localhost, informando a porta e acessando o Swagger
```bash
  https://localhost:44325/swagger/index.html
```

Na página Swagger, você pode realizar as requisições HTTP da API.
![image](https://github.com/AndreMeneses0103/teste-back-hmz/assets/89109574/6adb18cc-d45f-418a-96d1-f9498af2f649)


## Considerações Finais

Este projeto foi desenvolvido como parte do teste back-end da empresa HMZ. Sinta-se à vontade para explorar este projeto. Se tiver alguma dúvida ou problema, não hesite em entrar em contato. Desde já, agradeço pela oportunidade!
