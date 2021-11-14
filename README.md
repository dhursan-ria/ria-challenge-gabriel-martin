# ria-challenge-gabriel-martin

Things to improve:
* add view models/DTOs (that will be used in the API layer) with mappers
* use either in memory DB or dedicated testing DB for integration tests
* more tests to be added

Notes:
* BookAuthor entity was not added because EF Core 6(5+) does not need it anymore: https://docs.microsoft.com/en-us/ef/core/modeling/relationships?tabs=fluent-api%2Cfluent-api-simple-key%2Csimple-key#join-entity-type-configuration
* The migrations were run using the CLI, and not in the application startup