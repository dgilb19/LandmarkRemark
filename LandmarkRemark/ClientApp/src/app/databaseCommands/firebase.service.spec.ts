import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MockComponent } from 'ng-mocks';
import { firebaseService } from './firebase.service';

// Basic Spec tests
describe('Integration::AppComponent', () => {
    let component: firebaseService;
    let fixture: ComponentFixture<firebaseService>

    beforeEach(() => {
        fixture = TestBed.createComponent(firebaseService);
        component = fixture.componentInstance;
        fixture.detectChanges();
    })

    it('should have button', () => {
        // TODO 
    });

    it('should should be clickable', () => {
        // TODO 
    });
});

