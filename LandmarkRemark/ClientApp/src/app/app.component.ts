import { Component, OnInit } from '@angular/core';
import { MouseEvent } from '@agm/core';


@Component({
    selector: 'my-app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})

export class AppComponent {
  /*  constructor() {
        let btn = document.getElementById("coolbutton");
        btn.addEventListener("click", (e: Event) => this.getTrainingName(4));
    }*/
    getTrainingName() {
        console.log("Bananananananna") 
    }
}

interface marker {
    lat: number;
    lng: number;
    label?: string;
    draggable: boolean;
}
