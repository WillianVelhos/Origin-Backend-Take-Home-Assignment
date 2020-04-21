FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["RiskProfile.Web.Test/RiskProfile.Web.Test.csproj", "RiskProfile.Web.Test/"]
COPY ["RiskProfile.Web/RiskProfile.Web.csproj", "RiskProfile.Web/"]
COPY ["RiskProfile.Domain/RiskProfile.Domain.csproj", "RiskProfile.Domain/"]
RUN dotnet restore "RiskProfile.Web.Test/RiskProfile.Web.Test.csproj"
COPY . .
WORKDIR "/src/RiskProfile.Web.Test"

RUN dotnet test "RiskProfile.Web.Test.csproj" 