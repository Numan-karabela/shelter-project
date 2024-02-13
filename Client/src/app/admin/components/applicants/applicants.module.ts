import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ApplicantsComponent } from '../applicants/applicants.component';
import { RouterModule } from '@angular/router';
import { ListComponent } from './list/list.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatDialogModule } from '@angular/material/dialog';
import { DialogModule } from 'src/app/dialogs/dialog.module';
import { FileUploatModule } from 'src/app/services/common/file-uploat/file-uploat.module';



@NgModule({
  declarations: [
    ApplicantsComponent,
    ListComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      {path:"",component:ApplicantsComponent}
    ]),
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatButtonModule,
    MatTableModule, 
    MatPaginatorModule, 
    MatDialogModule,
    DialogModule,
    FileUploatModule
  ]
})
export class ApplicantsModule { }
