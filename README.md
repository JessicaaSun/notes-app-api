# 🖥️ Note with Jess - Backend  

This is the backend for **Note with Jess**, a simple note-taking app powered by **.NET** and **SQL Server**. 🚀  

## 🛠 Setup Instructions  

Follow these steps to set up and run the backend:  

### 1️⃣ Clone the Repository  

```sh
git clone https://github.com/JessicaaSun/notes-app-api.git
cd notes-app-api
```
### 2️⃣ Restore Dependencies

```sh
dotnet restore
```
### 3️⃣ Run Database with Docker

```sh
docker compose up -d --build
```
### 4️⃣ Database Connection Credentials

- Host: localhost
- Port: 1433
- Username: sa
- Password: yourStrong(!)Password

### 5️⃣ Create Database

Ensure the database name is set as:
```sh
notes-db
```
### 6️⃣ Apply Migrations

Run the following command to apply migrations:
```sh
dotnet ef database update
```

### 7️⃣ Start the Backend Server

Run the following command to apply migrations:
```sh
dotnet watch run
```