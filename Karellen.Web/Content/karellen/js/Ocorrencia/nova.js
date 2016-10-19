$(function() {
    if (App.SuportaAjax()) {
        debugger;
        var url = window.location.pathname.split('/');
        local = url[url.length - 1].toLowerCase();
        if (local === "nova") {
            App.NovaOcorrencia();
            $("#DataAcontecimento").val(moment().format("DD-MM-YYYY hh:mm"));
        } else {
            App.Editar();
        }
    };
});