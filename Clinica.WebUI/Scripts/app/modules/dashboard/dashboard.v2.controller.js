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
            ["Administrativos TI", "Administrativos", "Tiempo para tí"],
            ["Administrativos TI", "Administrativos", "Clases"],
            ["Administrativos TI", "Administrativos", "Incapacidades"],
            ["Administrativos TI", "Administrativos", "Permisos"],
            ["Administrativos TI", "Administrativos", "Pausas activas"],
            ["Administrativos TI", "Administrativos", "Reuniones de Trabajo Analistas"],
            ["Administrativos TI", "Administrativos", "Gestión de viáticos en I-viajes"],
            ["Administrativos TI", "Administrativos", "Desplazamientos en función de sus labores"],
            ["Administrativos TI", "Administrativos", "Gestión de Jefes y Directivos"],
            ["Administrativos TI", "Administrativos", "Licencias no Remuneradas"],
            ["Administrativos TI", "Administrativos", "Compensatorio por Disponibilidad"],
            ["Crear valor", "Proyectos", "Idea"],
            ["Crear valor", "Proyectos", "Inicio"],
            ["Crear valor", "Proyectos", "Planeación"],
            ["Crear valor", "Proyectos", "Ejecución"],
            ["Crear valor", "Proyectos", "Seguimiento y control"],
            ["Crear valor", "Proyectos", "Cierre"],
            ["Crear valor", "Requerimientos", "Inicio"],
            ["Crear valor", "Requerimientos", "Planeación"],
            ["Crear valor", "Requerimientos", "Ejecución"],
            ["Crear valor", "Requerimientos", "Seguimiento y control"],
            ["Crear valor", "Requerimientos", "Cierre"],
            ["Entregar valor", "Operación", "Instalación, configuración y afinación de aplicaciones"],
            ["Entregar valor", "Operación", "Procesos de Producción"],
            ["Entregar valor", "Operación", "Gestión de Respaldos"],
            ["Entregar valor", "Operación", "Mantenimiento y actualización a HW"],
            ["Entregar valor", "Operación", "Mantenimiento y actualización a Bases de Datos"],
            ["Entregar valor", "Operación", "Mantenimiento y actualización a Sistemas Operativos"],
            ["Entregar valor", "Operación", "Gestión de Niveles de Servicio de TI"],
            ["Entregar valor", "Operación", "Gestión de Seguridad"],
            ["Entregar valor", "Operación", "Relación con Entes de Control"],
            ["Entregar valor", "Operación", "Administración del CCP y CCA"],
            ["Entregar valor", "Operación", "Gestión de eventos y monitoreo de disponibilidad"],
            ["Entregar valor", "Operación", "Gestión de Cambios"],
            ["Entregar valor", "Operación", "Análisis y conclusión sobre estadísticas"],
            ["Entregar valor", "Operación", "Tareas proactivas de mantenimiento"],
            ["Entregar valor", "Operación", "Gestión de la Calidad"],
            ["Entregar valor", "Operación", "Administración de Contratos con Proveedores"],
            ["Entregar valor", "Operación", "Comités de Operación"],
            ["Entregar valor", "Soporte", "Gestión de Solicitudes de Servicio"],
            ["Entregar valor", "Soporte", "Gestión de Incidentes"],
            ["Entregar valor", "Soporte", "Asesoria Usuarios"],
            ["Entregar valor", "Soporte", "Gestión de Problemas"],
            ["Entregar valor", "Soporte", "Gestión de Activos Tecnológicos (CMBD)"],
            ["Gestión de TI", "Finanzas TI", "Administración de facturas y órdenes de compra"],
            ["Gestión de TI", "Finanzas TI", "Administración CAPEX"],
            ["Gestión de TI", "Finanzas TI", "Administración OPEX"],
            ["Gestión de TI", "Finanzas TI", "Adminstración de Costos TI"],
            ["Gestión de TI", "Gobierno TI", "Administración del Gobierno -Comités"],
            ["Gestión de TI", "Gobierno TI", "Gestión de Portafolio"],
            ["Gestión de TI", "Gobierno TI", "Estrategia TI"],
            ["Gestión de TI", "Gobierno TI", "Metodologías"],
            ["Gestión de TI", "Gobierno TI", "Indicadores de Gestión TI"],
            ["Gestión de TI", "Recursos Humanos TI", "Plan de Trabajo (Asignación)"],
            ["Gestión de TI", "Recursos Humanos TI", "Gestión del Conocimiento"],
            ["Gestión de TI", "Recursos Humanos TI", "Gestión del desempeño"],
            ["Gestión de TI", "Recursos Humanos TI", "Apoyo en la selección"],
            ["Gestión de TI", "Recursos Humanos TI", "Grupos Primarios - Comités"]
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