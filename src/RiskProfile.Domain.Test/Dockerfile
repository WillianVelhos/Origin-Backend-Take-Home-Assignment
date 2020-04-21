FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["RiskProfile.Domain.Test/RiskProfile.Domain.Test.csproj", "RiskProfile.Domain.Test/"]
COPY ["RiskProfile.Domain/RiskProfile.Domain.csproj", "RiskProfile.Domain/"]
RUN dotnet restore "RiskProfile.Domain.Test/RiskProfile.Domain.Test.csproj"
COPY . .
WORKDIR "/src/RiskProfile.Domain.Test"

RUN dotnet test "RiskProfile.Domain.Test.csproj" 