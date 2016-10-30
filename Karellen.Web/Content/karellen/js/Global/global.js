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
        };

        _private.setActive = function(el) {
            var siblings = listings.getElementsByTagName('div');
            for (var i = 0; i < siblings.length; i++) {
                siblings[i].className = siblings[i].className
                    .replace(/active/, '')
                    .replace(/\s\s*$/, '');
            }

            el.className += ' active';
        };

        _private.index = function(data) {

            var json = data;
            var geoJson = L.geoJson(json);
            _private.markers = new L.MarkerClusterGroup();

            geoJson.eachLayer(function(layer) {
                var prop = layer.feature.properties;
                var popup = '<h3>' + prop.Nome + '</h3>';
                popup += '<div>' + prop.Detalhes + '</div>';

                var listing = listings.appendChild(document.createElement('div'));
                listing.className = 'item';

                listing.appendChild(document.createElement('h4'));
                var link = listing.childNodes[0].appendChild(document.createElement('a'));
                link.href = '#';
                link.className = 'title';

                link.innerHTML = prop.Nome;

                if (layer instanceof L.Marker) {

                    layer.setIcon(L.icon({
                        iconUrl: $public.Url() +
                            '/content/karellen/img/robbery.png', // load your own custom marker image here
                        iconSize: [32, 32],
                        iconAnchor: [28, 28],
                        popupAnchor: [0, -34]
                    }));
                }

                if (prop.Data) {
                    // Cria 
                    popup +=
                        '<br /><small class="quiet" style="text-align:center"><i class="fa fa-calendar" aria-hidden="true"></i>&nbsp' + prop.Data + '</small>';
                    popup += '<br /><a href="' +
                        $public.Url() +
                        "/ocorrencia/detalhes/" +
                        prop.Id +
                        '" type="button" data-title="Detalhes" data-pjax data-callback="Detalhes"' +
                        ' class="btn btn-primary btn-default btnsaibamais" style="color: white">Saiba mais</a>';
                }

                if (prop.UsuarioId !== null) {
                    popup += '<a href="' +
                        $public.Url() +
                        "/ocorrencia/editar/" +
                        prop.Id +
                        '" type="button" style="margin-left:1em; color:white;" data-title="Editar" data-pjax data-callback="Editar"' +
                        ' class="btn btn-primary btn-default btnsaibamais" style="color: white">' +
                        '<i class="fa fa-pencil" aria-hidden="true"></i> Editar</a>';

                    popup += '<button type="button" data-toggle="modal" data-hidden="' +
                        prop.Id +
                        '" data-target="#myModal" style="margin-left:1em; color:white;"' +
                        ' class="btn btn-primary btn-default btnsaibamais" style="color: white">' +
                        '<i class="fa fa-check" aria-hidden="true"></i> Solucionar</a>';

                    popup += '<button type="button" data-toggle="modal" data-hidden="' +
                        prop.Id +
                        '" data-target="#modalExcluir" style="margin-left:1em; color:white;"' +
                        ' class="btn btn-danger btn-default" style="color: white">' +
                        '<i class="fa fa-trash-o" aria-hidden="true"></i> Excluir</a>';

                    link.innerHTML += ' <i class="fa fa-pencil" aria-hidden="true"></i>';
                }

                var details = listing.appendChild(document.createElement('div'));
                details.innerHTML = prop.Data;


                popup += '</div>';
                layer.bindPopup(popup);

                layer.on('click',
                    function(e) {
                        _private.setActive(listing);
                    });

                link.onclick = function(evt) {
                    _private.setActive(listing);
                    _private.markers.removeLayer(layer);
                    _private.mapa.addLayer(layer);
                    layer.openPopup();
                    return false;
                };

                _private.markers.addLayer(layer);
            });

            _private.mapa.addLayer(_private.markers);
        };

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
                tipo = "mapbox.streets";
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
            $public.GetGeoJson("/ocorrencia/coordenada/" + _private.BuscarIdOcorrencia(), function(data) {
                var json = data;
                var geoJson = L.geoJson(json);

                geoJson.eachLayer(function (layer) {
                    _private.mapa.addLayer(layer);

                    var prop = layer.feature.properties;

                    var popup = '<h3>' + prop.Nome + '</h3>';
                    popup += '<div>' + prop.Detalhes + '</div>';

                    if (prop.Data) {
                        // Cria 
                        popup += '<br /><small class="quiet" style="text-align:center"><i class="fa fa-calendar" aria-hidden="true"></i>&nbsp' + prop.Data + '</small>';
                    }

                    if (layer instanceof L.Marker) {

                        layer.setIcon(L.icon({
                            iconUrl: $public.Url() +
                                '/content/karellen/img/robbery.png', // load your own custom marker image here
                            iconSize: [32, 32],
                            iconAnchor: [28, 28],
                            popupAnchor: [0, -34]
                        }));
                    }

                    layer.bindPopup(popup);


                    layer.openPopup();

                });
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

        $public.Index = function() {
            $public.IniciarMapa("mapa", [-15.65511, -47.79214], 14);

            $public.GetGeoJson("/ocorrencia/coordenadas", _private.index);
        };

        $public.IniciarGrafico = function() {
            $(function() {

                Array.prototype.max = function() {
                    return Math.max.apply(null, this);
                };


                var info = JSON.parse($("#grafico").val());
                var valores = new Array();

                for (var key in info) {
                    valores.push(info[key]);
                };

                var topo = (valores.max()) * 1.5;
                var options = {
                    scales: {
                        xAxes: [
                            {
                                stacked: true
                            }
                        ],
                        yAxes: [
                            {
                                stacked: true,
                                ticks: {
                                    beginAtZero: true,
                                    max: topo
                                }
                            }
                        ]
                    }
                }

                var data = {
                    labels: Object.keys(info),
                    datasets: [
                        {
                            label: "Quantidade de ocorrências nos ultimos 6 meses",
                            backgroundColor: "rgba(212, 247, 199, 1)",
                            borderColor: "rgba(81, 132, 62, 1)",
                            borderWidth: 1,
                            hoverBackgroundColor: "rgba(134, 158, 126, 1)",
                            hoverBorderColor: "rgba(3, 42, 81, 1)",
                            data: valores,
                        }
                    ]
                };


                var ctx = $("#ctx");

                var myBarChart = new Chart(ctx,
                {
                    type: 'bar',
                    data: data,
                    options: options
                });
            });
        };

        return $public;

    })($);

    window.App = app;
})(jQuery);