import { Component, OnInit } from '@angular/core';
import { MouseEvent } from '@agm/core';
import { delay } from 'q';
import { pinService } from '../pinService/pin.component';

@Component({
    selector: 'agm',
    templateUrl: './agm.component.html',
    styleUrls: ['./agm.component.css']
})

export class agmComponent implements OnInit {
    // google maps zoom level
    zoom: number = 8;
    lat: any;
    lng: any;

    ngOnInit() {
        this.setLocation()        
        this.startGetSetLocationWorker() 
    }

    // Worker not being reached, if worker could be reached it would return the location of the user every 10 seconds
    startGetSetLocationWorker() {
        if (typeof Worker !== 'undefined') {
            const worker = new Worker('.workers/app.worker', { type: 'module' });
            worker.onmessage = ({ data }) => {
                console.log(`page got message: ${data}`);
            };
            worker.postMessage('hello');
        } else {
            console.log('else');
            // Web workers are not supported in this environment.
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
            // #TODO stop location worker
        }
    }

    clickedMarker(label: string, index: number) {
    }

    error(err) {
        console.warn(`ERROR(${err.code}): ${err.message}`);
    }

    // obsolete function
/*    mapClicked($event: MouseEvent) {
        //pinService.getPinText();
        var note = prompt("Enter a short note to save at this location!", "e.g. Great views of the river...");
        if (note != null && note.trim() != "") {
            console.log("setting note: " + note)
            this.markers.push({
                lat: $event.coords.lat,
                lng: $event.coords.lng,
                note: note,
                draggable: false
            });
        }
    }
*/
    savePinClicked() {
        this.setLocation()
        var note = prompt("Enter a short note to save at this location!", "e.g. Great views of the river...");
        if (note != null && note.trim() != "") {
            console.log("setting note: " + note)
            this.markers.push({
                lat: this.lat,
                lng: this.lng,
                note: note,
                draggable: false
            });
        }
    }

    markerDragEnd(m: marker, $event: MouseEvent) {
        console.log('dragEnd', m, $event);
    }

    // #TODO make function to retieve current pins from Firebase
    markers: marker[] = []
}
 
// just an interface for type safety.
interface marker {
    lat: number;
    lng: number;
    label?: string;
    note: string;
    draggable: boolean;
}
