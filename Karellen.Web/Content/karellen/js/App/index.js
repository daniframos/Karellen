$(function () {

    if (App.SuportaAjax()) {
        App.IniciarMapa("mapa", [-15.64511, -47.78214], 13);

        var locations = App.GetGeoJson("/ocorrencia/coordenadas");
        locations.on('ready', function () {

            // Para cada layer
            locations.eachLayer(function (locale) {

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
                debugger;
                listing.appendChild(document.createElement('h4'));
                var link = listing.childNodes[0].appendChild(document.createElement('a'));
                link.href = '#';
                link.className = 'title';

                // Se tiver a propriedade crossStreet 'rua' diferente de undefined
                link.innerHTML = prop.Nome;
                if (prop.crossStreet) {
                    // Cria 
                    link.innerHTML += '<br /><small class="quiet">' + prop.Nome + '</small>';
                    popup += '<br /><small class="quiet">' + prop.DataAcontecimento + '</small>';
                }

                var details = listing.appendChild(document.createElement('div'));
                details.innerHTML = prop.Data;
                if (prop.phone) {
                    details.innerHTML += ' &middot; ' + prop.phoneFormatted;
                }

                popup += '</div>';
                locale.bindPopup(popup);
            });
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