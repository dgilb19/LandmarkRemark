import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MockComponent } from 'ng-mocks';
import { AppComponent } from './app.component';

// Basic Spec tests
describe('Integration::AppComponent', () => {
    let component: AppComponent;
    let fixture: ComponentFixture<AppComponent>

    beforeEach(() => {
        fixture = TestBed.createComponent(AppComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();

    })

    fit('should have header', () => {
        //spyOn(component)
        const header = fixture.nativeElement.querySelector('h1')
        expect(header.value).toBe('Landmark Remark!')
    });

    it('should import Maps', () => {
      // TODO test map import 
    });
});

