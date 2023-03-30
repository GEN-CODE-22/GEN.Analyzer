function mensajeAlerta(titulo, mensaje)
{
    Swal.fire({
        title: titulo,
        text:mensaje,
        icon: 'warning',
        // showCancelButton: true,
        confirmButtonColor: '#3085d6',
        //cancelButtonColor: '#d33',
        confirmButtonText: 'OK'
    }).then((result) => {

        if (result.isConfirmed) {

                                       
    }
})
}

function mensajeExitoso(titulo, mensaje, icon)
{
  
    Swal.fire({
        position: 'top',
        icon: icon,
        text:mensaje,
        title: titulo,
        showConfirmButton: false,
        timer: 2000
    })
}
function mensajeTimer(titulo, mensaje, icon)
{
  
    Swal.fire({
        position: 'top',
        icon: icon,
        text:mensaje,
        title: titulo,
        showConfirmButton: false,
        timer: 2000
    })
}

function mensajeInfo(titulo, mensaje)
{
    Swal.fire({
        title: titulo,
        text:mensaje,
        icon: 'info',
        // showCancelButton: true,
        confirmButtonColor: '#3085d6',
        //cancelButtonColor: '#d33',
        confirmButtonText: 'OK'
    }).then((result) => {

        if (result.isConfirmed) {

                                       
    }
})
}
function mensajeSweet(titulo, mensaje, icon)
{
    Swal.fire({
        title: titulo,
        text:mensaje,
        icon: icon,
        // showCancelButton: true,
        confirmButtonColor: '#3085d6',
        //cancelButtonColor: '#d33',
        confirmButtonText: 'OK'
    }).then((result) => {

        if (result.isConfirmed) {

                                       
    }
})
}


