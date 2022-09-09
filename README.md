
### Start Local DB
```bash
docker run --name postgres-dev -e POSTGRES_PASSWORD=password -e POSTGRES_DB="CosmereDB" -v ~/postgres-data/:/var/lib/postgresql/data -p  5432:5432 postgres
```