import { Component, OnInit } from '@angular/core';
import { MouseEvent } from '@agm/core';
import { delay } from 'q';
//import { pinService } from '../pinService/pin.component';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { ApiService } from '../apiService/api.component';


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
    pins: string;


    basePinsURL: string = 'https://localhost:44343'; // If I was completing this correctly I would abstract this out to a config file.

    constructor(private apiService: ApiService) { }


    ngOnInit() {
        this.addMarkersFromDB()
        this.setLocation()
        this.startGetSetLocationWorker()
    }

    addMarkersFromDB() {
        this.apiService.getPins().subscribe((res) => {
            this.apiService.getPins().subscribe((res) => {
                for (var v in res) {
                    console.log(res[v].latitudes)
                    console.log('adding pin: ' + res[v].latitudes + ' - ' + res[v].longitude);
                    this.markers.push({
                        lat: res[v].latitudes,
                        lng: res[v].longitude,
                        note: res[v].note,
                        draggable: false
                    });
                }
            });
        });
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

    clickedMarker(label: string, index: number) { // to avoid errors 
    }

    error(err) {
        console.warn(`ERROR(${err.code}): ${err.message}`);
    }

    savePinClicked() {
        this.setLocation()
        var note = prompt("Enter a short note to save at this location!", "e.g. Great views of the river...");
        if (note != null && note.trim() != "") {
            console.log("setting note: " + note)
            var pin = {
                "Userid": 1,
                "Longitude": 152.9806848,
                "Latitudes": -28.1581184,
                "Note": "noteteeteyy"
            }
            this.apiService.setPin(pin).subscribe((res) => {
                console.log("Created a pin");
            });
            this.addMarkersFromDB()
        }
    }

    markerDragEnd(m: marker, $event: MouseEvent) {
        console.log('dragEnd', m, $event);
    }

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
