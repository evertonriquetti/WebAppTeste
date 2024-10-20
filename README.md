# Desafio_Tecnico
Testar conhecimento técnico desenvolvedor backend C#. Gerador de usuários aleatórios

## Criar Banco de dados
Utilize o seguinte código:
```sql
CREATE DATABASE Usuario;
```
## Configurar string da conexão
Incluir o código no arquivo ***appsettings.json***, substituindo **_Username_** e **_Password_** conforme configurado no seu banco de dados PostgreSQL
```json
"ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=Usuario;Username=seu_usuario;Password=sua_senha"
}
```

## Executar o migrations
No **_terminal_** acesse a pasta do projeto e execute o comando:
```shell
dotnet ef database update
```
