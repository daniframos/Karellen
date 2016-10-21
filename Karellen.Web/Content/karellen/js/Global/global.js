(function ($) {
    "use strict";

    var app = (function ($) {

        var _private = {};
        var $public = {};

        // Private
        _private.mapaCarregado = function() {
            return typeof _private.mapa !== "undefined";
        };

        _private.configurarAjax = function () {
            $(document).ajaxStart(function () {
                    NProgress.start();
                });
            $(document).ajaxStop(function () {
                    NProgress.done();
                });
            $.ajaxSetup({ cache: false });
        };

        _private.configurarChosen = function () {
            $(function() {
                $(".chosen-select").chosen({ no_results_text: "Nada encontrado", width: "100%" });
            });
        };

        _private.configurarDraw = function () {
            L.drawLocal.draw.handlers.marker.tooltip.start = "Click no mapa para inserir o local da ocorrência";
            L.drawLocal.draw.toolbar.buttons.marker = "Insira o local da ocorrência";
            L.drawLocal.edit.toolbar.buttons.edit = "Editar";
            L.drawLocal.edit.toolbar.buttons.remove = "Remover";
            L.Icon.Default.imagePath = _private.url + "/images";
        };

        _private.configurarDateTimePicker = function () {
           $(function() {
               $("#datetimepicker1").datetimepicker({
                   locale: 'pt-br'
               });
           });
        };

        _private.configurarBotaoEdicao = function () {
            $("#sidewrapper").on("click", "#btnedit", function () {
                $("form input[disabled]").removeAttr("disabled");
            });
        };

        _private.onDrawDeleted = function(event) {

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

        _private.onDrawCreated = function(event) {

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
                _private.configurarDraw();
            }

            drawItens.addLayer(layer);
        };

        _private.onDrawEdited = function(event) {

            var layers = event.layers;
            layers.eachLayer(function(layer) {
                if (layer instanceof L.Marker) {
                    $("#Latitude").val(layer._latlng.lat);
                    $("#Longitude").val(layer._latlng.lng);
                }
            });
        };

        _private.configurarModal = function(event) {
            $(document).on('show.bs.modal', function (e) {
                if (typeof e.relatedTarget !== "undefined") {

                    var elemento = $(e.relatedTarget);
                    $(".myhidden").val(elemento.data("hidden"));
                    var titulo = elemento.siblings("h3").first().text();
                    $("#myModalLabel").text("Solucionar " + titulo +"?");
                }
            });
        };

        _private.iniciarControlesEdicao = function (marcador) {

            var drawItens = new L.FeatureGroup();

            if (typeof marcador !== "undefined") {
                drawItens.addLayer(marcador);
            }


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
            _private.configurarDraw();
        };

        _private.BuscarIdOcorrencia = function() {
            var url = window.location.pathname.split('/');
            var id = url[url.length - 1];

            return id;
        };

        _private.IniciarMiniMapa = function() {
            _private.mapa.on('ready', function () {
                new L.Control.MiniMap(L.mapbox.tileLayer('mapbox.streets')).addTo(_private.mapa);
            });
        }

        $public.Url = function() {
            return _private.url;
        };

        $public.SuportaAjax = function () {
            return window.history.length > 0;
        };

        $public.Init = function (url) {

            _private.url = url;
            _private.configurarAjax();
            _private.configurarChosen();
            _private.configurarBotaoEdicao();
            _private.configurarModal();
        };

        $public.GetGeoJson = function (local, callback) {
            var resultado = {};

            $.getJSON(_private.url + local, callback);
        };

        $public.IniciarMapa = function (elemento, coordenadas, zoom, tipo) {

            _private.elemento = elemento;
            _private.coordenadas = coordenadas;
            _private.zoom = zoom;

            if (typeof tipo === "undefined") {
                tipo = "mapbox.light";
            }
            
            L.mapbox.accessToken = 'pk.eyJ1Ijoia2tyaWNvIiwiYSI6ImNpc3l5bGtsNDBmcDQycGtoOTgwN3JtN3IifQ.Bc9quEp60HksbmydwEUJqw';
            _private.mapa = L.mapbox.map(elemento, tipo).setView(coordenadas, zoom);
            _private.IniciarMiniMapa();
        };

        $public.DestruirMapa = function() {
            _private.mapa.off();
            _private.mapa.remove();
        };

        $public.HabilitarEdicao = function() {

            _private.iniciarControlesEdicao();
            _private.mapa.on("draw:created", _private.onDrawCreated);
            _private.mapa.on("draw:deleted", _private.onDrawDeleted);
            _private.mapa.on("draw:edited", _private.onDrawEdited);
        };

        $public.NovaOcorrencia = function () {
            if (_private.mapaCarregado()) {
                $public.DestruirMapa();
            }

            $public.IniciarMapa("mapa", [-15.64511, -47.78214], 13, "mapbox.streets");
            $public.HabilitarEdicao();

            _private.configurarChosen();
            _private.configurarDraw();
            _private.configurarDateTimePicker();

            $("#DataAcontecimento").val(moment().format("DD/MM/YYYY HH:mm"));
        };

        $public.AddLayer = function(layer) {
            _private.mapa.addLayer(layer);
        };

        $public.ZoomPara = function (coordenadas, zoomNivel) {
            if (typeof zoomNivel !== "undefined") {
                _private.mapa.setView(coordenadas, zoomNivel);
                return;
            }
            _private.mapa.panTo(coordenadas);
        };

        $public.Detalhes = function () {

            if (_private.mapaCarregado()) {
                $public.DestruirMapa();
            }

            $public.IniciarMapa("mapa", [-15.64511, -47.78214], 13, "mapbox.streets");
            var layers = $public.GetGeoJson("/ocorrencia/coordenada/" + _private.BuscarIdOcorrencia());

            layers.on("ready", function() {
                layers.eachLayer(function (layer) {
                    var prop = layer.feature.properties;

                    var popup = '<h3>' + prop.Nome + '</h3>';
                    popup += '<div>' + prop.Detalhes + '</div>';

                    if (prop.Data) {
                        // Cria 
                        popup += '<br /><small class="quiet" style="text-align:center"><i class="fa fa-calendar" aria-hidden="true"></i>&nbsp' + prop.Data + '</small>';
                    }

                    layer.bindPopup(popup);

                    layer.openPopup();
                });
            });

            layers.on('layeradd', function (e) {

                var marker = e.layer;
                marker.setIcon(L.icon({
                    iconUrl: App.Url() + '/content/karellen/img/robbery.png', // load your own custom marker image here
                    iconSize: [32, 32],
                    iconAnchor: [28, 28],
                    popupAnchor: [0, -34]
                }));

            });
        };

        $public.Editar = function () {

            if (_private.mapaCarregado()) {
                $public.DestruirMapa();
            }

            $public.IniciarMapa("mapa", [$("#Latitude").val(), $("#Longitude").val()], 13, "mapbox.streets");
            _private.configurarChosen();
            _private.configurarDraw();
            var marker = new L.Marker([$("#Latitude").val(), $("#Longitude").val()]);

            _private.iniciarControlesEdicao(marker);
            _private.mapa.on("draw:created", _private.onDrawCreated);
            _private.mapa.on("draw:deleted", _private.onDrawDeleted);
            _private.mapa.on("draw:edited", _private.onDrawEdited);
        };

        return $public;

    })($);

    window.App = app;
})(jQuery);