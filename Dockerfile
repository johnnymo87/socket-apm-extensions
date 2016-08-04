FROM microsoft/dotnet:latest
COPY . /app

RUN dotnet restore /app
RUN dotnet build /app

CMD bash
