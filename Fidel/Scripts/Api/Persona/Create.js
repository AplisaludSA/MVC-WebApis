
$(function () {
    $("#FECHA_NACIMIENTO").datepicker({
        format: "yyyy/mm/dd"
    });

    $("#btnGuardarPersona").click(function () {

        let Persona = { ID_PERSONA: $("#ID_PERSONA").val(), DOCUMENTO: $("#DOCUMENTO").val(), NOMBRE: $("#NOMBRE").val(), APELLIDO: $("#APELLIDO").val(), FECHA_NACIMIENTO: $("#FECHA_NACIMIENTO").val(), TELEFONO: $("#TELEFONO").val(), GRUPO_FAMILIAR: registrosNuevos }
        $.ajax({
            url: "/Persona/Create",
            type: 'POST',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(Persona),
            cache: false,
            success: function (res) {
                if (res.success) {
                    /*guardarGrupo()
                    .done(function (res) {
                        console.log(res);
                    })
                    .fail(function (error) {
                        console.log(res);
                    });*/
                }
            }
        });
    });
})