docker rmi -f dotnet5mvcokta:dev || true
docker build -t dotnet5mvcokta:dev . || true
docker rmi $(docker images -f "dangling=true" -q) || true