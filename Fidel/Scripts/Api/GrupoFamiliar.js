$(".title-action").append('<button type="button" class="btn btn-primary" data-toggle="modal" id="btnModalGrupo" title="Grupo Familiar"> <i class="fa fa-users"></i></button>');
let tblGrupo, registrosNuevos = [], registrosEliminar = [];

function guardarGrupo() {
    var promesa = $.Deferred();
    if (registrosNuevos.length > 0)
        $.ajax({
            url: "/service/grupoFamiliar",
            type: 'POST',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(registrosNuevos),
            cache: false,
            success: function (res) {
                if (res.success) promesa.resolve(res);
                else promesa.reject(res);
            },
            error: function (res) {
                promesa.reject(res);
            }
        });
    else promesa.resolve(true);
    return promesa;
}

function EliminarGrupo() {
    var promesa = $.Deferred();
    if (registrosEliminar.length > 0)
        $.ajax({
            url: "/service/grupoFamiliar",
            type: 'DELETE',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(registrosEliminar),
            cache: false,
            success: function (res) {
                if (res.success) promesa.resolve(res);
                else promesa.reject(res);
            },
            error: function (res) {
                promesa.reject(res);
            }
        });
    else promesa.resolve(true);
    return promesa;
}

function ValidarRegistros() {
    $.each(tblGrupo.rows().data(), (i, v) => { if (v.ID_GRUPO_FAMILIAR == 0) registrosNuevos.push(v); })
}
function CleanInputs() {
    $("#Parentesco_Grupo, #Documento_Grupo, #Nombre_Grupo, #Apellido_Grupo").val("")
}

$(function () {
    /*$.getJSON("/service/grupoFamiliar", {id:1}).complete(function (res) {
        tblGrupo.rows.add(res.responseJSON).draw();
    });
    */
    $.ajax({
        url: "/Parentesco/GetListParentesco/",
        type: 'POST',
        dataType: "json",
        cache: false,
        success: function (res) {
            let html = "";
            if (res.success)
                $.each(res.data, (i, v) => html += `<option value="${v.id}">${v.nombre}</option>`)
            $("#Parentesco_Grupo").append(html);
        }
    });

    tblGrupo = $("#tblGrupoFamiliar").DataTable({
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
            { targets: [0, 1], visible: false, searchable: false }
        ],
        columns: [
                { 'data': 'ID_GRUPO_FAMILIAR' },
                { 'data': 'ID_PARENTESCO' },
                { 'data': 'PARENTESCO' },
                { 'data': 'DOCUMENTO' },
                { 'data': 'NOMBRE' },
                { 'data': 'APELLIDO' },
                { 'data': 'Opciones', render: function (data, type, row) { return '<button class="btn btn-danger"><i class="fa fa-trash"></i></button>'; } },
        ],
    });
    $("#tblGrupoFamiliar tbody").on('click', '.btn-danger', function () {
        let tr = $(this).closest('tr');
        let data = tblGrupo.row(tr).data();
        if (data.ID_GRUPO_FAMILIAR != 0) registrosEliminar.push(data.ID_GRUPO_FAMILIAR);
        tblGrupo.row(tr).remove().draw();
    });

    $("#btnModalGrupo").click(() => $("#DlgGrupo").modal({ backdrop: 'static' }));
    $("#btnCleanGrupo").click(() => CleanInputs());

    $("#btnAddGrupo").click(function () {
        let parentesco = $("#Parentesco_Grupo").val();
        let documento = $("#Documento_Grupo").val();
        let nombre = $("#Nombre_Grupo").val();
        let apellido = $("#Apellido_Grupo").val();

        if ($.trim(parentesco).length == 0 || $.trim(documento).length == 0 || $.trim(nombre).length == 0 || $.trim(apellido).length == 0) return;

        let Familiar = { ID_GRUPO_FAMILIAR: 0, ID_PARENTESCO: parentesco, PARENTESCO: $("#Parentesco_Grupo :selected").text(), DOCUMENTO: documento, NOMBRE: nombre, APELLIDO: apellido, ID_PERSONA: $("#ID_PERSONA").val() };
        tblGrupo.row.add(Familiar).draw();
        registrosNuevos.push(Familiar)
        CleanInputs()
    });
});

