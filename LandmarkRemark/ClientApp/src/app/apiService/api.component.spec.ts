import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MockComponent } from 'ng-mocks';
import { ApiService } from './api.component';

// Basic Spec tests
describe('Integration::AppComponent', () => {
    let component: ApiService;
    let fixture: ComponentFixture<ApiService>

    beforeEach(() => {
        fixture = TestBed.createComponent(ApiService);
        component = fixture.componentInstance;
        fixture.detectChanges();
    })

});
