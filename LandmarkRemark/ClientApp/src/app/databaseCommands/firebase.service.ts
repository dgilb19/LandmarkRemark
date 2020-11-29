import { Injectable, Component } from "@angular/core";
import { AngularFirestore } from '@angular/fire/firestore';
import { FormControl, FormGroup } from "@angular/forms";

@Component({
    selector: 'firebaseService',
    templateUrl: './firebase.service.html',
    styleUrls: ['./firebase.service.css']
})

@Injectable({
    providedIn: "root"
})
export class firebaseService {
    constructor(
      //  private firestore: AngularFirestore
    ) { }

    logUserIn() {
        // # TODO
        // Will not be handling security correctly as it is out of sco
    }

    getAllUsers() {
        //return this.firestore.collection("users").snapshotChanges();
    }

    getAllUserPins() {
        // # TODO
    }

    SavePin() {
        // # TODO
    }

}
