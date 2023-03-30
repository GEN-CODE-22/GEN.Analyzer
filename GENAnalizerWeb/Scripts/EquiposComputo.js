var crd;
//Verifica si existe un equipo de computo con la ip encontrada
function ExisteEquipo()
{
    var settings = {
        "url": "http://localhost:7829/api/values/existEquipo",
        "method": "GET",
        "timeout": 0,
        
    };
    $.ajax(settings).done(function (response)
    {
        alert("Ayudanos a mejorar el servicio de soporte tecnico de Gas Express Nieto y compañias pertenesientes, completa el siguinete formulario y consede el permiso de tu ubicacion");
        if (response == 'NO')
        {
            window.open("/EquiposComputo/EquiposComputo");
        }
       
       
    });

}

function BuscaEquipo()
{
    //consultar las notas
    $.ajax({
        type: "GET",
        url: "/EquiposComputo/GetEquipo/",
        //data: { fechaI: fecha_ini, fechaF: fecha_fin, paramString1: findLectidDom },
        //datatype: "json",
        beforeSend: function () {

            //muestraDialog('cargando');
        },
        complete: function () {

        },
        success: function (data) {

            //alert(data);
            PrellenaCampos(data)

        },
        error: function (request, status, error) {
            alert(request+ status+ error);
        }
    });
}

function PrellenaCampos(data)
{
    var parser = new UAParser();
    var parser_info = parser.getResult();

    $('#SO_PC').val(parser_info.os.name+" "+parser_info.os.version);
    $('#ARQ_PC').val(parser_info.ua.split(';')[1]);

    //Optener posicion
    //optener posicion
    var options = {
        enableHighAccuracy: true,
        timeout: 5000,
        maximumAge: 0
    };

    function success(pos) {
         crd = pos.coords;

        console.log('Your current position is:');
        console.log('Latitude : ' + crd.latitude);
        console.log('Longitude: ' + crd.longitude);
        console.log('More or less ' + crd.accuracy + ' meters.');
        map.setCenter(new google.maps.LatLng(parseFloat(crd.latitude), parseFloat(crd.longitude)));
        var pointA = new google.maps.LatLng(parseFloat(crd.latitude), parseFloat(crd.longitude));
        var marker = new google.maps.Marker({
            position: pointA,
            //icon: urlImgCteDes,
            map: map,
            html:'',
            title: "Desface de:"+ crd.accuracy +" metros aproximadamente",
            draggable: true
        });
    };

    function error(err) {
        console.warn('ERROR(' + err.code + '): ' + err.message);
    };

    navigator.geolocation.getCurrentPosition(success, error, options);
    //fin de optener posicion
}


