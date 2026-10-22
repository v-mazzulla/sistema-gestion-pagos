document.querySelector("#Dto_TipoPago").addEventListener('change', OpcionesXTipo);
document.querySelector("#formAlta").addEventListener('submit', validarDatos);


OpcionesXTipo();

function OpcionesXTipo() {
    let op = document.querySelector("#Dto_TipoPago").value;

    if (op == "recurrente") {
        document.querySelector("#recurrentediv").style.display = "block";
        document.querySelector("#unicodiv").style.display = "none";
    } else {

        document.querySelector("#recurrentediv").style.display = "none";
        document.querySelector("#unicodiv").style.display = "block";
    }

}

function validarDatos(evt) {

    evt.preventDefault();
    let fechaDesde = document.querySelector("#Dto_FechaDesde");
    let fechaHasta = document.querySelector("#Dto_FechaHasta");
    let fecha = document.querySelector("#Dto_Fecha");
    let nroRecibo = document.querySelector("#Dto_NroRecibo").value;
    let op = document.querySelector("#Dto_TipoPago").value;

    let html = "";

    if (op == "recurrente") {
        if (!(fechaDesde.value) || !(fechaHasta.value)) {
            html = '<p class="text-danger"> Ingrese ambas fechas </p>';
        } else {
            this.submit();
        }
    } else {
        if (!(fecha.value)) {
            html = '<p class="text-danger"> Ingrese una fecha </p>';
        } else if (!nroRecibo) {
            html = '<p class="text-danger"> Ingrese nro de recibo </p>';
        } else {
            this.submit();
        }
    }

    document.querySelector("#errorJS").innerHTML = html;


}