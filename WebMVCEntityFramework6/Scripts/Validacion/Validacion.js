var app = angular.module("MyApp", []);

app.controller("MyController", function ($scope, $http, $window) {

    $scope.ValidarAngular = function () {

        var regexp = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
        //var re = new RegExp(regexp);
        var textEmail = regexp.test($scope.AngEmail);

        if ($scope.AngNumero != null && $scope.AngNumero != ""
            && $scope.AngDecimal != null && $scope.AngDecimal != ""
            && $scope.AngSoloLetra != null && $scope.AngSoloLetra != ""
            && textEmail)
        {
            return false;
        }
        else {
            return true;
        }
    };

    $scope.Guardar = function () {
        MessageSuccess("Titulo de mi mensaje", "Se guardo correctamente el formulario.");
        MessageDanger("Titulo de mi mensaje", "Se guardo correctamente el formulario.");
        MessageInfo("Titulo de mi mensaje", "Se guardo correctamente el formulario.");
    };


    $(function ()
    {
        //VALIDACION SOLO LETRAS
        $('#txtSoloLetra').keydown(function (e) {
            if (e.shiftKey || e.ctrlKey || e.altKey) {
                e.preventDefault();
            } else {
                var key = e.keyCode;
                if (!((key == 8) || (key == 32) || (key == 46) || (key >= 35 && key <= 40) || (key >= 65 && key <= 90))) {
                    e.preventDefault();
                }
            }
        });

        //VALIDACION DECIMAL
        $("#txtDecimal").keydown(function (event) {
            if (event.shiftKey == true) {
                event.preventDefault();
            }

            if ((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode >= 96 && event.keyCode <= 105) || event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 37 || event.keyCode == 39 || event.keyCode == 46 || event.keyCode == 190) {

            } else {
                event.preventDefault();
            }

            if ($(this).val().indexOf('.') !== -1 && event.keyCode == 190)
                event.preventDefault();

        });

    });


    //NOTIFICACIONES
    function MessageInfo(titulo, message) {
        $.notify({
            // options
            icon: 'fa fa-info-circle fa-lg',
            title: "<span class='title-notify'><strong>" + titulo + "</strong></span><br/>",
            message: "<span class='message-notify'>" + message + "</span><br/>"
        }, {
                // settings
                type: 'info',
                delay: 8000
            });
    }

    function MessageSuccess(titulo, message) {
        $.notify({
            // options
            icon: 'fa fa-check-circle fa-lg',
            title: "<span class='title-notify'><strong>" + titulo + "</strong></span><br/>",
            message: "<span class='message-notify'>" + message + "</span><br/>"
        }, {
                // settings
                type: 'success',
                delay: 8000
            });
    }

    function MessageDanger(titulo, message) {
        $.notify({
            // options
            icon: 'fa fa-window-close fa-lg',
            title: "<span class='title-notify'><strong>" + titulo + "</strong></span><br/>",
            message: "<span class='message-notify'>" + message + "</span><br/>"
        }, {
                // settings
                type: 'danger',
                delay: 8000
            });
    }


});