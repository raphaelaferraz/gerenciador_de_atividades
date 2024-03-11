# Gerenciador de Atividades

## Descrição

O projeto é um gerenciador de atividades (de qualquer objetivo), onde é possível criar, excluir e listar atividades que você cadastrou.

## Funcionalidades

- [x] Adicionar atividade
- [x] Listar atividades
- [x] Excluir atividade

## Tecnologias

- ASP.NET Core
- Entity Framework Core
- PostgreSQL
- AWS
- Vite.JS

## Estrutura de pastas

```
gerenciador_de_atividades
├── backend
│   ├── api_gerenciador_de_atividades
│   │   ├── bin
│   │   ├── Controllers
│   │   ├── Data
│   │   ├── Migrations
│   │   ├── Models
│   │   ├── obj
│   │   ├── Properties
│   │   ├── Services
│   │   ├── appsettings.json
│   │   ├── api_gerenciador_de_atividades.csproj
│   │   ├── Program.cs
│   └── api_gerenciador_de_atividades.sln
└── frontend
    └── gerenciador_de_atividades
        ├── public
        ├── src
        ├── package.json
        ├── vite.config.js

```

Backend: Possui todos os arquivos da API

- Controllers: Possui os controllers da API
- Data: Possui os arquivos de configuração do banco de dados
- Migrations: Possui as migrações do banco de dados
- Models: Possui os modelos de dados
- Services: Possui os serviços da API
- Demais pastas (bin, obj, Properties): Pastas padrões do projeto
  
  Frontend: Possui todos os arquivos do front-end
- Public: Possui os arquivos públicos do projeto
- Src: Possui os arquivos do projeto
- Demais arquivos: Arquivos padrões do projeto

## Demonstração

Acesse o link para verificar o vídeo de demonstração do projeto: https://drive.google.com/file/d/1XFjbdE54Nh_LJSArPCT9XJhWJD21hhmE/view?usp=drive_link
