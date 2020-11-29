import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MockComponent } from 'ng-mocks';
import { agmComponent } from './agm.component';

// Basic Spec tests
describe('Integration::AppComponent', () => {
    let component: agmComponent;
    let fixture: ComponentFixture<agmComponent>

    beforeEach(() => {
        fixture = TestBed.createComponent(agmComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    })

    it('map should be callable', () => {
        // TODO 
    });

    it('test startGetSetLocationWorker function', () => {
        // TODO 
    });

    it('test setLocation function', () => {
        // TODO 
    });

    it('test clickedMarker function', () => {
        // TODO 
    });

    /* void
    it('test mapClicked function', () => {
        // TODO 
    });*/

    it('test savePinClicked function', () => {
        // TODO 
    });

    it('test markerDragEnd function', () => {
        // TODO 
    });
  
});
