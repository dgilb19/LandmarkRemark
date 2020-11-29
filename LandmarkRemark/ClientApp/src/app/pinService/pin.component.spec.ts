import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MockComponent } from 'ng-mocks';
import { pinService } from './pin.component';

//
// NOT IMPLEMETED 
//


// Basic Spec tests
describe('Integration::AppComponent', () => {
    let component: pinService;
    let fixture: ComponentFixture<pinService>

    beforeEach(() => {
        fixture = TestBed.createComponent(pinService);
        component = fixture.componentInstance;
        fixture.detectChanges();
    })

    //
/*    it('should have button', () => {
        // TODO 
    });*/

});

