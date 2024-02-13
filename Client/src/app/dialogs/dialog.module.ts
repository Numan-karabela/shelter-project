import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DeleteDialogComponent } from './delete-dialog/delete-dialog.component';
import { FileUploadDialogComponent } from './file-upload-dialog/file-upload-dialog.component';
import { MatDialogClose, MatDialogModule } from '@angular/material/dialog';
import { MatButton, MatButtonModule } from '@angular/material/button';
import { SelectAnimalImageDialogComponent } from './select-animal-image-dialog/select-animal-image-dialog.component';
import { FileUploatModule } from '../services/common/file-uploat/file-uploat.module';
import { MatCardModule } from '@angular/material/card';
import { FormsModule } from '@angular/forms'; 
import { AuthorizeMenuDialogComponen, authorizeMenuState } from './authorize-menu-dialog/authorize-menu-dialog.component';
import { AuthorizeMenuComponent } from '../admin/components/authorize-menu/authorize-menu.component';
import { MatBadgeModule} from '@angular/material/badge';



@NgModule({
  declarations: [
   DeleteDialogComponent, 
   AuthorizeMenuDialogComponen,
   SelectAnimalImageDialogComponent, 
   
  ],
  imports: [
    CommonModule,
    MatDialogModule,
    MatButtonModule,
    MatCardModule,
    FileUploatModule, 
    FormsModule,
    MatBadgeModule

    
  ]
})
export class DialogModule { }
