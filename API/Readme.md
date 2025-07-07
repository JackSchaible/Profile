# Profile API – Minimal ASP.NET Core Serverless Backend

Welcome to the **Profile API**! This project is a modern, minimal ASP.NET Core Web API designed to run serverlessly on AWS Lambda, exposed via Amazon API Gateway. It powers the backend for my personal portfolio and projects, providing fast, scalable, and cost-effective APIs with zero server management.

---

## 🚀 Features

- **Minimal API**: Built with ASP.NET Core's latest minimal API syntax for simplicity and performance.
- **Serverless**: Deploys as a Lambda function, scaling automatically with demand.
- **API Gateway Integration**: Secure, public HTTP endpoints via Amazon API Gateway.
- **CI/CD Ready**: Designed for automated deployment with AWS and GitHub Actions.
- **CloudFormation Template**: Infrastructure-as-code for easy provisioning and updates.
- **Extensible**: Add new endpoints or business logic with minimal ceremony.

---

## 🛠️ Project Structure

- `src/API/` – Main ASP.NET Core Minimal API project
- `Controllers/` – Example and real API endpoints
- `serverless.template` – AWS SAM/CloudFormation template for Lambda & API Gateway
- `aws-lambda-tools-defaults.json` – Default deployment settings for AWS CLI/VS
- `Program.cs` – App entry point and Lambda hosting configuration
- `Profile.sln` – Visual Studio solution (now inside the `API/` folder)

---

## 🏗️ Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- AWS CLI configured with deploy permissions
- (Optional) Visual Studio 2022+ for IDE support

### Local Development

1. Clone the repo and open `API/Profile.sln` in Visual Studio or VS Code.

2. Run locally:

   ```sh
   cd API/src/API
   dotnet run
   ```

3. Access the API at `https://localhost:5001` (or the port shown in the console).

### Deploy to AWS Lambda

1. Install the AWS Lambda .NET CLI tools (if not already):

   ```sh
   dotnet tool install -g Amazon.Lambda.Tools
   ```

2. Deploy from the command line:

   ```sh
   cd API/src/API
   dotnet lambda deploy-serverless
   ```

3. Or, use **Publish to AWS Lambda** in Visual Studio.

---

## 📝 Example Endpoints

- `GET /api/hello` – Sample endpoint (see `Controllers/CalculatorController`)
- Add your own endpoints in the `Controllers/` folder or directly in `Program.cs` using minimal API syntax.

---

## 🤝 Contributing

Pull requests and suggestions are welcome! If you spot a bug or want to add a feature, open an issue or PR.

---

## 📄 License

MIT License. See [LICENSE](../LICENSE) for details.

---

## 👤 Author

**Jack S.**  
[Portfolio](https://your-portfolio-url.com) | [GitHub](https://github.com/your-github) | [LinkedIn](https://linkedin.com/in/your-linkedin)

---

_This project is part of my personal cloud-native portfolio stack. Built for learning, sharing, and real-world use._
