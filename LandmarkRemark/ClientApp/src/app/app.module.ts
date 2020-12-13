import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ServerModule } from '@angular/platform-server';
//import { FormsModule } from '@angular/forms';

// Components import 
import { AppComponent } from './app.component';
import { AgmCoreModule } from '@agm/core';
import { agmComponent } from './agmService/agm.component';
import { HttpModule } from '@angular/http';

//environment import
import { environment } from './environment';

import { HttpClientModule } from '@angular/common/http';



@NgModule({
    declarations: [
        AppComponent,
        agmComponent
    ],
    imports: [
        BrowserModule,
        HttpClientModule,
        HttpModule,
       
        // # out of scope to handle security correctly
        AgmCoreModule.forRoot({ apiKey: 'AIzaSyCKZa0a39awk0XBLRMYts7aRmJM-COCozk' })
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule { }
