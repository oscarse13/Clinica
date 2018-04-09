(function () {
    'use strict';

    angular
        .module('app.dashboard')
        .controller('DashboardV2Controller', DashboardV2Controller);

    DashboardV2Controller.$inject = ['$rootScope', '$scope', '$state'];
    function DashboardV2Controller($rootScope, $scope, $state) {
        var vm = this;
        vm.subcatergoria = 'Lectura de Correos';
        vm.data = [
            ["Administrativos TI", "Administrativos", "Lectura de Correos"],
            ["Administrativos TI", "Administrativos", "Actividades Corporativas"],
            ["Administrativos TI", "Administrativos", "Vacaciones y Licencias Remuneradas"],
            ["Administrativos TI", "Administrativos", "Tiempo para t�"],
            ["Administrativos TI", "Administrativos", "Clases"],
            ["Administrativos TI", "Administrativos", "Incapacidades"],
            ["Administrativos TI", "Administrativos", "Permisos"],
            ["Administrativos TI", "Administrativos", "Pausas activas"],
            ["Administrativos TI", "Administrativos", "Reuniones de Trabajo Analistas"],
            ["Administrativos TI", "Administrativos", "Gesti�n de vi�ticos en I-viajes"],
            ["Administrativos TI", "Administrativos", "Desplazamientos en funci�n de sus labores"],
            ["Administrativos TI", "Administrativos", "Gesti�n de Jefes y Directivos"],
            ["Administrativos TI", "Administrativos", "Licencias no Remuneradas"],
            ["Administrativos TI", "Administrativos", "Compensatorio por Disponibilidad"],
            ["Crear valor", "Proyectos", "Idea"],
            ["Crear valor", "Proyectos", "Inicio"],
            ["Crear valor", "Proyectos", "Planeaci�n"],
            ["Crear valor", "Proyectos", "Ejecuci�n"],
            ["Crear valor", "Proyectos", "Seguimiento y control"],
            ["Crear valor", "Proyectos", "Cierre"],
            ["Crear valor", "Requerimientos", "Inicio"],
            ["Crear valor", "Requerimientos", "Planeaci�n"],
            ["Crear valor", "Requerimientos", "Ejecuci�n"],
            ["Crear valor", "Requerimientos", "Seguimiento y control"],
            ["Crear valor", "Requerimientos", "Cierre"],
            ["Entregar valor", "Operaci�n", "Instalaci�n, configuraci�n y afinaci�n de aplicaciones"],
            ["Entregar valor", "Operaci�n", "Procesos de Producci�n"],
            ["Entregar valor", "Operaci�n", "Gesti�n de Respaldos"],
            ["Entregar valor", "Operaci�n", "Mantenimiento y actualizaci�n a HW"],
            ["Entregar valor", "Operaci�n", "Mantenimiento y actualizaci�n a Bases de Datos"],
            ["Entregar valor", "Operaci�n", "Mantenimiento y actualizaci�n a Sistemas Operativos"],
            ["Entregar valor", "Operaci�n", "Gesti�n de Niveles de Servicio de TI"],
            ["Entregar valor", "Operaci�n", "Gesti�n de Seguridad"],
            ["Entregar valor", "Operaci�n", "Relaci�n con Entes de Control"],
            ["Entregar valor", "Operaci�n", "Administraci�n del CCP y CCA"],
            ["Entregar valor", "Operaci�n", "Gesti�n de eventos y monitoreo de disponibilidad"],
            ["Entregar valor", "Operaci�n", "Gesti�n de Cambios"],
            ["Entregar valor", "Operaci�n", "An�lisis y conclusi�n sobre estad�sticas"],
            ["Entregar valor", "Operaci�n", "Tareas proactivas de mantenimiento"],
            ["Entregar valor", "Operaci�n", "Gesti�n de la Calidad"],
            ["Entregar valor", "Operaci�n", "Administraci�n de Contratos con Proveedores"],
            ["Entregar valor", "Operaci�n", "Comit�s de Operaci�n"],
            ["Entregar valor", "Soporte", "Gesti�n de Solicitudes de Servicio"],
            ["Entregar valor", "Soporte", "Gesti�n de Incidentes"],
            ["Entregar valor", "Soporte", "Asesoria Usuarios"],
            ["Entregar valor", "Soporte", "Gesti�n de Problemas"],
            ["Entregar valor", "Soporte", "Gesti�n de Activos Tecnol�gicos (CMBD)"],
            ["Gesti�n de TI", "Finanzas TI", "Administraci�n de facturas y �rdenes de compra"],
            ["Gesti�n de TI", "Finanzas TI", "Administraci�n CAPEX"],
            ["Gesti�n de TI", "Finanzas TI", "Administraci�n OPEX"],
            ["Gesti�n de TI", "Finanzas TI", "Adminstraci�n de Costos TI"],
            ["Gesti�n de TI", "Gobierno TI", "Administraci�n del Gobierno -Comit�s"],
            ["Gesti�n de TI", "Gobierno TI", "Gesti�n de Portafolio"],
            ["Gesti�n de TI", "Gobierno TI", "Estrategia TI"],
            ["Gesti�n de TI", "Gobierno TI", "Metodolog�as"],
            ["Gesti�n de TI", "Gobierno TI", "Indicadores de Gesti�n TI"],
            ["Gesti�n de TI", "Recursos Humanos TI", "Plan de Trabajo (Asignaci�n)"],
            ["Gesti�n de TI", "Recursos Humanos TI", "Gesti�n del Conocimiento"],
            ["Gesti�n de TI", "Recursos Humanos TI", "Gesti�n del desempe�o"],
            ["Gesti�n de TI", "Recursos Humanos TI", "Apoyo en la selecci�n"],
            ["Gesti�n de TI", "Recursos Humanos TI", "Grupos Primarios - Comit�s"]
        ];

        

        $scope.getPathInfo = function getPathInfo(subcategoria) {
            for (var index = 0; index < vm.data.length; index++) {
                if (vm.data[index][2] == subcategoria)
                    return vm.data[index][0] + " / " + vm.data[index][1];
            }
        };
     

        activate();

        ////////////////

        function activate() {
      
            // BAR STACKED
            // ----------------------------------- 
            vm.barStackedOptions = {
                series: {
                    stack: true,
                    bars: {
                        align: 'center',
                        lineWidth: 0,
                        show: true,
                        barWidth: 0.6,
                        fill: 0.9
                    }
                },
                grid: {
                    borderColor: '#eee',
                    borderWidth: 1,
                    hoverable: true,
                    backgroundColor: '#fcfcfc'
                },
                tooltip: true,
                tooltipOpts: {
                    content: function (label, x, y) { return x + ' : ' + y; }
                },
                xaxis: {
                    tickColor: '#fcfcfc',
                    mode: 'categories'
                },
                yaxis: {
                    min: 0,
                    max: 200, // optional: use it for a clear represetation
                    position: ($rootScope.app.layout.isRTL ? 'right' : 'left'),
                    tickColor: '#eee'
                },
                shadowSize: 0
            };

            // SPLINE
            // ----------------------------------- 

            vm.splineOptions = {
                series: {
                    lines: {
                        show: false
                    },
                    points: {
                        show: true,
                        radius: 4
                    },
                    splines: {
                        show: true,
                        tension: 0.4,
                        lineWidth: 1,
                        fill: 0.5
                    }
                },
                grid: {
                    borderColor: '#eee',
                    borderWidth: 1,
                    hoverable: true,
                    backgroundColor: '#fcfcfc'
                },
                tooltip: true,
                tooltipOpts: {
                    content: function (label, x, y) { return x + ' : ' + y; }
                },
                xaxis: {
                    tickColor: '#fcfcfc',
                    mode: 'categories'
                },
                yaxis: {
                    min: 0,
                    max: 150, // optional: use it for a clear represetation
                    tickColor: '#eee',
                    position: ($rootScope.app.layout.isRTL ? 'right' : 'left'),
                    tickFormatter: function (v) {
                        return v/* + ' visitors'*/;
                    }
                },
                shadowSize: 0
            };
        }
    }
})();