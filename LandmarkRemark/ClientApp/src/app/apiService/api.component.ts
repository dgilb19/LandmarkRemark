import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})
export class ApiService {

    basePinsURL: string = 'https://localhost:44343'; // If I was completing this correctly I would abstract this out to a config file.

    constructor(private httpClient: HttpClient) { }


    public getPins() {
        return this.httpClient.get(`${this.basePinsURL}/api/pins`);
    }

    public setPin(pin) {
        return this.httpClient.get(`${this.basePinsURL}/api/pins`, pin);
    }

    // #TODO
    /*
    Need to create delete, post, get{id}
    This did not occur as I ran out of time in my spike.
    */
}

