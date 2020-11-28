var options = {
    enableHighAccuracy: true,
    timeout: 5000,
    maximumAge: 0
};

function success(pos) {
    var crd = pos.coords;

    console.log('Your current position is:');
    console.log(`Latitude : ${crd.latitude}`);
    console.log(`Longitude: ${crd.longitude}`);
    console.log(`More or less ${crd.accuracy} meters.`);
   // return (crd.latitud, crd.longitude);
}

function foundLocation(position) {
    var lat = position.coords.latitude;
    var lon = position.coords.longitude;
    var userLocation = lat + ', ' + lon;
}


function error(err) {
    console.warn(`ERROR(${err.code}): ${err.message}`);
}

navigator.geolocation.getCurrentPosition(success, error, options);



navigator.geolocation.getCurrentPosition(foundLocation, error);

