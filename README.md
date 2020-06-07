# NumberSortingAPI
## 1. Set-up
1. Clone the repository
2. Start the API from the IDE or by using `dotnet run` command in terminal

## 2. Usage
### 2.1 Using Postman
First, make sure SSL certificate verification option is turned off in settings.
- **POST**
  1. Create a new POST request and put `https://localhost:5001/api/numbers/` in the request URL field.
  2. In the request body, select `raw` and `Text` options.
  3. Inside the text box, enter a line of numbers to be sorted, separated by whitespace. E.g. `2 1 -2 55 0`
  3. Hit SEND
- **GET**
  1. Create a new GET request and put `https://localhost:5001/api/numbers/` in the request URL field.
  2. Hit SEND

### 2.2 Using Curl
- **POST**
 Inside the terminal, run `curl -k -H "Content-Type: text/plain" --data "<numbers>" https://localhost:5001/api/numbers` command, replacing `<numbers>` with a line of numbers, separated by whitespace. E.g. `"5 2 1 0 -6 17"`

- **GET**
 Inside the terminal, run `curl -k https://localhost:5001/api/numbers` command.
