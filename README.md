# BookCatalog
## Catálogo de livros em RESTful Web API em .NET Core 5.0 e Reactjs para controle de livros

### Para rodar a aplicação, precisa estar com docker desktop instalado e funcionando e rodar os seguintes comandos:
- docker network create mongocatalog
- docker run -d --rm --name mongo -p 27017:27017 -v mongodbdata:/data/db -e MONGO_INITDB_ROOT_USERNAME=mongoadmin 
-e MONGO_INITDB_ROOT_PASSWORD=Pass#word1 --network=mongoparking mongo
- docker run -it --rm -p 8080:80 -e MongoDBSettings:Host=mongo -e MongoDBSettings:Password=Pass#word1 --network=mongocatalog hfvmarques/bookcatalog:v6
- Ainda estou descobrindo uma forma de rodar o frontend em docker, por enquanto só localmente com o código e npm start

Talvez dê alguns problemas de timeout quando rodar o comando do mongo, mas é só rodar novamente que ele retoma de onde parou o download;

A aplicação vai rodar em http://localhost:8080/books;

### Endpoints:

- GET /books : retorna todos os "livros", utilizado na página inicial para listagem do catálogo;
- GET /books/id : retorna um livro a partir do id, no formato { "id": "ae104ce6-d8eb-4401-a432-261fc6a56658", "title": "Adams Obvio", "author": "Robert R. Updegraff", "publishingCompany": "Faro Editorial", "publicationYear": 2015, "edition": 3, "subject": "crônicas adultas", "bookType": "Fisico", "borrowed": "Não" }
- GET /books?subject=assunto : retorna todos os livros que possuem o assunto pesquisado;
- POST /books : insere um novo livro na lista, no mesmo formato informado anteriormente no método get /books/id;
- PUT /books/id : permite editar qualquer atributo do livro, exceto id;
- GET /health/live : verifica a saúde da aplicação;
- GET /health/ready : verifica a saúde do mongodb;
- DELETE /books/id : deleta o livro a partir do id informado;

### Observações:

#### Possuo um backlog registrado em tarefa para novas funcionalidades, por enquanto são as seguintes:
- Criar uma entidade para empréstimos, com um controller e um repositório, pois hoje a propriedade empréstimo no livro está apenas aceitando qualquer string;
- Criar uma busca por tipo de livro, digital ou físico;
- Implementar api de busca do google para pesquisar o livro;

### Foram construídos 7 testes unitários (pretendo criar outros), para testá-los é necessário instalar a extensão .NET Core Test Explorer no VS Code:

- GetBookAsync_WithUnexistingBook_ReturnsNotFound;
- GetBookAsync_WithExistingBook_ReturnsExpectedBook;
- GetBooksAsync_WithExistingBooks_ReturnsAllBooks;
- GetBooksAsync_WithMatchingBooks_ReturnsMatchingBooks;
- CreateBookAsync_WithBookToCreate_ReturnsCreatedBook;
- UpdateBookAsync_WithExistingBook_ReturnsNoContent;
- DeleteBookAsync_WithExistingBook_ReturnsNoContent;
