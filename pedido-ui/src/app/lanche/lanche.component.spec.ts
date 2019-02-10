import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LancheComponent } from './lanche.component';

describe('LancheComponent', () => {
  let component: LancheComponent;
  let fixture: ComponentFixture<LancheComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LancheComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LancheComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
