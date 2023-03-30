var dialogos = [];

function getPdf(pdfName)
{
    
        var req = new XMLHttpRequest();
        req.open("GET", "/PDF/" + pdfName + ".pdf", true);
        req.responseType = "blob";

        req.onload = function (event) {
            var blob = req.response;
            console.log(blob.size);
            var link = document.createElement('a');
            link.href = window.URL.createObjectURL(blob);
            //window.open(link.href+".pdf");
            window.open(link.href)
            //link.download = "Dossier_" + new Date() + ".pdf";
            //link.click();
        };

        req.send();


    
}

function cierraDialog()
{
    for (var i = 0; i < dialogos.length; i++) {
        dialogos[i].className = '';
        dialogos[i].close();
    }
    dialogos = [];

}

function muestraDialog(id)
{

    if (dialogos.length > 0)
    {
        cierraDialog();
    }
    var msg = document.getElementById(id);
    msg.className = 'card card-body ';
    msg.showModal();
    dialogos.push(msg);
}
function setFechas()
{
    var now = new Date();
    var day = ("0" + now.getDate()).slice(-2);
    var month = ("0" + (now.getMonth() + 1)).slice(-2);
    var today = now.getFullYear() + "-" + (month) + "-" + (day);
    $('input[type="date"]').val(today);
    
  
}
function imprimirDIV(contenido, seccion) {
    var ficha = document.getElementById(contenido);

    var ventanaImpresion = window.open(' ', 'popUp');

    // ventanaImpresion.document.write('<link rel="stylesheet" type="text/css" href="~/Styles/stilosImpresion.css" media="print">');

    ventanaImpresion.document.write('<html>');
    ventanaImpresion.document.write('<body>');
    if (localStorage.getItem("empresa") == 'PLUS')
        ventanaImpresion.document.write('<img src="/Images/TEMAS/PLUS/logo_plus.png" style="width:150px;"');
    else
        ventanaImpresion.document.write('<img src="/Images/logo.png" style="width:150px;"');
    ventanaImpresion.document.write('<center>');
    ventanaImpresion.document.write('<div id="cuerpo">');
    ventanaImpresion.document.write(ficha.innerHTML);
    ventanaImpresion.document.write('</div>');
    ventanaImpresion.document.write('</center>');

    ventanaImpresion.document.write('<style type="text/css">');
    switch (seccion) {
        case "PrimerUltimoServicio":
            ventanaImpresion.document.write('@@media print{ body { } img {display: inline;} .fi-content {display: none}  img { position: fixed; top: 0; left: 2px;  width: 150px; height: 75px;}  div.divContenedor { page-break-before: always;   page-break-inside: avoid; } button { display: none;}  .divContenedor { margin: 0mm 0mm 0mm 40mm; } #cuerpo { margin: 15mm 0mm 0mm 0mm; }  label {color: #2C5690; font-weight: bold;display: block; font-size: 20px } #logo {display: inline; position: fixed; top: 0; left: 2px;  width: 150px; height: 75px; }   }');
            break;
        case "promediosTiepmosServicios":
            ventanaImpresion.document.write('@@media print{ body { } img {display: inline; .fi-content {display: none} width: 100px; height: 50px;}   img { position: fixed; top: 0; left: 2px; }  div.contenedores { page-break-inside: avoid; } button { display: none;}  .contenedores { margin: 0mm 0mm 0mm 30mm; } #cuerpo { margin: 15mm 0mm 0mm 0mm; }  label {color: #2C5690; font-weight: bold;display: block; font-size: 20px } #infogral {display: inline; position: fixed; bottom: 0; opacity: 0.5; }   }');
            break;
        case "informacion":
            ventanaImpresion.document.write('@@media print{ body { } img {display: inline;} .fi-content {display: none}  img { position: fixed; top: 0; left: 2px;  width: 150px; height: 75px;}  .descGral {position: fixed; bottom: 0;  font-size: 15px;   } .divTblChoferes {page-break-inside: avoid;  } .graficas { page-break-after: always;   page-break-inside: avoid; } button { display: none;}  .graficas { margin: 25mm 0mm 0mm 0mm; }  .descGral {color: #2C5690; font-weight: bold;display: block; font-size: 20px;  opacity: 0.5; } #logo {display: inline; position: fixed; top: 0; left: 2px;  width: 150px; height: 75px; }   #promXchofer { overflow: visible; width: 100%}  }');
            break;
        case "porcPromChof":
            ventanaImpresion.document.write('@@media print{ body { }  img {display: inline;  margin-bottom: 5cm;} .fi-content {display: none} #encabezado{ position: fixed; bottom: 0; left: 1px;  opacity: 0.5; }  img { position: fixed; botton: 0; left: 1px;  width: 100px; height: 70px;}   .divTblChoferes {  page-break-inside: avoid; margin: 0mm 0mm 0mm 30mm; width: 100% } button { display: none;}   label {color: #2C5690; font-weight: bold;display: block; font-size: 15px;  } #logo {display: inline; position: fixed; top: 0; left: 2px;  width: 150px; height: 75px; }  #logo{ }}');
            break;
        case "gerencial":
            ventanaImpresion.document.write('@@media print{ body { } img {display: inline; margin-bottom: 5cm;} .fi-content {display: none} #fechaReporte {position: fixed; bottom: 0; rigth: 20px;  opacity: 0.5;} #EncabezadoReporteGerencial{ position: fixed; top: 0; left: 200px;  opacity: 0.5; }  img { position: fixed; botton: 0; left: 1px;  width: 150px; height: 70px;}  button { display: none;}   label {color: #2C5690; font-weight: bold;display: block; font-size: 20px;  } #logo {display: inline; position: fixed; top: 0; left: 2px;  width: 150px; height: 75px; }  #lblCancelaciones{  }');
            break;
    }

    ventanaImpresion.document.write('@@media print{     table tr:nth-child(even) { border:black 1px solid; } table tr:nth-child(odd) { background-color: #fff; border:black 1px solid;} table td {border:black 1px solid; }}');

    ventanaImpresion.document.write('</style>');
    ventanaImpresion.document.write('</body>');
    ventanaImpresion.document.write('</html>');


    ventanaImpresion.document.close();
    ventanaImpresion.print();
    ventanaImpresion.close();





}