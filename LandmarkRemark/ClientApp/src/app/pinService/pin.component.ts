import { Component, EventEmitter } from '@angular/core';


@Component({
    selector: 'pinPromptService',
    templateUrl: `<h2>{{title}}</h2>
        < p > {{ message }}</p>
< mat - form - field class= "example-full-width" >
<input matInput placeholder = "Favorite food" #input >
</mat-form-field>
< button mat - button(click)="onOk.emit(input.value); dialog.close()" > OK </button>`
})

export class pinService {
    public title: string;
    public message: string;
    onOk = new EventEmitter();

    getPinText() {
    var note = prompt("Enter a short note to save at this location!", "e.g. Great views of the river...");
        if (note == null || note == "") { }
        else {
            return note
        }
    }
}
