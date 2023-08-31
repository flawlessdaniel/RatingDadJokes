# Add services to Consul
docker exec -it consul consul services register -name=SecretManager -address=http://localhost -port=8200
docker exec -it consul consul services register -name=RapidApi -address=https://dad-jokes.p.rapidapi.com
docker exec -it consul consul services register -name=Redis -address=localhost -port=6379
# Add secrets to Vault
docker exec -it vault vault kv put secret/externaldata dadjokeapikey=cebbfce582msh77b9db9002c101fp119f34jsne4b223f28bcb
docker exec -it vault vault kv put secret/externalhost dadjokeapihost=dad-jokes.p.rapidapi.com