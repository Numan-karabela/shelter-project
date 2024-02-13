import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RoleComponent } from './role.component';
import { RouterModule } from '@angular/router';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatDialogModule } from '@angular/material/dialog';
import { ListComponent} from './list/list.component';
import { CreateComponent } from './create/create.component'; 
import { DialogModule } from '@angular/cdk/dialog';
import { FileUploatModule } from 'src/app/services/common/file-uploat/file-uploat.module';
import { MatSidenavModule } from '@angular/material/sidenav'; 


@NgModule({
  declarations: [

    RoleComponent,
    ListComponent,
    CreateComponent
  ],
  imports: [
    CommonModule, 
     MatFormFieldModule,
    MatInputModule,
    MatSidenavModule,
    MatSelectModule,
    MatButtonModule,
    MatTableModule, 
    DialogModule,
    FileUploatModule,
    MatPaginatorModule, 
    MatDialogModule,
    RouterModule.forChild([
      {path:"",component:RoleComponent}
    ])
  ]
})
export class RoleModule { }
