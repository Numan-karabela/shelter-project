import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FileUploatComponent } from './file-uploat.component';
import { NgxFileDropModule } from 'ngx-file-drop';
import { DialogModule } from '../../../dialogs/dialog.module';
import { FileUploadDialogComponent } from 'src/app/dialogs/file-upload-dialog/file-upload-dialog.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
  


@NgModule({
  declarations: [
FileUploatComponent,
FileUploadDialogComponent
  ],
  imports: [
    CommonModule,
    NgxFileDropModule,
    MatDialogModule,
    MatButtonModule

  ],
  exports:[ 
    FileUploatComponent 
  ]
})
export class FileUploatModule { }
