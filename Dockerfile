FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY . .
RUN dotnet publish -c Release -o out
CMD ["dotnet", "out/ArqMediatr.Application.dll"]