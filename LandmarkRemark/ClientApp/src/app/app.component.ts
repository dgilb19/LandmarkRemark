import { Component } from '@angular/core';
import { MouseEvent } from '@agm/core';

@Component({
    selector: 'my-app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {
    // google maps zoom level
    zoom: number = 8;
    //lat: number = -33.868;
    //lng: number = 151.21;
    lat: any;
    lng: any;
    constructor() {
        console.log(navigator);
        if (navigator) {
            navigator.geolocation.getCurrentPosition(pos => {
                this.lng = +pos.coords.longitude;
                this.lat = +pos.coords.latitude;
                console.log('setting inital location');
            });
        }
    }

    setLocation() {
        navigator.geolocation.getCurrentPosition((position) => {
            console.log('position');
            this.lat = -33.868;
            this.lng = 151.21;
            console.log(position.coords.latitude);
            console.log(position.coords.longitude);
         
        });
    };
  

    clickedMarker(label: string, index: number) {
    //    navigator.geolocation.getCurrentPosition(this.foundLocation, this.error);
        this.setLocation();
        console.log(`clicked the marker: ${label || index}`)

       

        //console.log(navigator.geolocation.getCurrentPosition(success, error, options));
    }
    foundLocation(position) {
        var lat = position.coords.latitude;
        var lon = position.coords.longitude;
        var userLocation = lat + ', ' + lon;
        return userLocation
       
    }

    error(err) {
        console.warn(`ERROR(${err.code}): ${err.message}`);
    }

    mapClicked($event: MouseEvent) {
        this.markers.push({
            lat: $event.coords.lat,
            lng: $event.coords.lng,
            draggable: true
        });
    }

    markerDragEnd(m: marker, $event: MouseEvent) {
        console.log('dragEnd', m, $event);
    }

    markers: marker[] = [
        {
            lat: 51.673858,
            lng: 7.815982,
            label: 'A',
            draggable: true
        },
        {
            lat: 51.373858,
            lng: 7.215982,
            label: 'B',
            draggable: false
        },
        {
            lat: 51.723858,
            lng: 7.895982,
            label: 'C',
            draggable: true
        }
    ]
}

// just an interface for type safety.
interface marker {
    lat: number;
    lng: number;
    label?: string;
    draggable: boolean;
}
