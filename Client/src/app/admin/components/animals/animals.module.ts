import {NgModule} from '@angular/core';
import {CommonModule } from '@angular/common';
import {AnimalsComponent } from './animals.component';
import {RouterModule } from '@angular/router';
import {MatSidenavModule} from '@angular/material/sidenav';
import {CreateComponent } from './create/create.component';
import {ListComponent } from './list/list.component';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input'; 
import {MatButtonModule} from '@angular/material/button';
import {MatTableModule} from '@angular/material/table';  
import {MatPaginatorModule} from '@angular/material/paginator';  
import {MatSelectModule} from '@angular/material/select'; 
import { DeleteDirective } from 'src/app/directives/admin/delete.directive';
import {MatDialogModule} from '@angular/material/dialog'; 
import { FileUploatModule } from 'src/app/services/common/file-uploat/file-uploat.module';
import { DialogModule } from '@angular/cdk/dialog';


  @NgModule({
  declarations: [
    AnimalsComponent,
    CreateComponent,
    ListComponent,
    DeleteDirective,  
    
    
  ],
  imports: [
    CommonModule,
    MatSidenavModule,
    RouterModule.forChild([
      {path:"",component:AnimalsComponent} 
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
export class AnimalsModule { }
