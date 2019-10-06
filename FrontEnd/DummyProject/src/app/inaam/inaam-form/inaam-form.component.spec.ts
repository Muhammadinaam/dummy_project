import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InaamFormComponent } from './inaam-form.component';

describe('InaamFormComponent', () => {
  let component: InaamFormComponent;
  let fixture: ComponentFixture<InaamFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InaamFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InaamFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
