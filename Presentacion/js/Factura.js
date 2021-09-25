function pageLoad() {

}

function CalcularTotal(idElemento) {
    var cantidad, precio, total;
    var posicion_ = idElemento.lastIndexOf("_");
    let sumaTotal = 0;
    fila = idElemento.substr(posicion_ + 1);

    precio = $("[id*=txtPrecio_" + fila + "]").val();
    cantidad = $("[id*=txtCantidad_" + fila + "]").val();

    total = precio * cantidad;

    $("[id*=txtTotal_" + fila + "]").val(total);

    $("[id*=txtTotal_]").each(function () {

        sumaTotal += +$(this).val();
        //recorrer todos los y sacar valor
    });

    $("[id*=txtTotalSuperior]").val(sumaTotal);
}

function ValidarNumero(numero) {

    if (isNaN(numero)) {
        return false;
    }
    else {
        return true;
    }

}
