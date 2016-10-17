(function ($) {
    "use strict";

    var app = (function ($) {

        var _private = {};
        var $public = {};

        // Private
        _private.ConfigurarAjax = function () {
            $(document).ajaxStart(function () {
                    NProgress.start();
                });
            $(document).ajaxStop(function () {
                    NProgress.done();
                });
            $.ajaxSetup({ cache: false });
        };

        _private.ConfigurarChosen = function () {
            $(function() {
                $(".chosen-select").chosen({ no_results_text: "Nada encontrado", width: "100%" });
            });
        };

        _private.ConfigurarDraw = function () {
            L.drawLocal.draw.handlers.marker.tooltip.start = "Click no mapa para inserir o local da ocorrência";
            L.drawLocal.draw.toolbar.buttons.marker = "Insira o local da ocorrência";
            L.drawLocal.edit.toolbar.buttons.edit = "Editar";
            L.drawLocal.edit.toolbar.buttons.remove = "Remover";
            L.Icon.Default.imagePath = _private.url + "/images";
        };

        _private.ConfigurarDateTimePicker = function () {
           $(function() {
               $("#datetimepicker1").datetimepicker({
                   locale: 'pt-br'
               });
           });
        };

        _private.ConfigurarBotaoEdicao = function () {
            $("#sidewrapper").on("click", "#btnedit", function () {
                $("form input[disabled]").removeAttr("disabled");
            });
        };

        _private.OnDrawDeleted = function(event) {

            _private.mapa.removeLayer(_private.drawItens);

            var drawItens = new L.FeatureGroup();
            _private.mapa.addLayer(drawItens);

            var drawControl = new L.Control.Draw({
                draw: {
                    rectangle: false,
                    polyline: false,
                    polygon: false,
                    circle: false,
                    marker: true
                },
                edit: {
                    featureGroup: drawItens,
                    remove: true
                }
            });

            _private.mapa.removeControl(_private.drawControl);

            _private.drawControl = drawControl;
            _private.drawItens = drawItens;

            _private.mapa.addControl(drawControl);
            _private.TraduzirDraw();

            $("#Latitude").val("");
            $("#Longitude").val("");
        };

        _private.OnDrawCreated = function(event) {

            var tipo = event.layerType;
            var layer = event.layer;

            if (tipo === "marker") {

                $("#Latitude").val(layer._latlng.lat);
                $("#Longitude").val(layer._latlng.lng);

                _private.mapa.removeLayer(_private.drawItens);

                var drawItens = new L.FeatureGroup();
                _private.mapa.addLayer(drawItens);

                var drawControl = new L.Control.Draw({
                    draw: {
                        rectangle: false,
                        polyline: false,
                        polygon: false,
                        circle: false,
                        marker: false
                    },
                    edit: {
                        featureGroup: drawItens,
                        remove: true
                    }
                });

                _private.mapa.removeControl(_private.drawControl);

                _private.drawControl = drawControl;
                _private.drawItens = drawItens;

                _private.mapa.addControl(drawControl);
                _private.ConfigurarDraw();
            }

            drawItens.addLayer(layer);
        };

        _private.OnDrawEdited = function(event) {

            var layers = event.layers;
            layers.eachLayer(function(layer) {
                if (layer instanceof L.Marker) {
                    $("#Latitude").val(layer._latlng.lat);
                    $("#Longitude").val(layer._latlng.lng);
                }
            });
        };

        _private.IniciarControlesEdicao = function () {

            //debugger;
            //var kmarker = L.Icon.extend({
            //    iconUrl: _private.url + '/content/karellen/img/robbery.png',
            //    iconSize: [32, 32],
            //    iconAnchor: [28, 28],
            //    popupAnchor: [0, -34]
            //});

            var drawItens = new L.FeatureGroup();
            _private.mapa.addLayer(drawItens);

            var drawControl = new L.Control.Draw({
                draw: {
                    rectangle: false,
                    polyline: false,
                    polygon: false,
                    circle: false,
                    marker: true
                },
                edit: {
                    featureGroup: drawItens,
                    remove: true
                }
            });
            _private.drawControl = drawControl;
            _private.drawItens = drawItens;

            _private.mapa.addControl(drawControl);
            _private.ConfigurarDraw();
        };

        $public.Url = function(url) {
            return _private.url;
        }

        $public.SuportaAjax = function () {
            return window.history.length > 0;
        };

        $public.Init = function (url) {

            _private.url = url;
            _private.ConfigurarAjax();
            _private.ConfigurarChosen();
            _private.ConfigurarBotaoEdicao();
        };

        $public.GetGeoJson = function (local) {
            var locations = L.mapbox.featureLayer().addTo(_private.mapa); // Pega a feature layer. Acredito que somente exista 1 feature layer

            locations.loadURL(_private.url + local);
            return locations;
        };

        $public.IniciarMapa = function (elemento, coordenadas, zoom) {

            _private.elemento = elemento;
            _private.coordenadas = coordenadas;
            _private.zoom = zoom;

            L.mapbox.accessToken = 'pk.eyJ1Ijoia2tyaWNvIiwiYSI6ImNpc3l5bGtsNDBmcDQycGtoOTgwN3JtN3IifQ.Bc9quEp60HksbmydwEUJqw';
            _private.mapa = L.mapbox.map(elemento, "mapbox.light").setView(coordenadas, zoom);


            _private.mapa.on('ready', function() {
                new L.Control.MiniMap(L.mapbox.tileLayer('mapbox.streets')).addTo(_private.mapa);
            })
        };

        $public.DestruirMapa = function() {
            _private.mapa.off();
            _private.mapa.remove();
        };

        $public.HabilitarEdicao = function() {

            $public.DestruirMapa();
            $public.IniciarMapa(_private.elemento, _private.coordenadas, _private.zoom);

            _private.IniciarControlesEdicao();
            _private.mapa.on("draw:created", _private.OnDrawCreated);
            _private.mapa.on("draw:deleted", _private.OnDrawDeleted);
            _private.mapa.on("draw:edited", _private.OnDrawEdited);

            _private.ConfigurarChosen();
            _private.ConfigurarDraw();
            _private.ConfigurarDateTimePicker();
        };

        return $public;

    })($);

    window.App = app;
})(jQuery);