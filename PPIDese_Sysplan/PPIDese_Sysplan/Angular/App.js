//define aplicação angular e o controller
var app = angular.module("clienteApp", []);
//registra o controller e cria a função para obter os dados do Controlador MVC
app.controller("clienteCtrl", function ($scope, $http) {
    $http.get('/home/GetTodosClientes/')
    .success(function (result) {
        $scope.clientes = result;
    })
    .error(function (data) {
        console.log(data);
    });

    $scope.hoje = new Date();

    $scope.cliente = $scope.clientes;
    $scope.SelecionaCliente = function (cliente) {
        $scope.cliente = cliente;
    }

    //chama o  método AdicionarCliente do controlador
    $scope.IncluiCliente = function (cliente) {
        $http.post('/home/AdicionarCliente/', { cliente })
        .success(function (result) {
            $scope.clientes = result;
            delete $scope.cliente;
            $scope.TodosClientes();
    })
        .error(function (data) {
            console.log(data);
    });
    }

    //chama o  método AtualizarCliente do controlador
    $scope.AlteraCliente = function (cliente) {
        $http.post('/home/AtualizarCliente/', { cliente })
        .success(function (result) {
            $scope.clientes = result;
            $scope.TodosClientes();
        })
        .error(function (data) {
            console.log(data);
        });
    }

    //chama o  método DeletarCliente do controlador
    $scope.DeletaCliente = function (cliente) {
        $http.post('/home/DeletarCliente/', { cliente })
        .success(function (result) {
            $scope.clientes = result;
            $scope.TodosClientes();
        })
        .error(function (data) {
            console.log(data);
        });
    }

    //retorna todos os clientes
    $scope.TodosClientes = function () {
        $http.get('/home/GetTodosClientes/')
        .success(function (result) {
            $scope.clientes = result;
        })
        .error(function (data) {
            console.log(data);
        });
    }

});
