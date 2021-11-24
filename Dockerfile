FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app/BookCatalog.Api
COPY ["BookCatalog.Api.csproj", "./"]
RUN dotnet restore "BookCatalog.Api.csproj"
COPY . .
RUN dotnet publish "BookCatalog.Api.csproj" -c Release -o /app/publish

FROM node:14-alpine
ENV NODE_ENV=production
WORKDIR /usr/src/app
COPY ["package.json", "package-lock.json*", "npm-shrinkwrap.json*", "./"]
RUN npm install --production --silent && mv node_modules ../
COPY . .
EXPOSE 3000
RUN chown -R node /usr/src/app
USER node
CMD ["npm", "start"]

FROM base AS final
WORKDIR /BookCatalog.Api/app
COPY --from=build /app/publish .
COPY --from=build-node /usr/src/app/build ./usr/src/app/build
CMD ASPNETCORE_URLS=http://*:$PORT dotnet BookCatalog.Api.dll




