until pg_isready -h db -p 5432 -U postgres; do
  echo "Aguardando o PostgreSQL iniciar..."
  sleep 2
done

dotnet ef database update --project Agenda.API/Agenda.API.csproj --startup-project Agenda.API/Agenda.API.csproj --verbose
