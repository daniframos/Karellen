$(function () {
    if (App.SuportaAjax()) {
        $(document).pjax('[data-pjax] a, a[data-pjax]', '#sidewrapper',
        {
            fragment: "#sidewrapper"
        });


        $(document).on('pjax:end', function (xhr, options) {
            var elemento = xhr.relatedTarget;

            if (typeof(elemento) === "undefined")
                return;

            var fn = $(elemento).data("callback");
            App[fn]();
        })
    }
});