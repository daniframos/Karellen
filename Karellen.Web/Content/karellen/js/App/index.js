$(function () {

    if (App.SuportaAjax()) {
        App.IniciarMapa("mapa", [-15.64511, -47.78214], 14);

        var locations = App.GetGeoJson("/ocorrencia/coordenadas");
        locations.on('ready', function () {

            var cluster = new L.MarkerClusterGroup({
                maxClusterRadius:140
            });

            // Para cada layer
            locations.eachLayer(function (locale) {
                cluster.addLayer(locale);
                debugger;
                // Shorten locale.feature.properties to just `prop` so we're not
                // writing this long form over and over again.

                // Pega as propriedades
                var prop = locale.feature.properties;

                // Cria o header do popup
                // Each marker on the map.
                var popup = '<h3>' + prop.Nome + '</h3>';
                popup += '<div>' + prop.Detalhes + '</div>';

                // Cria a div em si que irá encapsular o corpo e o header
                var listing = listings.appendChild(document.createElement('div'));
                listing.className = 'item';

                // Cria a ancora
                listing.appendChild(document.createElement('h4'));
                var link = listing.childNodes[0].appendChild(document.createElement('a'));
                link.href = '#';
                link.className = 'title';

                // Se tiver a propriedade crossStreet 'rua' diferente de undefined
                link.innerHTML = prop.Nome;
                if (prop.Data) {
                    // Cria 
                    popup += '<br /><small class="quiet" style="text-align:center"><i class="fa fa-calendar" aria-hidden="true"></i>&nbsp' + prop.Data + '</small>';
                    popup += '<br /><button type="button" class="btn btn-primary btn-default btnsaibamais">Saiba mais</button>'
                }

                var details = listing.appendChild(document.createElement('div'));
                details.innerHTML = prop.Data;
                

                popup += '</div>';
                locale.bindPopup(popup);
            });

            App.AddLayer(cluster);
        });

        locations.on('layeradd', function (e) {

            var marker = e.layer;
            marker.setIcon(L.icon({
                iconUrl: App.Url() + '/content/karellen/img/robbery.png', // load your own custom marker image here
                iconSize: [32, 32],
                iconAnchor: [28, 28],
                popupAnchor: [0, -34]
            }));
            
        });
    }
});