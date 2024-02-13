import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FileUploatComponent } from './file-uploat.component';

describe('FileUploatComponent', () => {
  let component: FileUploatComponent;
  let fixture: ComponentFixture<FileUploatComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [FileUploatComponent]
    });
    fixture = TestBed.createComponent(FileUploatComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
