docker exec -it consul consul services register -name=SecretManager -address=http://localhost -port=8200
docker exec -it vault vault kv put secret/externaldata dadjokeapikey=cebbfce582msh77b9db9002c101fp119f34jsne4b223f28bcb