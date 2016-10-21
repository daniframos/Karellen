$(function () {

    if (App.SuportaAjax()) {
        App.IniciarMapa("mapa", [40.7224 , -73.9933], 14);

        App.GetGeoJson("/ocorrencia/coordenadas", function (data) {

              var json = data;
              var geoJson = L.geoJson(json);
              markers = new L.MarkerClusterGroup();

            geoJson.eachLayer(function(layer) {
                debugger;
                var prop = layer.feature.properties;

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
                        iconUrl: App
                            .Url() +
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
                        App.Url() +
                        "/ocorrencia/detalhes/" +
                        prop.Id +
                        '" type="button" data-title="Detalhes" data-pjax data-callback="Detalhes"' +
                        ' class="btn btn-primary btn-default btnsaibamais" style="color: white">Saiba mais</a>';
                }

                if (prop.UsuarioId !== null) {
                    popup += '<a href="' +
                        App.Url() +
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

                layer.on('click', function(e) {
                        setActive(listing);
                    });

                link.onclick = function(evt) {
                    debugger;
                    
                    setActive(listing);

                    App.AddLayer(layer);
                    markers.removeLayer(layer);
                    layer.openPopup();
                    return false;
                };

                markers.addLayer(layer);
            });

            App.AddLayer(markers);
        });
    }
});

function setActive(el) {
    var siblings = listings.getElementsByTagName('div');
    for (var i = 0; i < siblings.length; i++) {
        siblings[i].className = siblings[i].className
          .replace(/active/, '').replace(/\s\s*$/, '');
    }

    el.className += ' active';
}