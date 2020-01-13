import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListCalendarComponent } from './list-calendar.component';

describe('ListCalendarComponent', () => {
  let component: ListCalendarComponent;
  let fixture: ComponentFixture<ListCalendarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListCalendarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListCalendarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
