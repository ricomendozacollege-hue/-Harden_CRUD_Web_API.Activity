# Product API Lab
## Endpoint Reference & Status Codes
Below is a quick breakdown of our API endpoints, their expected success codes, and the error codes they return when something goes wrong.

| Method | Endpoint | Success Status | Error Status Codes | What it does |
| GET | /api/Product | 200 OK | 400, 500 | Fetches a paginated list of products packaged inside a clean data/meta envelope. |
| GET | /api/Product/{id} | 200 OK | 404, 500 | Finds a specific product by its ID, or throws a not-found exception if it doesn't exist. |
| POST | /api/Product | 201 Created | 400, 409, 500 | Creates a new product while running validation checks and preventing duplicate names. |
| PUT | /api/Product/{id} | 200 OK | 400, 404, 500 | Updates an existing product's details. |
| DELETE | /api/Product/{id} | 204 No Content | 404, 500 | Removes a product from the list by its ID. |