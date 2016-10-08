$(function () {

    if (App.SuportaAjax()) {
        App.IniciarMapa("mapa", [-15.64511, -47.78214], 13);

        App.GetGeoJson("/ocorrencia/coordenadas", function (data, res, mapa) {
            debugger;
        });
    }
});