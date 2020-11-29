import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ServerModule } from '@angular/platform-server';
//import { FormsModule } from '@angular/forms';

// Components import 
import { AppComponent } from './app.component';
import { AgmCoreModule } from '@agm/core';
import { AppRoutingModule } from "./app-routing.module";
import { agmComponent } from './agmService/agm.component';
import { firebaseService } from './databaseCommands/firebase.service'

//environment import
import { environment } from './environment';



//angularfire imports
import { AngularFirestore } from '@angular/fire/firestore';
import { AngularFirestoreModule } from '@angular/fire/firestore';
import { AngularFireDatabaseModule } from '@angular/fire/database';
import { AngularFireModule } from '@angular/fire';



@NgModule({
    declarations: [
        AppComponent,
        agmComponent,
        firebaseService
    ],
    imports: [
        BrowserModule,
        AppRoutingModule,

        // # firestore unable to work, cause is injector error?

        //AngularFireModule.initializeApp(environment.firebase),
        //AngularFirestoreModule,
        AgmCoreModule.forRoot({ apiKey: 'AIzaSyCKZa0a39awk0XBLRMYts7aRmJM-COCozk' })
    ],
    providers: [firebaseService],
    bootstrap: [AppComponent]
})
export class AppModule { }
