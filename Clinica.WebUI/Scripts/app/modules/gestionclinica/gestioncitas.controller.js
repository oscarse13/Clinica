(function () {
    'use strict';

    angular
        .module('app.gestioncitas')
        .controller('RegistroCitasController', RegistroCitasController);

    RegistroCitasController.$inject = ['$rootScope', '$scope', '$state', '$http'];
    function RegistroCitasController($rootScope, $scope, $state, $http) {
        $scope.currentUser = JSON.parse(localStorage.getItem('currentUser'));
        if (!$scope.currentUser) {
            $state.go('app.pages');
        }

        $('#mensaje').hide();
        $('#mensajeError').hide();
        $scope.apiUrl = 'http://localhost:2100/';
        $scope.formValido = false;
        $scope.listadoCitas = [];
        $scope.tiposCita = [];
        $scope.id = 0;
        $scope.pacienteId = 0;
        $scope.documento = '';
        $scope.nombres = '';
        $scope.fecha = '';
        $scope.tipoCita = '';
        $scope.sexo = 'M';
        $scope.edad = '';
        $scope.fecha = '';
        $scope.request = {};// your request parameters
        var headers = {
            // 'Authorization': 'Basic ' + btoa(username + ":" + password),
            'Access-Control-Allow-Origin': true,
            'Content-Type': 'application/json; charset=utf-8',
            "X-Requested-With": "XMLHttpRequest"
        }
        activate();


        $scope.consultarUsuario = function () {

            var url = $scope.apiUrl + 'api/GestionCitas/GetPaciente/' + $scope.documento;
            $http.get(url, $scope.request, { headers }).
                then(function (response) {
                    if (response.data) {
                        $scope.pacienteId = response.data.Id;
                        $scope.nombres = response.data.Nombre;
                        $scope.sexo = response.data.Sexo;
                        $scope.edad = response.data.Edad;
                    } else {
                        $scope.pacienteId = 0;
                        $scope.nombres = '';
                        $scope.sexo = '';
                        $scope.edad = 0;
                    }
                });

        }

        $scope.registrarCita = function () {
            var fechaActual = new Date(Date.now());
            var fechaCita = new Date($("#fecha").val());
            var diferencia = Math.abs(fechaActual - fechaCita) / 36e5;

            if (diferencia > 24 && fechaActual < fechaCita) {
                var tipoCita = $scope.tiposCita.find(x => x.id === $scope.tipoCita.id);
                var cita = {
                    Id: $scope.id,
                    PacienteId: $scope.pacienteId,
                    Paciente: { Id: $scope.pacienteId, Documento: $scope.documento, Nombre: $scope.nombres, Edad: $scope.edad, Sexo: $scope.sexo },
                    Fecha: $("#fecha").val(),
                    TipoCitaId: $scope.tipoCita.id,
                    TipoCita: { Id: $scope.tipoCita.id, Descripcion: tipoCita.name }
                };
                var url = $scope.apiUrl + 'api/GestionCitas/RegistrarCita/';
                $http.post(url, JSON.stringify(cita), { headers }).
                    then(function (response) {
                        if (response.data === "") {
                            $scope.limpiarCita();
                            mostrarmensaje('Cita registrada con éxito!');
                            cargarCitas();
                        }
                        else {
                            mostrarmensajeError(response.data);
                        }
                    });
            }else
                mostrarmensajeError('Las citas se deben agendar con mínimo 24 horas de antelación.');
        }

        $scope.editarCita = function (cita) {           
            $scope.id = cita.Id;
            $scope.documento = cita.Paciente.Documento;
            $scope.pacienteId = cita.Paciente.Id;
            $scope.nombres = cita.Paciente.Nombre;
            $scope.sexo = cita.Paciente.Sexo;
            $scope.edad = cita.Paciente.Edad;
            $("#fecha").val(new Date(cita.Fecha).toLocaleString('en-US'));
            $scope.tipoCita = $scope.tiposCita.find(x => x.id === cita.TipoCitaId);
            $scope.validarForm();
        }

        $scope.eliminarCita = function (cita) {
            var url = $scope.apiUrl + 'api/GestionCitas/EliminarCita/' + cita.Id;
            $http.delete(url, $scope.request, { headers }).
                then(function (response) {
                    if (response.data === "") {
                        mostrarmensaje('Cita eliminada con éxito!');
                        cargarCitas();
                    }
                    else {
                        mostrarmensajeError(response.data);
                    }
                });
        }

        $scope.limpiarCita = function (cita) {
            $scope.id = 0;
            $scope.documento = '';
            $scope.pacienteId = 0;
            $scope.nombres = '';
            $scope.sexo = '';
            $scope.edad = '';
            $scope.tipoCita = [];
            $("#fecha").val('');
            $scope.validarForm();
        }

        $scope.validarForm = function () {
            $scope.formValido = true;
            if ($("#fecha").val() == "" || $scope.tipoCita == "" || $scope.sexo == "") {
                $scope.formValido = false;
            }
        }
        ////////////////

        function mostrarmensaje(mensaje) {
            $('#textoMensaje').html("<strong'>Completado - </strong>" + mensaje);
            $("#mensaje").fadeTo(2000, 500).slideUp(2500, function () {
                $("mensaje").slideUp(2500);
            });
        }

        function mostrarmensajeError(mensaje) {
            $('#textoMensajeError').html("<strong'>Error - </strong>" + mensaje);
            $("#mensajeError").fadeTo(2000, 500).slideUp(2500, function () {
                $("mensajeError").slideUp(2500);
            });
        }

        function activate() {

            $('#datetimepicker1').datetimepicker();
            //Cargar listado de citas
            cargarCitas();

            //Cargar tipos de citas
            var url = $scope.apiUrl + 'api/GestionCitas/GetTipoCitas';
            $http.get(url, $scope.request, { headers }).
                then(function (response) {
                    if (response.data) {

                        for (var i = 0; i < response.data.length; i++) {
                            $scope.tiposCita.push({ name: response.data[i].Descripcion, id: response.data[i].Id });
                        }
                    } else {
                        $scope.tiposCita = [];
                    }
                });
        }

        function cargarCitas() {
            var url = $scope.apiUrl + 'api/GestionCitas/GetCitas';
            $http.get(url, $scope.request, { headers }).
                then(function (response) {
                    if (response.data) {
                        $scope.listadoCitas = response.data;
                    } else {
                        $scope.listadoCitas = [];
                    }
                });
        }

    }
})();