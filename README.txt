* Lembrar de usar Header nos métodos Create e Post => application/json

Como foi dado no exemplo, as Routes ficaram:

https://localhost:44355/api/category/{actionName}/{?id}   => CategoriaController
https://localhost:44355/api/product{actionName}/{?id}   => ProdutoController

Action names: Get, Create, Edit, Delete