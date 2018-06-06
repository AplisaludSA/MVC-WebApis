
$(function () {
     var tabla = $("#tblPersonas").DataTable({
        language: {
            lengthMenu: "Mostrar _MENU_ Registros",
            zeroRecords: "No se pudo encontrar registros",
            info: "Mostrando _PAGE_ de _PAGES_",
            infoEmpty: "Sin Registros Disponbles",
            infoFiltered: "(Filtrado de _MAX_ Registros)",
            decimal: ".",
            thousands: ",",
            search: "Busqueda:",
            paginate: {
                first: "Primer",
                last: "Ultimo",
                next: "Siguiente",
                previous: "Anterior"
            }
        },
        columnDefs: [
            { targets: [0], visible: false, searchable: false }
        ],
        columns: [
                { 'data': 'IdPersona' },
                { 'data': 'Documento' },
                { 'data': 'Nombre' },
                { 'data': 'Apellido' },
                { 'data': 'Fecha_nacimiento' },
                { 'data': 'Telefono' },
                { 'data': 'Opciones' }
        ],
    });

    $("#btnRegresar").click(() => location.href = "./Home/");
    $("#btnNuevo").click(() => location.href = "./Persona/Create");
    //$("#btnEliminar").click(() => location.href = "./Persona/Delete");
    $("#tblPersonas tbody").on('click', '.btn-primary', function () {
        let tr = $(this).closest('tr');
        let id = tabla.row(tr).data().IdPersona;
        location.href = "./Persona/Edit/" + id;
    });

    $("#tblPersonas tbody").on('click', '.btn-danger', function () {
        swal({
            title: 'Esta Seguro?',
            text: "Desea Eliminar Este Elemento?",
            type: 'warning',
            showCancelButton: true,
            cancelButtonText: 'Cancelar',
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Aceptar'
        }).then((result) => {
            if (result.dismiss !== swal.DismissReason.cancel) {
                let tr = $(this).closest('tr');
                let id = tabla.row(tr).data().IdPersona;

                $.ajax({
                    url: "./Persona/DeleteConfirmed/",
                    type: 'POST',
                    cache: false,
                    data: { id: id },
                    success: function (res) {
                        swal(
                          'Eliminado!',
                          'Registro Eliminado.',
                          'success'
                        )
                        tabla.row(tr).remove().draw();
                    },
                    error: function (res) {
                        swal(
                          'Error!',
                          'Ocurrio Un Error.',
                          'error'
                        )
                    }
                });
            }         
        });
    });
});