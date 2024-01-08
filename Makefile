COMPOSE=cd .docker/ && docker-compose
DOTNET_EF=dotnet ef
DOTNET=dotnet
DATABASE_PROJECT=MessageHub.Infrastructure

### Database
install-db: db-migrate

db-diff: ## Create database migration. Needs $NAME variable for migration name
	$(DOTNET_EF) migrations add --project=$(DATABASE_PROJECT) $(NAME)

db-migrate: ## Update database with current migrations not processed
	$(DOTNET_EF) database update --project=$(DATABASE_PROJECT)

.PHONY: install-db db-diff db-migrate

### Docker
docker-start: ## Start container.
	$(COMPOSE) start

docker-up: ## Start or restart all the docker services
	$(COMPOSE) up -d

docker-down: ## Stop all the docker services
	$(COMPOSE) down

docker-stop: ## Stop existing docker environment
	$(COMPOSE) stop

docker-rebuild: ## Rebuild docker environment
	$(COMPOSE) build --no-cache
	$(COMPOSE) up -d --build --force-recreate

docker-logs: ## Containers logs
	$(COMPOSE) logs -f

docker-restart-dotnet: ## Restart dotnet container.
	$(COMPOSE) restart dotnet

docker-bash: ## Launch a shell in dotnet container
	$(COMPOSE) exec dotnet bash

.PHONY: docker-start docker-up docker-down docker-stop docker-rebuild docker-logs  docker-restart-dotnet docker-bash