# Desafio Agenda

Projeto fullstack para gerenciamento de agendas e contatos. É composto por uma API desenvolvida em .NET 8 e uma interface web desenvolvida com Vue.js + Vite.

## 📁 Estrutura do Projeto

```
desafio_agenda
├── agenda_api         # Projeto backend (API .NET 8)
  ├── Agenda.API
  ├── Agenda.Application
  ├── Agenda.Domain
  ├── Agenda.Infrastructure
  ├── Agenda.Tests
  ├── Agenda.sln
  ├── Dockerfile
  └── wait-for-postgres.sh
├── agenda_ui          # Projeto frontend (Vue.js)
  ├── Dockerfile
  ├── README.md
  ├── config
  ├── index.html
  ├── package-lock.json
  ├── package.json
  ├── public
  ├── src
  ├── tsconfig.app.json
  ├── tsconfig.json
  ├── tsconfig.node.json
  ├── vite.config.js
  └── vite.config.ts
├── docker-compose.yml # Orquestração dos serviços
```

---

## 🧭 Acesso aos Projetos

### Backend (API)

- Caminho: `./agenda_api/Agenda.API`
- URL padrão (Docker): `http://localhost:5000`

### Frontend (UI)

- Caminho: `./agenda_ui`
- URL padrão (Docker): `http://localhost`

---

## ▶️ Executando Manualmente

### Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- [Node.js (18+)](https://nodejs.org/)
- [PostgreSQL](https://www.postgresql.org/) rodando localmente (porta padrão: 5432)

### 1. Backend (.NET API)

```bash
cd agenda_api
dotnet restore
dotnet build
dotnet ef database update # Certifique-se de configurar o appsettings com sua conexão local
dotnet run --project Agenda.API
```

A API estará disponível em `http://localhost:5000`.

### 2. Frontend (Vue.js)

```bash
cd agenda_ui
npm install
npm run dev
```

A UI estará disponível em `http://localhost:5173`.

> **Nota:** A porta `5173` é usada apenas no ambiente de desenvolvimento. Em produção via Docker, será a porta `80`.

---

## 🐳 Executando com Docker

### 1. Subir o ambiente completo com `docker-compose`:

```bash
docker-compose up --build
```

Este comando:

- Sobe o PostgreSQL
- Aguarda o banco estar pronto (`wait-for-postgres.sh`)
- Executa as migrations automaticamente
- Sobe a API na porta `5000`
- Sobe a UI na porta `80`

### 2. Acessos com Docker:

- **API:** [http://localhost:5000](http://localhost:5000)
- **Frontend:** [http://localhost](http://localhost)

---

## 🐋 Baixando Imagens do Docker Hub

Baixe as imagens diretamente do Docker Hub:

```bash
docker pull eviojoaquim/agenda_api:latest
docker pull eviojoaquim/agenda_ui:latest
```

Para executar utilizando apenas as imagens (sem build local):

```bash
docker-compose -f docker-compose.yml up
```

---

## 🧪 Testes

### Executar os testes da API:

```bash
cd agenda_api
dotnet test
```

---

## 📁 Informações Adicionais

- As migrations são aplicadas automaticamente ao subir com Docker.
- Variáveis de ambiente podem ser definidas no `docker-compose.yml` ou via `.env`.

---

## 🧑‍💻 Contribuição

Sinta-se livre para abrir issues ou enviar pull requests com melhorias.

---

## 📝 Licença

Este projeto está sob a licença MIT.
