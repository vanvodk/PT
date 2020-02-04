import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AppCountriesTableComponent } from './app-countries-table.component';

describe('AppCountriesTableComponent', () => {
  let component: AppCountriesTableComponent;
  let fixture: ComponentFixture<AppCountriesTableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AppCountriesTableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AppCountriesTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
