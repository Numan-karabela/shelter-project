import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SelectAnimalImageDialogComponent } from './select-animal-image-dialog.component';

describe('SelectAnimalImageDialogComponent', () => {
  let component: SelectAnimalImageDialogComponent;
  let fixture: ComponentFixture<SelectAnimalImageDialogComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SelectAnimalImageDialogComponent]
    });
    fixture = TestBed.createComponent(SelectAnimalImageDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
