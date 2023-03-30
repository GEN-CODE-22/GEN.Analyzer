function GetCbo(TipoCatalogo, IdCbo) {
    $.ajax({
        url: "/Catalogos/JsonLstCatalog",
        type: 'POST',
        dataType: 'json',
        data: JSON.stringify({ TipoCatalogo: TipoCatalogo }),
        contentType: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            var result = JSON.parse(data);
            $("#" + IdCbo).html("");
            $("#" + IdCbo).append("<option>---Seleccionar---</option>");
            $.each(result, function (i, item) {
                $("#" + IdCbo).append("<option data-tokens=" + item.Id + " value=" + item.Id + ">" + item.Nombre + "</option>");
            });

            if (IdCbo.includes("selP")) {
                $("#" + IdCbo).selectpicker('refresh');
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            if (XMLHttpRequest.status === 401) {
                window.location = "/Login/Login";
            }
            alert(errorThrown);
        }
    });
}

function SetId(cbo, IdHidden) {
    var IdNew = $(cbo).val();
    $("#" + IdHidden).val(IdNew);
}