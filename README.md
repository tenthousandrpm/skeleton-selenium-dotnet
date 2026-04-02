# skeleton-selenium-dotnet

Skeleton UI test framework using Selenium and MSTest on .NET 8. Tests run against a remote Selenium hub inside Docker.

## Project structure

| File/Folder | What it is |
|---|---|
| `Dockerfile` | Builds the test image — installs .NET and compiles the project |
| `docker-compose.yml` | Starts a Chrome browser container and the test container, wires them together |
| `Tests/Tests.csproj` | Lists the NuGet packages the project depends on |
| `Tests/appsettings.json` | Configuration — base URL, browser, timeouts. Environment variables override these values |
| `Tests/Settings.cs` | Reads `appsettings.json` and environment variables and exposes them to tests |
| `Tests/SampleTest.cs` | One sample test — navigates to the base URL and checks the page title is not empty |
| `.devcontainer/devcontainer.json` | Dev container configuration for VS Code — includes Docker so you can run builds from inside it |

## Build and run

```bash
docker compose up --build
```

This starts Chrome, waits for it to be ready, then builds and runs the tests against it. Results print to the terminal.

## Configuration

To change the base URL or other settings without editing files, pass environment variables:

```bash
BASE_URL=https://your-site.com docker compose up --build
```
