import { Component, OnInit } from '@angular/core';
import { MouseEvent } from '@agm/core';
import { delay } from 'q';

@Component({
    selector: 'agm',
    templateUrl: './agm.component.html',
    styleUrls: ['./agm.component.css']
})

export class agmComponent implements OnInit {
    // google maps zoom level
    zoom: number = 8;
    //lat: number = -33.868;
    //lng: number = 151.21;
    lat: any;
    lng: any;

    ngOnInit() {
        this.setLocation()        
        this.startGetSetLocationWorker() 
    }

    startGetSetLocationWorker() {
        if (typeof Worker !== 'undefined') {
            console.log('blaladdhhhhh');
            const worker = new Worker('../src/app/workers/app.worker', { type: 'module' });
            worker.onmessage = ({ data }) => {
                console.log(`page got message: ${data}`);
            };
            worker.postMessage('hello');
        } else {
            console.log('else');
            // Web workers are not supported in this environment.
            // You should add a fallback so that your program still executes correctly.
        }
        
    }
    
    setLocation() {
        if (navigator) {
            navigator.geolocation.getCurrentPosition(pos => {
                console.log('setting location');
                console.log(pos.coords.latitude);
                console.log(pos.coords.longitude);
                this.lng = +pos.coords.longitude;
                this.lat = +pos.coords.latitude;
            });
        } else {
            console.error(error);
            console.log('browser does not support geo-location');
            // #TODO stop location loop
        }
    }

  /*  setLocation() {
        navigator.geolocation.getCurrentPosition((position) => {
            console.log('setting location');
            console.log(position.coords.latitude);
            console.log(position.coords.longitude);
         
        });
    }; */ 

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
