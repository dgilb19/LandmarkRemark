import { Component, OnInit } from '@angular/core';
import { MouseEvent } from '@agm/core';


@Component({
    selector: 'my-app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})

export class AppComponent {
}

interface marker {
    lat: number;
    lng: number;
    label?: string;
    draggable: boolean;
}
