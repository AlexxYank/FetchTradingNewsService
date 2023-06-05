# FetchTradingNewsService

This solution provides components and services for fetching trading news, enriching the data, and storing it in a storage solution.

## Components/Services

- ApiService: Makes HTTP requests to fetch data from the trading news provider.
- DataService: Fetches data from the API, deserializes and maps it to entity classes, and stores the data in a database.
- NewsBackgroundService: Executes a trigger every hour to fetch and store trading news data in the background.

## Setup and Configuration

1. Configure the connection string in the `ConnectionString` class.
2. Set up the necessary dependencies and references in the projects.
3. Build and run the solution.

## Usage

1. The `ApiService` fetches data from the trading news provider at regular intervals.
2. The `DataService` fetches data from the API, enriches it, and stores it in the configured database.
3. The `NewsBackgroundService` runs in the background and triggers the `DataService` to fetch and store data periodically.

## Pros and Cons

Pros:

- Centralized data fetching and storage.
- Background service for regular data fetch.
- Enriches data and stores it in a separate service.

Cons:

- Limited focus, lacks API functionality.
- No direct access for clients to retrieve data.
- No built-in subscription management functionality.

## Dependencies

- HttpClient: Used for making HTTP requests.
- Entity Framework Core: Used for database operations.

## Contributing

Contributions to this solution are welcome. If you encounter any issues or have suggestions, please open an issue or submit a pull request.


